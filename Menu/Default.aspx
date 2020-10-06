<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Master.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Menu_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">


<style>
   .img-texto {
   	position: relative;
   	float: left;
        width:auto;
   }
   .img-texto span {
    position: absolute;
    bottom: 1030px;
    left: 0;
    right: 0;
    z-index: 999;
    background: #353535;
    padding: 10px;
    color: #fff;
    font-family: sans-serif;
    text-align: center;
    font-size: 27pt;
    filter:alpha(opacity=50);
    -moz-opacity:.50;
    opacity:.60;
    width:auto;
    }
</style>




</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="menu" Runat="Server">


                     <li>
                        <a class="active-menu"  href="Default.aspx"><i class="fa fa-dashboard fa-spin"></i>Inicio</a>
                    </li>
                    <li>
                        <a href="../Casuistica/Default.aspx"><i class="fa fa-medkit fa-spin"></i>Casuistica</a>
                    </li>
                     <li>
                        <a href="#"><i class="fa fa-gavel fa-spin"></i>Improcedentes</a>

                    </li>
                    <li>
                        <a href="#"><i class="fa fa-clipboard fa-spin"></i>Comopa</a>
                        
                    </li>
                     <li>
                        <a href="../Info/Default.aspx"><i class="fa fa-cloud-upload fa-spin"></i>Admon. Información</a>
                    </li>
                    <li>
                        <a href="../SegEspe/Menu_Seg_Esp.aspx"><i class="fa fa-cloud-upload fa-spin"></i>Seguros Especiales</a>
                    </li>
   
    
    
    
    
     </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
                <div class="row">
                    <div class="col-md-12">
                         <img src="../assets/img/SISAV.png" width="150" align="right" class="img-rounded"/>
                        <h1 class="page-head-line" style="font-size:17px;">Supervisión de Afiliación clasificación de empresas y vigencia de derechos</h1>                        
                    </div>
                </div>    
               <div class="row">

                    <div class="col-md-4">
                        <div class="main-box mb-red">
                            <a href="../Casuistica/Default.aspx">
                                <i class="fa fa-medkit fa-5x fa-spin"></i>
                                <h5>CASUISTICA</h5>
                            </a>
                        </div>
                    </div>

                    <div class="col-md-4">
                        <div class="main-box mb-dull">
                            <a href="#">
                                <i class="fa fa-gavel fa-5x fa-spin"></i>
                                <h5>IMPROCEDENTES</h5>
                            </a>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="main-box mb-pink">
                            <a href="#">
                                <i class="fa fa-clipboard fa-5x fa-spin"></i>
                                <h5>COMOPA</h5>
                            </a>
                        </div>
                    </div>

                   <div class="col-md-4">
                        <div class="main-box" style="background-color: #0094ff;">
                            <a href="../Info/Default.aspx">
                                <i class="fa fa-cloud-upload fa-5x fa-spin"></i>
                                <h5>Admon. Información</h5>
                            </a>
                        </div>
                    </div>
               
                  <div class="col-md-4">
                        <div class="main-box" style="background-color: #9d00ff;">
                            <a href="../SegEspe/Menu_Seg_Esp.aspx">
                                <i class="fa fa-users fa-5x fa-spin"></i>
                                <h5>Seguros Especiales</h5>
                            </a>
                        </div>
                    </div>
           </div>
                <!-- /. ROW  -->            
              
   <h1 class="page-subhead-line"></h1>
      <br />
    
    <div class="row">          
          <div class="col-md-12">
              <div class="container-fluid">
                  <div id="carousel-example" class="carousel slide" data-ride="carousel" style="border: 5px solid #000;">

                                <div class="carousel-inner">
                                    <div class="item active">
                                        
                                       
                                        
                                    <div class="img-texto col-md-12 col-sm-12">
                                     <img src="../assets/img/slideshow/1.jpg" alt="" />
                                        <span>Departamento de Afiliación y Vigencia Toluca</span>
                                    </div>
                                    </div>
                                    
                                        <div class="item">
                                       <div class="img-texto col-md-12 col-sm-12">
                                        <img src="../assets/img/slideshow/img_4.jpg" alt="" />
                                      <span>Departamento de Afiliación y Vigencia Toluca</span>
                                    </div>
                                    </div>
                                    <div class="item">
                                         <div class="img-texto col-md-12 col-sm-12">
                                        <img src="../assets/img/slideshow/img_5.jpg" alt="" />
                                       <span>Departamento de Afiliación y Vigencia Toluca</span>
                                    </div>
                                    </div>
                                </div>
                                <!--INDICATORS-->
                                <ol class="carousel-indicators col-md-12 col-sm-12">
                                    <li data-target="#carousel-example" data-slide-to="0" class="active"></li>
                                    <li data-target="#carousel-example" data-slide-to="1"></li>
                                    <li data-target="#carousel-example" data-slide-to="2"></li>
                                </ol>
                                <!--PREVIUS-NEXT BUTTONS-->
                                <a class="left carousel-control" href="#carousel-example" data-slide="prev">
                                    <span class="glyphicon glyphicon-chevron-left"></span>
                                </a>
                                <a class="right carousel-control" href="#carousel-example" data-slide="next">
                                    <span class="glyphicon glyphicon-chevron-right"></span>
                                </a>
                            </div>
              </div>
          </div>
              </div>
</asp:Content>

