<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>Departamento Supervision de Afiliación Web</title>

<!-- Meta-Tags -->
<meta name="viewport" content="width=device-width, initial-scale=1"/>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta name="keywords" content="Natural Signin Form Widget Responsive, Login Form Web Template, Flat Pricing Tables, Flat Drop-Downs, Sign-Up Web Templates, Flat Web Templates, Login Sign-up Responsive Web Template, Smartphone Compatible Web Template, Free Web Designs for Nokia, Samsung, LG, Sony Ericsson, Motorola Web Design"/>
<script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); } </script>
<!-- //Meta-Tags -->

<!-- Style --> <link rel="stylesheet" href="css/style.css" type="text/css" media="all"/>

<!-- Fonts -->
<link href="//fonts.googleapis.com/css?family=Quicksand:300,400,500,700" rel="stylesheet"/>
<!-- //Fonts -->

</head>
<body>
    <form id="form1" runat="server">
   <div class="banner">
<div class="agileinfo-dot">
	<h1>Departamento de Supervisión de Afiliación y Vigencia</h1>

	<div class="w3layoutscontaineragileits">
	<h2>Iniciar Sesión</h2>
		
             <asp:TextBox ID="Username" runat="server" placeholder="USUARIO" required=""></asp:TextBox>
             <asp:TextBox ID="password" TextMode="Password" runat="server" placeholder="CONTRASEÑA"  required=""></asp:TextBox>
			
			<ul class="agileinfotickwthree">
				<li>					
                    <asp:CheckBox ID="brand1" runat="server" />
					<label for="brand1"><span></span>Recordarme</label>
					<a href="#">Olvidaste tu Contraseña?</a> 
				</li>
			</ul>
			<div class="aitssendbuttonw3ls">
			<%--	<input id="logueo" type="submit" value="ACCEDER" onclick="Button1_Click"/>--%>
                <asp:Button ID="Button1" runat="server" Text="ACCEDER" OnClick="Button1_Click" />
				<div class="clear"></div>
			</div>
		
	</div>
	
	<div class="w3footeragile">
		<p> &copy; Katia Marcela Mendoza Ghigliazza | Titular de la Jefatura de Servicios de Afiliación y Cobranza || Estado de México Poniente </p>
        Dudas y Aclaraciones comunicarse con el equipo de Desarrollo Informático de la Jefatura de Servicios De Afiliación y Cobranza al siguiente correo <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" ForeColor="White">isaac.barrientos@imss.gob.mx</asp:LinkButton> , a el número 722 2 14 50 77 / 722 2 14 55 50 ext 1253
	</div>

</div>
</div>
   </form>
</body>
</html>
