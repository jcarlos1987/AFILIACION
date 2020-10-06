<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterClasEmpre.master" AutoEventWireup="true" CodeFile="Cga_scac10.aspx.cs" Inherits="Casuistica_Cga_scac10" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
   
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
        <ul class="nav nav-second-level ">  
            <li>
                <a  href="Clasificacion_de_empresas.aspx"><i class="fa fa-envelope-o fa-spin"></i>Bandeja de Entrada</a>
            </li>
            <li>
                <a  href="EnviarClasEmp.aspx"><i class="fa fa-sign-out fa-spin"></i>Bandeja de Salida</a>
            </li> 
             <li>
                <a href="Reporte.aspx"><i class="fa fa-file-pdf-o fa-spin"></i>Reporte de SCAC</a>
            </li>  
        </ul>
    </li>
    <li>
        <a href="#" ><i class="fa fa-upload fa-spin"></i>Carga Información  <span class="fa arrow"></span></a>
        <ul class="nav nav-second-level collapse in"> 
            <li>
                <a class="active-menu" href="Cga_scac10.aspx"><i class="fa fa-cloud-upload fa-spin"></i>SCAC-09 y SCAC-10</a>
            </li>
        </ul>
    </li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="row">
                    <div class="col-md-12">
                        <img src="../assets/img/SISAV.png" width="150" align="right" class="img-rounded"/>
                        <h1 class="page-head-line" style="font-size:15px;">Casuistica \ CLASIFICACIÓN DE EMPRESAS \ CARGA INFORMACIÓN</h1>
                        <br />
                    </div>
                </div>
      <div class="col-md-12 col-sm-12 col-xs-12">
          <div class="panel panel-primary">
              <div class="panel-heading">
                  Cargar Información SCAC-09 y SCAC-10
              </div>
              <div class="panel-body">
                  <div class="form-group col-sm-6">
                      <label>Selecciona Tipo de Archivo</label>
                                <asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server">
                                    <asp:ListItem disabled selected Value="" Text=" -- Seleccione Una Opción -- "></asp:ListItem>
                                    <asp:ListItem Value="9" Text=" SCAC-09 "></asp:ListItem>
                                    <asp:ListItem Value="10" Text=" SCAC-10"></asp:ListItem>
                                </asp:DropDownList>
                                        </div>
                           
                            <div class="form-group col-sm-6">
                                            <label>Seleccione el Archivo</label>
                                <asp:FileUpload ID="FileUpload1" CssClass="form-control" runat="server" />
                                        </div>
                            <hr>
                            <div class="form-group col-sm-6">
                                <asp:Button ID="Button1" runat="server" CssClass="btn btn-success" Text="Subir Archivo" OnClick="Button1_Click" />
                              
                            </div>
                  <div class="form-group col-sm-6">                                            
                       <asp:Label ID="LabelMensaje" runat="server" Text=""></asp:Label>
                      </div>
                       
                            </div>
                        </div>
                            </div>
</asp:Content>

