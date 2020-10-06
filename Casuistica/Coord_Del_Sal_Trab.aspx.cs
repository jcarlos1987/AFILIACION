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

public partial class Casuistica_Coord_Del_Sal_Trab : System.Web.UI.Page
{
    String strConnString = ConfigurationManager.ConnectionStrings["AfiliacionConnectionString"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        Consulta();
    }
    public void Consulta()
    {
        SqlConnection conn = new SqlConnection(strConnString);
        string query = "";
        //Label2.Text = Request.QueryString["type"] + " del Ciclo " + Request.QueryString["ciclo"];
        query = "SELECT [id],[tipo],[fecha],[Ciclo],[Fecha_Carga],[No_Regis],[mensaje],[leer],CASE WHEN DATEDIFF(SECOND, [Fech_Envio],GETDATE()) < 60 THEN 'Hace ' +CONVERT(NVARCHAR(50),  DATEDIFF(SECOND, [Fech_Envio],GETDATE())) + ' Segundos' " +
                "WHEN DATEDIFF(MINUTE, [Fech_Envio],GETDATE()) < 60 THEN 'Hace ' +CONVERT(NVARCHAR(50), DATEDIFF(MINUTE, [Fech_Envio],GETDATE())) + ' Minutos'" +
                "WHEN DATEDIFF(HOUR, [Fech_Envio],GETDATE()) < 24 THEN 'Hace ' +CONVERT(NVARCHAR(50), DATEDIFF(HOUR, [Fech_Envio],GETDATE())) + ' Horas'" +
                "WHEN DATEDIFF(DAY, [Fech_Envio],GETDATE()) > 0 THEN 'Hace ' +CONVERT(NVARCHAR(50), DATEDIFF(DAY, [Fech_Envio],GETDATE())) + ' Dias'" +
                "WHEN DATEDIFF(WEEK, [Fech_Envio],GETDATE()) > 0 THEN 'Hace ' +CONVERT(NVARCHAR(50), DATEDIFF(WEEK, [Fech_Envio],GETDATE())) + ' Semanas'" +
                "WHEN DATEDIFF(MONTH, [Fech_Envio],GETDATE()) > 0 THEN 'Hace ' +CONVERT(NVARCHAR(50), DATEDIFF(MONTH, [Fech_Envio],GETDATE())) + ' Meses'" +
                "WHEN DATEDIFF(YEAR, [Fech_Envio],GETDATE()) > 0 THEN 'Hace ' +CONVERT(NVARCHAR(50), DATEDIFF(YEAR, [Fech_Envio],GETDATE())) + ' Años'" +
          "END [Envio], [Fech_Envio] FROM [Afiliacion].[dbo].[BandeSalTrab] ORDER BY [Fech_Envio] DESC";
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
            else if (Convert.ToInt32(e.Row.Cells[6].Text) == 1)
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

        using (SqlConnection conn1 = new SqlConnection(strConnString))
        {
            try
            {
                conn1.Open();
                String sen = null;
                int resul;
                sen = "UPDATE [Afiliacion].[dbo].[BandeSalTrab] SET [leer] = @leer WHERE [id]=" + Convert.ToInt32(id) + "";
                SqlCommand cmd = new SqlCommand(sen, conn1);
                cmd.Parameters.Add(new SqlParameter("@leer", SqlDbType.Int));
                cmd.Parameters["@leer"].Value = 1;
                resul = cmd.ExecuteNonQuery();
            }
            catch (Exception Msj)
            {
                LabelMensaje.Text = Msj.Message + ". Actualizar";
            }
        }

        Response.Cookies["ID_DPTO_SALUD"].Value = Convert.ToString(id);
        Response.Redirect("GridScac09.aspx");
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
            query = "SELECT COUNT(*) FROM [Afiliacion].[dbo].[BandeSalTrab] WHERE [leer] = 0 ";
            SqlCommand cmd = new SqlCommand(query, conn);
            num = Convert.ToInt32(cmd.ExecuteScalar());
            return num;
        }
        catch (Exception Mens)
        {
            LabelMensaje.Text = Mens.Message + " Bandeja";
        }
        return num;
    }
}