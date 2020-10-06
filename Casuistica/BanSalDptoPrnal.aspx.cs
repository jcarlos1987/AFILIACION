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

public partial class Casuistica_BanSalDptoPrnal : System.Web.UI.Page
{
    String strConnString = ConfigurationManager.ConnectionStrings["AfiliacionConnectionString"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {

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

    public int Bandeja(string depto)
    {
        int num = 0;
        SqlConnection conn = new SqlConnection(strConnString);
        string query = "";
        try
        {
            conn.Open();
            query = "SELECT COUNT(*) FROM [Afiliacion].[dbo].[BandeDptoPrsonal] WHERE [leer] = 0 ";
            SqlCommand cmd = new SqlCommand(query, conn);
            num = Convert.ToInt32(cmd.ExecuteScalar());
            return num;
        }
        catch (Exception Mens)
        {
            Label1_msj.Text = Mens.Message + " Bandeja";
        }
        return num;
    }
}