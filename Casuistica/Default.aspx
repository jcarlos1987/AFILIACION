<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterCasuistica.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Casuistica_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="menu" Runat="Server">


  <li>
                        <a href="../Menu/Default.aspx"><i class="fa fa-dashboard fa-spin"></i>Inicio</a>
                    </li>
                    <li>
                        <a class="active-menu" href="Default.aspx"><i class="fa fa-medkit fa-spin"></i>Casuistica</a>
                        <%-- <ul class="nav nav-second-level">
                            <li>
                                <a href="panel-tabs.html"><i class="fa fa-toggle-on"></i>Improcedentes</a>
                            </li>
                            <li>
                                <a href="notification.html"><i class="fa fa-bell "></i>Comopa</a>
                            </li>
                             <li>
                                <a href="progress.html"><i class="fa fa-circle-o "></i>Siscopa</a>
                            </li>
                             <li>
                                <a href="buttons.html"><i class="fa fa-code "></i>Buttons</a>
                            </li>
                             <li>
                                <a href="icons.html"><i class="fa fa-bug "></i>Icons</a>
                            </li>
                             <li>
                                <a href="wizard.html"><i class="fa fa-bug "></i>Wizard</a>
                            </li>
                             <li>
                                <a href="typography.html"><i class="fa fa-edit "></i>Typography</a>
                            </li>
                             <li>
                                <a href="grid.html"><i class="fa fa-eyedropper "></i>Grid</a>
                            </li>
                            
                           
                        </ul>--%>
                    </li>
                  <%--  <li>
                        <a href="table.html"><i class="fa fa-clipboard fa-spin"></i>Comopa</a>
                        
                    </li>
                    <li>
                        <a href="#"><i class="fa fa-briefcase fa-spin"></i>Siscopa</a>--%>
                       <%--  <ul class="nav nav-second-level">
                           
                             <li>
                                <a href="form.html"><i class="fa fa-desktop "></i>Basic </a>
                            </li>
                             <li>
                                <a href="form-advance.html"><i class="fa fa-code "></i>Advance</a>
                            </li> 
                        </ul>--%>
                   <%-- </li>--%>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="row">
                    <div class="col-md-12">
                        <img src="../assets/img/SISAV.png" width="150" align="right" class="img-rounded"/>
                        <h1 class="page-head-line" style="font-size:17px;">Casuistica</h1>
                        <br />
                    </div>
                </div>
     <!-- /. ROW  -->
                 <div class="row">
                    <div class="col-md-12">
                      <div class="panel panel-default">
                        <div class="panel-heading">
                           Seleccione el Módulo a Acceder:
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                 <div class="col-md-4 ">
                      <div class="alert alert-info text-center ">
                          <h4>Clasificación de Empresas</h4> 
                          <hr />
                            <i class="fa fa-building-o fa-5x"></i>
                          <p>
                         
                        </p>
                          <hr />
                           <a href="Clasificacion_de_empresas.aspx" class="btn btn-info">Acceder</a> 
                        </div>
                    </div>
             <div class="col-md-4 ">                                                 
                      <div class="alert alert-danger text-center">
                          <h4>Coordinación Delegacional de Salud en el Trabajo</h4> 
                          <hr />
                            <i class="fa fa-stethoscope fa-5x"></i>
                          <p>                        
                        </p>
                          <hr />
                           <a href="Coord_Del_Sal_Trab.aspx" class="btn btn-danger">Acceder</a> 
                        </div>
                    </div>
              <div class="col-md-4 ">
                      <div class="alert alert-success text-center">
                          <h4>Departamento de Personal</h4> 
                          <hr />
                            <i class="fa fa-users fa-5x"></i>
                          <p>
                        
                        </p>
                          <hr />
                           <a href="Depto_Perso.aspx" class="btn btn-success">Acceder</a> 
                        </div>
                    </div>
                            </div>
                            </div>
                          </div>
                        </div>
                     </div>
                <!--/.ROW-->
</asp:Content>

