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

public partial class Casuistica_Reporte : System.Web.UI.Page
{
    String strConnString = ConfigurationManager.ConnectionStrings["AfiliacionConnectionString"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        
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
        }
        catch (Exception Mens)
        {
            //LabelMensaje.Text = Mens.Message + " Bandeja";
        }
        return num;
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        LabelMensaje.Text = "";
        DropDownList2.Items.Clear();
        DropDownList2.Items.Add(new ListItem("-- Seleccione el ciclo --", ""));
        DropDownList2.Items.Add(new ListItem(" Todos ", "0"));
        DropDownList3.Items.Clear();
        DropDownList3.Items.Add(new ListItem("-- Seleccione el ciclo --", ""));
        DropDownList2.AppendDataBoundItems = true;
        SqlConnection con = new SqlConnection(strConnString);
        SqlDataAdapter cmd = new SqlDataAdapter("COMBO_CICLOS", con);
        cmd.SelectCommand.CommandType = CommandType.StoredProcedure;
        cmd.SelectCommand.Parameters.AddWithValue("@TIPO", DropDownList1.SelectedValue.Trim());

        DataTable ds = new DataTable();
        if (cmd != null)
        {
            cmd.Fill(ds);
        }
        try
        {
            con.Open();
            DropDownList2.DataSource = ds;
            DropDownList2.DataTextField = "Ciclo";
            DropDownList2.DataValueField = "id";
            DropDownList2.DataBind();
            if (DropDownList2.Items.Count > 1)
            {
                DropDownList2.Enabled = true;
                Button1.Enabled = true;
            }
            else
            {
                DropDownList2.Enabled = false;
                DropDownList3.Enabled = false;
                Button1.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        LabelMensaje.Text = "";
        DropDownList3.Items.Clear();
        DropDownList3.Items.Add(new ListItem("-- Seleccione el ciclo --", ""));
        DropDownList3.AppendDataBoundItems = true;
        SqlConnection con = new SqlConnection(strConnString);
        SqlDataAdapter cmd = new SqlDataAdapter("COMBO_CICLOS_DOS", con);
        cmd.SelectCommand.CommandType = CommandType.StoredProcedure;
        cmd.SelectCommand.Parameters.AddWithValue("@TIPO", DropDownList1.SelectedValue);
        cmd.SelectCommand.Parameters.AddWithValue("@CICLO", DropDownList2.SelectedValue);
        DataTable ds = new DataTable();
        //DataSet ds = new DataSet();
        if (cmd != null)
        {
            cmd.Fill(ds);
        }
        try
        {
            con.Open();
            DropDownList3.DataSource = ds;
            DropDownList3.DataTextField = "Ciclo";
            DropDownList3.DataValueField = "id";
            DropDownList3.DataBind();
            if (DropDownList3.Items.Count > 1)
            {
                DropDownList3.Enabled = true;
            }
            else
            {
                DropDownList3.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        LabelMensaje.Text = "";
        if (DropDownList1.SelectedValue != "")
        {
            if (DropDownList2.SelectedValue != "")
            {
                if (DropDownList2.Items.Count > 2)
                {        
                    if (DropDownList2.SelectedValue == "0")
                    {
                        //LabelMensaje.Text = DropDownList2.SelectedValue;
                        Session["tipoSCAC"] = DropDownList1.SelectedValue;
                        Session["ciclo1"] = DropDownList2.SelectedValue;
                        Session["ciclo2"] = DropDownList3.SelectedValue.Trim();
                        if (DropDownList2.SelectedValue != "" && DropDownList3.SelectedValue != "")
                        {
                            Session["titulo"] = DropDownList1.SelectedItem + " del ciclo " + DropDownList2.SelectedItem + " al ciclo " + DropDownList3.SelectedItem;
                        }
                        else if (DropDownList3.SelectedValue == "")
                        {
                            Session["titulo"] = DropDownList1.SelectedItem + " con todos los Ciclos Cargados.";
                        }
                        if (DropDownList1.SelectedValue == "SCAC-09")
                        {
                            Session["Depto"] = "Departamento de Personal";
                        }
                        else if (DropDownList1.SelectedValue == "SCAC-10")
                        {
                            Session["Depto"] = "Coord. Delega. de Salud en el Trabajo";
                        }
                        Response.Write("<script>window.open('rtp.aspx','_blank');</script>");
                    }
                    else if (DropDownList2.SelectedValue != "0")
                    {
                        if(DropDownList3.SelectedValue != "")
                        {
                            Session["tipoSCAC"] = DropDownList1.SelectedValue;
                            Session["ciclo1"] = DropDownList2.SelectedValue;
                            Session["ciclo2"] = DropDownList3.SelectedValue.Trim();
                            if (DropDownList2.SelectedValue != "" && DropDownList3.SelectedValue != "")
                            {
                                Session["titulo"] = DropDownList1.SelectedItem + " del ciclo " + DropDownList2.SelectedItem + " al ciclo " + DropDownList3.SelectedItem;
                            }
                            else if (DropDownList3.SelectedValue == "")
                            {
                                Session["titulo"] = DropDownList1.SelectedItem + " con todos los Ciclos Cargados.";
                            }
                            if (DropDownList1.SelectedValue == "SCAC-09")
                            {
                                Session["Depto"] = "Departamento de Personal";
                            }
                            else if (DropDownList1.SelectedValue == "SCAC-10")
                            {
                                Session["Depto"] = "Coord. Delega. de Salud en el Trabajo";
                            }
                            Response.Write("<script>window.open('rtp.aspx','_blank');</script>");
                        }
                        else
                        {
                            LabelMensaje.Text = "<div class='alert alert-danger alert-dismissable'><button type='button' class='close' data-dismiss='alert' aria-hidden='true'>×</button> Seleccione el Ciclo 2 por favor.</div>";
                        }                        
                    }                    
                }
                else 
                {
                    LabelMensaje.Text = "<div class='alert alert-danger alert-dismissable'><button type='button' class='close' data-dismiss='alert' aria-hidden='true'>×</button> No hay ciclos que mostrar. " + DropDownList2.Items.Count + "</div>";
                }                    
            }
            else
            {
                LabelMensaje.Text = "<div class='alert alert-danger alert-dismissable'><button type='button' class='close' data-dismiss='alert' aria-hidden='true'>×</button> Seleccione el Ciclo 1 por favor.</div>";
            }
        }
        else
        {
            LabelMensaje.Text = "<div class='alert alert-danger alert-dismissable'><button type='button' class='close' data-dismiss='alert' aria-hidden='true'>×</button> Seleccione el Tipo de SCAC que desea por favor.</div>";
        }
    }
}