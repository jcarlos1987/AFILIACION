using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using ClosedXML.Excel;
using System.Net;
using System.IO;
using System.ComponentModel;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

public partial class SegEspe_Reportes_Seguros_Especiales : System.Web.UI.Page
{
    String ConecAfil67 = ConfigurationManager.ConnectionStrings["Afil-67ConnectionString"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            cargaBase();
            string valueS = ConfigurationManager.AppSettings["DelValue"].ToString();
            string textS = ConfigurationManager.AppSettings["DelMostrar"].ToString();
            string[] value1S = valueS.Split(',');
            string[] text1S = textS.Split(',');

            //for (int i = 0; i < text1.Length; i++)
            //{
            for (int j = 0; j < text1S.Length; j++)
            {
                ListItem li1 = new ListItem(text1S[j], value1S[j]);
                DropListSubdel.Items.Add(li1);
            }
            //BASE();
        }
    }


    public void BASE()
    {
        // Construimos la cadena de conexión Ole Db,
        // para conectarnos con el libro de Excel.
        string connString = "Provider = Microsoft.ACE.OLEDB.12.0;" + @"Data Source = C:\Libro5.xlsx;" + "Extended Properties='Excel 12.0 Xml;HDR=Yes'";
        // Creamos un nuevo objeto Connection
        OleDbConnection cnn = new OleDbConnection(connString);

        try
        {
            // Configuramos un objeto Command para ejecutar
            // la consulta SQL de creación de tabla
            
            OleDbCommand cmd = cnn.CreateCommand();
            // Creamos la consulta SQL de creación de tabla,
            // indicando que vamos a utilizar el driver
            // ODBC de Microsoft SQL Server
            cmd.CommandText =
       "INSERT INTO [$Hoja11] " +
       "IN ''[ODBC;DRIVER={SQL Server Native Client 11.0};" +
       "Server=172.24.86.203 ;Database=Afil-67 ;UID=sa ;PWD=katia.2014 ]";/* +
       "SELECT * FROM [$Hoja2]";*/

           /* cmd.CommandText =
                "SELECT * INTO [$Hoja11] " +
                "FROM [Afil67_C123_2019_05_07] " +
                "IN ''[ODBC;DRIVER={SQL Server Native Client 11.0};" +
                "Server = 172.24.86.203/NetSDK;" +
                "Database = Afil-67;UID=sa ;PWD=katia.2014" ;*/


            // Abrimos la conexión
            cnn.Open();
            // Ejecutamos la consulta
            int n = cmd.ExecuteNonQuery();
            Response.Write("Se creado satisfactoriamente la hoja de cálculo." + Environment.NewLine + "Número de registros afectados: " + n.ToString()+ "Importar datos a Microsoft Excel");

        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
        finally
        {
            // Cerramos y destruimos la conexión
            cnn.Dispose();
            cnn = null;
        }
    }

    public void cargaBase()
    {
        DropListCiclo.AppendDataBoundItems = true;
        String strQuery = @"SELECT REPLACE([ciclo],' ','') + '  ' +  CONVERT(NVARCHAR(15),[fechaCiclo]) MOSTRAR ,CONVERT(NVARCHAR(20),[fechaCiclo],112) VALUE FROM [Afil-67].[dbo].[RegistroAfil] ORDER BY MOSTRAR ASC";
        SqlConnection con = new SqlConnection(ConecAfil67);
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = strQuery;
        cmd.Connection = con;
        try
        {
            con.Open();
            DropListCiclo.DataSource = cmd.ExecuteReader();
            DropListCiclo.DataTextField = "MOSTRAR";
            DropListCiclo.DataValueField = "VALUE";
            DropListCiclo.DataBind();
            if (DropListCiclo.Items.Count > 1)
            {
                DropListCiclo.Enabled = true;
            }
            else
            {
                DropListCiclo.Enabled = false;
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




    protected void btnReporte_Click(object sender, EventArgs e)
    {
        div_Resumen.Visible = true;
        Data();
    }

    public void Data()
    {
        String query = "";
        if (DropListSubdel.SelectedValue == "16")
        {
            query = @"SELECT [cve_modalidad],CONVERT(CHAR(2),[cve_modalidad])+' - '+[descripcion] [descripcion], T2.CONTEO FROM [Afil-67].[dbo].[CTO_modalidades] T1 INNER JOIN (SELECT COUNT(*) CONTEO ,SUBSTRING([reg_pat],10,2) MODA FROM [Afil-67].[dbo].[Afil67_" + DropListCiclo.SelectedItem.ToString().Replace('-', '_').Replace("  ", "_") + "] GROUP BY SUBSTRING([reg_pat],10,2)) T2 ON T1.cve_modalidad=T2.MODA ORDER BY cve_modalidad ASC";
        }
        else
        {
            query = @"SELECT [cve_modalidad],CONVERT(CHAR(2),[cve_modalidad])+' - '+[descripcion] [descripcion], T2.CONTEO FROM [Afil-67].[dbo].[CTO_modalidades] T1 INNER JOIN (SELECT COUNT(*) CONTEO ,SUBSTRING([reg_pat],10,2) MODA FROM [Afil-67].[dbo].[Afil67_" + DropListCiclo.SelectedItem.ToString().Replace('-', '_').Replace("  ", "_") + "] WHERE [sub]=" + DropListSubdel.SelectedValue + " GROUP BY SUBSTRING([reg_pat],10,2)) T2 ON T1.cve_modalidad=T2.MODA ORDER BY cve_modalidad ASC";
        }
        SqlConnection conn1 = new SqlConnection(ConecAfil67);
        try
        {
            SqlCommand command = new SqlCommand(query, conn1);
            conn1.Open();
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            div_Resumen.Visible = true;
            GridView1.DataSource = dt;
            GridView1.DataBind();
            //Calculate Sum and display in Footer Row
            decimal total = dt.AsEnumerable().Sum(row => row.Field<Int32>("CONTEO"));
            GridView1.FooterRow.Cells[0].Text = "Total de Trabajadores";
            GridView1.FooterRow.Cells[0].HorizontalAlign = HorizontalAlign.Right;
            GridView1.FooterRow.Cells[0].Font.Bold = true;
            GridView1.FooterRow.Cells[0].Font.Size = 16;
            GridView1.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Right;
            GridView1.FooterRow.Cells[1].Text = total.ToString("###,###,###");
            GridView1.FooterRow.Cells[1].Font.Bold = true;
            GridView1.FooterRow.Cells[1].Font.Size = 16;
        }
        catch(Exception d)
        {
            Response.Write(d.Message);
        }
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = GridView1.SelectedRow;
        int mod = Convert.ToInt32(GridView1.DataKeys[row.RowIndex].Value);
        string sql = "";
        if (DropListSubdel.SelectedValue == "16")
        {
            sql = @"SELECT [nss],[nombre],[movt],[fecha_movt],[salario_BC],[iden_trabaj],[subr_serv],[umf],[tipo_jor_sem],[id_huelga],[reg_pat],[fecha_afil],[sub]
                                                               FROM [Afil-67].[dbo].[Afil67_" + DropListCiclo.SelectedItem.ToString().Replace('-', '_').Replace("  ", "_") + "] WHERE SUBSTRING([reg_pat], 10, 2)= " + mod + " ORDER BY nombre ASC ";
        }
        else
        {
            sql = @"SELECT [nss],[nombre],[movt],[fecha_movt],[salario_BC],[iden_trabaj],[subr_serv],[umf],[tipo_jor_sem],[id_huelga],[reg_pat],[fecha_afil],[sub]
                                                               FROM [Afil-67].[dbo].[Afil67_" + DropListCiclo.SelectedItem.ToString().Replace('-', '_').Replace("  ", "_") + "] WHERE SUBSTRING([reg_pat], 10, 2)= " + mod + " AND[sub] = " + DropListSubdel.SelectedValue + " ORDER BY nombre ASC";
        }
        using (SqlConnection conn = new SqlConnection(ConecAfil67))
        {
            conn.Open();
            // Create the sample database
            SqlCommand cmd = new SqlCommand(sql, conn);
            //cmd.CommandType = System.Data.CommandType;
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = conn;
                    sda.SelectCommand = cmd;
                    cmd.CommandTimeout = 3600;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        using (XLWorkbook wb = new XLWorkbook())
                        {
                            wb.Worksheets.Add(dt, DropListCiclo.SelectedItem.ToString());

                            Response.Clear();
                            Response.Buffer = true;
                            Response.Charset = "";
                            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                            Response.AddHeader("content-disposition", "attachment;filename=" + DropListSubdel.SelectedItem.ToString()+"_"+ mod + ".xlsx");
                            using (MemoryStream MyMemoryStream = new MemoryStream())
                            {
                                wb.SaveAs(MyMemoryStream);
                                MyMemoryStream.WriteTo(Response.OutputStream);
                                Response.Flush();
                                Response.End();
                            }
                        }
                    }
                }
            }
        }



        /* string sql = "";
         if (DropListSubdel.SelectedValue == "16")
         {
             sql = @"SELECT [nss],[nombre],[movt],[fecha_movt],[salario_BC],[iden_trabaj],[subr_serv],[umf],[tipo_jor_sem],[id_huelga],[reg_pat],[fecha_afil],[sub]
                                                               FROM [Afil-67].[dbo].[Afil67_" + DropListCiclo.SelectedItem.ToString().Replace('-', '_').Replace("  ", "_") + "] WHERE SUBSTRING([reg_pat], 10, 2)= " + mod + " ORDER BY nombre ASC ";
         }
         else
         {
             sql = @"SELECT [nss],[nombre],[movt],[fecha_movt],[salario_BC],[iden_trabaj],[subr_serv],[umf],[tipo_jor_sem],[id_huelga],[reg_pat],[fecha_afil],[sub]
                                                               FROM [Afil-67].[dbo].[Afil67_" + DropListCiclo.SelectedItem.ToString().Replace('-', '_').Replace("  ", "_") + "] WHERE SUBSTRING([reg_pat], 10, 2)= " + mod + " AND[sub] = " + DropListSubdel.SelectedValue + " ORDER BY nombre ASC";
         }

         SqlConnection conn1 = new SqlConnection(ConecAfil67);
         try
         {
             SqlCommand command = new SqlCommand(sql, conn1);
             conn1.Open();
             SqlDataAdapter da = new SqlDataAdapter(command);
             DataTable dt = new DataTable();
             da.Fill(dt);
             div_Resumen.Visible = true;

         }
         catch(Exception exc)
         {
             Response.Write(exc.Message);
         }*/
    }

    protected void DropListSubdel_SelectedIndexChanged(object sender, EventArgs e)
    {
        div_Resumen.Visible = false;
    }
}