<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="admin_Register" %>
<%@ Register Src="head.ascx" TagName="head" TagPrefix="ascx" %>
<%@ Register Src="foot.ascx" TagName="foot" TagPrefix="ascx" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>C语言试题管理系统</title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="js/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="js/kill-ie6.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <ascx:head id="head" runat="server" />
    <div class="block40"></div>
    <div class="center clearfix">
    
            <div class="main_box fr">
            	<div class="main_tit clearfix"><i></i>系统设置<span>></span>用户注册</div>
            	<div class="block40"></div>
            	<div class="form_box">
                <dl class="main_form clearfix">
                    <dt class="fl">账号</dt>
                    <dd class="fr">
                        <asp:TextBox ID="text_adm" runat="server" CssClass="input_text text1"></asp:TextBox> 
                        <h4><span>必填</span>不能为空，最大支持50个字符，可以是0-9、a-z、A-Z的组合</h4>
                    </dd>
                </dl>
               
                <dl class="main_form clearfix">
                    <dt class="fl">密码</dt>
                    <dd class="fr">
                        <asp:TextBox ID="text_npw" runat="server" CssClass="input_text text1"></asp:TextBox> 
                        <h4><span>必填</span>不能为空</h4>
                    </dd>
                </dl>
                <dl class="main_form clearfix">
                    <dt class="fl"></dt>
                    <asp:Button ID="butt_ok" runat="server" Text="数据提交"  CssClass="input_butt butt1" 
                            onclick="butt_ok_Click1"/>                
                </dl>
            </div>
        </div>
    </div>
    <div class="block40"></div>
    <ascx:foot id="foot" runat="server" />
    </form>
</body>
</html>
