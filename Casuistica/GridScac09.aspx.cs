using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Globalization;

public partial class Casuistica_GridScac09 : System.Web.UI.Page
{
    String strConnString = ConfigurationManager.ConnectionStrings["AfiliacionConnectionString"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        Consulta();
        Grid();
    }

    public void Consulta()
    {
        SqlConnection conn = new SqlConnection(strConnString);
        try
        {
            conn.Open();
            SqlDataReader myReader = null;
            SqlCommand Comando = new SqlCommand("SELECT [id],[tipo],[fecha],[Ciclo],[Fecha_Carga],[No_Regis],[mensaje],[leer],[Fech_Envio] FROM [Afiliacion].[dbo].[BandeSalTrab] WHERE [id]=" + Convert.ToInt32(Request.Cookies["ID_DPTO_SALUD"].Value) + "", conn);
            myReader = Comando.ExecuteReader();
            while (myReader.Read())
            {
                Label5.Text = myReader.GetString(1);
                Label8.Text = String.Format("{0:dd/MM/yyyy}", myReader.GetDateTime(2));
                Label7.Text = myReader.GetString(3);
                Label6.Text = Convert.ToString(myReader.GetDateTime(4));
                Label9.Text = Convert.ToString(myReader.GetInt32(5));
                Label10.Text = myReader.GetString(6);

                if (Porcentaje(myReader.GetString(3), myReader.GetString(1)) >= 0 && Porcentaje(myReader.GetString(3), myReader.GetString(1)) <= 2.5)
                {
                    Label12.Text = "<i class='fa fa-star-o fa-2x' style='color:#F5B639'></i><i class='fa fa-star-o fa-2x' style='color:#F5B639'></i><i class='fa fa-star-o fa-2x' style='color:#F5B639'></i> <i class='fa fa-star-o fa-2x' style='color:#F5B639'></i><i class='fa fa-star-o fa-2x' style='color:#F5B639'></i>" +
                                          "<i class='fa fa-star-o fa-2x' style='color:#F5B639'></i><i class='fa fa-star-o fa-2x' style='color:#F5B639'></i><i class='fa fa-star-o fa-2x' style='color:#F5B639'></i><i class='fa fa-star-o fa-2x' style='color:#F5B639'></i><i class='fa fa-star-o fa-2x' style='color:#F5B639'></i>";
                }
                else if (Porcentaje(myReader.GetString(3), myReader.GetString(1)) >= 2.5 && Porcentaje(myReader.GetString(3), myReader.GetString(1)) <= 5)
                {
                    Label12.Text = "<i class='fa fa-star-half-empty fa-2x' style='color:#F5B639'></i><i class='fa fa-star-o fa-2x' style='color:#F5B639'></i><i class='fa fa-star-o fa-2x' style='color:#F5B639'></i> <i class='fa fa-star-o fa-2x' style='color:#F5B639'></i><i class='fa fa-star-o fa-2x' style='color:#F5B639'></i>" +
                                  "        <i class='fa fa-star-o fa-2x' style='color:#F5B639'></i><i class='fa fa-star-o fa-2x' style='color:#F5B639'></i><i class='fa fa-star-o fa-2x' style='color:#F5B639'></i><i class='fa fa-star-o fa-2x' style='color:#F5B639'></i><i class='fa fa-star-o fa-2x' style='color:#F5B639'></i>";
                }
                else if (Porcentaje(myReader.GetString(3), myReader.GetString(1)) >= 5 && Porcentaje(myReader.GetString(3), myReader.GetString(1)) <= 10)
                {
                    Label12.Text = "<i class='fa fa-star fa-2x' style='color:#F5B639'></i><i class='fa fa-star-o fa-2x' style='color:#F5B639'></i><i class='fa fa-star-o fa-2x' style='color:#F5B639'></i> <i class='fa fa-star-o fa-2x' style='color:#F5B639'></i><i class='fa fa-star-o fa-2x' style='color:#F5B639'></i>" +
                    "<i class='fa fa-star-o fa-2x' style='color:#F5B639'></i><i class='fa fa-star-o fa-2x' style='color:#F5B639'></i><i class='fa fa-star-o fa-2x' style='color:#F5B639'></i><i class='fa fa-star-o fa-2x' style='color:#F5B639'></i><i class='fa fa-star-o fa-2x' style='color:#F5B639'></i>";
                }
                else if (Porcentaje(myReader.GetString(3), myReader.GetString(1)) >= 10 && Porcentaje(myReader.GetString(3), myReader.GetString(1)) <= 15)
                {
                    Label12.Text = " <i class='fa fa-star fa-2x' style='color:#F5B639'></i><i class='fa fa-star-half-empty fa-2x' style='color:#F5B639'></i><i class='fa fa-star-o fa-2x' style='color:#F5B639'></i> <i class='fa fa-star-o fa-2x' style='color:#F5B639'></i><i class='fa fa-star-o fa-2x' style='color:#F5B639'></i>" +
                     "<i class='fa fa-star-o fa-2x' style='color:#F5B639'></i><i class='fa fa-star-o fa-2x' style='color:#F5B639'></i><i class='fa fa-star-o fa-2x' style='color:#F5B639'></i><i class='fa fa-star-o fa-2x' style='color:#F5B639'></i><i class='fa fa-star-o fa-2x' style='color:#F5B639'></i>";
                }
                else if (Porcentaje(myReader.GetString(3), myReader.GetString(1)) >= 15 && Porcentaje(myReader.GetString(3), myReader.GetString(1)) <= 20)
                {
                    Label12.Text = "<i class='fa fa-star fa-2x' style='color:#F5B639'></i><i class='fa fa-star fa-2x' style='color:#F5B639'></i><i class='fa fa-star-o fa-2x' style='color:#F5B639'></i> <i class='fa fa-star-o fa-2x' style='color:#F5B639'></i><i class='fa fa-star-o fa-2x' style='color:#F5B639'></i>" +
                    "<i class='fa fa-star-o fa-2x' style='color:#F5B639'></i><i class='fa fa-star-o fa-2x' style='color:#F5B639'></i><i class='fa fa-star-o fa-2x' style='color:#F5B639'></i><i class='fa fa-star-o fa-2x' style='color:#F5B639'></i><i class='fa fa-star-o fa-2x' style='color:#F5B639'></i>";
                }
                else if (Porcentaje(myReader.GetString(3), myReader.GetString(1)) >= 20 && Porcentaje(myReader.GetString(3), myReader.GetString(1)) <= 25)
                {
                    Label12.Text = " <i class='fa fa-star fa-2x' style='color:#F5B639'></i><i class='fa fa-star fa-2x' style='color:#F5B639'></i><i class='fa fa-star-half-empty fa-2x' style='color:#F5B639'></i> <i class='fa fa-star-o fa-2x' style='color:#F5B639'></i><i class='fa fa-star-o fa-2x' style='color:#F5B639'></i>" +
                     "<i class='fa fa-star-o fa-2x' style='color:#F5B639'></i><i class='fa fa-star-o fa-2x' style='color:#F5B639'></i><i class='fa fa-star-o fa-2x' style='color:#F5B639'></i><i class='fa fa-star-o fa-2x' style='color:#F5B639'></i><i class='fa fa-star-o fa-2x' style='color:#F5B639'></i>";
                }
                else if (Porcentaje(myReader.GetString(3), myReader.GetString(1)) >= 25 && Porcentaje(myReader.GetString(3), myReader.GetString(1)) <= 30)
                {
                    Label12.Text = "<i class='fa fa-star fa-2x' style='color:#F5B639'></i><i class='fa fa-star fa-2x' style='color:#F5B639'></i><i class='fa fa-star fa-2x' style='color:#F5B639'></i> <i class='fa fa-star-o fa-2x' style='color:#F5B639'></i><i class='fa fa-star-o fa-2x' style='color:#F5B639'></i>" +
                   " <i class='fa fa-star-o fa-2x' style='color:#F5B639'></i><i class='fa fa-star-o fa-2x' style='color:#F5B639'></i><i class='fa fa-star-o fa-2x' style='color:#F5B639'></i><i class='fa fa-star-o fa-2x' style='color:#F5B639'></i><i class='fa fa-star-o fa-2x' style='color:#F5B639'></i>";
                }
                else if (Porcentaje(myReader.GetString(3), myReader.GetString(1)) >= 30 && Porcentaje(myReader.GetString(3), myReader.GetString(1)) <= 35)
                {
                    Label12.Text = "<i class='fa fa-star fa-2x' style='color:#F5B639'></i><i class='fa fa-star fa-2x' style='color:#F5B639'></i><i class='fa fa-star fa-2x' style='color:#F5B639'></i> <i class='fa fa-star-half-empty fa-2x' style='color:#F5B639'></i><i class='fa fa-star-o fa-2x' style='color:#F5B639'></i>" +
                    "<i class='fa fa-star-o fa-2x' style='color:#F5B639'></i><i class='fa fa-star-o fa-2x' style='color:#F5B639'></i><i class='fa fa-star-o fa-2x' style='color:#F5B639'></i><i class='fa fa-star-o fa-2x' style='color:#F5B639'></i><i class='fa fa-star-o fa-2x' style='color:#F5B639'></i>";
                }
                else if (Porcentaje(myReader.GetString(3), myReader.GetString(1)) >= 35 && Porcentaje(myReader.GetString(3), myReader.GetString(1)) <= 40)
                {
                    Label12.Text = "<i class='fa fa-star fa-2x' style='color:#F5B639'></i><i class='fa fa-star fa-2x' style='color:#F5B639'></i><i class='fa fa-star fa-2x' style='color:#F5B639'></i> <i class='fa fa-star fa-2x' style='color:#F5B639'></i><i class='fa fa-star-o fa-2x' style='color:#F5B639'></i>" +
                    "<i class='fa fa-star-o fa-2x' style='color:#F5B639'></i><i class='fa fa-star-o fa-2x' style='color:#F5B639'></i><i class='fa fa-star-o fa-2x' style='color:#F5B639'></i><i class='fa fa-star-o fa-2x' style='color:#F5B639'></i><i class='fa fa-star-o fa-2x' style='color:#F5B639'></i>";
                }
                else if (Porcentaje(myReader.GetString(3), myReader.GetString(1)) >= 40 && Porcentaje(myReader.GetString(3), myReader.GetString(1)) <= 45)
                {
                    Label12.Text = "<i class='fa fa-star fa-2x' style='color:#F5B639'></i><i class='fa fa-star fa-2x' style='color:#F5B639'></i><i class='fa fa-star fa-2x' style='color:#F5B639'></i> <i class='fa fa-star fa-2x' style='color:#F5B639'></i><i class='fa fa-star-half-empty fa-2x' style='color:#F5B639'></i>" +
                    "<i class='fa fa-star-o fa-2x' style='color:#F5B639'></i><i class='fa fa-star-o fa-2x' style='color:#F5B639'></i><i class='fa fa-star-o fa-2x' style='color:#F5B639'></i><i class='fa fa-star-o fa-2x' style='color:#F5B639'></i><i class='fa fa-star-o fa-2x' style='color:#F5B639'></i>";
                }
                else if (Porcentaje(myReader.GetString(3), myReader.GetString(1)) >= 45 && Porcentaje(myReader.GetString(3), myReader.GetString(1)) <= 50)
                {
                    Label12.Text = " <i class='fa fa-star fa-2x' style='color:#F5B639'></i><i class='fa fa-star fa-2x' style='color:#F5B639'></i><i class='fa fa-star fa-2x' style='color:#F5B639'></i> <i class='fa fa-star fa-2x' style='color:#F5B639'></i><i class='fa fa-star fa-2x' style='color:#F5B639'></i>" +
                     "<i class='fa fa-star-o fa-2x' style='color:#F5B639'></i><i class='fa fa-star-o fa-2x' style='color:#F5B639'></i><i class='fa fa-star-o fa-2x' style='color:#F5B639'></i><i class='fa fa-star-o fa-2x' style='color:#F5B639'></i><i class='fa fa-star-o fa-2x' style='color:#F5B639'></i>";
                }
                else if (Porcentaje(myReader.GetString(3), myReader.GetString(1)) >= 50 && Porcentaje(myReader.GetString(3), myReader.GetString(1)) <= 55)
                {
                    Label12.Text = "<i class='fa fa-star fa-2x' style='color:#F5B639'></i><i class='fa fa-star fa-2x' style='color:#F5B639'></i><i class='fa fa-star fa-2x' style='color:#F5B639'></i> <i class='fa fa-star fa-2x' style='color:#F5B639'></i><i class='fa fa-star fa-2x' style='color:#F5B639'></i>" +
                   " <i class='fa fa-star-half-empty fa-2x' style='color:#F5B639'></i><i class='fa fa-star-o fa-2x' style='color:#F5B639'></i><i class='fa fa-star-o fa-2x' style='color:#F5B639'></i><i class='fa fa-star-o fa-2x' style='color:#F5B639'></i><i class='fa fa-star-o fa-2x' style='color:#F5B639'></i>";
                }
                else if (Porcentaje(myReader.GetString(3), myReader.GetString(1)) >= 55 && Porcentaje(myReader.GetString(3), myReader.GetString(1)) <= 60)
                {
                    Label12.Text = "<i class='fa fa-star fa-2x' style='color:#F5B639'></i><i class='fa fa-star fa-2x' style='color:#F5B639'></i><i class='fa fa-star fa-2x' style='color:#F5B639'></i> <i class='fa fa-star fa-2x' style='color:#F5B639'></i><i class='fa fa-star fa-2x' style='color:#F5B639'></i>" +
                   " <i class='fa fa-star fa-2x' style='color:#F5B639'></i><i class='fa fa-star-o fa-2x' style='color:#F5B639'></i><i class='fa fa-star-o fa-2x' style='color:#F5B639'></i><i class='fa fa-star-o fa-2x' style='color:#F5B639'></i><i class='fa fa-star-o fa-2x' style='color:#F5B639'></i>";
                }
                else if (Porcentaje(myReader.GetString(3), myReader.GetString(1)) >= 60 && Porcentaje(myReader.GetString(3), myReader.GetString(1)) <= 65)
                {
                    Label12.Text = " <i class='fa fa-star fa-2x' style='color:#F5B639'></i><i class='fa fa-star fa-2x' style='color:#F5B639'></i><i class='fa fa-star fa-2x' style='color:#F5B639'></i> <i class='fa fa-star fa-2x' style='color:#F5B639'></i><i class='fa fa-star fa-2x' style='color:#F5B639'></i>" +
                    " <i class='fa fa-star fa-2x' style='color:#F5B639'></i><i class='fa fa-star-half-empty fa-2x' style='color:#F5B639'></i><i class='fa fa-star-o fa-2x' style='color:#F5B639'></i><i class='fa fa-star-o fa-2x' style='color:#F5B639'></i><i class='fa fa-star-o fa-2x' style='color:#F5B639'></i>";
                }
                else if (Porcentaje(myReader.GetString(3), myReader.GetString(1)) >= 65 && Porcentaje(myReader.GetString(3), myReader.GetString(1)) <= 70)
                {
                    Label12.Text = " <i class='fa fa-star fa-2x' style='color:#F5B639'></i><i class='fa fa-star fa-2x' style='color:#F5B639'></i><i class='fa fa-star fa-2x' style='color:#F5B639'></i> <i class='fa fa-star fa-2x' style='color:#F5B639'></i><i class='fa fa-star fa-2x' style='color:#F5B639'></i>" +
                    " <i class='fa fa-star fa-2x' style='color:#F5B639'></i><i class='fa fa-star fa-2x' style='color:#F5B639'></i><i class='fa fa-star-o fa-2x' style='color:#F5B639'></i><i class='fa fa-star-o fa-2x' style='color:#F5B639'></i><i class='fa fa-star-o fa-2x' style='color:#F5B639'></i>";
                }
                else if (Porcentaje(myReader.GetString(3), myReader.GetString(1)) >= 70 && Porcentaje(myReader.GetString(3), myReader.GetString(1)) <= 75)
                {
                    Label12.Text = " <i class='fa fa-star fa-2x' style='color:#F5B639'></i><i class='fa fa-star fa-2x' style='color:#F5B639'></i><i class='fa fa-star fa-2x' style='color:#F5B639'></i> <i class='fa fa-star fa-2x' style='color:#F5B639'></i><i class='fa fa-star fa-2x' style='color:#F5B639'></i>" +
                    " <i class='fa fa-star fa-2x' style='color:#F5B639'></i><i class='fa fa-star fa-2x' style='color:#F5B639'></i><i class='fa fa-star-half-empty fa-2x' style='color:#F5B639'></i><i class='fa fa-star-o fa-2x' style='color:#F5B639'></i><i class='fa fa-star-o fa-2x' style='color:#F5B639'></i>";
                }
                else if (Porcentaje(myReader.GetString(3), myReader.GetString(1)) >= 75 && Porcentaje(myReader.GetString(3), myReader.GetString(1)) <= 80)
                {
                    Label12.Text = " <i class='fa fa-star fa-2x' style='color:#F5B639'></i><i class='fa fa-star fa-2x' style='color:#F5B639'></i><i class='fa fa-star fa-2x' style='color:#F5B639'></i> <i class='fa fa-star fa-2x' style='color:#F5B639'></i><i class='fa fa-star fa-2x' style='color:#F5B639'></i>" +
                    " <i class='fa fa-star fa-2x' style='color:#F5B639'></i><i class='fa fa-star fa-2x' style='color:#F5B639'></i><i class='fa fa-star fa-2x' style='color:#F5B639'></i><i class='fa fa-star-o fa-2x' style='color:#F5B639'></i><i class='fa fa-star-o fa-2x' style='color:#F5B639'></i>";
                }
                else if (Porcentaje(myReader.GetString(3), myReader.GetString(1)) >= 80 && Porcentaje(myReader.GetString(3), myReader.GetString(1)) <= 85)
                {
                    Label12.Text = " <i class='fa fa-star fa-2x' style='color:#F5B639'></i><i class='fa fa-star fa-2x' style='color:#F5B639'></i><i class='fa fa-star fa-2x' style='color:#F5B639'></i> <i class='fa fa-star fa-2x' style='color:#F5B639'></i><i class='fa fa-star fa-2x' style='color:#F5B639'></i>" +
                   "  <i class='fa fa-star fa-2x' style='color:#F5B639'></i><i class='fa fa-star fa-2x' style='color:#F5B639'></i><i class='fa fa-star fa-2x' style='color:#F5B639'></i><i class='fa fa-star-half-empty fa-2x' style='color:#F5B639'></i><i class='fa fa-star-o fa-2x' style='color:#F5B639'></i>";
                }
                else if (Porcentaje(myReader.GetString(3), myReader.GetString(1)) >= 85 && Porcentaje(myReader.GetString(3), myReader.GetString(1)) <= 90)
                {
                    Label12.Text = " <i class='fa fa-star fa-2x' style='color:#F5B639'></i><i class='fa fa-star fa-2x' style='color:#F5B639'></i><i class='fa fa-star fa-2x' style='color:#F5B639'></i> <i class='fa fa-star fa-2x' style='color:#F5B639'></i><i class='fa fa-star fa-2x' style='color:#F5B639'></i>" +
                    " <i class='fa fa-star fa-2x' style='color:#F5B639'></i><i class='fa fa-star fa-2x' style='color:#F5B639'></i><i class='fa fa-star fa-2x' style='color:#F5B639'></i><i class='fa fa-star fa-2x' style='color:#F5B639'></i><i class='fa fa-star-o fa-2x' style='color:#F5B639'></i>";
                }
                else if (Porcentaje(myReader.GetString(3), myReader.GetString(1)) >= 90 && Porcentaje(myReader.GetString(3), myReader.GetString(1)) <= 99)
                {
                    Label12.Text = "  <i class='fa fa-star fa-2x' style='color:#F5B639'></i><i class='fa fa-star fa-2x' style='color:#F5B639'></i><i class='fa fa-star fa-2x' style='color:#F5B639'></i> <i class='fa fa-star fa-2x' style='color:#F5B639'></i><i class='fa fa-star fa-2x' style='color:#F5B639'></i>" +
                     " <i class='fa fa-star fa-2x' style='color:#F5B639'></i><i class='fa fa-star fa-2x' style='color:#F5B639'></i><i class='fa fa-star fa-2x' style='color:#F5B639'></i><i class='fa fa-star fa-2x'  style='color:#F5B639'></i><i class='fa fa-star-half-empty fa-2x' style='color:#F5B639'></i>";
                }
                else if (Porcentaje(myReader.GetString(3), myReader.GetString(1)) == 100)
                {
                    Label12.Text = "   <i class='fa fa-star fa-2x' style='color:#F5B639'></i><i class='fa fa-star fa-2x' style='color:#F5B639'></i><i class='fa fa-star fa-2x' style='color:#F5B639'></i> <i class='fa fa-star fa-2x' style='color:#F5B639'></i><i class='fa fa-star fa-2x' style='color:#F5B639'></i>" +
                      " <i class='fa fa-star fa-2x' style='color:#F5B639'></i><i class='fa fa-star fa-2x' style='color:#F5B639'></i><i class='fa fa-star fa-2x' style='color:#F5B639'></i><i class='fa fa-star fa-2x' style='color:#F5B639'></i><i class='fa fa-star fa-2x' style='color:#F5B639'></i>";
                }
            }
        }
        catch (Exception d)
        {
            LabelMensaje.Text = d.Message;
        }
    }

    public float Porcentaje(string Ciclo, string tipo)
    {
        float estado = 0;
        try
        {
            SqlConnection conexi = new SqlConnection(strConnString);
            conexi.Open();
            SqlParameter contar;
            SqlCommand consulta = new SqlCommand("PORCENTAJE", conexi);
            consulta.CommandType = CommandType.StoredProcedure;

            consulta.Parameters.Add("@Ciclo", SqlDbType.NVarChar, 10);
            consulta.Parameters["@Ciclo"].Value = Ciclo;

            consulta.Parameters.Add("@Tipo", SqlDbType.NVarChar, 10);
            consulta.Parameters["@Tipo"].Value = tipo;


            contar = new SqlParameter("RETURN_VALUE", SqlDbType.Float);
            contar.Direction = ParameterDirection.ReturnValue;
            consulta.Parameters.Add(contar);
            consulta.ExecuteNonQuery();
            conexi.Close();
            float valor = Convert.ToInt32(contar.Value);
            estado = valor;
        }
        catch (Exception M)
        {
            LabelMensaje.Text = "Porcentaje " + M.Message;
        }
        return estado;
    }

    public static string GetImage(int value)
    {
        string img = "";
        if (value == 1)
        {
            img = " <i class='fa fa-check fa-3x' style='color:green'></i>";
        }
        else if (value == 0)
        {
            img = " <i class='fa fa-close fa-3x' style='color:red'></i>";
        }
        return img;
    }
    public void Grid()
    {
        SqlConnection conn1 = new SqlConnection(strConnString);
        string query = "";
        query = "SELECT [id],[Fecha_Carga],[Folio_Error],[Cve_Docto],[NSS],[Registro_Pat],[Fecha_Inicio],[TR],CONVERT(FLOAT,[CS])[CS],[Dias_Sub],[Porc_Inc],[Fecha_Termino],[Deleg_Orgn],[UMF],[Codigo_Error]," +
                   "[Codigo_Error2],[Codigo_Error3],[Codigo_Error4],[Codigo_Error5],[Nombre_Asegurado],[CURP],[Folio_Docto],[Cto_Pag],[Tipo_Mto_Aju],[Fec_Extraccion],[Tipo_SCAC],[Ciclo],[status] FROM [Afiliacion].[dbo].[UPD_SCAC-09] WHERE [Tipo_SCAC]='" + Label5.Text.Trim() + "' AND [Ciclo]='" + Label7.Text.Trim() + "'";

        SqlCommand cmd = new SqlCommand(query, conn1);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        int envio = 0;
        SqlConnection conn = new SqlConnection(strConnString);
        SqlCommand command = new SqlCommand("SELECT [id],[tipo],[fecha],[Ciclo],[Fecha_Carga],[Envio_Cl],[Envio_ST],[Envio_P],[No_Regis] FROM [Afiliacion].[dbo].[Crtl_SCAC] WHERE [Ciclo]='" + Label7.Text.Trim() + "' AND [tipo]= '" + Label5.Text.Trim() + "'", conn);
        conn.Open();
        SqlDataReader reader = command.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                envio = reader.GetInt32(7);
            }
        }
        if (envio == 1)
        {
            GridView1.Visible = false;
        }
        else
        {
            GridView1.Visible = true;
        }

        GridView1.DataSource = dt;
        GridView1.DataBind();

        conn1.Close();

    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        this.GridView1.DataBind();
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = GridView1.SelectedRow;
        int id = Convert.ToInt32(GridView1.DataKeys[row.RowIndex].Value);
        Response.Cookies["ID_SCAC09"].Value = Convert.ToString(id);
        Response.Redirect("formuSCAC.aspx");
    }
    protected void Cancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("Coord_Del_Sal_Trab.aspx");
    }
}