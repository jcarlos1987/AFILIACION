using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ionic.Zip;
using System.Configuration;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using ClosedXML.Excel;

public partial class Info_DescargarAfil25 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LlenarDropList(1, "SELECT DISTINCT [anio] id, [anio] des FROM [Afil-25].[dbo].[RegistroAfil]");
        }
    }

    public void LlenarDropList(int id, string query)
    {
        if (id == 1)
        {
            anio.AppendDataBoundItems = true;
        }
        else if (id == 2)
        {
            ciclo.AppendDataBoundItems = true;
        }
        else if (id == 3)
        {
            guia.AppendDataBoundItems = true;
        }
        SqlConnection con = new SqlConnection(Conexion.constringAfil25);
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = query;
        cmd.Connection = con;
        try
        {
            con.Open();
            if (id == 1)
            {
                anio.DataSource = cmd.ExecuteReader();
                anio.DataTextField = "des";
                anio.DataValueField = "id";
                anio.DataBind();
            }
            else if (id == 2)
            {
                ciclo.ClearSelection();
                ciclo.DataSource = cmd.ExecuteReader();
                ciclo.DataTextField = "des";
                ciclo.DataValueField = "id";
                ciclo.DataBind();
            }
            else if (id == 3)
            {
                guia.DataSource = cmd.ExecuteReader();
                guia.DataTextField = "des";
                guia.DataValueField = "id";
                guia.DataBind();
            }    
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }

    protected void anio_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (anio.SelectedValue != "")
        {
            LabelMensaje.Visible = false;
            ciclo.Attributes.Remove("disabled");
            ciclo.Items.Clear();
            ciclo.Items.Add(new ListItem("-- Selecciona un Ciclo --", ""));
            LlenarDropList(2, "SELECT [ciclo] AS id,RIGHT('000' + Ltrim(Rtrim([ciclo])),3) AS des  FROM [Afil-25].[dbo].[RegistroAfil] WHERE [anio]=" + anio.SelectedValue + " GROUP BY [ciclo] ORDER BY [ciclo] DESC");
        }
    }

    protected void ciclo_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ciclo.SelectedValue != "")
        {
            LabelMensaje.Visible = false;
            ciclo.Attributes.Remove("disabled");
            guia.Attributes.Remove("disabled");
            guia.Items.Clear();
            guia.Items.Add(new ListItem("-- Selecciona una guia --", ""));
            guia.Items.Add(new ListItem("-- Todas las guias --", "0"));
            LlenarDropList(3, "SELECT [guia] AS id,[guia] AS des  FROM [Afil-25].[dbo].[RegistroAfil] WHERE [anio]=" + anio.SelectedValue + " AND [ciclo]=" + ciclo.SelectedValue + " GROUP BY [guia] ");
        }
    }
    public void Excell(string consulta, string ciclo)
    {
        using (SqlConnection conn = new SqlConnection(Conexion.constringAfil25))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(consulta, conn);
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = conn;
                    sda.SelectCommand = cmd;
                    cmd.CommandTimeout = 3600;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        using (XLWorkbook wb = new XLWorkbook())
                        {
                            wb.Worksheets.Add(dt, ciclo);
                            Response.Clear();
                            Response.Buffer = true;
                            Response.Charset = "";
                            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                            Response.AddHeader("content-disposition", "attachment;filename = reporte.xlsx");
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
            conn.Close();
        }
        Response.Clear();
    }

    protected void aceptar_Click(object sender, EventArgs e)
    {
        if (anio.SelectedValue != "")
        {
            LabelMensaje.Visible = false;
            if (ciclo.SelectedValue != "")
            {
                LabelMensaje.Visible = false;
                if (guia.SelectedValue != "")
                {
                    LabelMensaje.Visible = false;
                    string tabla = "afil25_" + ciclo.SelectedValue.PadLeft(3, '0') + "_" + anio.SelectedValue;                    
                    Excell(query(guia.SelectedValue, tabla), ciclo.SelectedValue);
                }
                else
                {
                    ciclo.Attributes.Remove("disabled");
                    guia.Attributes.Remove("disabled");
                    LabelMensaje.Visible = true;
                    LabelMensaje.Text = @"<div class='alert alert-danger alert-dismissable'><button type='button' class='close' 
                                   data-dismiss='alert' aria-hidden='true'>×</button> Selecciona una guia por favor.</div>";
                }
            }
            else
            {
                guia.Attributes.Remove("disabled");
                ciclo.Attributes.Remove("disabled");
                LabelMensaje.Visible = true;
                LabelMensaje.Text = @"<div class='alert alert-danger alert-dismissable'><button type='button' class='close' 
                                   data-dismiss='alert' aria-hidden='true'>×</button> Selecciona un ciclo por favor.</div>";
            }
        }
        else
        {
            LabelMensaje.Visible = true;
            LabelMensaje.Text = @"<div class='alert alert-danger alert-dismissable'><button type='button' class='close' 
                                   data-dismiss='alert' aria-hidden='true'>×</button> Selecciona un año por favor.</div>";
        }
    }

    public string query(string tipo, string tabla)
    {
        string querys = "";
        if (tipo == "0")
        {
            querys = @"SELECT [DEL],[SUBDEL],[CICLO_ACTUALIZACION_NUM],[GUIA],[NSS_CORR],[NOM_DEL_ASEGU_NOM_CORREC],[SEXO],[MES_NAC],[LUG_NAC],[UMF],[REGPAT],[TIPO_TRAB]
           ,[SALARIO_BASE],[SEM_JOR],[TIP_SAL],[ARG_TP],[SUS_RE_SERV],[ID_HUEL],[ID_EXT],[FECH_MOV],[TIPO_MOV]
        FROM [Afil-25].[dbo].["+tabla+"]";
        }
        else
        {
            querys = @"SELECT [DEL],[SUBDEL],[CICLO_ACTUALIZACION_NUM],[GUIA],[NSS_CORR],[NOM_DEL_ASEGU_NOM_CORREC],[SEXO],[MES_NAC],[LUG_NAC],[UMF],[REGPAT],[TIPO_TRAB]
       ,[SALARIO_BASE],[SEM_JOR],[TIP_SAL],[ARG_TP],[SUS_RE_SERV],[ID_HUEL],[ID_EXT],[FECH_MOV],[TIPO_MOV]
    FROM [Afil-25].[dbo].["+tabla+"] WHERE[GUIA]= "+ tipo + "";
        }
        return querys;
    }
}