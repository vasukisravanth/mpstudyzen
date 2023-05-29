<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentRegistration.aspx.cs" Inherits="StudentMaterialBoard.StudentRegistration" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>

<head>
	<title>Student Material Board System</title>
	<!-- Meta-Tags -->
	<meta name="viewport" content="width=device-width, initial-scale=1">
	<meta charset="utf-8">
	<meta name="keywords" content="Elite login Form a Responsive Web Template, Bootstrap Web Templates, Flat Web Templates, Android Compatible Web Template, Smartphone Compatible Web Template, Free Webdesigns for Nokia, Samsung, LG, Sony Ericsson, Motorola Web Design">
	<script>
	    addEventListener("load", function () {
	        setTimeout(hideURLbar, 0);
	    }, false);

	    function hideURLbar() {
	        window.scrollTo(0, 1);
	    }
	</script>
	<!-- //Meta-Tags -->
	<!-- Stylesheets -->
	<link href="css/font-awesome.css" rel="stylesheet">
	<link href="css/style_css.css" rel='stylesheet' type='text/css' />
	<!--// Stylesheets -->
	<!--fonts-->
	<link href="//fonts.googleapis.com/css?family=Source+Sans+Pro:200,200i,300,300i,400,400i,600,600i,700,700i,900,900i" rel="stylesheet">
	<!--//fonts-->
</head>

<body>
	<h1>Student Registration Form </h1>
	<div class="w3ls-login">
		<!-- form starts here -->
		<form id="form1" runat="server">
        
			<div class="agile-field-txt">
				<label>
					<i class="fa fa-user" aria-hidden="true"></i>Enter Student USN :</label>
				<asp:TextBox ID="txtUSN" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter Student USN" ValidationGroup="A" ControlToValidate="txtUSN" ForeColor="#fb0b57"></asp:RequiredFieldValidator>
			</div>
			<div class="agile-field-txt">
				<label>
					<i class="fa fa-email" aria-hidden="true"></i> Enter Student Name :</label>
				
				<asp:TextBox ID="txtName" runat="server" ></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter Student Name" ValidationGroup="A" ControlToValidate="txtName" ForeColor="#fb0b57"></asp:RequiredFieldValidator>
				
			</div>
		<div class="agile-field-txt">
				<label>
					<i class="fa fa-email" aria-hidden="true"></i> Enter Email Id :</label>
				
				<asp:TextBox ID="txtEmailId" runat="server" ></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Email Id" ValidationGroup="A" ControlToValidate="txtEmailId" ForeColor="#fb0b57"></asp:RequiredFieldValidator>
				
			</div>
			<!-- //script for show password -->
			<div class="w3ls-login  w3l-sub">
				<asp:Label ID="lblMsg" runat="server" Text=""></asp:Label><br />
                            <asp:Button ID="btnVerifyEmail" runat="server" Text="Verify Email" 
                                 ValidationGroup="A" onclick="btnVerifyEmail_Click" />
                            <asp:Button ID="btnHome" runat="server" Text="Home" onclick="btnHome_Click" />
			</div>

            
        
		</form>
	</div>
	<!-- //form ends here -->
	<!--copyright-->
	<div class="copy-wthree">
		<p>© 2023 Student Material Board System . All Rights Reserved | Design by
			Student Material Board System
		</p>
	</div>
	<!--//copyright-->
</body>

</html>
