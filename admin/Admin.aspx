<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="admin_Admin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<link rel="stylesheet" type="text/css" href="css/login.css" />
    <title>C语言试题管理系统</title>
    <script type="text/javascript" src="js/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="js/kill-ie6.js"></script>
    <script type="text/javascript">
        $(function () { $(".top_box").css("height", $(window).height() + "px"); });
        $(window).resize(function () { $(".top_box").css("height", $(window).height() + "px"); });
    </script>
</head>
<body>
     <form id="form1" runat="server">
     <div class="top_box"></div>
     <div class="log_box">
   		<div class="log_top">
            <h1>C语言试题管理系统后台系统</h1>
            <h2>C Question Management System</h2>
        </div>
        
        <dl class="log_foot clearfix">
            <dt class="fl"><span>帐号</span></dt>
            <dd class="fl"><asp:TextBox ID="text_adm" runat="server"></asp:TextBox></dd>
            <dt class="fl"><span>密码</span></dt>
            <dd class="fl"><asp:TextBox ID="text_pwd" runat="server" TextMode="Password"></asp:TextBox></dd>
            <dt class="fl"><asp:Button ID="butt_log" runat="server" Text="登录" onclick="butt_log_Click" /></dt>
        </dl>
        
        <p class="log_copy">Copyright @2016vichaovi </p>
   </div>
    </form>
</body>
</html>
