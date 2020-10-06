<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterClasEmpre.master" AutoEventWireup="true" CodeFile="Clasificacion_de_empresas.aspx.cs" Inherits="Casuistica_Clasificacion_de_empresas" %>

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
    <a href="Clasificacion_de_empresas.aspx" class="btn btn-info" title="New Message"><b><% Response.Write(Bandeja("")); %> </b><i class="fa fa-envelope-o fa-2x"></i></a>
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
                <a class="active-menu" href="Clasificacion_de_empresas.aspx"><i class="fa fa-envelope-o fa-spin"></i>Bandeja de Entrada</a>
            </li>
            <li>
                <a  href="EnviarClasEmp.aspx"><i class="fa fa-sign-out fa-spin"></i>Bandeja de Salida</a>
            </li>
            <li>
                <a  href="Reporte.aspx"><i class="fa fa-file-pdf-o fa-spin"></i>Reporte de SCAC</a>
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
     <div class="row">
                    <div class="col-md-12">
                        <img src="../assets/img/SISAV.png" width="150" align="right" class="img-rounded"/>
                        <h1 class="page-head-line" style="font-size:15px;">Casuistica \ CLASIFICACIÓN DE EMPRESAS \ Bandeja de Entrada</h1>
                        <br />
                    </div>
                </div>
     <div class="bd-example">
         <div class="table-responsive">
             <asp:GridView ID="GridView1" CssClass="table" HeaderStyle-CssClass="gridViewHeader" PageSize="14" DataKeyNames="id" runat="server" PagerStyle-CssClass="gridViewPaginacion" AllowPaging="true" AutoGenerateColumns="false" OnRowDataBound="GridView1_RowDataBound" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnPageIndexChanging="GridView1_PageIndexChanging">
                 <Columns>
                      <asp:BoundField DataField="tipo"  SortExpression="tipo" HeaderText="Tipo de Producto"><ItemStyle ForeColor="Black" Width="100px" /></asp:BoundField>
                     <asp:BoundField DataField="Ciclo"  SortExpression="Ciclo" HeaderText="Ciclo"><ItemStyle ForeColor="Black" Width="80px" /></asp:BoundField>
                     <asp:BoundField DataField="mensaje"  SortExpression="mensaje" HeaderText="Asunto"><ItemStyle ForeColor="Black"  Width="900px" /></asp:BoundField>
                     <asp:BoundField DataField="Fech_Envio"  SortExpression="Fech_Envio" HeaderText="Fecha de Recepcion" DataFormatString="{0:yyyy/MM/dd HH:mm:ss}" ><ItemStyle ForeColor="Black"  Width="160px" /></asp:BoundField>
                     <asp:BoundField DataField="Envio"  SortExpression="Envio" HeaderText="Antigüedad"><ItemStyle ForeColor="Black"  Width="150px" /></asp:BoundField>                     
                     <asp:TemplateField HeaderText="Ver">
                        <ItemStyle  HorizontalAlign="Center" Width="60px" /> 
                        <ItemTemplate>
                            <asp:LinkButton ID="Enviar" CommandName="Select"  runat="server"><i class="fa fa-envelope-o fa-2x"></i></asp:LinkButton>
                        </ItemTemplate>
                     </asp:TemplateField>
                     <asp:BoundField DataField="leer" ><ItemStyle ForeColor="Black" Font-Size="0px" Width="1px" /></asp:BoundField>
                 </Columns>
                 <RowStyle Font-Size="12px" />
             </asp:GridView>
         </div>
     </div>
        <asp:Panel ID="PanelMostrarMsj" Visible="false" runat="server">
            <div class="row">
            <div class="col-md-12 col-sm-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                           Información del Mensaje
                        </div>
                        <div class="panel-body">
                            <ul class="nav nav-pills">
                                <li class="active"><a href="#homepills" data-toggle="tab">Detalles</a>
                                </li>
                                <li class=""><a href="#profilepills" data-toggle="tab">Registros</a>
                                </li>
                            </ul>

                            <div class="tab-content">
                                <div class="tab-pane fade active in" id="homepills" >                                   
                                    <div class="row">
                                    <div  class="row pad-top-botm client-info">
         <div class="col-lg-12 col-md-12 col-sm-12">
         <h4>  <strong>Información del Mensaje</strong></h4>
                <a href="#" class="list-group-item">
                                        <i class="fa fa-building-o fa-2x"></i> <strong>  Departamento Clasificación de Empresas</strong>
                                    </a>
             <a href="#" class="list-group-item">
                                        <i class="fa fa-info"></i>             
                  <b>Tipo Producto :</b>  <asp:Label ID="Label5" runat="server" Text=""></asp:Label>   
             </a>
                     
           <a href="#" class="list-group-item">
                                        <i class="fa fa-calendar-check-o"></i>  
             <b>Fecha de Carga :</b> <asp:Label ID="Label6" runat="server" Text=""></asp:Label>
              </a>
             <a href="#" class="list-group-item">
                                        <i class="fa fa-cogs"></i>  
             <b>Ciclo :</b> <asp:Label ID="Label7" runat="server" Text=""></asp:Label>
             </a>
             <a href="#" class="list-group-item">
                                        <i class="fa fa-calendar-check-o"></i>  
             <b>Fecha de Extracción :</b> <asp:Label ID="Label8" runat="server" Text=""></asp:Label>
             </a>
             <a href="#" class="list-group-item">
                                        <i class="fa fa-registered"></i>  
             <b>Total de Registros:</b> <asp:Label ID="Label9" runat="server" Text=""></asp:Label>
             </a>
             <a href="#" class="list-group-item">
                                        <i class="fa fa-deafness"></i>  
             <b>Asunto : <br /></b> <asp:Label ID="Label10" runat="server" Text=""></asp:Label>
                 </a>
         </div>
     </div>
                                        </div>
                                </div>
                                <div class="tab-pane fade" id="profilepills" >
                                    <h4>Registros</h4>
                                       <div class="bd-example">
       <div class="table-responsive">

                                    <asp:GridView ID="GridView2" Visible="false" CssClass="gridView table table-responsive" HeaderStyle-CssClass="gridViewHeader" PagerStyle-CssClass="gridViewPaginacion" DataKeyNames="id,Fecha_Carga,Folio_Error,Cve_Docto,NSS,Registro_Pat,Fecha_Inicio,TR,CS,Dias_Sub,Folio_Docto,Porc_Inc,Fecha_Termino,Deleg_Orgn,UMF,Codigo_Error,Codigo_Error2,Codigo_Error3,Codigo_Error4,Codigo_Error5,Nombre_Asegurado,CURP,Cto_Pag,Tipo_Mto_Aju,Fecha_Extrac,Tipo,Ciclo"
                                        AutoGenerateColumns="false" AllowPaging="true" runat="server" PageSize="15" OnPageIndexChanging="GridView2_PageIndexChanging" >
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
                                            <asp:BoundField DataField="NSS"  SortExpression="NSS" HeaderText="N.S.S."><ItemStyle ForeColor="Black"  Width="85px" /></asp:BoundField>
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
                                            <asp:BoundField DataField="Nombre_Asegurado"  SortExpression="Nombre_Asegurado" HeaderText="Nombre del Asegurado"><ItemStyle HorizontalAlign="Left" ForeColor="Black" Width="170px" /></asp:BoundField>
                                            <asp:BoundField DataField="CURP"  SortExpression="CURP" HeaderText="CURP"><ItemStyle ForeColor="Black" HorizontalAlign="Center" Width="20px" /></asp:BoundField>
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
           </div>
                          </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                </div>



                    
            
        <asp:Label ID="LabelMensaje" runat="server" Text=""></asp:Label>
    </asp:Panel>



</asp:Content>

