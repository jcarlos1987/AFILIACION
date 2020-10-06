<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPageSegEsp.master" AutoEventWireup="true" CodeFile="Menu_Seg_Esp.aspx.cs" Inherits="SegEspe_Menu_Seg_Esp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="menu" Runat="Server">

                     <li>
                        <a  href="../Menu/Default.aspx"><i class="fa fa-dashboard fa-spin"></i>Inicio</a>
                    </li>
                          <li>
                            <a  class="active-menu" href="Menu_Seg_Esp.aspx"><i class="fa fa-building-o fa-spin"></i>Seguros Especiales</a>
                               
                          </li>
                         <li>
                        <a href="#"><i class="fa fa-envelope-o fa-spin "></i>Informes <span class="fa arrow"></span></a>
                         <ul class="nav nav-second-level">
                            <li>
                                <a href="Reportes_Seguros_Especiales.aspx"><i class="fa fa-address-book fa fa-spin"></i>Informe por modalidad</a>
                            </li>
                        </ul>
                    </li>
                               
                       
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Mesagge" Runat="Server">
              

</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
                 <div class="row">
                    <div class="col-md-12">
                         <img src="../assets/img/SISAV.png" width="150" align="right" class="img-rounded"/>
                        <h1 class="page-head-line" style="font-size:17px;">Seguros Especiales</h1>                        
                    </div>
                </div>  
    
     <div class="row">

                    <div class="col-md-4">
                        <div class="main-box mb-red">
                            <a href="../SegEspe/Reportes_Seguros_Especiales.aspx">
                                <i class="fa fa-edit  fa-5x fa-spin"></i>
                                <h5>Informes</h5>
                            </a>
                        </div>
                    </div>

                  <%--  <div class="col-md-4">
                        <div class="main-box mb-dull">
                            <a href="#">
                                <i class="fa fa-gavel fa-5x fa-spin"></i>
                                <h5>titulo</h5>
                            </a>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="main-box mb-pink">
                            <a href="#">
                                <i class="fa fa-clipboard fa-5x fa-spin"></i>
                                <h5>titulo</h5>
                            </a>
                        </div>
                    </div>

                   <div class="col-md-4">
                        <div class="main-box" style="background-color: #0094ff;">
                            <a href="../Info/Default.aspx">
                                <i class="fa fa-cloud-upload fa-5x fa-spin"></i>
                                <h5>titulo</h5>
                            </a>
                        </div>
                    </div>
               
                  <div class="col-md-4">
                        <div class="main-box" style="background-color: #9d00ff;">
                            <a href="../SegEspe/Menu_Seg_Esp.aspx">
                                <i class="fa fa-users fa-5x fa-spin"></i>
                                <h5>titulo</h5>
                            </a>
                        </div>
                    </div>--%>
           </div>  
</asp:Content>


