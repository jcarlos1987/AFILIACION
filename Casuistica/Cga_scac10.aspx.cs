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
public partial class Casuistica_Cga_scac10 : System.Web.UI.Page
{
    string ruta = null;
    string Nom_SCAC = "";
    string Ciclo_SCAC = "";
    string fecha_scac = "";
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
            LabelMensaje.Text = Mens.Message + " Bandeja";
        }
        return num;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (FileUpload1.FileName.Replace(" ", "").Equals(""))
        {
            LabelMensaje.Text = "<div class='alert alert-danger alert-dismissable'><button type='button' class='close' data-dismiss='alert' aria-hidden='true'>×</button> Selecciona un Archivo por Favor. </div>";
        }
        else
        {            
            string fecha = String.Format("{0: dd/MM/yyyy}", DateTime.Now);
            ruta = Server.MapPath("~") + "/temp/" + fecha.Replace("/", "_") + FileUpload1.FileName;
            FileUpload1.SaveAs(ruta);
            System.IO.StreamReader fd = System.IO.File.OpenText(ruta);
            System.IO.StreamWriter ArchivoSalida = new System.IO.StreamWriter(ruta + ".txt");
            string fila = "";
            Int32 indice = 1;
            fila = fd.ReadLine();
            while (fd.Peek() > -1)
            {
                indice += 1;
                fila = fd.ReadLine();
                if (indice == 4)
                {
                    fecha_scac = fila.Substring(102, 10); 
                    Nom_SCAC = fila.Substring(238, 7);
                    Ciclo_SCAC = fila.Substring(294, 6);
                }
                if (fila.Split('/').Length >= 5)
                {
                    fila = fila.Replace(@"""", "");
                    fila = fila.Replace(",", ";");
                    ArchivoSalida.WriteLine(fila.Replace("�", "").Replace("0//", ""));
                }
            }
            ArchivoSalida.Close();
            fd.Close();
            if(Nom_SCAC == DropDownList1.SelectedItem.ToString().Trim())
            {
                if (Validar(Ciclo_SCAC, Nom_SCAC) == 0)
                {
                    LabelMensaje.Text = "<div class='alert alert-info alert-dismissable'><button type='button' class='close' data-dismiss='alert' aria-hidden='true'>×</button> " + archivoFiltrado(ruta) + " </div>";
                }
                else
                {
                    LabelMensaje.Text = "<div class='alert alert-danger alert-dismissable'><button type='button' class='close' data-dismiss='alert' aria-hidden='true'>×</button> " + Nom_SCAC + " del Ciclo " + Ciclo_SCAC + " YA Existe.  </div>";
                }
            }
            else
            {
                LabelMensaje.Text = "<div class='alert alert-danger alert-dismissable'><button type='button' class='close' data-dismiss='alert' aria-hidden='true'>×</button> El archivo no es el correcto. Intente de nuevo por favor.</div>";
            }
        }
    }


    private string archivoFiltrado(string ruta)
    {
        string estado = "";
        try
        {            
            System.IO.StreamReader filtrado = System.IO.File.OpenText(ruta + ".txt");
            System.IO.StreamWriter ArchivoSalida_F = new System.IO.StreamWriter(ruta + "Final.txt");
            string fila_F = "";
            while (filtrado.Peek() > -1)
            {
                fila_F = filtrado.ReadLine();
                ArchivoSalida_F.WriteLine(fila_F.Replace("�", "").Replace("0//", "") + ";" + fecha_scac + ";" + Nom_SCAC + ";" + Ciclo_SCAC);
            }
            ArchivoSalida_F.Close();
            filtrado.Close();
            if (Vaciar() == 0)
            {
                estado =  subirAlServidor(ruta + "Final.txt", Nom_SCAC);
            }
            else
            {
                estado = "Problemas con la Tabla Temporal. Intente de Nuevo por Favor.";
            }
        }
        catch(Exception msj)
        {
            estado = "Archivo Filtrado " + msj.Message;
        }
        return estado;
    }
    private string subirAlServidor(string ruta, string tabla)
    {
        string estado = "";
        try
        {
            SqlConnection nwindConn = new SqlConnection(strConnString);
            SqlCommand catCMD = nwindConn.CreateCommand();
            string textConmand = ("BULK INSERT [Afiliacion].[dbo].["+tabla+"-TMP]");
                textConmand = (textConmand + ("FROM \'" + (ruta +  "\' ")));
                textConmand += "WITH( ";
                textConmand += "FIELDTERMINATOR=\';\', ";
                textConmand += "ROWTERMINATOR=\'\\n\', ";
                textConmand += "FIRE_TRIGGERS ";
                textConmand += ")";
                catCMD.CommandText = textConmand;           
            nwindConn.Open();

            if ((catCMD.ExecuteNonQuery() <= 0))
            {
                estado = "Problemas con la actualización. Intente de Nuevo por Favor.";
            }
            else
            {
                estado = SubirServidor(Ciclo_SCAC, fecha_scac, Nom_SCAC);
            }
        }
        catch(Exception m)
        {
            estado = "Carga BULK  " + m.Message;
        }
        return estado;
    }
    private string SubirServidor(string Ciclo, string fecha, string tipo)
    {
        string estado = "";
        try
        {
            SqlConnection conexi = new SqlConnection(strConnString);
            conexi.Open();
            SqlParameter contar;
            SqlCommand consulta = new SqlCommand("Carga_SCAC", conexi);
            consulta.CommandType = CommandType.StoredProcedure;
            consulta.Parameters.Add("@FechaC", SqlDbType.NVarChar,30);
            consulta.Parameters["@FechaC"].Value = String.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime.Now);
            consulta.Parameters.Add("@FechaE", SqlDbType.NVarChar,25);
            consulta.Parameters["@FechaE"].Value = fecha;
            consulta.Parameters.Add("@Ciclo", SqlDbType.NVarChar, 10);
            consulta.Parameters["@Ciclo"].Value = Ciclo;
            consulta.Parameters.Add("@Tipo", SqlDbType.NVarChar, 10);
            consulta.Parameters["@Tipo"].Value = tipo;

            contar = new SqlParameter("RETURN_VALUE", SqlDbType.Int);
            contar.Direction = ParameterDirection.ReturnValue;
            consulta.Parameters.Add(contar);
            consulta.ExecuteNonQuery();
            conexi.Close();
            Int32 valor = Convert.ToInt32(contar.Value);
            estado = "Se Cargo el "+ tipo +" del Ciclo " + Ciclo + "  con Fecha de Extracción del "+ fecha +", con un total de " + valor + " Registros.";
        }
        catch(Exception M)
        {
            estado = "Carga_SCAC " + M.Message ;
        }
        return estado;
    }


    private int Validar(string Ciclo, string tipo)
    {
        int estado = 0;
        try
        {
            SqlConnection conexi = new SqlConnection(strConnString);
            conexi.Open();
            SqlParameter contar;
            SqlCommand consulta = new SqlCommand("VALIDAR", conexi);
            consulta.CommandType = CommandType.StoredProcedure;
            consulta.Parameters.Add("@Tipo", SqlDbType.NVarChar, 10);
            consulta.Parameters["@Tipo"].Value = tipo;
            consulta.Parameters.Add("@Ciclo", SqlDbType.NVarChar, 10);
            consulta.Parameters["@Ciclo"].Value = Ciclo;
            

            contar = new SqlParameter("RETURN_VALUE", SqlDbType.Int);
            contar.Direction = ParameterDirection.ReturnValue;
            consulta.Parameters.Add(contar);
            consulta.ExecuteNonQuery();
            conexi.Close();
            Int32 valor = Convert.ToInt32(contar.Value);
            estado = valor;
        }
        catch (Exception M)
        {
            LabelMensaje.Text = "Carga_SCAC " + M.Message;
        }
        return estado;
    }

    private int Vaciar()
    {
        int estado = 0;
        try
        {
            SqlConnection conexi = new SqlConnection(strConnString);
            conexi.Open();
            SqlParameter contar;
            SqlCommand consulta = new SqlCommand("VACIAR_SCAC", conexi);
            consulta.CommandType = CommandType.StoredProcedure;            

            contar = new SqlParameter("RETURN_VALUE", SqlDbType.Int);
            contar.Direction = ParameterDirection.ReturnValue;
            consulta.Parameters.Add(contar);
            consulta.ExecuteNonQuery();
            conexi.Close();
            Int32 valor = Convert.ToInt32(contar.Value);
            estado = valor;
        }
        catch (Exception M)
        {
            LabelMensaje.Text = "VACIAR_SCAC " + M.Message;
        }
        return estado;
    }
}