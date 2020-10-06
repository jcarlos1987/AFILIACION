using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Net;
using ClosedXML.Excel;

public partial class Casuistica_Compara : System.Web.UI.Page
{
    String strConnString = ConfigurationManager.ConnectionStrings["AfiliacionConnectionString"].ConnectionString;
    string type;
    string ciclo; 
    DateTime fecha;
    DateTime fechaC;
    int reg;
    protected void Page_Load(object sender, EventArgs e)
    {
        Origen();
        Copia();
    }

    public void Origen()
    {
        SqlConnection conn = new SqlConnection(strConnString);
        try
        {
            conn.Open();
            SqlDataReader myReader = null;
            SqlCommand Comando = new SqlCommand("SELECT [id],[tipo],[fecha],[Ciclo],[Fecha_Carga],[Envio_Cl],[Envio_ST],[Envio_P],[No_Regis] FROM [Afiliacion].[dbo].[Crtl_SCAC] WHERE [id]=" + Request.QueryString["id"] + "", conn);
            myReader = Comando.ExecuteReader();
            while (myReader.Read())
            {
                type = myReader.GetString(1);
                fecha = myReader.GetDateTime(2);
                ciclo = myReader.GetString(3);
                fechaC = myReader.GetDateTime(4);
                reg = myReader.GetInt32(8);
            }
        }
        catch (Exception d)
        {
            Label2.Text = d.Message;
        }
        conn.Close();

        SqlConnection conn1 = new SqlConnection(strConnString);
        string query = "";
        Label2.Text = type + " del Ciclo " + ciclo;
        if (type.Trim() == "SCAC-10")
        {
            query = "SELECT [id],[Fecha_Carga],[Folio_Error],[Cve_Docto],[NSS],[Registro_Pat],[Fecha_Inicio],[TR],CONVERT(FLOAT,[CS])[CS],[Dias_Sub],[Folio_Docto],[Porc_Inc],[Fecha_Termino],[Deleg_Orgn],[UMF],[Codigo_Error],[Codigo_Error2]" +
                    ",[Codigo_Error3],[Codigo_Error4],[Codigo_Error5],[Nombre_Asegurado],[CURP],[Cto_Pag],[Tipo_Mto_Aju],[Fecha_Extrac],[Tipo],[Ciclo],[status] FROM [Afiliacion].[dbo].[SCAC-10] WHERE [Tipo]='" + type + "' AND [Ciclo]='" + ciclo + "'";
        }
        else if (type.Trim() == "SCAC-09")
        {
            query = "SELECT [id],[Fecha_Carga],[Folio_Error],[Cve_Docto],[NSS],[Registro_Pat],[Fecha_Inicio],[TR],CONVERT(FLOAT,[CS])[CS],[Dias_Sub],[Porc_Inc],[Fecha_Termino],[Deleg_Orgn],[UMF],[Codigo_Error]," +
                    "[Codigo_Error2],[Codigo_Error3],[Codigo_Error4],[Codigo_Error5],[Nombre_Asegurado],[CURP],[Folio_Docto],[Cto_Pag],[Tipo_Mto_Aju],[Fec_Extraccion],[Tipo_SCAC],[Ciclo],[status] FROM [Afiliacion].[dbo].[SCAC-09] WHERE [Tipo_SCAC]='" + type + "' AND [Ciclo]='" + ciclo + "'";
        }
        SqlCommand cmd = new SqlCommand(query, conn1);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        if (type.Trim() == "SCAC-10")
        {
            GridView1.Visible = true;
            GridView2.Visible = false;
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        else if (type.Trim() == "SCAC-09")
        {
            GridView2.Visible = true;
            GridView1.Visible = false;
            GridView2.DataSource = dt;
            GridView2.DataBind();
        }
        conn1.Close();
    }


    public void Copia()
    {
        SqlConnection conn = new SqlConnection(strConnString);
        try
        {
            conn.Open();
            SqlDataReader myReader = null;
            SqlCommand Comando = new SqlCommand("SELECT [id],[tipo],[fecha],[Ciclo],[Fecha_Carga],[Envio_Cl],[Envio_ST],[Envio_P],[No_Regis] FROM [Afiliacion].[dbo].[Crtl_SCAC] WHERE [id]=" + Request.QueryString["id"] + "", conn);
            myReader = Comando.ExecuteReader();
            while (myReader.Read())
            {
                type = myReader.GetString(1);
                fecha = myReader.GetDateTime(2);
                ciclo = myReader.GetString(3);
                fechaC = myReader.GetDateTime(4);
                reg = myReader.GetInt32(8);
            }
        }
        catch (Exception d)
        {
            Label2.Text = d.Message;
        }
        conn.Close();

        SqlConnection conn1 = new SqlConnection(strConnString);
        string query = "";
        Label2.Text = type + " del Ciclo " + ciclo;
        if (type.Trim() == "SCAC-10")
        {
            query = "SELECT [id],[Fecha_Carga],[Folio_Error],[Cve_Docto],[NSS],[Registro_Pat],[Fecha_Inicio],[TR],CONVERT(FLOAT,[CS])[CS],[Dias_Sub],[Folio_Docto],[Porc_Inc],[Fecha_Termino],[Deleg_Orgn],[UMF],[Codigo_Error],[Codigo_Error2]" +
                    ",[Codigo_Error3],[Codigo_Error4],[Codigo_Error5],[Nombre_Asegurado],[CURP],[Cto_Pag],[Tipo_Mto_Aju],[Fecha_Extrac],[Tipo],[Ciclo],[status] FROM [Afiliacion].[dbo].[UPD_SCAC-10] WHERE [Tipo]='" + type + "' AND [Ciclo]='" + ciclo + "'";
        }
        else if (type.Trim() == "SCAC-09")
        {
            query = "SELECT [id],[Fecha_Carga],[Folio_Error],[Cve_Docto],[NSS],[Registro_Pat],[Fecha_Inicio],[TR],CONVERT(FLOAT,[CS])[CS],[Dias_Sub],[Porc_Inc],[Fecha_Termino],[Deleg_Orgn],[UMF],[Codigo_Error]," +
                    "[Codigo_Error2],[Codigo_Error3],[Codigo_Error4],[Codigo_Error5],[Nombre_Asegurado],[CURP],[Folio_Docto],[Cto_Pag],[Tipo_Mto_Aju],[Fec_Extraccion],[Tipo_SCAC],[Ciclo],[status] FROM [Afiliacion].[dbo].[UPD_SCAC-09] WHERE [Tipo_SCAC]='" + type + "' AND [Ciclo]='" + ciclo + "'";
        }
        SqlCommand cmd = new SqlCommand(query, conn1);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        if (type.Trim() == "SCAC-10")
        {
            GridView3.Visible = true;
            GridView4.Visible = false;
            GridView3.DataSource = dt;
            GridView3.DataBind();
        }
        else if (type.Trim() == "SCAC-09")
        {
            GridView4.Visible = true;
            GridView3.Visible = false;
            GridView4.DataSource = dt;
            GridView4.DataBind();
        }
        conn1.Close();
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        this.GridView1.DataBind();
    }

    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView2.PageIndex = e.NewPageIndex;
        this.GridView2.DataBind();
    }

    protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView3.PageIndex = e.NewPageIndex;
        this.GridView3.DataBind();
    }
    protected void GridView4_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView4.PageIndex = e.NewPageIndex;
        this.GridView4.DataBind();
    }
    protected void Cancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("EnviarClasEmp.aspx");
    }
    protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string Codigo1 = DataBinder.Eval(e.Row.DataItem, "Codigo_Error").ToString();
            string Codigo2 = DataBinder.Eval(e.Row.DataItem, "Codigo_Error2").ToString();
            string Codigo3 = DataBinder.Eval(e.Row.DataItem, "Codigo_Error3").ToString();
            string Codigo4 = DataBinder.Eval(e.Row.DataItem, "Codigo_Error4").ToString();
            string Codigo5 = DataBinder.Eval(e.Row.DataItem, "Codigo_Error5").ToString();

            if (Codigo1.Trim() == "4006" || Codigo2.Trim() == "4006" || Codigo3.Trim() == "4006" || Codigo4.Trim() == "4006" || Codigo5.Trim() == "4006")
            {
                e.Row.Cells[4].BackColor = Color.FromName("#ff6666");
            }
            if (Codigo1.Trim() == "4008" || Codigo2.Trim() == "4008" || Codigo3.Trim() == "4008" || Codigo4.Trim() == "4008" || Codigo5.Trim() == "4008")
            {
                e.Row.Cells[6].BackColor = Color.FromName("#ff6666");
            }
            if (Codigo1.Trim() == "4010" || Codigo2.Trim() == "4010" || Codigo3.Trim() == "4010" || Codigo4.Trim() == "4010" || Codigo5.Trim() == "4010")
            {
                e.Row.Cells[9].BackColor = Color.FromName("#ff6666");
            }
            if (Codigo1.Trim() == "4012" || Codigo2.Trim() == "4012" || Codigo3.Trim() == "4012" || Codigo4.Trim() == "4012" || Codigo5.Trim() == "4012")
            {
                e.Row.Cells[7].BackColor = Color.FromName("#ff6666");
            }
            if (Codigo1.Trim() == "4014" || Codigo2.Trim() == "4014" || Codigo3.Trim() == "4014" || Codigo4.Trim() == "4014" || Codigo5.Trim() == "4014")
            {
                e.Row.Cells[10].BackColor = Color.FromName("#ff6666");
            }
            if (Codigo1.Trim() == "4016" || Codigo2.Trim() == "4016" || Codigo3.Trim() == "4016" || Codigo4.Trim() == "4016" || Codigo5.Trim() == "4016")
            {
                e.Row.Cells[12].BackColor = Color.FromName("#ff6666");
            }
            if (Codigo1.Trim() == "4018" || Codigo2.Trim() == "4018" || Codigo3.Trim() == "4018" || Codigo4.Trim() == "4018" || Codigo5.Trim() == "4018")
            {
                e.Row.Cells[8].BackColor = Color.FromName("#ff6666");
            }
            if (Codigo1.Trim() == "4020" || Codigo2.Trim() == "4020" || Codigo3.Trim() == "4020" || Codigo4.Trim() == "4020" || Codigo5.Trim() == "4020")
            {
                e.Row.Cells[11].BackColor = Color.FromName("#ff6666");
            }
            if (Codigo1.Trim() == "4022" || Codigo2.Trim() == "4022" || Codigo3.Trim() == "4022" || Codigo4.Trim() == "4022" || Codigo5.Trim() == "4022")
            {
                e.Row.Cells[22].BackColor = Color.FromName("#ff6666");
            }
            if (Codigo1.Trim() == "4024" || Codigo2.Trim() == "4024" || Codigo3.Trim() == "4024" || Codigo4.Trim() == "4024" || Codigo5.Trim() == "4024")
            {
                e.Row.Cells[1].BackColor = Color.FromName("#ff6666");
            }
            if (Codigo1.Trim() == "4026" || Codigo2.Trim() == "4026" || Codigo3.Trim() == "4026" || Codigo4.Trim() == "4026" || Codigo5.Trim() == "4026")
            {
                e.Row.Cells[22].BackColor = Color.FromName("#ff6666");
            }
            if (Codigo1.Trim() == "4028" || Codigo2.Trim() == "4028" || Codigo3.Trim() == "4028" || Codigo4.Trim() == "4028" || Codigo5.Trim() == "4028")
            {
                e.Row.Cells[22].BackColor = Color.FromName("#ff6666");
            }
            if (Codigo1.Trim() == "4030" || Codigo2.Trim() == "4030" || Codigo3.Trim() == "4030" || Codigo4.Trim() == "4030" || Codigo5.Trim() == "4030")
            {
                e.Row.Cells[4].BackColor = Color.FromName("#ff6666");
            }
            if (Codigo1.Trim() == "4032" || Codigo2.Trim() == "4032" || Codigo3.Trim() == "4032" || Codigo4.Trim() == "4032" || Codigo5.Trim() == "4032")
            {
                e.Row.Cells[6].BackColor = Color.FromName("#ff6666");                
            }
            if (Codigo1.Trim() == "4034" || Codigo2.Trim() == "4034" || Codigo3.Trim() == "4034" || Codigo4.Trim() == "4034" || Codigo5.Trim() == "4034")
            {
                e.Row.Cells[4].BackColor = Color.FromName("#ff6666");
                e.Row.Cells[6].BackColor = Color.FromName("#ff6666");
            }
            if (Codigo1.Trim() == "4042" || Codigo2.Trim() == "4042" || Codigo3.Trim() == "4042" || Codigo4.Trim() == "4042" || Codigo5.Trim() == "4042")
            {
                e.Row.Cells[2].BackColor = Color.FromName("#ff6666");
            }
            if (Codigo1.Trim() == "4050" || Codigo2.Trim() == "4050" || Codigo3.Trim() == "4050" || Codigo4.Trim() == "4050" || Codigo5.Trim() == "4050")
            {
                e.Row.Cells[6].BackColor = Color.FromName("#ff6666");
            }
        }
    }
    protected void GridView4_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string Codigo1 = DataBinder.Eval(e.Row.DataItem, "Codigo_Error").ToString();
            string Codigo2 = DataBinder.Eval(e.Row.DataItem, "Codigo_Error2").ToString();
            string Codigo3 = DataBinder.Eval(e.Row.DataItem, "Codigo_Error3").ToString();
            string Codigo4 = DataBinder.Eval(e.Row.DataItem, "Codigo_Error4").ToString();
            string Codigo5 = DataBinder.Eval(e.Row.DataItem, "Codigo_Error5").ToString();

            if (Codigo1.Trim() == "4006" || Codigo2.Trim() == "4006" || Codigo3.Trim() == "4006" || Codigo4.Trim() == "4006" || Codigo5.Trim() == "4006")
            {
                e.Row.Cells[4].BackColor = Color.FromName("#ff6666");
            }
            if (Codigo1.Trim() == "4008" || Codigo2.Trim() == "4008" || Codigo3.Trim() == "4008" || Codigo4.Trim() == "4008" || Codigo5.Trim() == "4008")
            {
                e.Row.Cells[6].BackColor = Color.FromName("#ff6666");
            }
            if (Codigo1.Trim() == "4010" || Codigo2.Trim() == "4010" || Codigo3.Trim() == "4010" || Codigo4.Trim() == "4010" || Codigo5.Trim() == "4010")
            {
                e.Row.Cells[9].BackColor = Color.FromName("#ff6666");
            }
            if (Codigo1.Trim() == "4012" || Codigo2.Trim() == "4012" || Codigo3.Trim() == "4012" || Codigo4.Trim() == "4012" || Codigo5.Trim() == "4012")
            {
                e.Row.Cells[7].BackColor = Color.FromName("#ff6666");
            }
            if (Codigo1.Trim() == "4014" || Codigo2.Trim() == "4014" || Codigo3.Trim() == "4014" || Codigo4.Trim() == "4014" || Codigo5.Trim() == "4014")
            {
                e.Row.Cells[10].BackColor = Color.FromName("#ff6666");
            }
            if (Codigo1.Trim() == "4016" || Codigo2.Trim() == "4016" || Codigo3.Trim() == "4016" || Codigo4.Trim() == "4016" || Codigo5.Trim() == "4016")
            {
                e.Row.Cells[12].BackColor = Color.FromName("#ff6666");
            }
            if (Codigo1.Trim() == "4018" || Codigo2.Trim() == "4018" || Codigo3.Trim() == "4018" || Codigo4.Trim() == "4018" || Codigo5.Trim() == "4018")
            {
                e.Row.Cells[8].BackColor = Color.FromName("#ff6666");
            }
            if (Codigo1.Trim() == "4020" || Codigo2.Trim() == "4020" || Codigo3.Trim() == "4020" || Codigo4.Trim() == "4020" || Codigo5.Trim() == "4020")
            {
                e.Row.Cells[11].BackColor = Color.FromName("#ff6666");
            }
            if (Codigo1.Trim() == "4022" || Codigo2.Trim() == "4022" || Codigo3.Trim() == "4022" || Codigo4.Trim() == "4022" || Codigo5.Trim() == "4022")
            {
                e.Row.Cells[22].BackColor = Color.FromName("#ff6666");
            }
            if (Codigo1.Trim() == "4024" || Codigo2.Trim() == "4024" || Codigo3.Trim() == "4024" || Codigo4.Trim() == "4024" || Codigo5.Trim() == "4024")
            {
                e.Row.Cells[1].BackColor = Color.FromName("#ff6666");
            }
            if (Codigo1.Trim() == "4026" || Codigo2.Trim() == "4026" || Codigo3.Trim() == "4026" || Codigo4.Trim() == "4026" || Codigo5.Trim() == "4026")
            {
                e.Row.Cells[22].BackColor = Color.FromName("#ff6666");
            }
            if (Codigo1.Trim() == "4028" || Codigo2.Trim() == "4028" || Codigo3.Trim() == "4028" || Codigo4.Trim() == "4028" || Codigo5.Trim() == "4028")
            {
                e.Row.Cells[22].BackColor = Color.FromName("#ff6666");
            }
            if (Codigo1.Trim() == "4030" || Codigo2.Trim() == "4030" || Codigo3.Trim() == "4030" || Codigo4.Trim() == "4030" || Codigo5.Trim() == "4030")
            {
                e.Row.Cells[4].BackColor = Color.FromName("#ff6666");
            }
            if (Codigo1.Trim() == "4032" || Codigo2.Trim() == "4032" || Codigo3.Trim() == "4032" || Codigo4.Trim() == "4032" || Codigo5.Trim() == "4032")
            {
                e.Row.Cells[6].BackColor = Color.FromName("#ff6666");
            }
            if (Codigo1.Trim() == "4034" || Codigo2.Trim() == "4034" || Codigo3.Trim() == "4034" || Codigo4.Trim() == "4034" || Codigo5.Trim() == "4034")
            {
                e.Row.Cells[4].BackColor = Color.FromName("#ff6666");
                e.Row.Cells[6].BackColor = Color.FromName("#ff6666");
            }
            if (Codigo1.Trim() == "4042" || Codigo2.Trim() == "4042" || Codigo3.Trim() == "4042" || Codigo4.Trim() == "4042" || Codigo5.Trim() == "4042")
            {
                e.Row.Cells[2].BackColor = Color.FromName("#ff6666");
            }
            if (Codigo1.Trim() == "4050" || Codigo2.Trim() == "4050" || Codigo3.Trim() == "4050" || Codigo4.Trim() == "4050" || Codigo5.Trim() == "4050")
            {
                e.Row.Cells[6].BackColor = Color.FromName("#ff6666");
            }
        }
    }
    protected void LinkButtonOriginal_Click(object sender, EventArgs e)
    {
        using (SqlConnection con = new SqlConnection(strConnString))
        {
            con.Open();
            // Create the sample database
            SqlCommand cmd = new SqlCommand("DESCARGAR", con);

            cmd.Parameters.Add("@CICLO", SqlDbType.NVarChar, 10);
            cmd.Parameters["@CICLO"].Value = ciclo.Trim();

            cmd.Parameters.Add("@TIPO", SqlDbType.NVarChar, 10);
            cmd.Parameters["@TIPO"].Value = type.Trim();

            cmd.Parameters.Add("@ORIGEN", SqlDbType.Int);
            cmd.Parameters["@ORIGEN"].Value = 1;

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            using (SqlDataAdapter sda = new SqlDataAdapter())
            {
                cmd.Connection = con;
                sda.SelectCommand = cmd;
                cmd.CommandTimeout = 3600;
                using (DataTable dt = new DataTable())
                {
                    sda.Fill(dt);
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        wb.Worksheets.Add(dt, "Registros");
                        Response.Clear();
                        Response.Buffer = true;
                        Response.Charset = "";
                        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                        Response.AddHeader("content-disposition", "attachment;filename=" + type.Trim() + "-" + ciclo.Trim() + ".xlsx");
                        using (MemoryStream MyMemoryStream = new MemoryStream())
                        {
                            wb.SaveAs(MyMemoryStream);
                            MyMemoryStream.WriteTo(Response.OutputStream);
                            Response.Flush();
                            Response.End();
                        }
                    }
                }
            }
        }
    }

    protected void LinkButtonCopia_Click(object sender, EventArgs e)
    {
        using (SqlConnection con = new SqlConnection(strConnString))
        {
            con.Open();
            // Create the sample database
            SqlCommand cmd = new SqlCommand("DESCARGAR", con);

            cmd.Parameters.Add("@CICLO", SqlDbType.NVarChar, 10);
            cmd.Parameters["@CICLO"].Value = ciclo.Trim();

            cmd.Parameters.Add("@TIPO", SqlDbType.NVarChar, 10);
            cmd.Parameters["@TIPO"].Value = type.Trim();

            cmd.Parameters.Add("@ORIGEN", SqlDbType.Int);
            cmd.Parameters["@ORIGEN"].Value = 0;

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            using (SqlDataAdapter sda = new SqlDataAdapter())
            {
                cmd.Connection = con;
                sda.SelectCommand = cmd;
                cmd.CommandTimeout = 3600;
                using (DataTable dt = new DataTable())
                {
                    sda.Fill(dt);
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        wb.Worksheets.Add(dt, "Registros");

                        Response.Clear();
                        Response.Buffer = true;
                        Response.Charset = "";
                        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                        Response.AddHeader("content-disposition", "attachment;filename=" + type.Trim() + "-" + ciclo.Trim() + ".xlsx");
                        using (MemoryStream MyMemoryStream = new MemoryStream())
                        {
                            wb.SaveAs(MyMemoryStream);
                            MyMemoryStream.WriteTo(Response.OutputStream);
                            Response.Flush();
                            Response.End();
                        }
                    }
                }
            }
        }
    }
}