using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ionic.Zip;
using System.Configuration;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using ClosedXML.Excel;

public partial class Info_Afil_25 : System.Web.UI.Page
{
    string subdel = "";
    string Delegacion = "";
    string ciclo = "";
    string guia = "";
    string fecha = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Grid();
    }

    public Tuple<string, string> LeerArchivo(string ruta)
    {
        //string newruta = ruta; //Server.MapPath("~") + "/temp/afil25/ 24_10_2019AFIL25/AFIL25.C001";
        System.IO.StreamReader fd = System.IO.File.OpenText(ruta);
        System.IO.StreamWriter ArchivoSalida2 = new System.IO.StreamWriter(ruta + DateTime.Now.Year + ".txt");
        string filas = "";
        filas = fd.ReadLine();
        while (fd.Peek() > -1)
        {
            if (filas.Contains("SUBDELG."))
            {
                subdel = filas.Substring((filas.LastIndexOf("SUBDELG.") + 12), 2);
            }
            if (filas.Contains("DELEGACION  "))
            {
                Delegacion = filas.Substring((filas.LastIndexOf("DELEGACION  ") + 12), 2);
            }
            if (filas.Contains("CICLO ACTUALIZACION NUM."))
            {
                ciclo = filas.Substring((filas.LastIndexOf("CICLO ACTUALIZACION NUM.") + 24), 4);
            }
            if (filas.Contains("  GUIA "))
            {
                guia = filas.Substring((filas.LastIndexOf("  GUIA ") + 7), 5);
            }
            if (filas.Contains("MOVIMIENTOS OPERADOS DE ASEGURADOS, PATRONES"))
            {
                fecha = filas.Substring((filas.LastIndexOf("MOVIMIENTOS OPERADOS DE ASEGURADOS, PATRONES") + 66), 10);
            }
            filas = fd.ReadLine();
            if ((filas.Length == 132))
            {
                if (!filas.Contains("DELEGACION"))
                {
                    if (!filas.Contains("NO.SEGURO SOCIAL"))
                    {
                        if (!filas.Contains("NO.SEG.SOC.CORR"))
                        {
                            filas = filas.Insert(0, Delegacion + ";");
                            filas = filas.Insert(3, subdel + ";");
                            filas = filas.Insert(6, ciclo.Trim().PadLeft(4, '0') + ";");
                            filas = filas.Insert(11, guia + ";");
                            filas = filas.Insert(34, ";");
                            filas = filas.Insert(64, ";");
                            filas = filas.Insert(68, ";");
                            filas = filas.Insert(73, ";");
                            filas = filas.Insert(78, ";");
                            filas = filas.Insert(83, ";");
                            filas = filas.Insert(99, ";");
                            filas = filas.Insert(102, ";");
                            filas = filas.Insert(114, ";");
                            filas = filas.Insert(120, ";");
                            filas = filas.Insert(125, ";");
                            filas = filas.Insert(133, ";");
                            filas = filas.Insert(141, ";");
                            filas = filas.Insert(146, ";");
                            filas = filas.Insert(150, ";");
                            filas = filas.Insert(162, ";");
                            ArchivoSalida2.WriteLine(filas);
                        }
                    }
                }
            }
        }
        ArchivoSalida2.Close();
        fd.Close();
        return Tuple.Create(ciclo, fecha);
    }

    public string ExtracZip(string ruta)
    {
        using (ZipFile zip = ZipFile.Read(ruta))
        {
            zip.StatusMessageTextWriter = System.Console.Out;
            zip.ExtractAll(ruta.Replace(".zip", ""));
            zip.Dispose();
        }
        string[] frale = Directory.GetFiles(ruta.Replace(".zip", ""));
        for (Int32 i = 0; i <= (frale.Length - 1); i++)
        {
            ruta = frale.GetValue(i).ToString();
        }
        return ruta;
    }

    public bool existeTabla(string nombreTabla)
    {
        string sCmd = "SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES " + "WHERE TABLE_TYPE = 'BASE TABLE' " + "AND TABLE_NAME = @nombreTabla";
        try
        {
            using (SqlConnection con = new SqlConnection(Conexion.constringAfil25))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sCmd, con);
                cmd.Parameters.AddWithValue("@nombreTabla", nombreTabla);
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

    public string createTabla(string nombre)
    {
        string n = "NO";
        try
        {
            using (SqlConnection con = new SqlConnection(Conexion.constringAfil25))
            {
                con.Open();
                string sql = @" CREATE TABLE [dbo].[" + nombre + "] ([id][int] IDENTITY(1, 1) NOT NULL, [DEL] [nvarchar](2) NULL, ";
                sql += " [SUBDEL] [nvarchar](2) NULL, [CICLO_ACTUALIZACION_NUM] [float] NULL, [GUIA] ";
                sql += " [nvarchar](5) NULL,	[NSS_CORR]  [nvarchar](15) NULL, [NOM_DEL_ASEGU_NOM_CORREC] [nvarchar](255) NULL, ";
                sql += " [SEXO] [nvarchar](1) NULL,[MES_NAC] [nvarchar](2) NULL,	[LUG_NAC] [nvarchar](2) NULL, ";
                sql += " [UMF] [nvarchar](3) NULL,[REGPAT] [nvarchar](255) NULL,	[TIPO_TRAB] [nvarchar](5) NULL,	[SALARIO_BASE] ";
                sql += " [float] NULL,[SEM_JOR] [nvarchar](2) NULL,[TIP_SAL] [nvarchar](5) NULL,	[ARG_TP] [nvarchar](2) NULL, ";
                sql += " [SUS_RE_SERV] [nvarchar](5) NULL,[ID_HUEL] [nvarchar](5) NULL,[ID_EXT] [nvarchar](5) NULL,[FECH_MOV] ";
                sql += " [datetime] NULL,[TIPO_MOV] [nvarchar](2) NULL,[FECH_CARGA] [datetime] NULL,	[IP_CARGA] [nchar](50) NULL, ";
                sql += " [HORA_CARGA] [nvarchar](50) NULL )";
                SqlCommand cmd = new SqlCommand(sql, con);
                n = Convert.ToString((int)cmd.ExecuteScalar());
                //Response.Write(n);
                con.Close();
                return n;
            }
        }
        catch (Exception E)
        {
            return n + " " + E.Message;
        }
    }

    public static string GetIP4Address()
    {
        string IP4Address = String.Empty;

        foreach (IPAddress IPA in Dns.GetHostAddresses(HttpContext.Current.Request.UserHostAddress))
        {
            if (IPA.AddressFamily.ToString() == "InterNetwork")
            {
                IP4Address = IPA.ToString();
                break;
            }
        }

        if (IP4Address != String.Empty)
        {
            return IP4Address;
        }

        foreach (IPAddress IPA in Dns.GetHostAddresses(Dns.GetHostName()))
        {
            if (IPA.AddressFamily.ToString() == "InterNetwork")
            {
                IP4Address = IPA.ToString();
                break;
            }
        }
        return IP4Address;
    }

    public string Carga(string tablaOrigen, string tablaDestino)
    {
        //DateTime rec = Convert.ToDateTime(DateTime.Now + " " + DateTime.Now.ToString("hh:mm:ss tt"));
        string ip = GetIP4Address();
        string query = "INSERT INTO[Afil-25].[dbo].[" + tablaDestino + "] ([DEL] ,[SUBDEL]  ,[CICLO_ACTUALIZACION_NUM] ,[GUIA]  ,[NSS_CORR]";
        query += " ,[NOM_DEL_ASEGU_NOM_CORREC],[SEXO] ,[MES_NAC] ,[LUG_NAC],[UMF] ,[REGPAT],[TIPO_TRAB],[SALARIO_BASE],[SEM_JOR],[TIP_SAL]";
        query += " ,[ARG_TP],[SUS_RE_SERV] ,[ID_HUEL] ,[ID_EXT],[FECH_MOV] ,[TIPO_MOV],[FECH_CARGA] ,[IP_CARGA] ,[HORA_CARGA]) ";
        query += " SELECT[del],[sub],SUBSTRING([ciclo],2,3) [ciclo],[guia],[nss],[nombre],[sexo],[mes_nac],[lug_nac],[umf],[reg_patro],[tipo_pa] ";
        query += " ,CONVERT(FLOAT, [salario_B]) [salario_B],[sem_jor],[tip_sal],[arg_tp],[serv],[id_huelga],[id_ext],CASE WHEN [fech_movi] = '00/00/0000' THEN '01/01/1900' WHEN SUBSTRING([fech_movi],4,2)>12 THEN CONVERT(DATETIME,SUBSTRING([fech_movi],4,2) +'/'+ SUBSTRING([fech_movi],1,2)+'/'+ SUBSTRING([fech_movi],7,4)) WHEN [fech_movi] <> '00/00/0000' THEN CONVERT(DATETIME, [fech_movi]) END[fech_movi],[tipo_mov], ";
        query += " '" + String.Format("{0: dd/MM/yyyy }", DateTime.Now) + "','" + ip + "','" + String.Format("{0: HH:mm:ss}", DateTime.Now) + "' ";
        query += " FROM [Afil-25].[dbo].[" + tablaOrigen + "] ";
        //Response.Write(query);
        try
        {
            using (SqlConnection con = new SqlConnection(Conexion.constringAfil25))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                int n = (int)cmd.ExecuteNonQuery();
                con.Close();
                return "Se cargo Correctamente el archivo. Total de Registros " + Convert.ToString(n);
            }
        }
        catch(Exception E)
        {
            return E.Message;
        }
    }

    public string CargarServidor(string ruta, string nombreTabla)
    {
        string nombre = nombreTabla;
        string estado = "";
        try
        {
            SqlConnection nwindConn = new SqlConnection(Conexion.constringAfil25);
            SqlCommand catCMD = nwindConn.CreateCommand();
            string textConmand = ("BULK INSERT [AFIL25_tmp] ");
            textConmand = (textConmand + ("FROM \'" + (ruta + "\' ")));
            textConmand += "WITH( ";
            textConmand += "FIELDTERMINATOR=\';\', ";
            textConmand += "ROWTERMINATOR=\'\\n\', ";
            textConmand += "FIRE_TRIGGERS ";
            textConmand += ")";
            catCMD.CommandText = textConmand;
            nwindConn.Open();
            if ((catCMD.ExecuteNonQuery() <= 0))
            {
                estado = "Problemas con la actualizacion";
                nwindConn.Close();
            }
            else
            {
                estado = "Afil-25 Cargado Correctamente.";
            }
            nwindConn.Close();
        }
        catch (Exception ex)
        {
            estado = ex.Message;
        }
        return estado;
    }

    public string truncateTabla()
    {
        try
        {
            using (SqlConnection con = new SqlConnection(Conexion.constringAfil25))
            {
                con.Open();
                string sql = "TRUNCATE TABLE [Afil-25].[dbo].[AFIL25_tmp]";
                SqlCommand cmd = new SqlCommand(sql, con);
                int n = (int)cmd.ExecuteNonQuery();
                con.Close();
               // return n > 0;
                return  Convert.ToString(n);
            }
        }
        catch(Exception E)
        {
            return E.Message;
        }
    }

    public int RegAfil(string fechaCiclo, string fecha_carga, string anio, string tabla)
    {
        int num = 0;
        using (SqlConnection cn = new SqlConnection(Conexion.constringAfil25))
        {
            string sql = @"INSERT INTO [Afil-25].[dbo].[RegistroAfil] ([ciclo],[fechaCiclo],[fechaCarga],[numRegistros],[guia] ";
            sql += " ,[anio]) SELECT [CICLO_ACTUALIZACION_NUM],'" + String.Format("{0: dd/MM/yyyy}", Convert.ToDateTime(fechaCiclo)) + "' FEC_CICLO,'" + String.Format("{0: dd/MM/yyyy}", Convert.ToDateTime(fecha_carga)) + "' FEC_CARGA,COUNT([CICLO_ACTUALIZACION_NUM]) REG,";
            sql += " [GUIA], " + anio + " ANIO FROM [Afil-25].[dbo].[" + tabla + "] GROUP BY [GUIA], [CICLO_ACTUALIZACION_NUM]";
            //Response.Write(sql);
            SqlCommand cmd = new SqlCommand(sql, cn);
            cn.Open();
            num = cmd.ExecuteNonQuery();
            cn.Close();
        }
        return num;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (!FileUpload1.FileName.Replace(" ", "").Equals(""))
        {
            string extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
            string ruta = "";
            if (extension == ".zip" || extension.ToUpper() == ".ZIP")
            {
                string fecha = String.Format("{0: dd/MM/yyyy}", DateTime.Now);
                ruta = Server.MapPath("~") + "/temp/afil25/" + fecha.Replace("/", "_") + FileUpload1.FileName;
                if (!System.IO.File.Exists(ruta))
                {
                    FileUpload1.SaveAs(ruta);
                    string rutaN= ExtracZip(ruta);
                    Tuple<string, string> result = LeerArchivo(rutaN);
                    string tabla = "afil25_" + result.Item1.Trim().PadLeft(3, '0') + "_" + result.Item2.Substring(6, 4);                    
                    if (!existeTabla(tabla))
                    {
                        truncateTabla();
                        CargarServidor(rutaN + result.Item2.Substring(6, 4) + ".txt", tabla);
                        createTabla(tabla);
                        LabelMensaje.Visible = true;
                        LabelMensaje.Text = @"<div class='alert-success alert-dismissable'><button type='button' class='close' 
                                   data-dismiss='alert' aria-hidden='true'>×</button> " + Carga("AFIL25_tmp", tabla) + ". </div>";
                        RegAfil(result.Item2, String.Format("{0: dd/MM/yyyy}", DateTime.Now), result.Item2.Substring(6, 4), tabla);
                        Grid();
                    }
                    else
                    {
                        LabelMensaje.Visible = true;
                        LabelMensaje.Text = @"<div class='alert alert-danger alert-dismissable'><button type='button' class='close' 
                                   data-dismiss='alert' aria-hidden='true'>×</button> Ya existe Informacion con ese ciclo. Intenta de nuevo. </div>";
                    }
                }
                else
                {
                    LabelMensaje.Visible = true;
                    LabelMensaje.Text = @"<div class='alert alert-danger alert-dismissable'><button type='button' class='close' 
                                   data-dismiss='alert' aria-hidden='true'>×</button> El archivo con nombre " + FileUpload1.FileName + " ya existe. Intenta de nuevo. </div>";
                }
            }
            else
            {
                LabelMensaje.Visible = true;
                LabelMensaje.Text = @"<div class='alert alert-danger alert-dismissable'><button type='button' class='close' 
                                   data-dismiss='alert' aria-hidden='true'>×</button> Seleccione un archivo .zip </div>";
            }
        }
        else
        {
            LabelMensaje.Visible = true;
            LabelMensaje.Text = @"<div class='alert alert-danger alert-dismissable'><button type='button' class='close' 
                                   data-dismiss='alert' aria-hidden='true'>×</button> Selecciona el archivo por favor.</div>";
        }
    }
    public void Grid()
    {
        SqlConnection conn1 = new SqlConnection(Conexion.constringAfil25);
        string query = "";
        query = @"SELECT [ciclo],[fechaCiclo],[fechaCarga],SUM([numRegistros]) NumRegistros
      ,COUNT([guia]) NumGuias,[anio] FROM[Afil-25].[dbo].[RegistroAfil] GROUP BY[ciclo],[fechaCiclo],[fechaCarga],[anio] ORDER BY [ciclo] DESC";
        SqlCommand cmd = new SqlCommand(query, conn1);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();
        conn1.Close();
    }



    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        Grid();
    }
}