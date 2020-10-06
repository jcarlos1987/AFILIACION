using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Web;
using System.Net;

public partial class Casuistica_rtp : System.Web.UI.Page
{
    String strConnString = ConfigurationManager.ConnectionStrings["AfiliacionConnectionString"].ConnectionString;
    ReportDocument crystalReport = new ReportDocument();
    protected void Page_Load(object sender, EventArgs e)
    {
        using (SqlConnection scSqlConnection = new SqlConnection(strConnString))
        {
            SqlCommand cmd = new SqlCommand("RTP", scSqlConnection);

            cmd.Parameters.Add("@TIPO", SqlDbType.NVarChar, 10);
            cmd.Parameters["@TIPO"].Value = Session["tipoSCAC"];

            cmd.Parameters.Add("@CICLO1", SqlDbType.NVarChar, 8);
            cmd.Parameters["@CICLO1"].Value = Session["ciclo1"];

            cmd.Parameters.Add("@CICLO2", SqlDbType.NVarChar, 8);
            cmd.Parameters["@CICLO2"].Value = Session["ciclo2"];

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 3600;

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable datatable = new DataTable();
            da.Fill(datatable);

            CrystalDecisions.Shared.ParameterDiscreteValue delegacion = new ParameterDiscreteValue();
            delegacion.Value = Session["titulo"].ToString();
            CrystalDecisions.Shared.ParameterDiscreteValue numero = new ParameterDiscreteValue();
            numero.Value = Session["Depto"].ToString();

            crystalReport.Load(Server.MapPath("~/Reportes/SCAC.rpt"));
            crystalReport.SetDataSource(datatable);            
            crystalReport.ParameterFields[0].CurrentValues.Add(delegacion);
            crystalReport.ParameterFields[1].CurrentValues.Add(numero);
            CrystalReportViewer1.ReportSource = crystalReport;
            crystalReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, Session["tipoSCAC"].ToString());
        }
    }
    protected void CrystalReportViewer1_Unload(object sender, EventArgs e)
    {
        crystalReport.Close();
        CrystalReportViewer1.Dispose();
        crystalReport.Dispose();
    }
}