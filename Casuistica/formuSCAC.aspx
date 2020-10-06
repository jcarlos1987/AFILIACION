<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterSaludTrab.master" AutoEventWireup="true" CodeFile="formuSCAC.aspx.cs" Inherits="Casuistica_formuSCAC" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
      <style type="text/css">

          /*///////////////////////////////*/
        /*                               */
        /*    Estilo del Calendario      */
        /*                               */
        /*///////////////////////////////*/
        .custom-calendar .ajax__calendar_container
        {
            background-color: White;
            border:solid 1px #666;
        }
        .custom-calendar .ajax__calendar_title
        {
            height:20px;
            color:#333;
        }
        .custom-calendar .ajax__calendar_prev,
        .custom-calendar .ajax__calendar_next
        {
            background-color:#aaa; /* darker gray */
            height:20px;
            width:20px;
        }
        .custom-calendar .ajax__calendar_today
        {
            background-color: #00CE6F;  /* pale blue */
            height:20px;
        }
        .custom-calendar .ajax__calendar_days table thead tr td
        {
            color:#333;
        }
        .custom-calendar .ajax__calendar_day
        {
            color:#333; /* normal day - darker gray color */
        }
        .custom-calendar .ajax__calendar_other .ajax__calendar_day
        {
            background-color:#D5D6DA;
            color: Black; /* day not actually in this month - lighter gray color */
        }
        .custom-calendar .ajax__calendar_invalid .ajax__calendar_day
        {
            background-color: #AAAAAA;
            color: Black;
            text-decoration: line-through;
            cursor: not-allowed;
        }
    </style>
    <style type="text/css">
   input:required:invalid {border: 1px solid #f00;}
   input:required:valid {border: 1px solid #31ff00;}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Mesagge" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="menu" Runat="Server">
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
                <a class="active-menu" href="Coord_Del_Sal_Trab.aspx"><i class="fa fa-envelope-o fa-spin"></i>Bandeja de Entrada</a>
            </li>
            <li>
                <a href="BanSalTrabajo.aspx"><i class="fa fa-sign-out fa-spin"></i>Bandeja de Salida</a>
            </li> 
        </ul>
    </li>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="row">
                    <div class="col-md-12">
                        <img src="../assets/img/SISAV.png" width="150" align="right" class="img-rounded"/>
                        <h1 class="page-head-line" style="font-size:17px;">CASUISTICA \ Coordinación Delegacional de Salud en el Trabajo \ ACTUALIZAR REGISTROS</h1>
                        <br />
                    </div>
                </div> 

            <asp:Panel ID="PanelFormulario" runat="server">
     <div class="row">
            <div class="col-md-12 col-sm-12 col-xs-12">
               <div class="panel panel-info">
                        <div class="panel-heading">
                           Errores a Corregir
                        </div>
                        <div class="panel-body">
                            <a id="div_cod_error1" href="#" class="list-group-item" visible="false" runat="server">
                                <i class="fa fa-hashtag"></i> <asp:Label ID="Labelcodigoerror1" runat="server" Text=""></asp:Label> 
                            </a>
                            <a id="div_cod_error2" href="#" class="list-group-item" visible="false" runat="server">
                                <i class="fa fa-hashtag"></i> <asp:Label ID="Labelcodigoerror2" runat="server" Text=""></asp:Label> 
                            </a>
                            <a id="div_cod_error3" href="#" class="list-group-item" visible="false" runat="server">
                                <i class="fa fa-hashtag"></i> <asp:Label ID="Labelcodigoerror3" runat="server" Text=""></asp:Label> 
                            </a>
                            <a id="div_cod_error4" href="#" class="list-group-item" visible="false" runat="server">
                                <i class="fa fa-hashtag"></i> <asp:Label ID="Labelcodigoerror4" runat="server" Text=""></asp:Label> 
                            </a>
                            <a id="div_cod_error5" href="#" class="list-group-item" visible="false" runat="server">
                                <i class="fa fa-hashtag"></i> <asp:Label ID="Labelcodigoerror5" runat="server" Text=""></asp:Label> 
                            </a>
                            <a id="div_cod_error6" href="#" class="list-group-item" visible="false" runat="server">
                                <i class="fa fa-hashtag"></i> <asp:Label ID="Labelcodigoerror6" runat="server" Text=""></asp:Label> 
                            </a>
                            <a id="div_cod_error7" href="#" class="list-group-item" visible="false" runat="server">
                                <i class="fa fa-hashtag"></i> <asp:Label ID="Labelcodigoerror7" runat="server" Text=""></asp:Label> 
                            </a>
                            <a id="div_cod_error8" href="#" class="list-group-item" visible="false" runat="server">
                                <i class="fa fa-hashtag"></i> <asp:Label ID="Labelcodigoerror8" runat="server" Text=""></asp:Label> 
                            </a>
                            <a id="div_cod_error9" href="#" class="list-group-item" visible="false" runat="server">
                                <i class="fa fa-hashtag"></i> <asp:Label ID="Labelcodigoerror9" runat="server" Text=""></asp:Label> 
                            </a>
                            <a id="div_cod_error10" href="#" class="list-group-item" visible="false" runat="server">
                                <i class="fa fa-hashtag"></i> <asp:Label ID="Labelcodigoerror10" runat="server" Text=""></asp:Label> 
                            </a>
                            <a id="div_cod_error11" href="#" class="list-group-item" visible="false" runat="server">
                                <i class="fa fa-hashtag"></i> <asp:Label ID="Labelcodigoerror11" runat="server" Text=""></asp:Label> 
                            </a>
                            <a id="div_cod_error12" href="#" class="list-group-item" visible="false" runat="server">
                                <i class="fa fa-hashtag"></i> <asp:Label ID="Labelcodigoerror12" runat="server" Text=""></asp:Label> 
                            </a>
                            <a id="div_cod_error13" href="#" class="list-group-item" visible="false" runat="server">
                                <i class="fa fa-hashtag"></i> <asp:Label ID="Labelcodigoerror13" runat="server" Text=""></asp:Label> 
                            </a>
                            <a id="div_cod_error14" href="#" class="list-group-item" visible="false" runat="server">
                                <i class="fa fa-hashtag"></i> <asp:Label ID="Labelcodigoerror14" runat="server" Text=""></asp:Label> 
                            </a>
                            <a id="div_cod_error15" href="#" class="list-group-item" visible="false" runat="server">
                                <i class="fa fa-hashtag"></i> <asp:Label ID="Labelcodigoerror15" runat="server" Text=""></asp:Label> 
                            </a>
                            <a id="div_cod_error16" href="#" class="list-group-item" visible="false" runat="server">
                                <i class="fa fa-hashtag"></i> <asp:Label ID="Labelcodigoerror16" runat="server" Text=""></asp:Label> 
                            </a>
                            <a id="div_cod_error17" href="#" class="list-group-item" visible="false" runat="server">
                                <i class="fa fa-hashtag"></i> <asp:Label ID="Labelcodigoerror17" runat="server" Text=""></asp:Label> 
                            </a>

                            <asp:Label ID="Labelmsj" runat="server" Text=""></asp:Label>
                        </div>
                   </div>
                </div>
          
         </div>                                 
     <div class="row">
            <div class="col-md-12 col-sm-12 col-xs-12">
               <div class="panel panel-info">
                        <div class="panel-heading">
                           Formulario de <strong><asp:Label ID="LabelTipo" runat="server" Text=""></asp:Label></strong>
                        </div>
                        <div class="panel-body">
                           

                           <div class="col-md-6">
                            <div class="form-group"> 
        											<label class="control-label">Folio Error</label> 
				                  	<div id="id_folio_error" class="input-group" runat="server">				                  		 
    												<span class="input-group-addon"><i class="fa fa-hashtag"></i></span>             		
				                  		<asp:TextBox ID="folio_error" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                          <span class="glyphicon glyphicon-pencil form-control-feedback" id="Gly_folioError" runat="server" visible="false"></span>                   		
				                  	</div>
				                  </div>
                               </div>

                              <div class="col-md-6">             
                                  <div class="form-group"> 
        									<label class="control-label">Clave de Documento</label>
				                  	<div id="id_clav_doc" class="input-group" runat="server">				                  		 
    												<span class="input-group-addon"><i class="fa fa-file-text-o"></i></span>             		
				                  		 <asp:TextBox ID="clav_doc" runat="server" Style="text-transform: uppercase" CssClass="form-control" Enabled="false"></asp:TextBox>
                                          <span class="glyphicon glyphicon-pencil form-control-feedback" id="Gly_clav_doc" runat="server" visible="false"></span>                  		
				                  	</div>
				                  </div>
                               </div>

                                <div class="col-md-6">
                                    <div class="form-group"> 
        										 <label class="control-label">No. de Seguridad Social</label>
				                  	<div id="id_nss" class="input-group" runat="server">				                  		 
    												<span class="input-group-addon"><i class="fa fa-user"></i></span>             		
				                  		 <asp:TextBox ID="nss" runat="server" Style="text-transform: uppercase" required  pattern="[0-9]{2}\s[0-9]{2}\s[0-9]{2}\s[0-9]{4}" title="No coincide" CssClass="form-control" Enabled="false" ></asp:TextBox>	                  		
                                          <span class="glyphicon glyphicon-pencil form-control-feedback" id="Gly_nss" runat="server" visible="false"></span>
				                  	</div>
				                  </div>
                                </div>
                            
                            <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label">Nombre del Asegurado</label>
                                         <div id="id_nom_aseg" class="input-group" runat="server">
                                            <span class="input-group-addon"><i class="fa fa-user"></i></span>    
                                      <asp:TextBox ID="nom_aseg" runat="server" Style="text-transform: uppercase" CssClass="form-control" Enabled="false"></asp:TextBox>
                                             <span class="glyphicon glyphicon-pencil form-control-feedback" id="Gly_nom_aseg" runat="server" visible="false"></span>  
                                           </div>
                                        </div>
                                </div>

                             <div class="col-md-6">
                                    <div class="form-group">
                          <label class="control-label">Curp</label>
                                        <div id="id_curp" class="input-group" runat="server">
                                            <span class="input-group-addon"><i class="fa fa-users"></i></span> 
                                             <asp:TextBox ID="curp" runat="server" Style="text-transform: uppercase" CssClass="form-control" Enabled="false" ></asp:TextBox>
                                            <span class="glyphicon glyphicon-pencil form-control-feedback" id="Gly_curp" runat="server" visible="false"></span>  
                                            </div>  
                                        </div>
                                 </div>

                               
                            <div class="col-md-6">
                                <div class="form-group"> 
        								 <label class="control-label">Registro Patronal</label>
				                  	<div id="id_reg_pat" class="input-group" runat="server">				                  		 
    												<span class="input-group-addon"><i class="fa fa-building-o"></i></span>             		
				                  		<asp:TextBox ID="reg_pat" runat="server" Style="text-transform: uppercase" CssClass="form-control" required  pattern="[0-9A-Z]{3}\s[0-9]{5}\s[0-9]{2}" Enabled="false" ></asp:TextBox>                  		
                                          <span class="glyphicon glyphicon-pencil form-control-feedback" id="Gly_reg_pat" runat="server" visible="false"></span>  
				                  	</div>
				                  </div>
                               </div>
                            
                             <div class="col-md-6">
                                 <div class="form-group"> 
        								<label class="control-label">Fecha de Inicio</label>  
				                  	<div id="id_fecha_inic" class="input-group" runat="server">				                  		 
    												<span class="input-group-addon"> <asp:ImageButton ID="ImageButton6" runat="server" 
                                             ImageUrl="~/images/calendar.png" Width="16px" CausesValidation="False" /></span>              		
				                  		<asp:TextBox ID="fech_inic" runat="server" CssClass="form-control"  Enabled="false"></asp:TextBox>
                                          <span class="glyphicon glyphicon-pencil form-control-feedback" id="Gly_fech_inic" runat="server" visible="false"></span>  
                                            <cc1:CalendarExtender ID="fech_inic_CalendarExtender"   CssClass="custom-calendar"  Format="dd/MM/yyyy" PopupButtonID="ImageButton6" runat="server" Enabled="True" TargetControlID="fech_inic">
                                            </cc1:CalendarExtender>	                  		
				                  	</div>
				                  </div>
                                 </div>

                                <div class="col-md-6">
                                <div class="form-group has-feedback">
                                            <label class="control-label">TR</label>
                                           <div id="id_tr" class="input-group" runat="server">
                                           <span class="input-group-addon"><i class="fa fa-user-md"></i></span>
                                            <asp:TextBox ID="tr" runat="server" Style="text-transform: uppercase" CssClass="form-control" Enabled="false"></asp:TextBox>
                                               <span class="glyphicon glyphicon-pencil form-control-feedback" id="Gly_tr" runat="server" visible="false"></span>  
                                            </div>
                                      </div>
                                 </div>
                                
                             <div class="col-md-6">
                                 <div class="form-group"> 
        											<label class="control-label">CS</label>
				                  	<div id="id_cs" class="input-group" runat="server">				                  		 
    												<span class="input-group-addon"><i class="fa fa-stethoscope"></i></span>             		
				                  		<asp:TextBox ID="cs" runat="server" Style="text-transform: uppercase" CssClass="form-control"  Enabled="false"></asp:TextBox>   
                                          <span class="glyphicon glyphicon-pencil form-control-feedback" id="Gly_cs" runat="server" visible="false"></span>                 		
				                  	</div>
				                  </div>
                                 </div>

                            <div class="col-md-6">
                                 <div class="form-group"> 
                                     <label class="control-label">Dias Sub</label>
                                     <div id="id_dias_sub" class="input-group" runat="server">
                                            <span class="input-group-addon"><i class="fa fa-calendar-o"></i></span>
                                             <asp:TextBox ID="dias_sub" runat="server" Style="text-transform: uppercase" CssClass="form-control" Enabled="false" ></asp:TextBox>
                                         <span class="glyphicon glyphicon-pencil form-control-feedback" id="Gly_dias_sub" runat="server" visible="false"></span>  
                                            </div> 
                                     </div>
                                </div>

                            <div class="col-md-6">
                                 <div class="form-group">
                                     <label class="control-label">Porc Inc</label>
                                       <div id="id_porc_inc" class="input-group" runat="server">
                                     <span class="input-group-addon"><i class="fa fa-calculator"></i></span>        
                                     <asp:TextBox ID="porc_inc" runat="server" Style="text-transform: uppercase" CssClass="form-control" Enabled="false"></asp:TextBox>
                                           <span class="glyphicon glyphicon-pencil form-control-feedback" id="Gly_porc_inc" runat="server" visible="false"></span>  
                                            </div> 
                                     </div>
                                </div>

                                 <div class="col-md-6">
                                     <div class="form-group">
                                            <label class="control-label">Fecha de Término</label>
                                             <div id="id_fecha_termino" class="input-group" runat="server">
                                            <span class="input-group-addon"> <asp:ImageButton ID="ImageButton1" runat="server" 
                                             ImageUrl="~/images/calendar.png" Width="16px" CausesValidation="False" /></span>  
                                           
                                            <asp:TextBox ID="fecha_term" runat="server" Style="text-transform: uppercase" CssClass="form-control"  Enabled="false"></asp:TextBox>
                                            <span class="glyphicon glyphicon-pencil form-control-feedback" id="GlyFechaTermino" runat="server" visible="false"></span>
                                            <cc1:CalendarExtender ID="CalendarExtender1"   CssClass="custom-calendar"  Format="dd/MM/yyyy" PopupButtonID="ImageButton1" runat="server" Enabled="True" TargetControlID="fecha_term">
                                            </cc1:CalendarExtender>
                                           </div>
                                         </div>
                                 </div>
                                
                                  <div class="col-md-6">
                                      <div class="form-group">
                                            <label class="control-label">Delegación Origen</label>
                                       <div id="id_del_ori" class="input-group" runat="server">
                                     <span class="input-group-addon"><i class="fa fa-building"></i></span>       
                                      <asp:TextBox ID="del_ori" runat="server" Style="text-transform: uppercase" CssClass="form-control"  Enabled="false"></asp:TextBox>
                                           <span class="glyphicon glyphicon-pencil form-control-feedback" id="Gly_del_ori" runat="server" visible="false"></span>  
                                          </div>
                                          </div>
                                </div>
                                      
                                      <div class="col-md-6">
                                    <div class="form-group">
                                            <label  class="control-label">UMF</label>
                                            <div id="id_umf" class="input-group" runat="server">
                                            <span class="input-group-addon"><i class="fa fa-hospital-o"></i></span>   
                                           <asp:TextBox ID="umf" runat="server" Style="text-transform: uppercase" CssClass="form-control" Enabled="false" ></asp:TextBox>
                                                <span class="glyphicon glyphicon-pencil form-control-feedback" id="Gly_umf" runat="server" visible="false"></span>  
                                            </div>
                                          </div>
                                      </div>
                                 
                            <%--  <div class="col-md-6">
                           <div class="form-group has-feedback">
                                            <label class="control-label">Código Error</label>
                                            <div class="input-group">
                                            <span class="input-group-addon"><i class="fa fa-exclamation-circle"></i></span>
                                             <asp:TextBox ID="codigo_error" runat="server" Style="text-transform: uppercase" CssClass="form-control" ></asp:TextBox>
                                             </div>
                                           <span class="glyphicon form-control-feedback" aria-hidden="true"></span>
                                           <div class="help-block with-errors"></div>
                                      </div> </div>--%>

                             <div class="col-md-6">
                                 <div class="form-group">
                                            <label class="control-label">Folio</label>
                                     <div id="id_folio" class="input-group" runat="server">
                                     <span class="input-group-addon"><i class="fa fa-list-ol"></i></span>         
                                     <asp:TextBox ID="folio" runat="server" Style="text-transform: uppercase" CssClass="form-control"  Enabled="false"></asp:TextBox>
                                         <span class="glyphicon glyphicon-pencil form-control-feedback" id="Gly_folio" runat="server" visible="false"></span>  
                                     </div>       
                                    </div>
                                      </div>
                                 
                                 <div class="col-md-6">
                                     <div class="form-group">
                                            <label class="control-label">Cto. Pag</label>
                                <div id="id_cto_pag" class="input-group" runat="server">
                                    <span class="input-group-addon"><i class="fa fa-file"></i></span> 
                                             <asp:TextBox ID="cto_pag" runat="server" Style="text-transform: uppercase" CssClass="form-control" Enabled="false" ></asp:TextBox>
                                    <span class="glyphicon glyphicon-pencil form-control-feedback" id="Gly_cto_pag" runat="server" visible="false"></span>  
                                           </div> 
                                         </div>
                                      </div>

                                
                                 
                             <div class="col-md-6">
                                 <div class="form-group">
                                            <label class="control-label">Tipo Mvo. Aju</label>
                                  <div id="id_tipo_mov_ajust" class="input-group" runat="server">
                                    <span class="input-group-addon"><i class="fa fa-bullseye"></i></span>            
                                  <asp:TextBox ID="tipo_mov_ajust" runat="server" Style="text-transform: uppercase" CssClass="form-control" Enabled="false" ></asp:TextBox>
                                      <span class="glyphicon glyphicon-pencil form-control-feedback" id="Gly_tipo_mov_ajust" runat="server" visible="false"></span>  
                                           </div>  
                                     </div>
                                      </div>

                                  <div class="col-md-6">
                                            <label>Observaciones:</label>
                                    <div class="input-group">
                                    <span class="input-group-addon"><i class="fa fa-weixin"></i></span> 
                                        <asp:TextBox ID="obser" runat="server" TextMode="MultiLine" Rows="3" CssClass="form-control" ></asp:TextBox>
                                        </div>                                   
    
                            </div>
                            <div class="col-md-6">
                                <button type="button" class="btn btn-success btn-lg" data-toggle="modal" data-target="#correcto">
                                Corregir  <i class="fa fa-edit"></i>
                            </button>
                                <button type="button" class="btn btn-danger btn-lg" data-toggle="modal" data-target="#cancelar">
                                Cancelar  <i class="fa fa-ban"></i>
                            </button>
                                
                                
                            </div>
                                 </div><!--panel body-->         
                            </div>
            </div>
    </div>
               


    </asp:Panel>
                        <div class="modal fade" id="correcto" tabindex="-1" role="dialog" aria-labelledby="Labelcorrecto" aria-hidden="true">
                                <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                                            <h4 class="modal-title" id="Labelcorrecto">Casuistica</h4>
                                        </div>
                                        <div class="modal-body">
                                            Esta seguro(a) de Corregir el Registro de <strong> <% Response.Write(nom_aseg.Text); %> </strong> ?
                                        </div>
                                        <div class="modal-footer">
                                            <button type="button" class="btn btn-warning" data-dismiss="modal">Cancelar</button>
                                            <asp:Button ID="Aceptar" runat="server" CssClass="btn btn-success" Text="Corregir" OnClick="Aceptar_Click" ></asp:Button>
                                        </div>
                                    </div>
                                </div>
                            </div>

    <div class="modal fade" id="cancelar" tabindex="-1" role="dialog" aria-labelledby="Labelcancelar" aria-hidden="true">
                                <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                                            <h4 class="modal-title" id="Labelcancelar">Casuistica</h4>
                                        </div>
                                        <div class="modal-body">
                                            Esta seguro(a) de salir del modulo de correccion de datos ?
                                        </div>
                                        <div class="modal-footer">
                                            <button type="button" class="btn btn-warning" data-dismiss="modal">Cancelar</button>
                                            <asp:Button ID="Cancelar" runat="server" CssClass="btn btn-success" Text="Aceptar" CausesValidation="False" OnClick="Cancelar_Click" UseSubmitBehavior="False" ></asp:Button>
                                        </div>
                                    </div>
                                </div>
                            </div>





<%--       <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            Modals
                        </div>
                        <div class="panel-body">
                            <button type="button" class="btn btn-primary btn-lg" data-toggle="modal" data-target="#myModal">
                                Launch Demo Modal
                            </button>
                            <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                                            <h4 class="modal-title" id="myModalLabel">Modal title</h4>
                                        </div>
                                        <div class="modal-body">
                                            Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
                                        </div>
                                        <div class="modal-footer">
                                            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                            <button type="button" class="btn btn-primary">Save changes</button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                
            </div>--%>























        
    <%-- <script src="../assets/js/jquery-1.10.2.js"></script>--%>

</asp:Content>

