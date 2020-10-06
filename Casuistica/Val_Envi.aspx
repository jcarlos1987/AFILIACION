<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterClasEmpre.master" AutoEventWireup="true" CodeFile="Val_Envi.aspx.cs" Inherits="Casuistica_Val_Envi" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
/*Estilo general para el gridView*/
.gridView {
margin:0 auto;
font-size:11px;
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
                <a  class="active-menu" href="EnviarClasEmp.aspx"><i class="fa fa-sign-out fa-spin"></i>Bandeja de Salida</a>
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
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
      <div class="row">
                    <div class="col-md-12">
                        <img src="../assets/img/SISAV.png" width="150" align="right" class="img-rounded"/>
                        <h1 class="page-head-line" style="font-size:17px;">Casuistica \ CLASIFICACIÓN DE EMPRESAS \ BANDEJA DE SALIDA</h1>
                        <h1 class="page-subhead-line"><asp:Label ID="Label2" runat="server" Text=""></asp:Label> </h1>
                    </div>
          <div class="col-md-12">
           <div class="form-group">
         <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
         </div>
              </div>
                </div>

   <div class="bd-example">
       <div class="table-responsive">

                                    <asp:GridView ID="GridView1" Visible="false" CssClass="gridView table table-responsive" HeaderStyle-CssClass="gridViewHeader" PagerStyle-CssClass="gridViewPaginacion" AutoGenerateColumns="false" AllowPaging="true" runat="server" PageSize="15" OnPageIndexChanging="GridView1_PageIndexChanging">
                                        <Columns>
                                            <asp:TemplateField HeaderText="N.">
                                                <ItemTemplate>                                                    
                                                        <asp:Label ID="Label1" runat="server" Text='<%# (GridView1.PageSize * GridView1.PageIndex) + Container.DisplayIndex + 1 %>' Font-Size="10px" Font-Bold="True">
                                                        </asp:Label>                                                   
                                                </ItemTemplate>
                                                <ItemStyle ForeColor="Black"  Width="2px" />
                                            </asp:TemplateField>
                                            
                                            <asp:BoundField DataField="Folio_Error"  SortExpression="Folio_Error" HeaderText="Folio Error"><ItemStyle ForeColor="Black" Width="20px" /></asp:BoundField>
                                            <asp:BoundField DataField="Cve_Docto"  SortExpression="Cve_Docto" HeaderText="Cve. Docto."><ItemStyle ForeColor="Black"  Width="20px" /></asp:BoundField>
                                            <asp:BoundField DataField="Nombre_Asegurado"  SortExpression="Nombre_Asegurado" HeaderText="Nombre del Asegurado"><ItemStyle HorizontalAlign="Left" ForeColor="Black" Width="170px" /></asp:BoundField>
                                            <asp:BoundField DataField="NSS"  SortExpression="NSS" HeaderText="N.S.S."><ItemStyle ForeColor="Black"  Width="85px" /></asp:BoundField>
                                            <asp:BoundField DataField="CURP"  SortExpression="CURP" HeaderText="CURP"><ItemStyle ForeColor="Black" HorizontalAlign="Center" Width="20px" /></asp:BoundField>
                                            <asp:BoundField DataField="Registro_Pat"  SortExpression="Registro_Pat" HeaderText="Registro Pat."><ItemStyle ForeColor="Black"  Width="85px" /></asp:BoundField>
                                            <asp:BoundField DataField="Fecha_Inicio"  SortExpression="Fecha_Inicio" HeaderText="Fecha Inicio"><ItemStyle ForeColor="Black" HorizontalAlign="Center" Width="20px" /></asp:BoundField>
                                            <asp:BoundField DataField="TR"  SortExpression="TR" HeaderText="T R"><ItemStyle ForeColor="Black" HorizontalAlign="Center" Width="20px" /></asp:BoundField>
                                            <asp:BoundField DataField="CS"  SortExpression="CS" HeaderText="C S" HtmlEncode="False" DataFormatString="{0:0.}"><ItemStyle ForeColor="Black" HorizontalAlign="Center" Width="20px" /></asp:BoundField>
                                            <asp:BoundField DataField="Dias_Sub"  SortExpression="Dias_Sub" HeaderText="Dias Sub."><ItemStyle ForeColor="Black" HorizontalAlign="Center" Width="20px" /></asp:BoundField>
                                            <asp:BoundField DataField="Porc_Inc"  SortExpression="Porc_Inc" HeaderText="Porc. Inc."><ItemStyle ForeColor="Black" HorizontalAlign="Center" Width="20px" /></asp:BoundField>
                                            <asp:BoundField DataField="Fecha_Termino"  SortExpression="Fecha_Termino" HeaderText="Fecha Termino"><ItemStyle ForeColor="Black" HorizontalAlign="Center" Width="20px" /></asp:BoundField>
                                            <asp:BoundField DataField="Deleg_Orgn"  SortExpression="Deleg_Orgn" HeaderText="Deleg. Orgn."><ItemStyle ForeColor="Black" HorizontalAlign="Center" Width="20px" /></asp:BoundField>
                                            <asp:BoundField DataField="UMF"  SortExpression="UMF" HeaderText="UMF"><ItemStyle ForeColor="Black" HorizontalAlign="Center" Width="20px" /></asp:BoundField>
                                            <asp:BoundField DataField="Codigo_Error"  SortExpression="Codigo_Error" HeaderText="Código Error"><ItemStyle ForeColor="Black" HorizontalAlign="Center" Width="20px" /></asp:BoundField>
                                            <asp:BoundField DataField="Codigo_Error2"  SortExpression="Codigo_Error2"><ItemStyle ForeColor="Black" HorizontalAlign="Center" Width="20px" /></asp:BoundField>
                                            <asp:BoundField DataField="Codigo_Error3"  SortExpression="Codigo_Error3"><ItemStyle ForeColor="Black" HorizontalAlign="Center" Width="20px" /></asp:BoundField>
                                            <asp:BoundField DataField="Codigo_Error4"  SortExpression="Codigo_Error4"><ItemStyle ForeColor="Black" HorizontalAlign="Center" Width="20px" /></asp:BoundField>
                                            <asp:BoundField DataField="Codigo_Error5"  SortExpression="Codigo_Error5"><ItemStyle ForeColor="Black" HorizontalAlign="Center" Width="20px" /></asp:BoundField>
                                            
                                            
                                            <asp:BoundField DataField="Folio_Docto"  SortExpression="Folio_Docto" HeaderText="Folio Docto."><ItemStyle ForeColor="Black" HorizontalAlign="Center" Width="20px" /></asp:BoundField>
                                            <asp:BoundField DataField="Cto_Pag"  SortExpression="Cto_Pag" HeaderText="Cto. Pag."><ItemStyle ForeColor="Black" HorizontalAlign="Center" Width="20px" /></asp:BoundField>
                                            <asp:BoundField DataField="Tipo_Mto_Aju"  SortExpression="Tipo_Mto_Aju" HeaderText="Tipo Mto. Aju."><ItemStyle ForeColor="Black" HorizontalAlign="Center" Width="20px" /></asp:BoundField>
                                            <asp:BoundField DataField="Fecha_Extrac"  SortExpression="Fecha_Extrac" HeaderText="Fecha Extrac."><ItemStyle ForeColor="Black" HorizontalAlign="Center" Width="20px" /></asp:BoundField>
                                            <asp:BoundField DataField="Fecha_Carga"  SortExpression="Fecha_Carga" HeaderText="Fecha Carga"><ItemStyle ForeColor="Black"  Width="80px" /></asp:BoundField>
                                            <%--<asp:BoundField DataField="Tipo"  SortExpression="Tipo"><ItemStyle ForeColor="Black" HorizontalAlign="Center" Width="10px" /></asp:BoundField>
                                            <asp:BoundField DataField="Ciclo"  SortExpression="Ciclo"><ItemStyle ForeColor="Black" HorizontalAlign="Center" Width="10px" /></asp:BoundField>--%>
                                        </Columns>
                                        <RowStyle Font-Size="9px" />
                                    </asp:GridView>



           <asp:GridView ID="GridView2" Visible="false" CssClass="gridView table table-responsive" HeaderStyle-CssClass="gridViewHeader" PagerStyle-CssClass="gridViewPaginacion" AutoGenerateColumns="false" AllowPaging="true" runat="server" PageSize="15" OnPageIndexChanging="GridView2_PageIndexChanging">
                                        <Columns>
                                            <asp:TemplateField HeaderText="N.">
                                                <ItemTemplate>                                                    
                                                        <asp:Label ID="Label1" runat="server" Text='<%# (GridView2.PageSize * GridView2.PageIndex) + Container.DisplayIndex + 1 %>' Font-Size="10px" Font-Bold="True">
                                                        </asp:Label>                                                   
                                                </ItemTemplate>
                                                <ItemStyle ForeColor="Black"  Width="2px" />
                                            </asp:TemplateField>
                                            
                                            <asp:BoundField DataField="Folio_Error"  SortExpression="Folio_Error" HeaderText="Folio Error"><ItemStyle ForeColor="Black" Width="20px" /></asp:BoundField>
                                            <asp:BoundField DataField="Cve_Docto"  SortExpression="Cve_Docto" HeaderText="Cve. Docto."><ItemStyle ForeColor="Black"  Width="20px" /></asp:BoundField>
                                            <asp:BoundField DataField="Nombre_Asegurado"  SortExpression="Nombre_Asegurado" HeaderText="Nombre del Asegurado"><ItemStyle HorizontalAlign="Left" ForeColor="Black" Width="170px" /></asp:BoundField>                                           
                                            <asp:BoundField DataField="NSS"  SortExpression="NSS" HeaderText="N.S.S."><ItemStyle ForeColor="Black"  Width="85px" /></asp:BoundField>
                                            <asp:BoundField DataField="CURP"  SortExpression="CURP" HeaderText="CURP"><ItemStyle ForeColor="Black" HorizontalAlign="Center" Width="20px" /></asp:BoundField>
                                            <asp:BoundField DataField="Registro_Pat"  SortExpression="Registro_Pat" HeaderText="Registro Pat."><ItemStyle ForeColor="Black"  Width="85px" /></asp:BoundField>
                                            <asp:BoundField DataField="Fecha_Inicio"  SortExpression="Fecha_Inicio" HeaderText="Fecha Inicio"><ItemStyle ForeColor="Black" HorizontalAlign="Center" Width="20px" /></asp:BoundField>
                                            <asp:BoundField DataField="TR"  SortExpression="TR" HeaderText="T R"><ItemStyle ForeColor="Black" HorizontalAlign="Center" Width="20px" /></asp:BoundField>
                                            <asp:BoundField DataField="CS"  SortExpression="CS" HeaderText="C S"><ItemStyle ForeColor="Black" HorizontalAlign="Center" Width="20px" /></asp:BoundField>
                                            <asp:BoundField DataField="Dias_Sub"  SortExpression="Dias_Sub" HeaderText="Dias Sub."><ItemStyle ForeColor="Black" HorizontalAlign="Center" Width="20px" /></asp:BoundField>
                                            <asp:BoundField DataField="Porc_Inc"  SortExpression="Porc_Inc" HeaderText="Porc. Inc."><ItemStyle ForeColor="Black" HorizontalAlign="Center" Width="20px" /></asp:BoundField>
                                            <asp:BoundField DataField="Fecha_Termino"  SortExpression="Fecha_Termino" HeaderText="Fecha Termino"><ItemStyle ForeColor="Black" HorizontalAlign="Center" Width="20px" /></asp:BoundField>
                                            <asp:BoundField DataField="Deleg_Orgn"  SortExpression="Deleg_Orgn" HeaderText="Deleg. Orgn."><ItemStyle ForeColor="Black" HorizontalAlign="Center" Width="20px" /></asp:BoundField>
                                            <asp:BoundField DataField="UMF"  SortExpression="UMF" HeaderText="UMF"><ItemStyle ForeColor="Black" HorizontalAlign="Center" Width="20px" /></asp:BoundField>
                                            <asp:BoundField DataField="Codigo_Error"  SortExpression="Codigo_Error" HeaderText="Código Error"><ItemStyle ForeColor="Black" HorizontalAlign="Center" Width="20px" /></asp:BoundField>
                                            <asp:BoundField DataField="Codigo_Error2"  SortExpression="Codigo_Error2"><ItemStyle ForeColor="Black" HorizontalAlign="Center" Width="20px" /></asp:BoundField>
                                            <asp:BoundField DataField="Codigo_Error3"  SortExpression="Codigo_Error3"><ItemStyle ForeColor="Black" HorizontalAlign="Center" Width="20px" /></asp:BoundField>
                                            <asp:BoundField DataField="Codigo_Error4"  SortExpression="Codigo_Error4"><ItemStyle ForeColor="Black" HorizontalAlign="Center" Width="20px" /></asp:BoundField>
                                            <asp:BoundField DataField="Codigo_Error5"  SortExpression="Codigo_Error5"><ItemStyle ForeColor="Black" HorizontalAlign="Center" Width="20px" /></asp:BoundField>
                                            
                                            <asp:BoundField DataField="Folio_Docto"  SortExpression="Folio_Docto" HeaderText="Folio Docto."><ItemStyle ForeColor="Black" HorizontalAlign="Center" Width="20px" /></asp:BoundField>
                                            <asp:BoundField DataField="Cto_Pag"  SortExpression="Cto_Pag" HeaderText="Cto. Pag."><ItemStyle ForeColor="Black" HorizontalAlign="Center" Width="20px" /></asp:BoundField>
                                            <asp:BoundField DataField="Tipo_Mto_Aju"  SortExpression="Tipo_Mto_Aju" HeaderText="Tipo Mto. Aju."><ItemStyle ForeColor="Black" HorizontalAlign="Center" Width="20px" /></asp:BoundField>
                                            <asp:BoundField DataField="Fec_Extraccion"  SortExpression="Fec_Extraccion" HeaderText="Fecha Extrac."><ItemStyle ForeColor="Black" HorizontalAlign="Center" Width="20px" /></asp:BoundField>
                                            <asp:BoundField DataField="Fecha_Carga"  SortExpression="Fecha_Carga" HeaderText="Fecha Carga"><ItemStyle ForeColor="Black"  Width="80px" /></asp:BoundField>
                                            <%--<asp:BoundField DataField="Tipo"  SortExpression="Tipo"><ItemStyle ForeColor="Black" HorizontalAlign="Center" Width="10px" /></asp:BoundField>
                                            <asp:BoundField DataField="Ciclo"  SortExpression="Ciclo"><ItemStyle ForeColor="Black" HorizontalAlign="Center" Width="10px" /></asp:BoundField>--%>
                                        </Columns>
                                        <RowStyle Font-Size="9px" />
                                    </asp:GridView>
           </div>
                                </div>


      <div class="form-group">
                                            <label>Mensaje :</label>
          <asp:TextBox ID="msj" CssClass="form-control" Rows="5" TextMode="MultiLine" runat="server"></asp:TextBox> 
                                        </div>
    <div class="form-group">
        <button type="button" class="btn btn-info btn-lg" data-toggle="modal" data-target="#aceptar">Enviar  <i class="fa fa-paper-plane"></i></button>
        <button type="button" class="btn btn-danger btn-lg" data-toggle="modal" data-target="#cancelar">Cancelar  <i class="fa fa-ban"></i></button>
    </div>

    <div class="panel-body">
        <div class="modal fade" id="aceptar" tabindex="-1" role="dialog" aria-labelledby="myModalAceptar" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                        <h4 class="modal-title" id="myModalAceptar">Casuistica</h4>
                    </div>
                    <div class="modal-body">
                        Estas seguro que deseas enviar la información del <% Response.Write(Label2.Text); %>?
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-danger" data-dismiss="modal">Cancelar</button>
                        <asp:Button ID="Enviar" runat="server" CssClass="btn btn-success" Text="Aceptar" OnClick="Enviar_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>


    <!--Inicio boton Cancelar-->
    <div class="panel-body">
        <div class="modal fade" id="cancelar" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                        <h4 class="modal-title" id="myModalLabel">Casuistica</h4>
                    </div>
                    <div class="modal-body">
                        Estas seguro que deseas salir de la Validación del <% Response.Write(Label2.Text); %>?
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-danger" data-dismiss="modal">Cancelar</button>
                        <asp:Button ID="Cancelar" runat="server" CssClass="btn btn-success" Text="Aceptar" OnClick="Cancelar_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>

