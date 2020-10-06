<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPersonal.master" AutoEventWireup="true" CodeFile="Depto_Perso.aspx.cs" Inherits="Casuistica_Depto_Perso" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
            <style type="text/css">
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

<asp:Content ID="Content4" ContentPlaceHolderID="Mesagge" Runat="Server">
     <a href="Depto_Perso.aspx" class="btn btn-info" title="New Message"><b><% Response.Write(Bandeja("")); %> </b><i class="fa fa-envelope-o fa-2x"></i></a>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="menu" Runat="Server">
     <li>
        <a href="../Menu/Default.aspx"><i class="fa fa-dashboard fa-spin"></i>Inicio</a>
    </li>
    <li>
        <a  href="Default.aspx"><i class="fa fa-medkit fa-spin"></i>Casuistica</a>
    </li>
    <li>
        <a  href="#"><i class="fa fa-users fa-spin"></i>Departamento de Personal<span class="fa arrow"></span></a>
        <ul class="nav nav-second-level collapse in">  
            <li>
                <a class="active-menu" href="Depto_Perso.aspx"><i class="fa fa-envelope-o fa-spin"></i>Bandeja de Entrada</a>
            </li>
            <li>
                <a href="BanSalDptoPrnal.aspx"><i class="fa fa-sign-out fa-spin"></i>Bandeja de Salida</a>
            </li> 
        </ul>
    </li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
         <div class="row">
                    <div class="col-md-12">
                        <img src="../assets/img/SISAV.png" width="150" align="right" class="img-rounded"/>
                        <h1 class="page-head-line" style="font-size:15px;">Casuistica \ Departamento de Personal \ Bandeja de Entrada</h1>
                        <br />
                    </div>
                </div>
     <div class="bd-example">
         <div class="table-responsive">
             <asp:GridView ID="GridView1" CssClass="table" HeaderStyle-CssClass="gridViewHeader" DataKeyNames="id" runat="server" PagerStyle-CssClass="gridViewPaginacion" AllowPaging="true" AutoGenerateColumns="false" OnRowDataBound="GridView1_RowDataBound" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="14">
                 <Columns>
                      <asp:BoundField DataField="tipo"  SortExpression="tipo" HeaderText="Tipo de Producto"><ItemStyle ForeColor="Black" Width="130px" /></asp:BoundField>
                      <asp:BoundField DataField="Ciclo"  SortExpression="Ciclo" HeaderText="Ciclo"><ItemStyle ForeColor="Black" Width="100px" /></asp:BoundField>
                     <asp:BoundField DataField="mensaje"  SortExpression="mensaje" HeaderText="Asunto"><ItemStyle ForeColor="Black"  Width="1000px" /></asp:BoundField>
                     <asp:BoundField DataField="Fech_Envio"  SortExpression="Fech_Envio" HeaderText="Fecha de Recepcion" DataFormatString="{0:yyyy/MM/dd HH:mm:ss}" ><ItemStyle ForeColor="Black"  Width="160px" /></asp:BoundField>
                     <asp:BoundField DataField="Envio"  SortExpression="Envio" HeaderText="Antigüedad"><ItemStyle ForeColor="Black"  Width="150px" /></asp:BoundField>                     
                     <asp:TemplateField HeaderText="Ver">
                        <ItemStyle  HorizontalAlign="Center" Width="50px" /> 
                        <ItemTemplate>
                            <asp:LinkButton ID="Enviar" CommandName="Select"  runat="server"><i class="fa fa-envelope-o fa-2x"></i></asp:LinkButton>
                        </ItemTemplate>
                     </asp:TemplateField>
                     <asp:BoundField DataField="leer" ><ItemStyle ForeColor="Black" Font-Size="0px" Width="1px" /></asp:BoundField>
                 </Columns>
                  <RowStyle Font-Size="11px" />
             </asp:GridView>
         </div>
     </div>
    <asp:Label ID="LabelMensaje" runat="server" Text=""></asp:Label>
    
</asp:Content>

