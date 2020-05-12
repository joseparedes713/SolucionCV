<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AplicacionSIPA1.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server" >
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    
<meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Centro Vivo - Login </title>
	 <script>
        addEventListener("load", function () {
            setTimeout(hideURLbar, 0);
        }, false);

        function hideURLbar() {
            window.scrollTo(0, 1);
        }
    </script>

	<!-- Custom Theme files -->
    <link href="Content/css/style2.css"rel="stylesheet" type="text/css" media="all" />
	<link href="Content/css/font-awesome.min.css" rel="stylesheet" type="text/css" media="all" />
	<!-- //Custom Theme files -->

	<!-- web font -->
	<link href="//fonts.googleapis.com/css?family=Hind:300,400,500,600,700" rel="stylesheet" />
	<!-- //web font -->
 <%--   <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css" integrity="sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh" crossorigin="anonymous" />
    <script src="https://code.jquery.com/jquery-3.4.1.slim.min.js" integrity="sha384-J6qa4849blE2+poT4WnyKhv5vZF5SrPo0iEjwBvKU7imGFAV0wwj1yYfoRSJoZ+n" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js" integrity="sha384-wfSDF2E50Y2D1uUdj0O3uMBJnjuUD4Ih7YwaYd1iqfktj0Uod8GCExl3Og8ifwB6" crossorigin="anonymous"></script>
  --%>
</head>
<body>
    <form id="form1" runat="server">
      <div class="w3layouts-main"> 
	<div class="bg-layerS">
		<h1>Bienvenidos</h1>
		<div class="header-mainS">
			<div class="main-iconS">
                <asp:Image ID="imgIcono" runat="server" ImageUrl="~/img/centrovivo15.png" />
			</div>
			<div class="header-left-bottomS">
				<br />
                <br />
					<div class="">
						
                        <asp:TextBox ID="txtUser" runat="server" required="" placeholder="Usuario" Height="38px" Width="100%" CssClass="input"></asp:TextBox>
					</div>
					<div class=" ">
					<br />
                        <asp:TextBox ID="txtPassword" runat="server" placeholder="Contraseña"  CssClass="input"  TextMode="Password" Height="38px" Width="100%" required="" ></asp:TextBox>
					</div>
					<div class="login-check">
						 <%--<label class="checkbox">
                             <input type="checkbox" name="checkbox" checked=""><i> </i> Keep me logged in</label>--%>
					</div>
					<div class="bottom">
                        <asp:Button ID="btnInicioSession" runat="server" CssClass="btn  button" Text="Inicio Session"  OnClick="btnInicioSession_Click" />
					</div>
					
				    <div >
                        <br />
                        <asp:Label ID="lblSuccess" runat="server" CssClass=" alert alert-success" Visible="false" Width="100%"></asp:Label>
                        <asp:Label ID="lblError" runat="server" CssClass=" alert alert-danger" Visible="false" Width="100%" ></asp:Label>
 				    </div>
			</div>
			
		</div>
		
		<!-- copyright -->
	
		<!-- //copyright --> 
	</div>
</div>	
    </form>
</body>
</html>
