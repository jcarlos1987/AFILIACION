<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Error.aspx.cs" Inherits="Menu_Error" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Supervisión de Afiliación Error</title>
       <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    
    <!-- BOOTSTRAP STYLES-->
    <link href="../assets/css/bootstrap.css" rel="stylesheet" />
    <!-- FONTAWESOME STYLES-->
    <link href="../assets/css/font-awesome.css" rel="stylesheet" />
     <!-- PAGE LEVEL STYLES-->
    <link href="../assets/css/error.css" rel="stylesheet" />
    <!-- GOOGLE FONTS-->
    <link href='http://fonts.googleapis.com/css?family=Open+Sans' rel='stylesheet' type='text/css' />
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <div class="container">
        
         <div class="row text-center">
               
                <div class="col-md-12 set-pad" >
                           
                             <div class="alert alert-danger"><strong class="error-txt">Alerta ! </strong></div>
                           <p class="p-err">No Tienes Acceso a este Modulo</p>
                    <a href="../Casuistica/Default.aspx" class="btn btn-danger" ><i class="fa fa-mail-reply fa-spin"></i>&nbsp;Por favor regresa</a>
                        </div>
                
                
        </div>
    </div>
  
    <div class="container">
        <div class="row text-center">
            <div class="col-md-12">
            </div>

        </div>

    </div>
  
  
    <hr />
    <div class="container">
        <div class="row text-center">
            <div class="col-md-12">
                
                Todos los derechos reservados | &copy Jefatura de Servicios de Afiliación y Cobranza
            </div>

        </div>

    </div>
    </div>
    </form>
</body>
</html>
