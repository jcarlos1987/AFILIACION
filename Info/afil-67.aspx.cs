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

public partial class Info_afil_67 : System.Web.UI.Page
{
    string fechaC = "";
    string PRO = "";
    string RegistroP = "";
    string sub = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Grid();
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        string ruta = "";
        int n = 0;
        if (FileUpload1.FileName.Replace(" ", "").Equals(""))
        {
            LabelMensaje.Visible = true;
            LabelMensaje.Text = @"<div class='alert alert-danger alert-dismissable'><button type='button' class='close' 
                                   data-dismiss='alert' aria-hidden='true'>×</button> Selecciona el archivo por favor.</div>";
        }
        else
        {
            string fecha = String.Format("{0: dd/MM/yyyy}", DateTime.Now);
            ruta = Server.MapPath("~") + "/temp/" + fecha.Replace("/", "_") + FileUpload1.FileName;
            if (System.IO.File.Exists(ruta))
            {
                LabelMensaje.Visible = true;
                LabelMensaje.Text = @"<div class='alert alert-danger alert-dismissable'><button type='button' class='close' 
                                   data-dismiss='alert' aria-hidden='true'>×</button> Afil-67 con ciclo  " + FileUpload1.FileName + " ya existe.</div>";
            }
            else
            {
                try
                {
                    FileUpload1.SaveAs(ruta);
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
                    string newruta = Server.MapPath("~") + "/temp/" + DateTime.Now.Year + System.IO.Path.GetExtension(ruta);
                    System.IO.File.Move(ruta, newruta);
                    System.IO.File.Delete(ruta);
                    System.IO.StreamReader fd = System.IO.File.OpenText(newruta);
                    System.IO.StreamWriter ArchivoSalida = new System.IO.StreamWriter(newruta + ".txt");
                    string fila = "";
                    fila = fd.ReadLine();
                    while (fd.Peek() > -1)
                    {
                        if (fila.Contains("REGISTRO PATRONAL"))
                        {
                            RegistroP = fila.Substring((fila.LastIndexOf("REGISTRO PATRONAL") + 18), 12).Replace(" ", "");
                        }
                        if (RegistroP == "")
                        {
                            RegistroP = "            ";
                        }
                        if (fila.Contains("RELACION DE ASEGURADOS POR MODALIDAD"))
                        {
                            fechaC = fila.Substring((fila.LastIndexOf("RELACION DE ASEGURADOS POR MODALIDAD") + 58), 10).Replace(" ", "");
                        }
                        if (fila.Contains("SUBDELEGACION"))
                        {
                            sub = fila.Substring((fila.LastIndexOf("SUBDELEGACION") + 14), 2).Replace(" ", "");
                        }
                        fila = fd.ReadLine();
                        if ((fila.Length == 130))
                        {
                            if (!fila.Contains("NUMERO DE"))
                            {
                                fila = fila.Insert(17, ";");
                                fila = fila.Insert(71, ";");
                                fila = fila.Insert(75, ";");
                                fila = fila.Insert(88, ";");
                                fila = fila.Insert(102, ";");
                                fila = fila.Insert(108, ";");
                                fila = fila.Insert(115, ";");
                                fila = fila.Insert(125, ";");
                                fila = fila.Insert(137, ";");
                                fila = fila.Insert(139, ";" + RegistroP.Substring(1, 11) + ";" + sub);
                                fila = fila.Insert(151, ";" + fechaC);
                                fila = fila.Replace(" ", "");
                                ArchivoSalida.WriteLine(fila);
                                n = n + 1;
                            }
                        }
                    }
                    ArchivoSalida.Close();
                    fd.Close();

                    //23/07/2018
                    string fechaCC = fechaC.Substring(6, 4) + "-" + fechaC.Substring(3, 2) + "-" + fechaC.Substring(0, 2);
                    if (Classafil.CreateTable(System.IO.Path.GetExtension(newruta).Replace(".", ""), String.Format("{0: dd/MM/yyyy}", fechaCC)) == 0)
                    {
                        string rutaRaleFinal = newruta + ".txt";
                        if (!Classafil.existeTabla(System.IO.Path.GetExtension(newruta).Replace(".", ""), String.Format("{0: dd/MM/yyyy}", fechaCC), n))
                        {
                            if (Classafil.RegAfil(System.IO.Path.GetExtension(newruta), String.Format("{0: dd/MM/yyyy}", fechaC), n) == 1)
                            {
                                /*Response.Write(newruta+"<br>");
                                Response.Write(rutaRaleFinal);
                                CargarServidor(rutaRaleFinal, System.IO.Path.GetExtension(newruta).Replace(".", ""), String.Format("{0: dd/MM/yyyy}", fechaCC));*/
                                LabelMensaje.Text = @"<div class='alert-success alert-dismissable'><button type='button' class='close' 
                                   data-dismiss='alert' aria-hidden='true'>×</button> " + CargarServidor(rutaRaleFinal, System.IO.Path.GetExtension(newruta).Replace(".", ""), String.Format("{0: dd/MM/yyyy}", fechaCC)) + " Ciclo Número " + System.IO.Path.GetExtension(newruta) + " Fecha del ciclo " + fechaC + " con un total de " + n + " registros.</div>";
                                Grid();
                                this.GridView1.DataBind();
                               /* System.IO.File.Delete(ruta + ".zip");
                                System.IO.File.Delete(newruta);
                                System.IO.File.Delete(rutaRaleFinal);*/
                            }
                        }
                        else
                        {
                            LabelMensaje.Text = @"<div class='alert alert-danger alert-dismissable'><button type='button' class='close' 
                                   data-dismiss='alert' aria-hidden='true'>×</button> Afil-67 con ciclo  " + System.IO.Path.GetExtension(newruta) + " ya existe. Intente con otro ciclo.</div>";
                            System.IO.File.Delete(ruta);
                            System.IO.File.Delete(newruta);
                            System.IO.File.Delete(rutaRaleFinal);
                        }
                    }
                    else
                    {
                        LabelMensaje.Text = @"<div class='alert-success alert-dismissable'><button type='button' class='close' 
                                   data-dismiss='alert' aria-hidden='true'>×</button> Ya existe la Tabla. Error Tabla </div>";
                    }
                }
                catch (Exception excep)
                {
                    LabelMensaje.Text = excep.Message;
                }
            }
        }
    }

    private string CargarServidor(string ruta, string ciclo, string fecha)
    {
        string nombre = "Afil67_" + ciclo + "_" + fecha.Replace('-', '_');
        string estado = "";
        try
        {
            SqlConnection nwindConn = new SqlConnection(Conexion.contring);
            SqlCommand catCMD = nwindConn.CreateCommand();
            string textConmand = ("BULK INSERT " + nombre + " ");
            textConmand = (textConmand + ("FROM \'" + (ruta + "\' ")));
            textConmand += "WITH( ";
            textConmand += "FIELDTERMINATOR=\';\', ";
            textConmand += "ROWTERMINATOR=\'\\n\', ";
            textConmand += "FIRE_TRIGGERS ";
            textConmand += ")";
            Response.Write(textConmand);
            catCMD.CommandText = textConmand;
            nwindConn.Open();
            if ((catCMD.ExecuteNonQuery() <= 0))
            {
                estado = "Problemas con la actualizacion";
                nwindConn.Close();
            }
            else
            {
                estado = "Afil-67 Cargado Correctamente.";
            }
            nwindConn.Close();
        }
        catch (Exception ex)
        {
            estado = ex.Message ;
        }
        return estado;
    }


    public void Grid()
    {
        SqlConnection conn1 = new SqlConnection(Conexion.contring);
        string query = "";
        query = "SELECT [ciclo],[fechaCiclo],[fechaCarga],[numRegistros] FROM [Afil-67].[dbo].[RegistroAfil]  ORDER BY [fechaCiclo] DESC";
        SqlCommand cmd = new SqlCommand(query, conn1);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();
        conn1.Close();
    }
}