<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterSaludTrab.master" AutoEventWireup="true" CodeFile="BanSalTrabajo.aspx.cs" Inherits="Casuistica_BanSalTrabajo" %>
<%@ Import Namespace="System.Configuration" %>
<%@ Import Namespace="System.Data.SqlClient" %>
<%@ Import Namespace="System.Data.Sql" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <!--PAGE LEVEL STYLES-->
    <link href="../assets/css/pricing.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Mesagge" Runat="Server">
     <a href="Coord_Del_Sal_Trab.aspx" class="btn btn-info" title="New Message"><b><% Response.Write(Bandeja("")); %> </b><i class="fa fa-envelope-o fa-2x"></i></a>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="menu" Runat="Server">
     <li>
        <a href="../Menu/Default.aspx"><i class="fa fa-dashboard fa-spin"></i>Inicio</a>
    </li>
    <li>
        <a  href="Default.aspx"><i class="fa fa-medkit fa-spin"></i>Casuistica</a>
    </li>
    <li>
        <a  href="#"><i class="fa fa-users fa-spin"></i>Coordinación Delegacional de Salud en el Trabajo<span class="fa arrow"></span></a>
        <ul class="nav nav-second-level collapse in">  
            <li>
                <a  href="Coord_Del_Sal_Trab.aspx"><i class="fa fa-envelope-o fa-spin"></i>Bandeja de Entrada</a>
            </li>
            <li>
                <a class="active-menu" href="BanSalTrabajo.aspx"><i class="fa fa-sign-out fa-spin"></i>Bandeja de Salida</a>
            </li> 
        </ul>
    </li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="row">
                    <div class="col-md-12">
                        <img src="../assets/img/SISAV.png" width="150" align="right" class="img-rounded"/>
                        <h1 class="page-head-line" style="font-size:15px;">Casuistica \ Coordinación Delegacional de Salud en el Trabajo \ BANDEJA DE SALIDA</h1>
                        <br />
                    </div>
                </div>

     <div class="row text-center pad-row">
         <asp:Label ID="Label1_msj" runat="server" Text=""></asp:Label>
         <%String strConnString = ConfigurationManager.ConnectionStrings["AfiliacionConnectionString"].ConnectionString;
           SqlConnection conn = new SqlConnection(strConnString);
           SqlCommand command = new SqlCommand("SELECT [id],[tipo],[fecha],[Ciclo],[Fecha_Carga],[Envio_Cl],[Envio_ST],[Envio_P],[No_Regis] FROM [Afiliacion].[dbo].[Crtl_SCAC] WHERE [Envio_ST] IN(1,0) AND [tipo]= 'SCAC-09' ORDER BY [Fecha_Carga]  DESC", conn);
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
                                    <li><i class="fa fa-clock-o"></i>Estatus : <strong> <% if (reader.GetInt32(7) == 0)
                                                                                           {
                                                                                               Response.Write("<div class='col-md-12'><div class='alert alert-info text-center'><i class='fa fa-spinner fa-spin fa-4x'></i>Pendiente</div></div>");
                                                                                           }
                                                                                           else if(reader.GetInt32(7) == 1)
                                                                                           {
                                                                                               Response.Write("<div class='col-md-12'><div class='alert alert-info text-center'><i class='fa fa-check-square-o fa-5x'></i>Enviado</div></div>");
                                                                                           }%> </strong></li>
                                </ul>
                            </div>
                            <div class="panel-footer">
                    <%
                        
                   if (reader.GetInt32(7) == 0)
                   {
                       if (Porcentaje(reader.GetString(3), reader.GetString(1)) == 100)
                       {
                           Response.Write("<a href='ValEnvTrabajo.aspx?id=" + reader.GetInt32(0) + "' class='btn btn-primary btn-block btn-lg adjust-border-radius'>VALIDAR</a>");
                       }
                       else if (Porcentaje(reader.GetString(3), reader.GetString(1)) != 100)
                       {
                           Response.Write("<a href='#' class='btn btn-primary btn-block btn-lg adjust-border-radius' disabled='disabled'>Pendiente</a>");
                       }
                   }
                   else if (reader.GetInt32(7) == 1)
                   {
                       if (Porcentaje(reader.GetString(3), reader.GetString(1)) == 100)
                       {
                           Response.Write("<a href='#' class='btn btn-primary btn-block btn-lg adjust-border-radius' disabled='disabled'>VALIDADO</a>");
                       }
                       else if (Porcentaje(reader.GetString(3), reader.GetString(1)) != 100)
                       {
                           Response.Write("<a href='#' class='btn btn-primary btn-block btn-lg adjust-border-radius' disabled='disabled'>Pendiente</a>");
                       }
                   }
                   %>
                                
                            </div>
                        </div>
                    </div>
           <%
                }
            } %>
</asp:Content>

