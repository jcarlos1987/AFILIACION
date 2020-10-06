using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.Sql;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Office.Interop.Outlook;


public partial class _Default : System.Web.UI.Page
{
    string conexion = ConfigurationManager.ConnectionStrings["AfiliacionConnectionString"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["user_Afil"] != null)
        {
            Username.Text = Request.Cookies["user_Afil"].Value;
            password.Attributes["value"] = Request.Cookies["pass_Afil"].Value;
            if (!IsPostBack)
            {
                brand1.Checked = true;
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (brand1.Checked == true)
        {
                Response.Cookies["user_Afil"].Value = Username.Text;
                Response.Cookies["pass_Afil"].Value = password.Text;
                Response.Cookies["user_Afil"].Expires = DateTime.Now.AddYears(2);
                Response.Cookies["pass_Afil"].Expires = DateTime.Now.AddYears(2);
                if (Login(Username.Text, password.Text))
                {
                    Response.Redirect("~/Menu/Default.aspx");
                }
                else
                {
                    Response.Write("<script language=javascript> alert('Usuario y/o Contraseña Incorrecta');</script>");
                }
        }
        if (brand1.Checked == false)
        {
            Response.Cookies["user_Afil"].Expires = DateTime.Now.AddYears(-2);
            Response.Cookies["pass_Afil"].Expires = DateTime.Now.AddYears(-2);
            if (Login(Username.Text, password.Text))
            {
                Response.Redirect("~/Menu/Default.aspx");
            }
            else
            {
                Response.Write("<script language=javascript> alert('Usuario y/o Contraseña Incorrecta');</script>");
            }
        }        
    }
    protected bool Login(string user, string pass)
    {
        bool status = false;
        SqlConnection conn = new SqlConnection(conexion);
        try
        {
            SqlCommand command = new SqlCommand("SELECT T1.[id], T2.[nombre], T1.[del], T1.[sub], [user_type], [cargo],[depto] FROM [Afiliacion].[dbo].[User] T1 INNER JOIN [172.24.86.201].[Panel_Control].[dbo].[Usuarios] T2 ON T1.[id]=T2.[id] WHERE T2.[user]='" + user + "' AND T2.[pass]='" + pass + "' AND T1.[id]=T2.[id]", conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Response.Cookies["ID_AFILIACION"].Value = Convert.ToString(reader.GetInt32(0));
                    Response.Cookies["ID_AFIL_NOMBRE"].Value = reader.GetString(1);
                    Response.Cookies["ID_AFIL_DEL"].Value = reader.GetString(2);
                    Response.Cookies["ID_AFIL_SUB"].Value = reader.GetString(3);
                    Response.Cookies["ID_AFIL_TYPE"].Value = reader.GetString(4);
                    Response.Cookies["ID_AFIL_CARGO"].Value = reader.GetString(5);
                    Response.Cookies["ID_AFIL_DEPTO"].Value = reader.GetString(6);
                    status = true;
                }
            }
        }
        catch(System.Exception msj)
        {
            Response.Write("<script language=javascript> alert('" + msj.Message + " ');</script>");
        }
        return status;
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Microsoft.Office.Interop.Outlook.Application mapp = new Microsoft.Office.Interop.Outlook.Application();
        Microsoft.Office.Interop.Outlook.MailItem email = null;
        email = (Microsoft.Office.Interop.Outlook.MailItem)mapp.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);
        email.To = "isaac.barrientos@imss.gob.mx";
        email.Subject = "texto";
        email.Display();
        /*string email = "isaac.barrientos@imss.gob.mx";
        ClientScript.RegisterStartupScript(this.GetType(), "mailto", "parent.location='mailto:" + email + "'", true);*/
    }
}