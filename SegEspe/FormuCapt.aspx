<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPageSegEsp.master" AutoEventWireup="true" CodeFile="FormuCapt.aspx.cs" Inherits="SegEspe_Default" %>

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
</asp:Content>

