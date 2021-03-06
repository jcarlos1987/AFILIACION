﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPageSegEsp.master" AutoEventWireup="true" CodeFile="Reportes_Seguros_Especiales.aspx.cs" Inherits="SegEspe_Reportes_Seguros_Especiales" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.SqlClient" %>
<%@ Import Namespace="System.Configuration" %>
<%@ Import Namespace="System.Data.SqlClient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
   <link rel="stylesheet" href="../datatables/media/css/dataTables.bootstrap.min.css" />
   <link rel="stylesheet" href="../datatables/bootstrap.min.css" /> 
     <style type="text/css">
/*Estilo general para el gridView*/
.gridView {
margin:0 auto;
font-size:14px;
text-align:center;
border:hidden;
}
/*Selecciona las filas pares y las colorea*/
.gridView tr:nth-child(even)
{
background-color: #a9c673;
}
/*Selecciona las filas impares y las colorea*/
.gridView tr:nth-child(odd)
{
background-color: #fff;
}
/*Estilo para las casillas del gridView*/
.gridView td {
padding-left:3px;
padding-right:3px;
border: solid 1px #757575;
}
/*Color de fondo para la paginación*/
 
.gridViewPaginacion td {
background-color:#435B14;
border: hidden;
}
 
/*Bordes redondeados para la paginacion*/
 
.gridViewPaginacion > td{
border-radius:0px 0px 5px 5px;
border: hidden;
}
 
/*Centramos la tabla que contiene los enlaces para las paginas*/
 
.gridViewPaginacion table {
margin:3px auto;
border: hidden;
}
 
/*El span representa el enlace a la pagina en la que estamos actualmente*/
 
.gridViewPaginacion span {
display:block;
margin:0;
padding:5px;
width:20px;
height:20px;
border-radius:50% 50%;
background:#B1C689;
color:#3743a1;
border: hidden;
}
 
/*Estilo para los enlaces redondos*/
 
.gridViewPaginacion a {
display:block;
text-decoration:none;
margin:0;
padding:5px;
width:20px;
height:20px;
border-radius:50% 50%;
background:#367DEE;
color:#fff;
border: hidden;
}
 
.gridViewPaginacion a:hover {
display:block;
margin:0;
padding:5px;
width:18px;
height:18px;
border-radius:50% 50%;
background:#B1C689;
color:#3743a1;
box-shadow: 0 0 .5em rgba(0, 0, 0, .8);
 border: hidden;
}
.gridViewHeader{
height:35px;
}
 
.gridViewHeader th {
background-color:#435B14;
padding:5px;
border:solid 1px #757575;
color:#fff;
text-align:center; 
font-size:12px;
}
 
/*Redondeamos el borde superior izquierdo de la primera casilla del header*/
 
.gridViewHeader th:first-child {
border-radius:5px 0 0 0;
}
 
/*Y el borde superior derecho de la ultima casilla*/
 
.gridViewHeader th:last-child {
border-radius:0 5px 0 0;
}
 
/*Estilo para los enlaces del header...*/
 
.gridViewHeader th a {
padding:5px;
text-decoration:none;
color:#435B14;
background-color:#a9c673;
border-radius:5px;
}
 
.gridViewHeader th a:hover {
color:#435B14;
background-color:#B1C689;
box-shadow:0 0 .9em rgba(0, 0, 0, .8);
}
           </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Mesagge" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="menu" Runat="Server">
                    <li>
                        <a  href="../Menu/Default.aspx"><i class="fa fa-dashboard fa-spin"></i>Inicio</a>
                    </li>
                   <li>
                        <a  href="Menu_Seg_Esp.aspx"><i class="fa fa-dashboard fa-spin"></i>Seguros Especiales</a>
                   </li>


     <li>
        <a  href="Reportes_Seguros_Especiales.aspx"><i class="fa fa-building-o fa-spin"></i>Informes<span class="fa arrow"></span></a>
        <ul class="nav nav-second-level collapse in">  
            <li>
                <a class="active-menu" href="Reportes_Seguros_Especiales.aspx"><i class="fa fa-envelope-o fa-spin"></i>Informes por Modalidad</a>
            </li>
        </ul>
    </li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <div class="row">
                    <div class="col-md-12">
                         <img src="../assets/img/SISAV.png" width="150" align="right" class="img-rounded"/>
                        <h1 class="page-head-line" style="font-size:17px;">Informes por Modalidad</h1>                        
                    </div>
                </div>  

     <div class="panel-body">
                  <div class="form-group col-sm-6">
                      <label>Selecciona el Ciclo</label>
                                <asp:DropDownList ID="DropListCiclo"  Enabled="true" CssClass="form-control" runat="server">
                                    <asp:ListItem disabled selected Value="" Text=" -- Seleccione un Ciclo -- "></asp:ListItem> 
                                </asp:DropDownList>
                                        </div>

                           
                          
                    <div class="form-group col-sm-6">
                       <label>Seleccione la Subdelegación</label>
                         <asp:DropDownList ID="DropListSubdel" CssClass="form-control" Enabled="true" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropListSubdel_SelectedIndexChanged" >
                                    <asp:ListItem disabled selected Value="" Text=" -- Seleccione Una Opción -- "></asp:ListItem>
                                </asp:DropDownList>
                                        </div>
                           <hr>
                            <div class="form-group col-sm-6">
                                <asp:Button ID="btnReporte" CssClass="btn btn-success" runat="server" Text="Generar Reporte" OnClick="btnReporte_Click" />                              
                            </div>
         <div class="form-group col-sm-6">
             <asp:Label ID="LabelMensaje" runat="server" Text=""></asp:Label>
         </div>
     </div>
     <div class="row" id="div_Resumen" runat="server" visible="false">
                    <div class="col-md-12">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                Reporte por Modalidad Afil-67
                            </div>
                            <div class="panel-body">
                                
                                <asp:GridView ID="GridView1" runat="server" ShowFooter="true" AutoGenerateColumns="false" CssClass="gridView table table-responsive" HeaderStyle-CssClass="gridViewHeader" DataKeyNames="cve_modalidad, descripcion" PagerStyle-CssClass="gridViewPaginacion" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                                    <Columns>
                                        <asp:BoundField DataField="descripcion" ItemStyle-HorizontalAlign="Left" SortExpression="descripcion" HeaderText="Descripción de la Modalidad"><ItemStyle ForeColor="Black" /></asp:BoundField>
                                        <asp:BoundField DataField="CONTEO"  SortExpression="CONTEO" DataFormatString="{0:###,###}" ItemStyle-HorizontalAlign="Right" HeaderText="Número de Trabajadores"><ItemStyle ForeColor="Black"  /></asp:BoundField>
                                       <%-- <asp:TemplateField HeaderText="Ver Registros">
                                            <ItemStyle  HorizontalAlign="Center" Width="50px" /> 
                                            <ItemTemplate>
                                                <asp:LinkButton ID="Enviar" CommandName="Select" runat="server"><i class="fa fa-search-plus fa-2x" style="color: dodgerblue"></i></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                    </Columns>
                                </asp:GridView>

                                <hr />
                            </div>
                        </div>
                    </div>
      </div>
  
   
</asp:Content>

