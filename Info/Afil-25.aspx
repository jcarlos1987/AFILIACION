<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterAdmonInfo.master" AutoEventWireup="true" CodeFile="Afil-25.aspx.cs" Inherits="Info_Afil_25" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
      <style type="text/css">
/*Estilo general para el gridView*/
.gridView {
margin:0 auto;
font-size:14px;
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
        <a href="../Menu/Default.aspx"><i class="fa fa-dashboard fa-spin"></i>Inicio</a>
    </li>
    <li>
        <a  href="#"><i class="fa fa-building-o fa-spin"></i>Admon. Información<span class="fa arrow"></span></a>
        <ul class="nav nav-second-level collapse in">  
            <li>
                <a  href="afil-67.aspx"><i class="fa fa-envelope-o fa-spin"></i>Afil-67</a>
            </li>
            <li>
                <a href="#">Afil-25<span class="fa arrow"></span></a>
                <ul class="nav nav-third-level collapse in">
                    <li>
                        <a class="active-menu" href="Afil-25.aspx"><i class="fa fa-envelope-o fa-spin"></i>Cargar Afil-25</a>
                    </li>
                    <li>
                        <a href="DescargarAfil25.aspx"><i class="fa fa-comments-o "></i>Descargar Afil-25 </a>
                    </li>
                </ul>
            </li>
        </ul>
    </li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row">
        <div class="col-md-12">
            <img src="../assets/img/SISAV.png" width="150" align="right" class="img-rounded"/>
            <h1 class="page-head-line" style="font-size:15px;">Administración de Información\ Afil-25 </h1>
            <br />
        </div>
    </div>
    
    <div class="col-md-12 col-sm-12 col-xs-12">
        <div class="panel panel-primary">
            <div class="panel-heading">
                Carga del Afil-25
            </div>
            <div class="panel-body">
                <div class="form-group col-sm-6">
                    <label>Selecciona el archivo .zip</label>
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </div>
                <div class="form-group col-sm-6">
                    <asp:Button ID="Button1" runat="server" CssClass="btn btn-success" Text="Aceptar" OnClick="Button1_Click"  />
                </div>
                <div class="form-group col-sm-6">
                    <asp:Label ID="LabelMensaje" runat="server" Text="" ></asp:Label>
                </div>
                <div  class="row pad-top-botm client-info">
                    <div class="col-lg-12 col-md-12 col-sm-12">
                        <h4>
                            <strong>
                            </strong>
                        </h4>
                        <a href="#" class="list-group-item">
                            <i class="fa fa-table fa-2x"></i> <strong>  Información detallada del AFIL-25</strong>
                               <asp:GridView ID="GridView1" AllowPaging="true" AutoGenerateColumns="false"  CssClass="gridView table table-responsive" HeaderStyle-CssClass="gridViewHeader" PagerStyle-CssClass="gridViewPaginacion" runat="server" OnPageIndexChanging="GridView1_PageIndexChanging">
                <Columns>
                    <asp:BoundField DataField="ciclo"  SortExpression="ciclo" HeaderText="Número de Ciclo" DataFormatString="{0:000}"  ItemStyle-HorizontalAlign="Center"><ItemStyle ForeColor="Black" Width="20px" /></asp:BoundField>
                    <asp:BoundField DataField="fechaCiclo"  SortExpression="fechaCiclo" DataFormatString="{0:dd/MM/yyyy}"  ItemStyle-HorizontalAlign="Center" HeaderText="Fecha del Ciclo"><ItemStyle ForeColor="Black" Width="20px" /></asp:BoundField>
                    <asp:BoundField DataField="fechaCarga"  SortExpression="fechaCarga"  DataFormatString="{0:dd/MM/yyyy}"  ItemStyle-HorizontalAlign="Center" HeaderText="Fecha de Carga"><ItemStyle ForeColor="Black" Width="20px" /></asp:BoundField>
                    <asp:BoundField DataField="numRegistros"  SortExpression="numRegistros" DataFormatString="{0:###,###}" ItemStyle-HorizontalAlign="Right" HeaderText="Total de Registros"><ItemStyle ForeColor="Black" Width="20px" /></asp:BoundField>
                    <asp:BoundField DataField="NumGuias"  SortExpression="NumGuias" HeaderText="N° de Guias"  ItemStyle-HorizontalAlign="Right"><ItemStyle ForeColor="Black" Width="20px" /></asp:BoundField>
                    <asp:BoundField DataField="anio"  SortExpression="anio"  HeaderText="Año"  ItemStyle-HorizontalAlign="Center"><ItemStyle ForeColor="Black" Width="20px" /></asp:BoundField>
                </Columns>
            </asp:GridView>
                        </a>
                    </div>
                </div>
            </div>
         
        </div>
    </div>

</asp:Content>

