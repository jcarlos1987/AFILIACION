<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterAdmonInfo.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Info_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Mesagge" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="menu" Runat="Server">
    <li>
        <a href="../Menu/Default.aspx"><i class="fa fa-dashboard fa-spin"></i>Inicio</a>
    </li>
    <li>
        <a href="#" ><i class="fa fa-upload fa-spin"></i>Admon. Información  <span class="fa arrow"></span></a>
        <ul class="nav nav-second-level"> 
            <li>
                <a href="afil-67.aspx"><i class="fa fa-cloud-upload fa-spin"></i>Afil-67</a>
            </li>
             <li>
                <a href="Afil-25.aspx"><i class="fa fa-cloud-upload fa-spin"></i>Afil-25</a>
            </li>
        </ul>
    </li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="row">
                    <div class="col-md-12">
                        <img src="../assets/img/SISAV.png" width="150" align="right" class="img-rounded"/>
                        <h1 class="page-head-line" style="font-size:17px;">Administrador de Información</h1>
                        <br />
                    </div>
                </div>
     <!-- /. ROW  -->
                 <div class="row">
                    <div class="col-md-12">
                      <div class="panel panel-default">
                        <div class="panel-heading">
                           Seleccione una Opción:
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                 <div class="col-md-4 ">
                      <div class="alert alert-info text-center ">
                          <h4>AFIL-67</h4> 
                          <hr />
                            <i class="fa fa-building-o fa-5x"></i>
                          <p>
                         
                        </p>
                          <hr />
                           <a href="afil-67.aspx" class="btn btn-info">Acceder</a> 
                        </div>
                    </div>
             <div class="col-md-4 ">                                                 
                      <div class="alert alert-danger text-center">
                          <h4>AFIL-25</h4> 
                          <hr />
                            <i class="fa fa-recycle fa-5x"></i>
                          <p>                        
                        </p>
                          <hr />
                           <a href="Afil-25.aspx" class="btn btn-danger">Acceder</a> 
                        </div>
                    </div>
            <%--  <div class="col-md-4 ">
                      <div class="alert alert-success text-center">
                          <h4>Departamento de Personal</h4> 
                          <hr />
                            <i class="fa fa-users fa-5x"></i>
                          <p>
                        
                        </p>
                          <hr />
                           <a href="Depto_Perso.aspx" class="btn btn-success">Acceder</a> 
                        </div>
                    </div>--%>
                            </div>
                            </div>
                          </div>
                        </div>
                     </div>
                <!--/.ROW-->
</asp:Content>

