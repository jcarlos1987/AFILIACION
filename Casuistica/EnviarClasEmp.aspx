<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterClasEmpre.master" AutoEventWireup="true" CodeFile="EnviarClasEmp.aspx.cs" Inherits="Casuistica_EnviarClasEmp" %>
<%@ Import Namespace="System.Configuration" %>
<%@ Import Namespace="System.Data.SqlClient" %>
<%@ Import Namespace="System.Data.Sql" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
      <!--PAGE LEVEL STYLES-->
    <link href="../assets/css/pricing.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="menu" Runat="Server">
    <li>
        <a href="../Menu/Default.aspx"><i class="fa fa-dashboard fa-spin"></i>Inicio</a>
    </li>
    <li>
        <a  href="Default.aspx"><i class="fa fa-medkit fa-spin"></i>Casuistica</a>
    </li>
    <li>
        <a  href="#"><i class="fa fa-building-o fa-spin"></i>Clasificación de Empresas<span class="fa arrow"></span></a>
        <ul class="nav nav-second-level collapse in">  
            <li>
                <a  href="Clasificacion_de_empresas.aspx"><i class="fa fa-envelope-o fa-spin"></i>Bandeja de Entrada</a>
            </li>
            <li>
                <a class="active-menu" href="EnviarClasEmp.aspx"><i class="fa fa-sign-out fa-spin"></i>Bandeja de Salida</a>
            </li> 
             <li>
                <a href="Reporte.aspx"><i class="fa fa-file-pdf-o fa-spin"></i>Reporte de SCAC</a>
            </li>  
        </ul>
    </li>
    <li>
        <a href="#" ><i class="fa fa-upload fa-spin"></i>Carga Información  <span class="fa arrow"></span></a>
        <ul class="nav nav-second-level"> 
            <li>
                <a href="Cga_scac10.aspx"><i class="fa fa-cloud-upload fa-spin"></i>SCAC-09 y SCAC-10</a>
            </li>
        </ul>
    </li>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Mesagge" Runat="Server">
    <a href="Clasificacion_de_empresas.aspx" class="btn btn-info" title="New Message"><b><% Response.Write(Bandeja("")); %> </b><i class="fa fa-envelope-o fa-2x"></i></a>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row">
                    <div class="col-md-12">
                        <img src="../assets/img/SISAV.png" width="150" align="right" class="img-rounded"/>
                        <h1 class="page-head-line" style="font-size:15px;">Casuistica \ CLASIFICACIÓN DE EMPRESAS \ BANDEJA DE SALIDA</h1>
                        <br />
                    </div>
                </div>

     <div class="row text-center pad-row">
         <asp:Label ID="Label1_msj" runat="server" Text=""></asp:Label>
         <%
           SqlConnection conn = new SqlConnection(strConnString);
           SqlCommand command = new SqlCommand("SELECT TOP 30 [id],[tipo],[fecha],[Ciclo],[Fecha_Carga],[Envio_Cl],[Envio_ST],[Envio_P],[No_Regis] FROM [Afiliacion].[dbo].[Crtl_SCAC] WHERE [Envio_Cl] IN(1,0) ORDER BY [Fecha_Carga]  DESC", conn);
           conn.Open();
           SqlDataReader reader = command.ExecuteReader();
           if (reader.HasRows)
           {
               while (reader.Read())
               {                   
           %>
             <div class="col-md-4">
                 <%if (reader.GetString(1).Trim() == "SCAC-09")
                   {
                       Response.Write("<div class='panel normal-table panel-primary adjust-border-radius'>");
                   }
                   else if (reader.GetString(1).Trim() == "SCAC-10")
                   {
                       Response.Write("<div class='panel normal-table panel-success adjust-border-radius'>");
                   } 
                   %>
                            <div class="panel-heading adjust-border">
                                <h4>Ciclo <% Response.Write(reader.GetString(3)); %></h4>
                            </div>
                            <div class="panel-body">

                                <ul class="plan">
                                    <li class="price"> <% Response.Write(reader.GetString(1)); %> </li>
                                    <li><i class="fa fa-calendar-o"></i>Fecha de Carga:  <strong><% Response.Write(reader.GetDateTime(4)); %> </strong></li>
                                    <li><i class="fa fa-calendar"></i>Fecha del Archivo : <strong><% Response.Write(String.Format("{0:dd/MM/yyyy}",reader.GetDateTime(2))); %> </strong></li>
                                    <li><i class="fa fa-pencil-square"></i>No. de Registros : <strong><% Response.Write(reader.GetInt32(8)); %></strong></li>
                                    <li><i class="fa fa-percent"></i>Porcentaje de corrección: <br />
                                         <% if (Porcentaje(reader.GetString(3), reader.GetString(1)) >= 0 && Porcentaje(reader.GetString(3), reader.GetString(1)) <= 2.5)
                                           { %>
                                            <i class="fa fa-star-o fa-2x" style="color:#F5B639"></i><i class="fa fa-star-o fa-2x" style="color:#F5B639"></i><i class="fa fa-star-o fa-2x" style="color:#F5B639"></i> <i class="fa fa-star-o fa-2x" style="color:#F5B639"></i><i class="fa fa-star-o fa-2x" style="color:#F5B639"></i>
                                            <i class="fa fa-star-o fa-2x" style="color:#F5B639"></i><i class="fa fa-star-o fa-2x" style="color:#F5B639"></i><i class="fa fa-star-o fa-2x" style="color:#F5B639"></i><i class="fa fa-star-o fa-2x" style="color:#F5B639"></i><i class="fa fa-star-o fa-2x" style="color:#F5B639"></i>
                                        <% }
                                           else if (Porcentaje(reader.GetString(3), reader.GetString(1)) >=2.5 && Porcentaje(reader.GetString(3), reader.GetString(1)) <= 5)
                                           { %>
                                            <i class="fa fa-star-half-empty fa-2x" style="color:#F5B639"></i><i class="fa fa-star-o fa-2x" style="color:#F5B639"></i><i class="fa fa-star-o fa-2x" style="color:#F5B639"></i> <i class="fa fa-star-o fa-2x" style="color:#F5B639"></i><i class="fa fa-star-o fa-2x" style="color:#F5B639"></i>
                                            <i class="fa fa-star-o fa-2x" style="color:#F5B639"></i><i class="fa fa-star-o fa-2x" style="color:#F5B639"></i><i class="fa fa-star-o fa-2x" style="color:#F5B639"></i><i class="fa fa-star-o fa-2x" style="color:#F5B639"></i><i class="fa fa-star-o fa-2x" style="color:#F5B639"></i>
                                        <% }
                                           else if (Porcentaje(reader.GetString(3), reader.GetString(1)) >= 5 && Porcentaje(reader.GetString(3), reader.GetString(1)) <= 10)
                                           {%>
                                            <i class="fa fa-star fa-2x" style="color:#F5B639"></i><i class="fa fa-star-o fa-2x" style="color:#F5B639"></i><i class="fa fa-star-o fa-2x" style="color:#F5B639"></i> <i class="fa fa-star-o fa-2x" style="color:#F5B639"></i><i class="fa fa-star-o fa-2x" style="color:#F5B639"></i>
                                            <i class="fa fa-star-o fa-2x" style="color:#F5B639"></i><i class="fa fa-star-o fa-2x" style="color:#F5B639"></i><i class="fa fa-star-o fa-2x" style="color:#F5B639"></i><i class="fa fa-star-o fa-2x" style="color:#F5B639"></i><i class="fa fa-star-o fa-2x" style="color:#F5B639"></i>
                                        <% }
                                           else if (Porcentaje(reader.GetString(3), reader.GetString(1)) >= 10 && Porcentaje(reader.GetString(3), reader.GetString(1)) <= 15)
                                           { %>
                                            <i class="fa fa-star fa-2x" style="color:#F5B639"></i><i class="fa fa-star-half-empty fa-2x" style="color:#F5B639"></i><i class="fa fa-star-o fa-2x" style="color:#F5B639"></i> <i class="fa fa-star-o fa-2x" style="color:#F5B639"></i><i class="fa fa-star-o fa-2x" style="color:#F5B639"></i>
                                            <i class="fa fa-star-o fa-2x" style="color:#F5B639"></i><i class="fa fa-star-o fa-2x" style="color:#F5B639"></i><i class="fa fa-star-o fa-2x" style="color:#F5B639"></i><i class="fa fa-star-o fa-2x" style="color:#F5B639"></i><i class="fa fa-star-o fa-2x" style="color:#F5B639"></i>
                                        <% }
                                           else if (Porcentaje(reader.GetString(3), reader.GetString(1)) >= 15 && Porcentaje(reader.GetString(3), reader.GetString(1)) <= 20)
                                           { %>
                                            <i class="fa fa-star fa-2x" style="color:#F5B639"></i><i class="fa fa-star fa-2x" style="color:#F5B639"></i><i class="fa fa-star-o fa-2x" style="color:#F5B639"></i> <i class="fa fa-star-o fa-2x" style="color:#F5B639"></i><i class="fa fa-star-o fa-2x" style="color:#F5B639"></i>
                                            <i class="fa fa-star-o fa-2x" style="color:#F5B639"></i><i class="fa fa-star-o fa-2x" style="color:#F5B639"></i><i class="fa fa-star-o fa-2x" style="color:#F5B639"></i><i class="fa fa-star-o fa-2x" style="color:#F5B639"></i><i class="fa fa-star-o fa-2x" style="color:#F5B639"></i>
                                        <% }
                                           else if (Porcentaje(reader.GetString(3), reader.GetString(1)) >= 20 && Porcentaje(reader.GetString(3), reader.GetString(1)) <= 25)
                                           { %>
                                            <i class="fa fa-star fa-2x" style="color:#F5B639"></i><i class="fa fa-star fa-2x" style="color:#F5B639"></i><i class="fa fa-star-half-empty fa-2x" style="color:#F5B639"></i> <i class="fa fa-star-o fa-2x" style="color:#F5B639"></i><i class="fa fa-star-o fa-2x" style="color:#F5B639"></i>
                                            <i class="fa fa-star-o fa-2x" style="color:#F5B639"></i><i class="fa fa-star-o fa-2x" style="color:#F5B639"></i><i class="fa fa-star-o fa-2x" style="color:#F5B639"></i><i class="fa fa-star-o fa-2x" style="color:#F5B639"></i><i class="fa fa-star-o fa-2x" style="color:#F5B639"></i>
                                        <% }
                                           else if (Porcentaje(reader.GetString(3), reader.GetString(1)) >= 25 && Porcentaje(reader.GetString(3), reader.GetString(1)) <= 30)
                                           { %>
                                            <i class="fa fa-star fa-2x" style="color:#F5B639"></i><i class="fa fa-star fa-2x" style="color:#F5B639"></i><i class="fa fa-star fa-2x" style="color:#F5B639"></i> <i class="fa fa-star-o fa-2x" style="color:#F5B639"></i><i class="fa fa-star-o fa-2x" style="color:#F5B639"></i>
                                            <i class="fa fa-star-o fa-2x" style="color:#F5B639"></i><i class="fa fa-star-o fa-2x" style="color:#F5B639"></i><i class="fa fa-star-o fa-2x" style="color:#F5B639"></i><i class="fa fa-star-o fa-2x" style="color:#F5B639"></i><i class="fa fa-star-o fa-2x" style="color:#F5B639"></i>
                                        <% }
                                           else if (Porcentaje(reader.GetString(3), reader.GetString(1)) >= 30 && Porcentaje(reader.GetString(3), reader.GetString(1)) <= 35)
                                           { %>
                                            <i class="fa fa-star fa-2x" style="color:#F5B639"></i><i class="fa fa-star fa-2x" style="color:#F5B639"></i><i class="fa fa-star fa-2x" style="color:#F5B639"></i> <i class="fa fa-star-half-empty fa-2x" style="color:#F5B639"></i><i class="fa fa-star-o fa-2x" style="color:#F5B639"></i>
                                            <i class="fa fa-star-o fa-2x" style="color:#F5B639"></i><i class="fa fa-star-o fa-2x" style="color:#F5B639"></i><i class="fa fa-star-o fa-2x" style="color:#F5B639"></i><i class="fa fa-star-o fa-2x" style="color:#F5B639"></i><i class="fa fa-star-o fa-2x" style="color:#F5B639"></i>
                                        <% }
                                           else if (Porcentaje(reader.GetString(3), reader.GetString(1)) >= 35 && Porcentaje(reader.GetString(3), reader.GetString(1)) <= 40)
                                           { %>
                                            <i class="fa fa-star fa-2x" style="color:#F5B639"></i><i class="fa fa-star fa-2x" style="color:#F5B639"></i><i class="fa fa-star fa-2x" style="color:#F5B639"></i> <i class="fa fa-star fa-2x" style="color:#F5B639"></i><i class="fa fa-star-o fa-2x" style="color:#F5B639"></i>
                                            <i class="fa fa-star-o fa-2x" style="color:#F5B639"></i><i class="fa fa-star-o fa-2x" style="color:#F5B639"></i><i class="fa fa-star-o fa-2x" style="color:#F5B639"></i><i class="fa fa-star-o fa-2x" style="color:#F5B639"></i><i class="fa fa-star-o fa-2x" style="color:#F5B639"></i>
                                        <% }
                                           else if (Porcentaje(reader.GetString(3), reader.GetString(1)) >= 40 && Porcentaje(reader.GetString(3), reader.GetString(1)) <= 45)
                                           { %>
                                            <i class="fa fa-star fa-2x" style="color:#F5B639"></i><i class="fa fa-star fa-2x" style="color:#F5B639"></i><i class="fa fa-star fa-2x" style="color:#F5B639"></i> <i class="fa fa-star fa-2x" style="color:#F5B639"></i><i class="fa fa-star-half-empty fa-2x" style="color:#F5B639"></i>
                                            <i class="fa fa-star-o fa-2x" style="color:#F5B639"></i><i class="fa fa-star-o fa-2x" style="color:#F5B639"></i><i class="fa fa-star-o fa-2x" style="color:#F5B639"></i><i class="fa fa-star-o fa-2x" style="color:#F5B639"></i><i class="fa fa-star-o fa-2x" style="color:#F5B639"></i>
                                        <% }
                                           else if (Porcentaje(reader.GetString(3), reader.GetString(1)) >= 45 && Porcentaje(reader.GetString(3), reader.GetString(1)) <= 50)
                                           { %>
                                            <i class="fa fa-star fa-2x" style="color:#F5B639"></i><i class="fa fa-star fa-2x" style="color:#F5B639"></i><i class="fa fa-star fa-2x" style="color:#F5B639"></i> <i class="fa fa-star fa-2x" style="color:#F5B639"></i><i class="fa fa-star fa-2x" style="color:#F5B639"></i>
                                            <i class="fa fa-star-o fa-2x" style="color:#F5B639"></i><i class="fa fa-star-o fa-2x" style="color:#F5B639"></i><i class="fa fa-star-o fa-2x" style="color:#F5B639"></i><i class="fa fa-star-o fa-2x" style="color:#F5B639"></i><i class="fa fa-star-o fa-2x" style="color:#F5B639"></i>
                                        <% }
                                           else if (Porcentaje(reader.GetString(3), reader.GetString(1)) >= 50 && Porcentaje(reader.GetString(3), reader.GetString(1)) <= 55)
                                           { %>
                                            <i class="fa fa-star fa-2x" style="color:#F5B639"></i><i class="fa fa-star fa-2x" style="color:#F5B639"></i><i class="fa fa-star fa-2x" style="color:#F5B639"></i> <i class="fa fa-star fa-2x" style="color:#F5B639"></i><i class="fa fa-star fa-2x" style="color:#F5B639"></i>
                                            <i class="fa fa-star-half-empty fa-2x" style="color:#F5B639"></i><i class="fa fa-star-o fa-2x" style="color:#F5B639"></i><i class="fa fa-star-o fa-2x" style="color:#F5B639"></i><i class="fa fa-star-o fa-2x" style="color:#F5B639"></i><i class="fa fa-star-o fa-2x" style="color:#F5B639"></i>
                                        <% }
                                           else if (Porcentaje(reader.GetString(3), reader.GetString(1)) >= 55 && Porcentaje(reader.GetString(3), reader.GetString(1)) <= 60)
                                           { %>
                                            <i class="fa fa-star fa-2x" style="color:#F5B639"></i><i class="fa fa-star fa-2x" style="color:#F5B639"></i><i class="fa fa-star fa-2x" style="color:#F5B639"></i> <i class="fa fa-star fa-2x" style="color:#F5B639"></i><i class="fa fa-star fa-2x" style="color:#F5B639"></i>
                                            <i class="fa fa-star fa-2x" style="color:#F5B639"></i><i class="fa fa-star-o fa-2x" style="color:#F5B639"></i><i class="fa fa-star-o fa-2x" style="color:#F5B639"></i><i class="fa fa-star-o fa-2x" style="color:#F5B639"></i><i class="fa fa-star-o fa-2x" style="color:#F5B639"></i>
                                       <% }
                                           else if (Porcentaje(reader.GetString(3), reader.GetString(1)) >= 60 && Porcentaje(reader.GetString(3), reader.GetString(1)) <= 65)
                                           { %>
                                            <i class="fa fa-star fa-2x" style="color:#F5B639"></i><i class="fa fa-star fa-2x" style="color:#F5B639"></i><i class="fa fa-star fa-2x" style="color:#F5B639"></i> <i class="fa fa-star fa-2x" style="color:#F5B639"></i><i class="fa fa-star fa-2x" style="color:#F5B639"></i>
                                            <i class="fa fa-star fa-2x" style="color:#F5B639"></i><i class="fa fa-star-half-empty fa-2x" style="color:#F5B639"></i><i class="fa fa-star-o fa-2x" style="color:#F5B639"></i><i class="fa fa-star-o fa-2x" style="color:#F5B639"></i><i class="fa fa-star-o fa-2x" style="color:#F5B639"></i>
                                        <% }
                                           else if (Porcentaje(reader.GetString(3), reader.GetString(1)) >= 65 && Porcentaje(reader.GetString(3), reader.GetString(1)) <= 70)
                                           { %>
                                            <i class="fa fa-star fa-2x" style="color:#F5B639"></i><i class="fa fa-star fa-2x" style="color:#F5B639"></i><i class="fa fa-star fa-2x" style="color:#F5B639"></i> <i class="fa fa-star fa-2x" style="color:#F5B639"></i><i class="fa fa-star fa-2x" style="color:#F5B639"></i>
                                            <i class="fa fa-star fa-2x" style="color:#F5B639"></i><i class="fa fa-star fa-2x" style="color:#F5B639"></i><i class="fa fa-star-o fa-2x" style="color:#F5B639"></i><i class="fa fa-star-o fa-2x" style="color:#F5B639"></i><i class="fa fa-star-o fa-2x" style="color:#F5B639"></i>
                                        <% }
                                           else if (Porcentaje(reader.GetString(3), reader.GetString(1)) >= 70 && Porcentaje(reader.GetString(3), reader.GetString(1)) <= 75)
                                           { %>
                                            <i class="fa fa-star fa-2x" style="color:#F5B639"></i><i class="fa fa-star fa-2x" style="color:#F5B639"></i><i class="fa fa-star fa-2x" style="color:#F5B639"></i> <i class="fa fa-star fa-2x" style="color:#F5B639"></i><i class="fa fa-star fa-2x" style="color:#F5B639"></i>
                                            <i class="fa fa-star fa-2x" style="color:#F5B639"></i><i class="fa fa-star fa-2x" style="color:#F5B639"></i><i class="fa fa-star-half-empty fa-2x" style="color:#F5B639"></i><i class="fa fa-star-o fa-2x" style="color:#F5B639"></i><i class="fa fa-star-o fa-2x" style="color:#F5B639"></i>
                                       <% }
                                           else if (Porcentaje(reader.GetString(3), reader.GetString(1)) >= 75 && Porcentaje(reader.GetString(3), reader.GetString(1)) <= 80)
                                           { %>
                                            <i class="fa fa-star fa-2x" style="color:#F5B639"></i><i class="fa fa-star fa-2x" style="color:#F5B639"></i><i class="fa fa-star fa-2x" style="color:#F5B639"></i> <i class="fa fa-star fa-2x" style="color:#F5B639"></i><i class="fa fa-star fa-2x" style="color:#F5B639"></i>
                                            <i class="fa fa-star fa-2x" style="color:#F5B639"></i><i class="fa fa-star fa-2x" style="color:#F5B639"></i><i class="fa fa-star fa-2x" style="color:#F5B639"></i><i class="fa fa-star-o fa-2x" style="color:#F5B639"></i><i class="fa fa-star-o fa-2x" style="color:#F5B639"></i>
                                        <% }
                                           else if (Porcentaje(reader.GetString(3), reader.GetString(1)) >= 80 && Porcentaje(reader.GetString(3), reader.GetString(1)) <= 85)
                                           { %>
                                            <i class="fa fa-star fa-2x" style="color:#F5B639"></i><i class="fa fa-star fa-2x" style="color:#F5B639"></i><i class="fa fa-star fa-2x" style="color:#F5B639"></i> <i class="fa fa-star fa-2x" style="color:#F5B639"></i><i class="fa fa-star fa-2x" style="color:#F5B639"></i>
                                            <i class="fa fa-star fa-2x" style="color:#F5B639"></i><i class="fa fa-star fa-2x" style="color:#F5B639"></i><i class="fa fa-star fa-2x" style="color:#F5B639"></i><i class="fa fa-star-half-empty fa-2x" style="color:#F5B639"></i><i class="fa fa-star-o fa-2x" style="color:#F5B639"></i>
                                        <% }
                                           else if (Porcentaje(reader.GetString(3), reader.GetString(1)) >= 85 && Porcentaje(reader.GetString(3), reader.GetString(1)) <= 90)
                                           { %>
                                            <i class="fa fa-star fa-2x" style="color:#F5B639"></i><i class="fa fa-star fa-2x" style="color:#F5B639"></i><i class="fa fa-star fa-2x" style="color:#F5B639"></i> <i class="fa fa-star fa-2x" style="color:#F5B639"></i><i class="fa fa-star fa-2x" style="color:#F5B639"></i>
                                            <i class="fa fa-star fa-2x" style="color:#F5B639"></i><i class="fa fa-star fa-2x" style="color:#F5B639"></i><i class="fa fa-star fa-2x" style="color:#F5B639"></i><i class="fa fa-star fa-2x" style="color:#F5B639"></i><i class="fa fa-star-o fa-2x" style="color:#F5B639"></i>
                                        <% }
                                           else if (Porcentaje(reader.GetString(3), reader.GetString(1)) >= 90 && Porcentaje(reader.GetString(3), reader.GetString(1)) <= 99)
                                           { %>
                                            <i class="fa fa-star fa-2x" style="color:#F5B639"></i><i class="fa fa-star fa-2x" style="color:#F5B639"></i><i class="fa fa-star fa-2x" style="color:#F5B639"></i> <i class="fa fa-star fa-2x" style="color:#F5B639"></i><i class="fa fa-star fa-2x" style="color:#F5B639"></i>
                                            <i class="fa fa-star fa-2x" style="color:#F5B639"></i><i class="fa fa-star fa-2x" style="color:#F5B639"></i><i class="fa fa-star fa-2x" style="color:#F5B639"></i><i class="fa fa-star fa-2x"  style="color:#F5B639"></i><i class="fa fa-star-half-empty fa-2x" style="color:#F5B639"></i>
                                        <% }
                                           else if (Porcentaje(reader.GetString(3), reader.GetString(1)) == 100)
                                           { %>
                                            <i class="fa fa-star fa-2x" style="color:#F5B639"></i><i class="fa fa-star fa-2x" style="color:#F5B639"></i><i class="fa fa-star fa-2x" style="color:#F5B639"></i> <i class="fa fa-star fa-2x" style="color:#F5B639"></i><i class="fa fa-star fa-2x" style="color:#F5B639"></i>
                                            <i class="fa fa-star fa-2x" style="color:#F5B639"></i><i class="fa fa-star fa-2x" style="color:#F5B639"></i><i class="fa fa-star fa-2x" style="color:#F5B639"></i><i class="fa fa-star fa-2x" style="color:#F5B639"></i><i class="fa fa-star fa-2x" style="color:#F5B639"></i>
                                        <% } %>


                                    </li>
                                    <%if (Excel(reader.GetString(3), reader.GetString(1)) == 1)
                                      { %>
                                    <li><i class="fa fa-code"></i>Comparar Archivos: <br />
                                       <% Response.Write("<a href='Compara.aspx?id=" + reader.GetInt32(0) + "' ><i class='fa fa-exchange fa-2x' ></i></a>");%>
                                    </li>
                                    <%} %>
                                    <li><i class="fa fa-clock-o"></i>Estatus : <strong> <% if (reader.GetInt32(5) == 0)
                                                                                           {
                                                                                               Response.Write("<div class='col-md-12'><div class='alert alert-info text-center'><i class='fa fa-spinner fa-spin fa-4x'></i>Pendiente</div></div>");
                                                                                           }
                                                                                           else if(reader.GetInt32(5) == 1)
                                                                                           {
                                                                                               Response.Write("<div class='col-md-12'><div class='alert alert-info text-center'><i class='fa fa-check-square-o fa-5x'></i>Enviado</div></div>");
                                                                                           }%> </strong></li>
                                </ul>
                            </div>
                            <div class="panel-footer">
                    <%
                   if (reader.GetInt32(5) == 0)
                   {
                       if (reader.GetString(1).Trim() == "SCAC-09")
                       {
                           Response.Write("<a href='Val_Envi.aspx?id=" + reader.GetInt32(0) + "' class='btn btn-primary btn-block btn-lg adjust-border-radius' >VALIDAR</a>");
                       }
                       else if (reader.GetString(1).Trim() == "SCAC-10")
                       {
                           Response.Write("<a href='Val_Envi.aspx?id=" + reader.GetInt32(0) + "' class='btn btn-success btn-block btn-lg adjust-border-radius'>VALIDAR</a>");
                       }
                   }
                   else if (reader.GetInt32(5) == 1)
                   {
                       if (reader.GetString(1).Trim() == "SCAC-09")
                       {
                           Response.Write("<a href='#' class='btn btn-primary btn-block btn-lg adjust-border-radius' disabled='disabled'>VALIDADO</a>");
                       }
                       else if (reader.GetString(1).Trim() == "SCAC-10")
                       {
                           Response.Write("<a href='#' class='btn btn-success btn-block btn-lg adjust-border-radius' disabled='disabled'>VALIDADO</a>");
                       }
                   }
                   %>
                                
                            </div>
                        </div><!--col-md-4-->
                    </div>
           <%
                }
            }
               conn.Close();
                %>
<%--          <div class="row text-center pad-row">
    <div class="col-md-3">
                    <div class="panel normal-table panel-primary adjust-border-radius">
                        <div class="panel-heading adjust-border">
                            <h4>MEDIUM PLAN</h4>
                        </div>
                        <div class="panel-body">

                            <ul class="plan">
                                <li class="price"><strong>45</strong> <i class="fa fa-dollar"></i><small>/ month</small></li>
                                <li><i class="fa fa-paper-plane-o"></i><strong>1500 </strong>Emails Accounts</li>
                                <li><i class="fa fa-graduation-cap"></i><strong>5000 GB </strong>Cloud Space</li>
                                <li><i class="fa fa-bolt"></i><strong>5000 GB </strong>Cloud Space</li>
                                <li><i class="fa fa-bars"></i><strong>230 </strong>Support Queries </li>
                            </ul>
                        </div>
                        <div class="panel-footer">
                            <a href="#" class="btn btn-primary btn-block btn-lg adjust-border-radius">BUY NOW</a>
                        </div>
                    </div>
                </div>

         </div>--%>
</asp:Content>

