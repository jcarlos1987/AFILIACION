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

public partial class Casuistica_Val_Envi : System.Web.UI.Page
{
    String strConnString = ConfigurationManager.ConnectionStrings["AfiliacionConnectionString"].ConnectionString;
    string type = "";
    string ciclo = "";
    DateTime fecha;
    DateTime fechaC;
    int reg;
    protected void Page_Load(object sender, EventArgs e)
    {
        Consulta();
    }

    public void Consulta()
    {        
        SqlConnection conn = new SqlConnection(strConnString);
        try 
        {
            conn.Open();
            SqlDataReader myReader = null;
            SqlCommand Comando = new SqlCommand("SELECT [id],[tipo],[fecha],[Ciclo],[Fecha_Carga],[Envio_Cl],[Envio_ST],[Envio_P],[No_Regis] FROM [Afiliacion].[dbo].[Crtl_SCAC] WHERE [id]=" + Request.QueryString["id"] + "", conn);
            myReader = Comando.ExecuteReader();
            while (myReader.Read())
            {
                type = myReader.GetString(1);
                fecha = myReader.GetDateTime(2);
                ciclo = myReader.GetString(3);
                fechaC = myReader.GetDateTime(4);
                reg = myReader.GetInt32(8);
            }            
        }
        catch(Exception d)
        {
            Label2.Text = d.Message;
        }
        conn.Close();

        SqlConnection conn1 = new SqlConnection(strConnString);
        string query = "";
        Label2.Text = type + " del Ciclo " + ciclo;
        if (type.Trim() == "SCAC-10")
        {
            query = "SELECT [id],[Fecha_Carga],[Folio_Error],[Cve_Docto],[NSS],[Registro_Pat],[Fecha_Inicio],[TR],CONVERT(FLOAT,[CS])[CS],[Dias_Sub],[Folio_Docto],[Porc_Inc],[Fecha_Termino],[Deleg_Orgn],[UMF],[Codigo_Error],[Codigo_Error2]" +
                    ",[Codigo_Error3],[Codigo_Error4],[Codigo_Error5],[Nombre_Asegurado],[CURP],[Cto_Pag],[Tipo_Mto_Aju],[Fecha_Extrac],[Tipo],[Ciclo],[status] FROM [Afiliacion].[dbo].[SCAC-10] WHERE [Tipo]='" + type + "' AND [Ciclo]='" + ciclo + "'";
        }
        else if (type.Trim() == "SCAC-09")
        {
            query = "SELECT [id],[Fecha_Carga],[Folio_Error],[Cve_Docto],[NSS],[Registro_Pat],[Fecha_Inicio],[TR],CONVERT(FLOAT,[CS])[CS],[Dias_Sub],[Porc_Inc],[Fecha_Termino],[Deleg_Orgn],[UMF],[Codigo_Error]," +
                    "[Codigo_Error2],[Codigo_Error3],[Codigo_Error4],[Codigo_Error5],[Nombre_Asegurado],[CURP],[Folio_Docto],[Cto_Pag],[Tipo_Mto_Aju],[Fec_Extraccion],[Tipo_SCAC],[Ciclo],[status] FROM [Afiliacion].[dbo].[SCAC-09] WHERE [Tipo_SCAC]='" + type + "' AND [Ciclo]='" + ciclo + "'";
        }
        SqlCommand cmd = new SqlCommand(query, conn1);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        if (type.Trim() == "SCAC-10")
        {
            GridView1.Visible = true;
            GridView2.Visible = false;
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        else if (type.Trim() == "SCAC-09")
        {
            GridView2.Visible = true;
            GridView1.Visible = false;
            GridView2.DataSource = dt;
            GridView2.DataBind();
        }       
        conn1.Close();
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        this.GridView1.DataBind();
    }

    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView2.PageIndex = e.NewPageIndex;
        this.GridView2.DataBind();
    }
    protected void Enviar_Click(object sender, EventArgs e)
    {
        using (SqlConnection conn = new SqlConnection(strConnString))
        {
            String sentencia = null;
            if (type.Trim() == "SCAC-10")
            {
                sentencia = "INSERT INTO [Afiliacion].[dbo].[BandeDptoPrsonal] ([tipo],[fecha],[Ciclo],[Fecha_Carga],[No_Regis],[mensaje],[leer],[Fech_Envio])" +
                                                                     " VALUES  (@tipo, @fecha, @Ciclo, @Fecha_Carga, @No_Regis, @mensaje, @leer, @Fech_Envio)";
            }
            else if (type.Trim() == "SCAC-09")
            {
                sentencia = "INSERT INTO [Afiliacion].[dbo].[BandeSalTrab] ([tipo],[fecha],[Ciclo],[Fecha_Carga],[No_Regis],[mensaje],[leer],[Fech_Envio])" +
                                                                     " VALUES  (@tipo, @fecha, @Ciclo, @Fecha_Carga, @No_Regis, @mensaje, @leer, @Fech_Envio)";
            }
            SqlCommand comando = new SqlCommand(sentencia, conn);
            int resultado;
            try
            {
                conn.Open();

                comando.Parameters.Add(new SqlParameter("@tipo", SqlDbType.NChar, 10));
                comando.Parameters["@tipo"].Value = type;

                comando.Parameters.Add(new SqlParameter("@fecha", SqlDbType.Date));
                comando.Parameters["@fecha"].Value = fecha;

                comando.Parameters.Add(new SqlParameter("@Ciclo", SqlDbType.NChar, 10));
                comando.Parameters["@Ciclo"].Value = ciclo;

                comando.Parameters.Add(new SqlParameter("@Fecha_Carga", SqlDbType.DateTime));
                comando.Parameters["@Fecha_Carga"].Value = fechaC;

                comando.Parameters.Add(new SqlParameter("@No_Regis", SqlDbType.Int));
                comando.Parameters["@No_Regis"].Value = reg;

                comando.Parameters.Add(new SqlParameter("@mensaje", SqlDbType.NVarChar, 255));
                comando.Parameters["@mensaje"].Value = msj.Text;

                comando.Parameters.Add(new SqlParameter("@leer", SqlDbType.Int));
                comando.Parameters["@leer"].Value = 0;

                comando.Parameters.Add(new SqlParameter("@Fech_Envio", SqlDbType.DateTime));
                comando.Parameters["@Fech_Envio"].Value = String.Format("{0:yyyy/M/dd HH:mm:ss}", DateTime.Now);

                resultado = comando.ExecuteNonQuery();
                if(resultado > 0)
                {
                    using (SqlConnection conn1 = new SqlConnection(strConnString))
                    {                        
                        try
                        {
                            conn1.Open();
                            String sen = null;
                            int resul;
                            if (type.Trim() == "SCAC-10")
                            {
                                sen = "UPDATE [Afiliacion].[dbo].[Crtl_SCAC] SET [Envio_Cl] = @ENVIO, [FechEnt_Cl] = @FECHAENVIO, [FechEnt_P] = @FECHA WHERE [id]=" + Request.QueryString["id"] + "";
                            }
                            else if (type.Trim() == "SCAC-09")
                            {
                                sen = "UPDATE [Afiliacion].[dbo].[Crtl_SCAC] SET [Envio_Cl] = @ENVIO, [FechEnt_Cl] = @FECHAENVIO, [FechEnt_ST] = @FECHA WHERE [id]=" + Request.QueryString["id"] + "";
                            }
                            SqlCommand cmd = new SqlCommand(sen, conn1);
                            cmd.Parameters.Add(new SqlParameter("@ENVIO", SqlDbType.Int));
                            cmd.Parameters["@ENVIO"].Value = 1;

                            cmd.Parameters.Add(new SqlParameter("@FECHAENVIO", SqlDbType.DateTime));
                            cmd.Parameters["@FECHAENVIO"].Value = String.Format("{0:yyyy/M/dd HH:mm:ss}", DateTime.Now);

                            cmd.Parameters.Add(new SqlParameter("@FECHA", SqlDbType.DateTime));
                            cmd.Parameters["@FECHA"].Value = String.Format("{0:yyyy/M/dd HH:mm:ss}", DateTime.Now);

                            resul = cmd.ExecuteNonQuery();
                            if(resul > 0)
                            {
                                Label3.Text = "<div class='alert alert-success alert-dismissable'>"+
                                              "<button type='button' class='close' data-dismiss='alert' aria-hidden='true'>×</button>"+
                                              "La información de "+ type +" del ciclo "+ ciclo +" se envio correctamente. "+
                                              "</div>";
                                Response.AppendHeader("Refresh", 3 + "; URL=EnviarClasEmp.aspx");
                               // Response.Redirect("Modificar_Registros.aspx");
                            }
                        }
                        catch (Exception Msj)
                        {
                            Label2.Text= Msj.Message + ". Actualizar";
                        }
                    }
                }
                conn.Close();
            }
            catch (Exception M)
            {
                Label2.Text = M.Message + ". Insertar";
            }
        }
    }
    protected void Cancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("EnviarClasEmp.aspx");
    }
}