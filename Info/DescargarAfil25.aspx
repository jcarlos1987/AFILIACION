<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterAdmonInfo.master" AutoEventWireup="true" CodeFile="DescargarAfil25.aspx.cs" Inherits="Info_DescargarAfil25" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
                        <a href="Afil-25.aspx"><i class="fa fa-envelope-o fa-spin"></i>Cargar Afil-25</a>
                    </li>
                    <li>
                        <a class="active-menu" href="DescargarAfil25.aspx"><i class="fa fa-comments-o "></i>Descargar Afil-25 </a>
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
                Descarga del Afil-25
            </div>
            <div class="panel-body">
                <div class="form-group col-sm-6 col-lg-4 col-md-12">
                    <div class="form-group">
                        <label>Año</label>
                        <asp:DropDownList ID="anio" class="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="anio_SelectedIndexChanged">
                            <asp:ListItem Value ="" Text="-- Selecciona el año --"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group col-sm-6 col-lg-4 col-md-12">
                    <div class="form-group">
                        <label>Ciclo</label>
                        <asp:DropDownList ID="ciclo" class="form-control" runat="server" AutoPostBack="true" disabled="" OnSelectedIndexChanged="ciclo_SelectedIndexChanged" >
                            <asp:ListItem Value="" Text="-- Selecciona un Ciclo --"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group col-sm-6 col-lg-4 col-md-12">
                    <div class="form-group">
                        <label>Guias</label>
                        <asp:DropDownList ID="guia" class="form-control" disabled="" runat="server" >
                            <asp:ListItem Text="-- Selecciona una guia --" Value=""></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group col-sm-6">
                    <asp:Button ID="aceptar" runat="server" CssClass="btn btn-success" Text="Aceptar" OnClick="aceptar_Click" />
                </div>
                <div class="form-group col-sm-6">
                    <asp:Label ID="LabelMensaje" runat="server" Text="" ></asp:Label>
                </div>
            </div>         
        </div>
    </div>
</asp:Content>

