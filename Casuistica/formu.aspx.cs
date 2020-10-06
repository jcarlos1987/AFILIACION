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

public partial class Casuistica_formu : System.Web.UI.Page
{
    String strConnString = ConfigurationManager.ConnectionStrings["AfiliacionConnectionString"].ConnectionString;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Grid();
        }
    }

    public void Grid()
    {
        try
        {
            SqlConnection conn1 = new SqlConnection(strConnString);
            conn1.Open();
            SqlDataReader myReader = null;
            SqlCommand cmd = new SqlCommand("SELECT [id],[Fecha_Carga],[Folio_Error],[Cve_Docto],[NSS],[Registro_Pat],[Fecha_Inicio],[TR],CONVERT(FLOAT,[CS])[CS],[Dias_Sub],[Folio_Docto],[Porc_Inc],[Fecha_Termino],[Deleg_Orgn],[UMF],[Codigo_Error],[Codigo_Error2]" +
                    ",[Codigo_Error3],[Codigo_Error4],[Codigo_Error5],[Nombre_Asegurado],[CURP],[Cto_Pag],[Tipo_Mto_Aju],[Fecha_Extrac],[Tipo],[Ciclo],[status] FROM [Afiliacion].[dbo].[UPD_SCAC-10] WHERE [id]=" + Convert.ToInt32(Request.Cookies["ID_SCAC10"].Value) + "", conn1);
            myReader = cmd.ExecuteReader();
            while (myReader.Read())
            {
                folio_error.Text = myReader.GetString(2);
                clav_doc.Text = myReader.GetString(3);
                nss.Text = myReader.GetString(4);
                nom_aseg.Text = myReader.GetString(20);
                curp.Text = myReader.GetString(21);
                reg_pat.Text = myReader.GetString(5);
                fech_inic.Text = myReader.GetString(6);
                tr.Text = myReader.GetString(7);
                cs.Text = Convert.ToString(myReader.GetDouble(8));
                dias_sub.Text = myReader.GetString(9);
                porc_inc.Text = myReader.GetString(11);
                fecha_term.Text = myReader.GetString(12);
                del_ori.Text = myReader.GetString(13);
                umf.Text = myReader.GetString(14);
                folio.Text = myReader.GetString(10);
                cto_pag.Text = myReader.GetString(22).Trim();
                tipo_mov_ajust.Text = myReader.GetString(23).Trim();
                LabelTipo.Text = myReader.GetString(25);
                Response.Cookies["CodError1"].Value = myReader.GetString(15);
                Response.Cookies["CodError2"].Value = myReader.GetString(16);
                Response.Cookies["CodError3"].Value = myReader.GetString(17);
                Response.Cookies["CodError4"].Value = myReader.GetString(18);
                Response.Cookies["CodError5"].Value = myReader.GetString(19);

                if (Convert.ToInt32(Request.Cookies["CodError1"].Value) == 4006 || Convert.ToInt32(Request.Cookies["CodError2"].Value) == 4006 || Convert.ToInt32(Request.Cookies["CodError3"].Value) == 4006 || Convert.ToInt32(Request.Cookies["CodError4"].Value) == 4006 || Convert.ToInt32(Request.Cookies["CodError5"].Value) == 4006)
                {
                    string cod4006 = null;
                    if (Convert.ToInt32(Request.Cookies["CodError1"].Value) == 4006)
                    {
                        cod4006 = Request.Cookies["CodError1"].Value;
                    }
                    else if (Convert.ToInt32(Request.Cookies["CodError2"].Value) == 4006)
                    {
                        cod4006 = Request.Cookies["CodError2"].Value;
                    }
                    else if (Convert.ToInt32(Request.Cookies["CodError3"].Value) == 4006)
                    {
                        cod4006 = Request.Cookies["CodError3"].Value;
                    }
                    else if (Convert.ToInt32(Request.Cookies["CodError4"].Value) == 4006)
                    {
                        cod4006 = Request.Cookies["CodError4"].Value;
                    }
                    else if (Convert.ToInt32(Request.Cookies["CodError5"].Value) == 4006)
                    {
                        cod4006 = Request.Cookies["CodError5"].Value;
                    }
                    nss.Enabled = true;
                    Labelcodigoerror1.Text = "<strong>Cod. Error : " + cod4006 + " .</strong> Número de Seguridad Social (Consistencia del...)";
                    div_cod_error1.Visible = true;
                    Gly_nss.Visible = true;
                    id_nss.Attributes.Add("class", "input-group has-success");
                }
                if (Convert.ToInt32(Request.Cookies["CodError1"].Value) == 4008 || Convert.ToInt32(Request.Cookies["CodError2"].Value) == 4008 || Convert.ToInt32(Request.Cookies["CodError3"].Value) == 4008 || Convert.ToInt32(Request.Cookies["CodError4"].Value) == 4008 || Convert.ToInt32(Request.Cookies["CodError5"].Value) == 4008)
                {
                    string cod4008 = null;
                    if (Convert.ToInt32(Request.Cookies["CodError1"].Value) == 4008)
                    {
                        cod4008 = Request.Cookies["CodError1"].Value;
                    }
                    else if (Convert.ToInt32(Request.Cookies["CodError2"].Value) == 4008)
                    {
                        cod4008 = Request.Cookies["CodError2"].Value;
                    }
                    else if (Convert.ToInt32(Request.Cookies["CodError3"].Value) == 4008)
                    {
                        cod4008 = Request.Cookies["CodError3"].Value;
                    }
                    else if (Convert.ToInt32(Request.Cookies["CodError4"].Value) == 4008)
                    {
                        cod4008 = Request.Cookies["CodError4"].Value;
                    }
                    else if (Convert.ToInt32(Request.Cookies["CodError5"].Value) == 4008)
                    {
                        cod4008 = Request.Cookies["CodError5"].Value;
                    }
                    reg_pat.Enabled = true;
                    Labelcodigoerror2.Text = "<strong>Cod. Error : " + cod4008 + " .</strong>Registro Patronal (consistencia del...)";
                    div_cod_error2.Visible = true;
                    Gly_reg_pat.Visible = true;
                    id_reg_pat.Attributes.Add("class", "input-group has-success");
                }
                if (Convert.ToInt32(Request.Cookies["CodError1"].Value) == 4010 || Convert.ToInt32(Request.Cookies["CodError2"].Value) == 4010 || Convert.ToInt32(Request.Cookies["CodError3"].Value) == 4010 || Convert.ToInt32(Request.Cookies["CodError4"].Value) == 4010 || Convert.ToInt32(Request.Cookies["CodError5"].Value) == 4010)
                {
                    string cod4010 = null;
                    if (Convert.ToInt32(Request.Cookies["CodError1"].Value) == 4010)
                    {
                        cod4010 = Request.Cookies["CodError1"].Value;
                    }
                    else if (Convert.ToInt32(Request.Cookies["CodError2"].Value) == 4010)
                    {
                        cod4010 = Request.Cookies["CodError2"].Value;
                    }
                    else if (Convert.ToInt32(Request.Cookies["CodError3"].Value) == 4010)
                    {
                        cod4010 = Request.Cookies["CodError3"].Value;
                    }
                    else if (Convert.ToInt32(Request.Cookies["CodError4"].Value) == 4010)
                    {
                        cod4010 = Request.Cookies["CodError4"].Value;
                    }
                    else if (Convert.ToInt32(Request.Cookies["CodError5"].Value) == 4010)
                    {
                        cod4010 = Request.Cookies["CodError5"].Value;
                    }
                    cs.Enabled = true;
                    Labelcodigoerror3.Text = "<strong>Cod. Error : " + cod4010 + " .</strong>Consecuencia (error en la...)";
                    div_cod_error3.Visible = true;
                    Gly_cs.Visible = true;
                    id_cs.Attributes.Add("class", "input-group has-success");
                }
                if (Convert.ToInt32(Request.Cookies["CodError1"].Value) == 4012 || Convert.ToInt32(Request.Cookies["CodError2"].Value) == 4012 || Convert.ToInt32(Request.Cookies["CodError3"].Value) == 4012 || Convert.ToInt32(Request.Cookies["CodError4"].Value) == 4012 || Convert.ToInt32(Request.Cookies["CodError5"].Value) == 4012)
                {
                    string cod4012 = null;
                    if (Convert.ToInt32(Request.Cookies["CodError1"].Value) == 4012)
                    {
                        cod4012 = Request.Cookies["CodError1"].Value;
                    }
                    else if (Convert.ToInt32(Request.Cookies["CodError2"].Value) == 4012)
                    {
                        cod4012 = Request.Cookies["CodError2"].Value;
                    }
                    else if (Convert.ToInt32(Request.Cookies["CodError3"].Value) == 4012)
                    {
                        cod4012 = Request.Cookies["CodError3"].Value;
                    }
                    else if (Convert.ToInt32(Request.Cookies["CodError4"].Value) == 4012)
                    {
                        cod4012 = Request.Cookies["CodError4"].Value;
                    }
                    else if (Convert.ToInt32(Request.Cookies["CodError5"].Value) == 4012)
                    {
                        cod4012 = Request.Cookies["CodError5"].Value;
                    }
                    fech_inic.Enabled = true;
                    Labelcodigoerror4.Text = "<strong>Cod. Error : " + cod4012 + " .</strong> Fecha de inicio (error en la...)";
                    div_cod_error4.Visible = true;
                    Gly_fech_inic.Visible = true;
                    id_fecha_inic.Attributes.Add("class", "input-group has-success");
                }
                if (Convert.ToInt32(Request.Cookies["CodError1"].Value) == 4014 || Convert.ToInt32(Request.Cookies["CodError2"].Value) == 4014 || Convert.ToInt32(Request.Cookies["CodError3"].Value) == 4014 || Convert.ToInt32(Request.Cookies["CodError4"].Value) == 4014 || Convert.ToInt32(Request.Cookies["CodError5"].Value) == 4014)
                {
                    string cod4014 = null;
                    if (Convert.ToInt32(Request.Cookies["CodError1"].Value) == 4014)
                    {
                        cod4014 = Request.Cookies["CodError1"].Value;
                    }
                    else if (Convert.ToInt32(Request.Cookies["CodError2"].Value) == 4014)
                    {
                        cod4014 = Request.Cookies["CodError2"].Value;
                    }
                    else if (Convert.ToInt32(Request.Cookies["CodError3"].Value) == 4014)
                    {
                        cod4014 = Request.Cookies["CodError3"].Value;
                    }
                    else if (Convert.ToInt32(Request.Cookies["CodError4"].Value) == 4014)
                    {
                        cod4014 = Request.Cookies["CodError4"].Value;
                    }
                    else if (Convert.ToInt32(Request.Cookies["CodError5"].Value) == 4014)
                    {
                        cod4014 = Request.Cookies["CodError5"].Value;
                    }
                    dias_sub.Enabled = true;
                    Labelcodigoerror5.Text = "<strong>Cod. Error : " + cod4014 + " .</strong> Días subsidiados (error en los...)";
                    div_cod_error5.Visible = true;
                    Gly_dias_sub.Visible = true;
                    id_dias_sub.Attributes.Add("class", "input-group has-success");
                }
                if (Convert.ToInt32(Request.Cookies["CodError1"].Value) == 4016 || Convert.ToInt32(Request.Cookies["CodError2"].Value) == 4016 || Convert.ToInt32(Request.Cookies["CodError3"].Value) == 4016 || Convert.ToInt32(Request.Cookies["CodError4"].Value) == 4016 || Convert.ToInt32(Request.Cookies["CodError5"].Value) == 4016)
                {
                    string cod4016 = null;
                    if (Convert.ToInt32(Request.Cookies["CodError1"].Value) == 4016)
                    {
                        cod4016 = Request.Cookies["CodError1"].Value;
                    }
                    else if (Convert.ToInt32(Request.Cookies["CodError2"].Value) == 4016)
                    {
                        cod4016 = Request.Cookies["CodError2"].Value;
                    }
                    else if (Convert.ToInt32(Request.Cookies["CodError3"].Value) == 4016)
                    {
                        cod4016 = Request.Cookies["CodError3"].Value;
                    }
                    else if (Convert.ToInt32(Request.Cookies["CodError4"].Value) == 4016)
                    {
                        cod4016 = Request.Cookies["CodError4"].Value;
                    }
                    else if (Convert.ToInt32(Request.Cookies["CodError5"].Value) == 4016)
                    {
                        cod4016 = Request.Cookies["CodError5"].Value;
                    }
                    fecha_term.Enabled = true;
                    Labelcodigoerror6.Text = "<strong>Cod. Error : " + cod4016 + " .</strong> Fecha de término (error en la...)";
                    div_cod_error6.Visible = true;
                    GlyFechaTermino.Visible = true;
                    ImageButton6.Enabled = false;
                    id_fecha_termino.Attributes.Add("class", "input-group has-success");
                }
                if (Convert.ToInt32(Request.Cookies["CodError1"].Value) == 4018 || Convert.ToInt32(Request.Cookies["CodError2"].Value) == 4018 || Convert.ToInt32(Request.Cookies["CodError3"].Value) == 4018 || Convert.ToInt32(Request.Cookies["CodError4"].Value) == 4018 || Convert.ToInt32(Request.Cookies["CodError5"].Value) == 4018)
                {
                    string cod4018 = null;
                    if (Convert.ToInt32(Request.Cookies["CodError1"].Value) == 4018)
                    {
                        cod4018 = Request.Cookies["CodError1"].Value;
                    }
                    else if (Convert.ToInt32(Request.Cookies["CodError2"].Value) == 4018)
                    {
                        cod4018 = Request.Cookies["CodError2"].Value;
                    }
                    else if (Convert.ToInt32(Request.Cookies["CodError3"].Value) == 4018)
                    {
                        cod4018 = Request.Cookies["CodError3"].Value;
                    }
                    else if (Convert.ToInt32(Request.Cookies["CodError4"].Value) == 4018)
                    {
                        cod4018 = Request.Cookies["CodError4"].Value;
                    }
                    else if (Convert.ToInt32(Request.Cookies["CodError5"].Value) == 4018)
                    {
                        cod4018 = Request.Cookies["CodError5"].Value;
                    }
                    tr.Enabled = true;
                    Labelcodigoerror7.Text = "<strong>Cod. Error : " + cod4018 + " .</strong> Tipo de riesgo (error en el...)";
                    div_cod_error7.Visible = true;
                    Gly_tr.Visible = true;
                    id_tr.Attributes.Add("class", "input-group has-success");
                }
                if (Convert.ToInt32(Request.Cookies["CodError1"].Value) == 4020 || Convert.ToInt32(Request.Cookies["CodError2"].Value) == 4020 || Convert.ToInt32(Request.Cookies["CodError3"].Value) == 4020 || Convert.ToInt32(Request.Cookies["CodError4"].Value) == 4020 || Convert.ToInt32(Request.Cookies["CodError5"].Value) == 4020)
                {
                    string cod4020 = null;
                    if (Convert.ToInt32(Request.Cookies["CodError1"].Value) == 4020)
                    {
                        cod4020 = Request.Cookies["CodError1"].Value;
                    }
                    else if (Convert.ToInt32(Request.Cookies["CodError2"].Value) == 4020)
                    {
                        cod4020 = Request.Cookies["CodError2"].Value;
                    }
                    else if (Convert.ToInt32(Request.Cookies["CodError3"].Value) == 4020)
                    {
                        cod4020 = Request.Cookies["CodError3"].Value;
                    }
                    else if (Convert.ToInt32(Request.Cookies["CodError4"].Value) == 4020)
                    {
                        cod4020 = Request.Cookies["CodError4"].Value;
                    }
                    else if (Convert.ToInt32(Request.Cookies["CodError5"].Value) == 4020)
                    {
                        cod4020 = Request.Cookies["CodError5"].Value;
                    }
                    porc_inc.Enabled = true;
                    Labelcodigoerror8.Text = "<strong>Cod. Error : " + cod4020 + " .</strong> Porcentaje de incapacidad (error en el...)";
                    div_cod_error8.Visible = true;
                    Gly_porc_inc.Visible = true;
                    id_porc_inc.Attributes.Add("class", "input-group has-success");
                }
                if (Convert.ToInt32(Request.Cookies["CodError1"].Value) == 4022 || Convert.ToInt32(Request.Cookies["CodError2"].Value) == 4022 || Convert.ToInt32(Request.Cookies["CodError3"].Value) == 4022 || Convert.ToInt32(Request.Cookies["CodError4"].Value) == 4022 || Convert.ToInt32(Request.Cookies["CodError5"].Value) == 4022)
                {
                    string cod4022 = null;
                    if (Convert.ToInt32(Request.Cookies["CodError1"].Value) == 4022)
                    {
                        cod4022 = Request.Cookies["CodError1"].Value;
                    }
                    else if (Convert.ToInt32(Request.Cookies["CodError2"].Value) == 4022)
                    {
                        cod4022 = Request.Cookies["CodError2"].Value;
                    }
                    else if (Convert.ToInt32(Request.Cookies["CodError3"].Value) == 4022)
                    {
                        cod4022 = Request.Cookies["CodError3"].Value;
                    }
                    else if (Convert.ToInt32(Request.Cookies["CodError4"].Value) == 4022)
                    {
                        cod4022 = Request.Cookies["CodError4"].Value;
                    }
                    else if (Convert.ToInt32(Request.Cookies["CodError5"].Value) == 4022)
                    {
                        cod4022 = Request.Cookies["CodError5"].Value;
                    }
                    tipo_mov_ajust.Enabled = true;
                    Labelcodigoerror9.Text = "<strong>Cod. Error : " + cod4022 + " .</strong> Tipo de movimiento (error en el...)";
                    div_cod_error9.Visible = true;
                    Gly_tipo_mov_ajust.Visible = true;
                    id_tipo_mov_ajust.Attributes.Add("class", "input-group has-success");
                }
                if (Convert.ToInt32(Request.Cookies["CodError1"].Value) == 4024 || Convert.ToInt32(Request.Cookies["CodError2"].Value) == 4024 || Convert.ToInt32(Request.Cookies["CodError3"].Value) == 4024 || Convert.ToInt32(Request.Cookies["CodError4"].Value) == 4024 || Convert.ToInt32(Request.Cookies["CodError5"].Value) == 4024)
                {
                    string cod4024 = null;
                    if (Convert.ToInt32(Request.Cookies["CodError1"].Value) == 4024)
                    {
                        cod4024 = Request.Cookies["CodError1"].Value;
                    }
                    else if (Convert.ToInt32(Request.Cookies["CodError2"].Value) == 4024)
                    {
                        cod4024 = Request.Cookies["CodError2"].Value;
                    }
                    else if (Convert.ToInt32(Request.Cookies["CodError3"].Value) == 4024)
                    {
                        cod4024 = Request.Cookies["CodError3"].Value;
                    }
                    else if (Convert.ToInt32(Request.Cookies["CodError4"].Value) == 4024)
                    {
                        cod4024 = Request.Cookies["CodError4"].Value;
                    }
                    else if (Convert.ToInt32(Request.Cookies["CodError5"].Value) == 4024)
                    {
                        cod4024 = Request.Cookies["CodError5"].Value;
                    }
                    folio_error.Enabled = true;
                    Labelcodigoerror10.Text = "<strong>Cod. Error : " + cod4024 + " .</strong> Folio de error (no existe el...)";
                    div_cod_error10.Visible = true;
                    Gly_folio.Visible = true;
                    id_folio.Attributes.Add("class", "input-group has-success");
                }
                if (Convert.ToInt32(Request.Cookies["CodError1"].Value) == 4026 || Convert.ToInt32(Request.Cookies["CodError2"].Value) == 4026 || Convert.ToInt32(Request.Cookies["CodError3"].Value) == 4026 || Convert.ToInt32(Request.Cookies["CodError4"].Value) == 4026 || Convert.ToInt32(Request.Cookies["CodError5"].Value) == 4026)
                {
                    string cod4026 = null;
                    if (Convert.ToInt32(Request.Cookies["CodError1"].Value) == 4026)
                    {
                        cod4026 = Request.Cookies["CodError1"].Value;
                    }
                    else if (Convert.ToInt32(Request.Cookies["CodError2"].Value) == 4026)
                    {
                        cod4026 = Request.Cookies["CodError2"].Value;
                    }
                    else if (Convert.ToInt32(Request.Cookies["CodError3"].Value) == 4026)
                    {
                        cod4026 = Request.Cookies["CodError3"].Value;
                    }
                    else if (Convert.ToInt32(Request.Cookies["CodError4"].Value) == 4026)
                    {
                        cod4026 = Request.Cookies["CodError4"].Value;
                    }
                    else if (Convert.ToInt32(Request.Cookies["CodError5"].Value) == 4026)
                    {
                        cod4026 = Request.Cookies["CodError5"].Value;
                    }
                    tipo_mov_ajust.Enabled = true;
                    Labelcodigoerror11.Text = "<strong>Cod. Error : " + cod4026 + " .</strong>  Tipo de moviemiento AJU (error en la llave de acceso del...)";
                    div_cod_error11.Visible = true;
                    Gly_tipo_mov_ajust.Visible = true;
                    id_tipo_mov_ajust.Attributes.Add("class", "input-group has-success");
                }
                if (Convert.ToInt32(Request.Cookies["CodError1"].Value) == 4028 || Convert.ToInt32(Request.Cookies["CodError2"].Value) == 4028 || Convert.ToInt32(Request.Cookies["CodError3"].Value) == 4028 || Convert.ToInt32(Request.Cookies["CodError4"].Value) == 4028 || Convert.ToInt32(Request.Cookies["CodError5"].Value) == 4028)
                {
                    string cod4028 = null;
                    if (Convert.ToInt32(Request.Cookies["CodError1"].Value) == 4028)
                    {
                        cod4028 = Request.Cookies["CodError1"].Value;
                    }
                    else if (Convert.ToInt32(Request.Cookies["CodError2"].Value) == 4028)
                    {
                        cod4028 = Request.Cookies["CodError2"].Value;
                    }
                    else if (Convert.ToInt32(Request.Cookies["CodError3"].Value) == 4028)
                    {
                        cod4028 = Request.Cookies["CodError3"].Value;
                    }
                    else if (Convert.ToInt32(Request.Cookies["CodError4"].Value) == 4028)
                    {
                        cod4028 = Request.Cookies["CodError4"].Value;
                    }
                    else if (Convert.ToInt32(Request.Cookies["CodError5"].Value) == 4028)
                    {
                        cod4028 = Request.Cookies["CodError5"].Value;
                    }
                    tipo_mov_ajust.Enabled = true;
                    Labelcodigoerror12.Text = "<strong>Cod. Error : " + cod4028 + " .</strong> Tipo de movimiento AJU (error en los datos a incluir del...)";
                    div_cod_error12.Visible = true;
                    Gly_tipo_mov_ajust.Visible = true;
                    id_tipo_mov_ajust.Attributes.Add("class", "input-group has-success");
                }
                if (Convert.ToInt32(Request.Cookies["CodError1"].Value) == 4030 || Convert.ToInt32(Request.Cookies["CodError2"].Value) == 4030 || Convert.ToInt32(Request.Cookies["CodError3"].Value) == 4030 || Convert.ToInt32(Request.Cookies["CodError4"].Value) == 4030 || Convert.ToInt32(Request.Cookies["CodError5"].Value) == 4030)
                {
                    string cod4030 = null;
                    if (Convert.ToInt32(Request.Cookies["CodError1"].Value) == 4030)
                    {
                        cod4030 = Request.Cookies["CodError1"].Value;
                    }
                    else if (Convert.ToInt32(Request.Cookies["CodError2"].Value) == 4030)
                    {
                        cod4030 = Request.Cookies["CodError2"].Value;
                    }
                    else if (Convert.ToInt32(Request.Cookies["CodError3"].Value) == 4030)
                    {
                        cod4030 = Request.Cookies["CodError3"].Value;
                    }
                    else if (Convert.ToInt32(Request.Cookies["CodError4"].Value) == 4030)
                    {
                        cod4030 = Request.Cookies["CodError4"].Value;
                    }
                    else if (Convert.ToInt32(Request.Cookies["CodError5"].Value) == 4030)
                    {
                        cod4030 = Request.Cookies["CodError5"].Value;
                    }
                    nss.Enabled = true;
                    Labelcodigoerror13.Text = "<strong>Cod. Error : " + cod4030 + " .</strong>  Número de Seguridad Social (no existe en la base de datos el...)";
                    div_cod_error13.Visible = true;
                    Gly_nss.Visible = true;
                    id_nss.Attributes.Add("class", "input-group has-success");
                }
                if (Convert.ToInt32(Request.Cookies["CodError1"].Value) == 4032 || Convert.ToInt32(Request.Cookies["CodError2"].Value) == 4032 || Convert.ToInt32(Request.Cookies["CodError3"].Value) == 4032 || Convert.ToInt32(Request.Cookies["CodError4"].Value) == 4032 || Convert.ToInt32(Request.Cookies["CodError5"].Value) == 4032)
                {
                    string cod4032 = null;
                    if (Convert.ToInt32(Request.Cookies["CodError1"].Value) == 4032)
                    {
                        cod4032 = Request.Cookies["CodError1"].Value;
                    }
                    else if (Convert.ToInt32(Request.Cookies["CodError2"].Value) == 4032)
                    {
                        cod4032 = Request.Cookies["CodError2"].Value;
                    }
                    else if (Convert.ToInt32(Request.Cookies["CodError3"].Value) == 4032)
                    {
                        cod4032 = Request.Cookies["CodError3"].Value;
                    }
                    else if (Convert.ToInt32(Request.Cookies["CodError4"].Value) == 4032)
                    {
                        cod4032 = Request.Cookies["CodError4"].Value;
                    }
                    else if (Convert.ToInt32(Request.Cookies["CodError5"].Value) == 4032)
                    {
                        cod4032 = Request.Cookies["CodError5"].Value;
                    }
                    reg_pat.Enabled = true;
                    Labelcodigoerror14.Text = "<strong>Cod. Error : " + cod4032 + " .</strong> Registro patronal (no existe en la Base de Datos el...)";
                    div_cod_error14.Visible = true;
                    Gly_reg_pat.Visible = true;
                    id_reg_pat.Attributes.Add("class", "input-group has-success");
                }
                if (Convert.ToInt32(Request.Cookies["CodError1"].Value) == 4034 || Convert.ToInt32(Request.Cookies["CodError2"].Value) == 4034 || Convert.ToInt32(Request.Cookies["CodError3"].Value) == 4034 || Convert.ToInt32(Request.Cookies["CodError4"].Value) == 4034 || Convert.ToInt32(Request.Cookies["CodError5"].Value) == 4034)
                {
                    string cod4034 = null;
                    if (Convert.ToInt32(Request.Cookies["CodError1"].Value) == 4034)
                    {
                        cod4034 = Request.Cookies["CodError1"].Value;
                    }
                    else if (Convert.ToInt32(Request.Cookies["CodError2"].Value) == 4034)
                    {
                        cod4034 = Request.Cookies["CodError2"].Value;
                    }
                    else if (Convert.ToInt32(Request.Cookies["CodError3"].Value) == 4034)
                    {
                        cod4034 = Request.Cookies["CodError3"].Value;
                    }
                    else if (Convert.ToInt32(Request.Cookies["CodError4"].Value) == 4034)
                    {
                        cod4034 = Request.Cookies["CodError4"].Value;
                    }
                    else if (Convert.ToInt32(Request.Cookies["CodError5"].Value) == 4034)
                    {
                        cod4034 = Request.Cookies["CodError5"].Value;
                    }
                    reg_pat.Enabled = true;
                    nss.Enabled = true;
                    Labelcodigoerror15.Text = "<strong>Cod. Error : " + cod4034 + " .</strong> Número de Seguridad Social vs registro patronal (No existe relación obrero-patronal)";
                    div_cod_error15.Visible = true;
                    Gly_reg_pat.Visible = true;
                    id_reg_pat.Attributes.Add("class", "input-group has-success");
                    Gly_nss.Visible = true;
                    id_nss.Attributes.Add("class", "input-group has-success");
                }
                if (Convert.ToInt32(Request.Cookies["CodError1"].Value) == 4042 || Convert.ToInt32(Request.Cookies["CodError2"].Value) == 4042 || Convert.ToInt32(Request.Cookies["CodError3"].Value) == 4042 || Convert.ToInt32(Request.Cookies["CodError4"].Value) == 4042 || Convert.ToInt32(Request.Cookies["CodError5"].Value) == 4042)
                {
                    string cod4042 = null;
                    if (Convert.ToInt32(Request.Cookies["CodError1"].Value) == 4042)
                    {
                        cod4042 = Request.Cookies["CodError1"].Value;
                    }
                    else if (Convert.ToInt32(Request.Cookies["CodError2"].Value) == 4042)
                    {
                        cod4042 = Request.Cookies["CodError2"].Value;
                    }
                    else if (Convert.ToInt32(Request.Cookies["CodError3"].Value) == 4042)
                    {
                        cod4042 = Request.Cookies["CodError3"].Value;
                    }
                    else if (Convert.ToInt32(Request.Cookies["CodError4"].Value) == 4042)
                    {
                        cod4042 = Request.Cookies["CodError4"].Value;
                    }
                    else if (Convert.ToInt32(Request.Cookies["CodError5"].Value) == 4042)
                    {
                        cod4042 = Request.Cookies["CodError5"].Value;
                    }
                    clav_doc.Enabled = true;
                    Labelcodigoerror16.Text = "<strong>Cod. Error : " + cod4042 + " .</strong> Los datos a incluir o modificar ya existen (la llave esta duplicada), para docto. AJU.";
                    div_cod_error16.Visible = true;
                    Gly_clav_doc.Visible = true;
                    id_clav_doc.Attributes.Add("class", "input-group has-success");
                }
                if (Convert.ToInt32(Request.Cookies["CodError1"].Value) == 4050 || Convert.ToInt32(Request.Cookies["CodError2"].Value) == 4050 || Convert.ToInt32(Request.Cookies["CodError3"].Value) == 4050 || Convert.ToInt32(Request.Cookies["CodError4"].Value) == 4050 || Convert.ToInt32(Request.Cookies["CodError5"].Value) == 4050)
                {
                    string cod4050 = null;
                    if (Convert.ToInt32(Request.Cookies["CodError1"].Value) == 4050)
                    {
                        cod4050 = Request.Cookies["CodError1"].Value;
                    }
                    else if (Convert.ToInt32(Request.Cookies["CodError2"].Value) == 4050)
                    {
                        cod4050 = Request.Cookies["CodError2"].Value;
                    }
                    else if (Convert.ToInt32(Request.Cookies["CodError3"].Value) == 4050)
                    {
                        cod4050 = Request.Cookies["CodError3"].Value;
                    }
                    else if (Convert.ToInt32(Request.Cookies["CodError4"].Value) == 4050)
                    {
                        cod4050 = Request.Cookies["CodError4"].Value;
                    }
                    else if (Convert.ToInt32(Request.Cookies["CodError5"].Value) == 4050)
                    {
                        cod4050 = Request.Cookies["CodError5"].Value;
                    }
                    reg_pat.Enabled = true;
                    Labelcodigoerror17.Text = "<strong>Cod. Error : " + cod4050 + " .</strong> Registro Patronal Convencional.)";
                    div_cod_error17.Visible = true;
                    Gly_reg_pat.Visible = true;
                    id_reg_pat.Attributes.Add("class", "input-group has-success");
                }
            }
        }
        catch(Exception m)
        {
            Labelmsj.Text = m.Message;
        }
    }
    protected void Cancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("GridScac.aspx");
    }
    protected void Aceptar_Click(object sender, EventArgs e)
    {
        using (SqlConnection conn1 = new SqlConnection(strConnString))
        {
            try
            {
                conn1.Open();
                String sen = null;
                int resul;
                sen = "UPDATE [Afiliacion].[dbo].[UPD_SCAC-10] SET [Folio_Error] = @Folio_Error ,[Cve_Docto] = @Cve_Docto ,[NSS] = @NSS ,[Registro_Pat] = @Registro_Pat,[Fecha_Inicio] = @Fecha_Inicio, " +
                      "[TR] = @TR,[CS] = @CS,[Dias_Sub] = @Dias_Sub,[Folio_Docto] = @Folio_Docto,[Porc_Inc] = @Porc_Inc, [Fecha_Termino] = @Fecha_Termino, [Deleg_Orgn] = @Deleg_Orgn,[UMF] = @UMF " +
                      ",[Codigo_Error] = @Codigo_Error,[Codigo_Error2] = @Codigo_Error2,[Codigo_Error3] = @Codigo_Error3,[Codigo_Error4] = @Codigo_Error4,[Codigo_Error5] = @Codigo_Error5,[Nombre_Asegurado] = @Nombre_Asegurado"+
                      ",[CURP] = @CURP,[Cto_Pag] = @Cto_Pag,[Tipo_Mto_Aju] = @Tipo_Mto_Aju,[status] = @status,[fecha_act] = @fecha_act ,[id_user_act] = @id_user_act, [Observa] = @Observa WHERE [id]=" + Convert.ToInt32(Request.Cookies["ID_SCAC10"].Value) + "";
                SqlCommand cmd = new SqlCommand(sen, conn1);

                cmd.Parameters.Add(new SqlParameter("@Folio_Error", SqlDbType.VarChar, 50));
                cmd.Parameters["@Folio_Error"].Value = folio_error.Text;

                cmd.Parameters.Add(new SqlParameter("@Cve_Docto", SqlDbType.VarChar, 50));
                cmd.Parameters["@Cve_Docto"].Value = clav_doc.Text;

                cmd.Parameters.Add(new SqlParameter("@NSS", SqlDbType.VarChar, 50));
                cmd.Parameters["@NSS"].Value = nss.Text;

                cmd.Parameters.Add(new SqlParameter("@Registro_Pat", SqlDbType.VarChar, 50));
                cmd.Parameters["@Registro_Pat"].Value = reg_pat.Text;

                cmd.Parameters.Add(new SqlParameter("@Fecha_Inicio", SqlDbType.VarChar, 50));
                cmd.Parameters["@Fecha_Inicio"].Value = fech_inic.Text;

                cmd.Parameters.Add(new SqlParameter("@TR", SqlDbType.VarChar, 50));
                cmd.Parameters["@TR"].Value = tr.Text;

                cmd.Parameters.Add(new SqlParameter("@CS", SqlDbType.VarChar, 50));
                cmd.Parameters["@CS"].Value = cs.Text+".00";

                cmd.Parameters.Add(new SqlParameter("@Dias_Sub", SqlDbType.VarChar, 50));
                cmd.Parameters["@Dias_Sub"].Value = dias_sub.Text;

                cmd.Parameters.Add(new SqlParameter("@Folio_Docto", SqlDbType.VarChar, 50));
                cmd.Parameters["@Folio_Docto"].Value = folio.Text;

                cmd.Parameters.Add(new SqlParameter("@Porc_Inc", SqlDbType.VarChar, 50));
                cmd.Parameters["@Porc_Inc"].Value = porc_inc.Text;

                cmd.Parameters.Add(new SqlParameter("@Fecha_Termino", SqlDbType.VarChar, 50));
                cmd.Parameters["@Fecha_Termino"].Value = fecha_term.Text;

                cmd.Parameters.Add(new SqlParameter("@Deleg_Orgn", SqlDbType.VarChar, 50));
                cmd.Parameters["@Deleg_Orgn"].Value = del_ori.Text;

                cmd.Parameters.Add(new SqlParameter("@UMF", SqlDbType.VarChar, 50));
                cmd.Parameters["@UMF"].Value = umf.Text;

                cmd.Parameters.Add(new SqlParameter("@Codigo_Error", SqlDbType.VarChar, 50));
                cmd.Parameters["@Codigo_Error"].Value = Request.Cookies["CodError1"].Value.Trim();

                cmd.Parameters.Add(new SqlParameter("@Codigo_Error2", SqlDbType.VarChar, 50));
                cmd.Parameters["@Codigo_Error2"].Value = Request.Cookies["CodError2"].Value.Trim();

                cmd.Parameters.Add(new SqlParameter("@Codigo_Error3", SqlDbType.VarChar, 50));
                cmd.Parameters["@Codigo_Error3"].Value = Request.Cookies["CodError3"].Value.Trim();

                cmd.Parameters.Add(new SqlParameter("@Codigo_Error4", SqlDbType.VarChar, 50));
                cmd.Parameters["@Codigo_Error4"].Value = Request.Cookies["CodError4"].Value.Trim();

                cmd.Parameters.Add(new SqlParameter("@Codigo_Error5", SqlDbType.VarChar, 50));
                cmd.Parameters["@Codigo_Error5"].Value = Request.Cookies["CodError5"].Value.Trim();

                cmd.Parameters.Add(new SqlParameter("@Nombre_Asegurado", SqlDbType.VarChar, 50));
                cmd.Parameters["@Nombre_Asegurado"].Value = nom_aseg.Text;

                cmd.Parameters.Add(new SqlParameter("@CURP", SqlDbType.VarChar, 50));
                cmd.Parameters["@CURP"].Value = curp.Text;

                cmd.Parameters.Add(new SqlParameter("@Cto_Pag", SqlDbType.VarChar, 50));
                cmd.Parameters["@Cto_Pag"].Value = cto_pag.Text;

                cmd.Parameters.Add(new SqlParameter("@Tipo_Mto_Aju", SqlDbType.VarChar, 50));
                cmd.Parameters["@Tipo_Mto_Aju"].Value = tipo_mov_ajust.Text;

                cmd.Parameters.Add(new SqlParameter("@status", SqlDbType.Int));
                cmd.Parameters["@status"].Value = 1;

                cmd.Parameters.Add(new SqlParameter("@fecha_act", SqlDbType.DateTime));
                cmd.Parameters["@fecha_act"].Value = String.Format("{0:yyyy/M/dd HH:mm:ss}", DateTime.Now);

                cmd.Parameters.Add(new SqlParameter("@id_user_act", SqlDbType.VarChar, 50));
                cmd.Parameters["@id_user_act"].Value = Request.Cookies["ID_AFILIACION"].Value;

                cmd.Parameters.Add(new SqlParameter("@Observa", SqlDbType.VarChar, 255));
                cmd.Parameters["@Observa"].Value = obser.Text;
                

                resul = cmd.ExecuteNonQuery();
                if (resul > 0)
                {
                    Labelmsj.Text = "<div class='alert alert-success alert-dismissable'>" +
                                  "<button type='button' class='close' data-dismiss='alert' aria-hidden='true'>×</button>" +
                                  "La información del asegurado " + nom_aseg.Text+ " con N.S.S. " + nss.Text + " se Actualizo correctamente. " +
                                  "</div>";
                    Response.AppendHeader("Refresh", 3 + "; URL=GridScac.aspx");
                }
            }
            catch (Exception Msj)
            {
                Labelmsj.Text = "<div class='alert alert-danger alert-dismissable'>" +
                                  "<button type='button' class='close' data-dismiss='alert' aria-hidden='true'>×</button>" +
                                  "" + Msj.Message +" " +
                                  "</div>";
            }
        }
    }
}