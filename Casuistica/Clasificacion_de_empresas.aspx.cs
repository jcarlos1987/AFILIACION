using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Web.UI.HtmlControls;
public partial class Casuistica_Clasificacion_de_empresas : System.Web.UI.Page
{
    String strConnString = ConfigurationManager.ConnectionStrings["AfiliacionConnectionString"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        HtmlGenericControl divYogesh = new HtmlGenericControl("homepills");
        divYogesh.Attributes.Add("class", "tab-pane fade active in");

        HtmlGenericControl div = new HtmlGenericControl("profilepills");
        div.Attributes.Add("class", "tab-pane fade");
        Consulta();
    }

    public void Consulta()
    {
        SqlConnection conn = new SqlConnection(strConnString);
        string query = "";
        //Label2.Text = Request.QueryString["type"] + " del Ciclo " + Request.QueryString["ciclo"];
        query = "SELECT [id],[tipo],[fecha],[Ciclo],[Fecha_Carga],[No_Regis],[mensaje],[leer],CASE WHEN DATEDIFF(SECOND, [Fech_Envio],GETDATE()) < 60 THEN 'Hace ' +CONVERT(NVARCHAR(50),  DATEDIFF(SECOND, [Fech_Envio],GETDATE())) + ' Segundos' "+
                "WHEN DATEDIFF(MINUTE, [Fech_Envio],GETDATE()) < 60 THEN 'Hace ' +CONVERT(NVARCHAR(50), DATEDIFF(MINUTE, [Fech_Envio],GETDATE())) + ' Minutos'"+
			    "WHEN DATEDIFF(HOUR, [Fech_Envio],GETDATE()) < 24 THEN 'Hace ' +CONVERT(NVARCHAR(50), DATEDIFF(HOUR, [Fech_Envio],GETDATE())) + ' Horas'"+
			    "WHEN DATEDIFF(DAY, [Fech_Envio],GETDATE()) > 0 THEN 'Hace ' +CONVERT(NVARCHAR(50), DATEDIFF(DAY, [Fech_Envio],GETDATE())) + ' Dias'"+
			    "WHEN DATEDIFF(WEEK, [Fech_Envio],GETDATE()) > 0 THEN 'Hace ' +CONVERT(NVARCHAR(50), DATEDIFF(WEEK, [Fech_Envio],GETDATE())) + ' Semanas'"+
			    "WHEN DATEDIFF(MONTH, [Fech_Envio],GETDATE()) > 0 THEN 'Hace ' +CONVERT(NVARCHAR(50), DATEDIFF(MONTH, [Fech_Envio],GETDATE())) + ' Meses'"+
			    "WHEN DATEDIFF(YEAR, [Fech_Envio],GETDATE()) > 0 THEN 'Hace ' +CONVERT(NVARCHAR(50), DATEDIFF(YEAR, [Fech_Envio],GETDATE())) + ' Años'"+
          "END [Envio], [Fech_Envio] FROM [Afiliacion].[dbo].[BandeClasEmpre] ORDER BY [Fech_Envio] DESC";
        conn.Open();
        SqlCommand cmd = new SqlCommand(query, conn);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();
        conn.Close();
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //Checking the RowType of the Row  
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //If Salary is less than 10000 than set the row Background Color to Cyan  
            if (Convert.ToInt32(e.Row.Cells[6].Text) == 0)
            {
                e.Row.BackColor = Color.FromName("#D6D6D6");
                e.Row.Font.Bold = true;
                e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#328F83'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#D6D6D6'");
            }
            else if(Convert.ToInt32(e.Row.Cells[6].Text) == 1)
            {
                e.Row.BackColor = Color.FromName("#FEF9F3");
                e.Row.CssClass = "list-group-item-success";
                e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#328F83'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FEF9F3'");
            }
        } 
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = GridView1.SelectedRow;
        int id = Convert.ToInt32(GridView1.DataKeys[row.RowIndex].Value);

        SqlConnection conn = new SqlConnection(strConnString);
        try
        {
            conn.Open();
            SqlDataReader myReader = null;
            SqlCommand Comando = new SqlCommand("SELECT [id],[tipo],[fecha],[Ciclo],[Fecha_Carga],[No_Regis],[mensaje],[leer],[Fech_Envio] FROM [Afiliacion].[dbo].[BandeClasEmpre] WHERE [id]=" + id + "", conn);
            myReader = Comando.ExecuteReader();
            while (myReader.Read())
            {
                Label5.Text = myReader.GetString(1);
                Label8.Text = String.Format("{0:dd/MM/yyyy}", myReader.GetDateTime(2));
                Label7.Text = myReader.GetString(3);
                Label6.Text = Convert.ToString(myReader.GetDateTime(4));
                Label9.Text = Convert.ToString(myReader.GetInt32(5));
                Label10.Text = myReader.GetString(6);
                GridView1.Visible = false;
                PanelMostrarMsj.Visible = true;
                GridView2.Visible = true;

                using (SqlConnection conn1 = new SqlConnection(strConnString))
                {
                    try
                    {
                        conn1.Open();
                        String sen = null;
                        int resul;
                        sen = "UPDATE [Afiliacion].[dbo].[BandeClasEmpre] SET [leer] = @leer WHERE [id]=" + Convert.ToInt32(id) + "";
                        SqlCommand cmd = new SqlCommand(sen, conn1);
                        cmd.Parameters.Add(new SqlParameter("@leer", SqlDbType.Int));
                        cmd.Parameters["@leer"].Value = 1;
                        resul = cmd.ExecuteNonQuery();
                        conn1.Close();
                    }
                    catch (Exception Msj)
                    {
                        LabelMensaje.Text = Msj.Message + ". Actualizar";
                    }
                }
                Grid();
            }
            conn.Close();
        }
        catch (Exception d)
        {
            LabelMensaje.Text = d.Message;
        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        this.GridView1.DataBind();
    }

    public int Bandeja(string depto)
    {
        int num = 0;
        SqlConnection conn = new SqlConnection(strConnString);
        string query = "";
        try
        {
            conn.Open();
            query = "SELECT COUNT(*) FROM [Afiliacion].[dbo].[BandeClasEmpre] WHERE [leer] = 0 ";
            SqlCommand cmd = new SqlCommand(query, conn);
            num = Convert.ToInt32(cmd.ExecuteScalar());
            //return num;
            conn.Close();
        }
        catch(Exception Mens)
        {
            LabelMensaje.Text = Mens.Message + " Bandeja";
        }
        return num;
    }

    public void Grid()
    {
        SqlConnection conn1 = new SqlConnection(strConnString);
        string query = "";
        //Label2.Text = type + " del Ciclo " + ciclo;
        if (Label5.Text.Trim() == "SCAC-10")
        {
            query = "SELECT [id],[Fecha_Carga],[Folio_Error],[Cve_Docto],[NSS],[Registro_Pat],[Fecha_Inicio],[TR],[CS],[Dias_Sub],[Folio_Docto],[Porc_Inc],[Fecha_Termino],[Deleg_Orgn],[UMF],[Codigo_Error],[Codigo_Error2]" +
                    ",[Codigo_Error3],[Codigo_Error4],[Codigo_Error5],[Nombre_Asegurado],[CURP],[Cto_Pag],[Tipo_Mto_Aju],[Fecha_Extrac],[Tipo],[Ciclo],[status] FROM [Afiliacion].[dbo].[SCAC-10] WHERE [Tipo]='" + Label5.Text.Trim() + "' AND [Ciclo]='" + Label7.Text.Trim() + "'";
        }
        else if (Label5.Text.Trim() == "SCAC-09")
        {
            query = "SELECT [id],[Fecha_Carga],[Folio_Error],[Cve_Docto],[NSS],[Registro_Pat],[Fecha_Inicio],[TR],[CS],[Dias_Sub],[Porc_Inc],[Fecha_Termino],[Deleg_Orgn],[UMF],[Codigo_Error]," +
                    "[Codigo_Error2],[Codigo_Error3],[Codigo_Error4],[Codigo_Error5],[Nombre_Asegurado],[CURP],[Folio_Docto],[Cto_Pag],[Tipo_Mto_Aju],[Fec_Extraccion],[Tipo_SCAC],[Ciclo],[status] FROM [Afiliacion].[dbo].[SCAC-09] WHERE [Tipo_SCAC]='" + Label5.Text.Trim() + "' AND [Ciclo]='" + Label7.Text.Trim() + "'";
        }
        conn1.Open();
        SqlCommand cmd = new SqlCommand(query, conn1);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        if (Label5.Text.Trim() == "SCAC-10")
        {
            
            GridView2.Visible = true;
            //GridView2.Visible = false;
            GridView2.DataSource = dt;
            GridView2.DataBind();
        }
        else if (Label5.Text.Trim() == "SCAC-09")
        {
            /*GridView2.Visible = true;
            GridView1.Visible = false;
            GridView2.DataSource = dt;
            GridView2.DataBind();*/
        }
        conn1.Close();
    }
    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Grid();
       /* homepills.Attributes.Add("class", "tab-pane fade");
        profilepills.Attributes.Add("class", "tab-pane fade active in");*/
        
        //dynDiv.Attributes.Add("class", "tab-pane fade active in");

       
        GridView2.PageIndex = e.NewPageIndex;
        this.GridView2.DataBind();

        HtmlGenericControl divYogesh = new HtmlGenericControl("homepills");
        divYogesh.Attributes.Add("class", "tab-pane fade");

        HtmlGenericControl div = new HtmlGenericControl("profilepills");
        div.Attributes.Add("class", "tab-pane fade active in");

        /*System.Web.UI.HtmlControls.HtmlGenericControl Div = new System.Web.UI.HtmlControls.HtmlGenericControl("homepills");
        Div.Attributes["class"] = "tab-pane fade";*/
        // Div.Attributes.Add("class", "tab-pane fade");

       /* System.Web.UI.HtmlControls.HtmlGenericControl dynDiv = new System.Web.UI.HtmlControls.HtmlGenericControl("profilepills");
        dynDiv.Attributes["class"] = "tab-pane fade active in";*/
    }
}