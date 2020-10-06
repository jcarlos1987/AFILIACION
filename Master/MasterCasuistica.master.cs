using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Master_MasterCasuistica : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["ID_AFILIACION"] != null)
        {
            if (Request.Cookies["ID_AFIL_TYPE"].Value == "1" || Request.Cookies["ID_AFIL_TYPE"].Value == "11" || Request.Cookies["ID_AFIL_TYPE"].Value == "111")
            {
                Label1.Text = Request.Cookies["ID_AFIL_NOMBRE"].Value.Substring(0, 20);
                Label2.Text = Request.Cookies["ID_AFIL_CARGO"].Value;
                Label3.Text = Request.Cookies["ID_AFIL_DEPTO"].Value;
                Label4.Text = String.Format("{0:dddd d MMMM, yyyy}", (DateTime.Now));
            }
            else
            {
                Response.Redirect("~/Menu/Error.aspx");
            }
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Cookies["ID_AFILIACION"].Expires = DateTime.Now.AddYears(-2);
        Response.Cookies["ID_AFIL_NOMBRE"].Expires = DateTime.Now.AddYears(-2);
        Response.Cookies["ID_AFIL_DEL"].Expires = DateTime.Now.AddYears(-2);
        Response.Cookies["ID_AFIL_SUB"].Expires = DateTime.Now.AddYears(-2);
        Response.Cookies["ID_AFIL_TYPE"].Expires = DateTime.Now.AddYears(-2);
        Response.Cookies["ID_AFIL_CARGO"].Expires = DateTime.Now.AddYears(-2);
        Response.Cookies["ID_AFIL_DEPTO"].Expires = DateTime.Now.AddYears(-2);
        Response.Redirect("~/Default.aspx");
    }
}
