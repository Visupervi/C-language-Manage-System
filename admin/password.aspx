<%@ Page Language="C#" AutoEventWireup="true" CodeFile="password.aspx.cs" Inherits="admin_password" %>
<%@ Register Src="head.ascx" TagName="head" TagPrefix="ascx" %>
<%@ Register Src="foot.ascx" TagName="foot" TagPrefix="ascx" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>C�����������ϵͳ</title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="js/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="js/kill-ie6.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <ascx:head id="head" runat="server" />
    <div class="block40"></div>
    <div class="center clearfix">
    <script type="text/javascript">
        $(function () {
            var fnav = $(".<%=f_nav%>");
            var cnav = $(".<%=c_nav%>");

            if (fnav) {
                fnav.addClass("curr");
                fnav.attr("isok", "1");
                cnav.addClass("curr");
            }
            $(".side_nav").click(function () {
                var isok = $(this).attr("isok");
                if (isok == 0) {
                    $(this).addClass("curr");
                    $(this).attr("isok", "1");
                } else {
                    $(this).removeClass("curr");
                    $(this).attr("isok", "0");
                }
            });
        });
</script>
            <div class="left">
            	<dl class="side_nav web" isok="0">
                    <dt class="clearfix"><i class="side_icon_l fl"></i><i class="side_icon_r fr"></i>���ݹ���</dt>
                    <dd class="web_lnk"><a href="stgl.aspx">�������</a></dd>
                    <dd class="web_lnk"><a href="#">�Ծ����</a></dd>
                </dl>
                <dl class="side_nav set" isok="0">
                    <dt class="clearfix">
                    <i class="side_icon_l fl"></i><i class="side_icon_r fr"></i>ϵͳ����</dt>
                    <dd class="set_pwd"><a href="/admin/set/password.aspx">����Ա�����޸�</a></dd>
                </dl>
            </div>
            <div class="main_box fr">
            	<div class="main_tit clearfix"><i></i>ϵͳ����<span>></span>����Ա�˺š������޸�</div>
            	<div class="block40"></div>
            	<div class="form_box">
                <dl class="main_form clearfix">
                    <dt class="fl">����Ա�˺�</dt>
                    <dd class="fr">
                        <asp:TextBox ID="text_adm" runat="server" CssClass="input_text text1"></asp:TextBox> 
                        <h4><span>����</span>����Ϊ�գ����֧��50���ַ���������0-9��a-z��A-Z�����</h4>
                    </dd>
                </dl>
                <dl class="main_form clearfix">
                    <dt class="fl">ԭ����</dt>
                    <dd class="fr">
                       <asp:TextBox ID="text_opw" runat="server" CssClass="input_text text1"></asp:TextBox> 
                        <h4><span>����</span>����Ϊ��</h4>
                    </dd>
                </dl>
                <dl class="main_form clearfix">
                    <dt class="fl">������</dt>
                    <dd class="fr">
                        <asp:TextBox ID="text_npw" runat="server" CssClass="input_text text1"></asp:TextBox> 
                        <h4><span>����</span>����Ϊ��</h4>
                    </dd>
                </dl>
                <dl class="main_form clearfix">
                    <dt class="fl">ȷ��������</dt>
                    <dd class="fr">
                        <asp:TextBox ID="text_spw" runat="server" CssClass="input_text text1"></asp:TextBox>
                        <h4><span>����</span>����Ϊ�գ������������뱣��һ��</h4>
                    </dd>
                </dl>
                
                <dl class="main_form clearfix">
                    <dt class="fl"></dt>
                    <asp:Button ID="butt_ok" runat="server" Text="�����ύ"  CssClass="input_butt butt1" 
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
