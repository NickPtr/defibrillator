﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DefibrillatorBase.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
      <title></title>
    	<meta charset="UTF-8">
	<meta name="viewport" content="width=device-width, initial-scale=1">
<!--===============================================================================================-->	
	<link rel="icon" type="image/png" href="images/icons/favicon.ico"/>
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="vendor/bootstrap/css/bootstrap.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="fonts/font-awesome-4.7.0/css/font-awesome.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="fonts/Linearicons-Free-v1.0.0/icon-font.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="vendor/animate/animate.css">
<!--===============================================================================================-->	
	<link rel="stylesheet" type="text/css" href="vendor/css-hamburgers/hamburgers.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="vendor/animsition/css/animsition.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="vendor/select2/select2.min.css">
<!--===============================================================================================-->	
	<link rel="stylesheet" type="text/css" href="vendor/daterangepicker/daterangepicker.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="css/util.css">
	<link rel="stylesheet" type="text/css" href="css/main.css">
</head>
<body>

 <div class="limiter">
     <div class="container-login100">
         <div class="wrap-login100 p-l-55 p-r-55 p-t-65 p-b-50">
              <form id="form1" class="login100-form validate-form" runat="server">
                  <span class="login100-form-title p-b-33">
						Account Login
					</span>
       
            <div>
        
         <asp:PlaceHolder runat="server" ID="LoginStatus" Visible="false">
            <p>
               <asp:Literal runat="server" ID="StatusText" />
            </p>
         </asp:PlaceHolder>
         <asp:PlaceHolder runat="server" ID="LoginForm" Visible="false">
            <div  class="wrap-input100 validate-input" data-validate = "Valid email is required: ex@abc.xyz">
               <div>
                  <asp:TextBox Placeholder="Mail" class="input100" type="text" runat="server" ID="UserName" />
                   <span class="focus-input100-1"></span>
				   <span class="focus-input100-2"></span>
               </div>
            </div>
            <div  class="wrap-input100 validate-input">
               <div >
                  <asp:TextBox runat="server" Placeholder="Password" class="input100" ID="Password" TextMode="Password" />
                   <span class="focus-input100-1"></span>
				   <span class="focus-input100-2"></span>
               </div>
            </div>
            <div class="container-login100-form-btn m-t-20">
               
                  <asp:Button runat="server" class="login100-form-btn" OnClick="SignIn" Text="Log in" />
               
            </div>
         </asp:PlaceHolder>
                <div class="text-center">
						<span class="txt1">
							Not a Member?
						</span>

						<asp:Linkbutton runat="server" onClick="CreateAcc" class="txt2 hov1">
							Sign up
						</asp:Linkbutton>
					</div>
         
    </form>
         </div>

     </div>

 </div>
   

    <script src="vendor/jquery/jquery-3.2.1.min.js"></script>
<!--===============================================================================================-->
	<script src="vendor/animsition/js/animsition.min.js"></script>
<!--===============================================================================================-->
	<script src="vendor/bootstrap/js/popper.js"></script>
	<script src="vendor/bootstrap/js/bootstrap.min.js"></script>
<!--===============================================================================================-->
	<script src="vendor/select2/select2.min.js"></script>
<!--===============================================================================================-->
	<script src="vendor/daterangepicker/moment.min.js"></script>
	<script src="vendor/daterangepicker/daterangepicker.js"></script>
<!--===============================================================================================-->
	<script src="vendor/countdowntime/countdowntime.js"></script>
<!--===============================================================================================-->
	<script src="js/main.js"></script>
</body>
</html>
