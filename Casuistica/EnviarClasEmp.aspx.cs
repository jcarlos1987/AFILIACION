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

public partial class Casuistica_EnviarClasEmp : System.Web.UI.Page
{
    public string tipoScac;
    public string cicloScac;
    public String strConnString = ConfigurationManager.ConnectionStrings["AfiliacionConnectionString"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        Label1_msj.Visible = true;
        Label1_msj.Text = tipoScac;
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
        catch (Exception Mens)
        {
            Label1_msj.Text = Mens.Message + " Bandeja";
        }
        return num;
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
            Label1_msj.Text = "Porcentaje " + M.Message;
        }
        return estado;
    }

    public int Excel(string Ciclo, string tipo)
    {
        int envio = 0;
        SqlConnection conn = new SqlConnection(strConnString);
        SqlCommand command = new SqlCommand("SELECT [id],[tipo],[fecha],[Ciclo],[Fecha_Carga],[Envio_Cl],[Envio_ST],[Envio_P],[No_Regis] FROM [Afiliacion].[dbo].[Crtl_SCAC] WHERE [Ciclo]='" + Ciclo.Trim() + "' AND [tipo]= '" + tipo.Trim() + "'", conn);
        conn.Open();
        SqlDataReader reader = command.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                envio = reader.GetInt32(7);
            }
        }
        conn.Close();
        return envio;
    }

   
}