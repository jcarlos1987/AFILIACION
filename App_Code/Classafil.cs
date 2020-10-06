using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;
using System.Configuration;

/// <summary>
/// Summary description for Classafil
/// </summary>
public class Classafil
{
    public Classafil()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static int RegAfil(string ciclo, string fechaCiclo, float num_reg)
    {
        int num = 0;
        using (SqlConnection cn = new SqlConnection(Conexion.contring))
        {
            string sql = @"INSERT INTO [Afil-67].[dbo].[RegistroAfil] ([ciclo],[fechaCiclo],[fechaCarga],[numRegistros]) VALUES 
           (@ciclo, @fechaCiclo, @fechaCarga, @numRegistros)";
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@ciclo", ciclo.Replace(".","").Replace(" ",""));
            cmd.Parameters.AddWithValue("@fechaCiclo", String.Format("{0:dd/MM/yyyy}", fechaCiclo));
            cmd.Parameters.AddWithValue("@fechaCarga", String.Format("{0:dd/MM/yyyy}", DateTime.Now));
            cmd.Parameters.AddWithValue("@numRegistros", num_reg);
            cn.Open();
            num = cmd.ExecuteNonQuery();
            cn.Close();
        }
        return num;
    }

    public static bool existeTabla(string ciclo, string fechaCiclo, float num_reg)
    {
        string sCmd = @"SELECT COUNT([id]) FROM [Afil-67].[dbo].[RegistroAfil] WHERE [ciclo] = @ciclo AND [fechaCiclo]= @fechaCiclo AND [numRegistros] = @numRegistros";
        try
        {
            using (SqlConnection con = new SqlConnection(Conexion.contring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sCmd, con);
                cmd.Parameters.AddWithValue("@ciclo", ciclo);
                cmd.Parameters.AddWithValue("@fechaCiclo", fechaCiclo);
                cmd.Parameters.AddWithValue("@numRegistros", num_reg);
                int n = (int)cmd.ExecuteScalar();
                con.Close();
                return n > 0;
            }
        }
        catch
        {
            return false;
        }
    }

    /*public static int ProceAlma(string Ciclo, string Fecha)
    {
        int estado = 0;
        try
        {
            SqlConnection conexi = new SqlConnection(Conexion.contring);
            conexi.Open();
            SqlParameter contar;
            SqlCommand consulta = new SqlCommand("RENAME_TABLE", conexi);
            consulta.CommandType =  CommandType.StoredProcedure;

            consulta.Parameters.Add("@CICLO", SqlDbType.NVarChar, 10);
            consulta.Parameters["@CICLO"].Value = Ciclo;

            consulta.Parameters.Add("@FECHA", SqlDbType.NVarChar, 10);
            consulta.Parameters["@FECHA"].Value = Fecha;

            contar = new SqlParameter("RETURN_VALUE", SqlDbType.Float);
            contar.Direction = ParameterDirection.ReturnValue;
            consulta.Parameters.Add(contar);
            consulta.ExecuteNonQuery();
            conexi.Close();
            int valor = Convert.ToInt32(contar.Value);
        }
        catch (Exception M)
        {
            estado= Convert.ToInt16(M.Message);
        }
        return estado;
    }*/

    public static int CreateTable(string Ciclo, string Fecha)
    {
        int estado = 0;
        try
        {
            SqlConnection conexi = new SqlConnection(Conexion.contring);
            conexi.Open();
            SqlParameter contar;
            SqlCommand consulta = new SqlCommand("CREATE_TABLAS", conexi);
            consulta.CommandType = CommandType.StoredProcedure;

            consulta.Parameters.Add("@CICLO", SqlDbType.NVarChar, 10);
            consulta.Parameters["@CICLO"].Value = Ciclo;

            consulta.Parameters.Add("@FECHA", SqlDbType.NVarChar, 10);
            consulta.Parameters["@FECHA"].Value = Fecha;

            contar = new SqlParameter("RETURN_VALUE", SqlDbType.Float);
            contar.Direction = ParameterDirection.ReturnValue;
            consulta.Parameters.Add(contar);
            consulta.ExecuteNonQuery();
            conexi.Close();
            int valor = Convert.ToInt32(contar.Value);
        }
        catch (Exception M)
        {
            estado = Convert.ToInt16(M.Message);
        }
        return estado;
    }
}