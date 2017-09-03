<%@ Page Language="C#" AutoEventWireup="true" CodeFile="stgl_edit.aspx.cs" Inherits="admin_stgl_edit" %>
<%@ Register Src="pega.ascx" TagName="pega" TagPrefix="ascx" %>
<%@ Register Src="head.ascx" TagName="head" TagPrefix="ascx" %>
<%@ Register Src="foot.ascx" TagName="foot" TagPrefix="ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>C语言试题库管理系统</title>
    <link rel="stylesheet" type="text/css" href="css/base.css"/>
    <link rel="stylesheet" type="text/css" href="css/ascx.css"/>
    <link rel="stylesheet"  type="text/css" href="css/style.css" />
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
                    <dt class="clearfix"><i class="side_icon_l fl"></i><i class="side_icon_r fr"></i>内容管理</dt>
                    <dd class="web_lnk"><a href="stgl.aspx">试题管理</a></dd>
                    <dd class="web_lnk"><a href="sjgl.aspx">试卷管理</a></dd>
                </dl>
                <dl class="side_nav set" isok="0">
                    <dt class="clearfix">
                    <i class="side_icon_l fl"></i><i class="side_icon_r fr"></i>系统设置</dt>
                    <dd class="set_pwd"><a href="password.aspx">管理员密码修改</a></dd>
                </dl>
            </div>
        <div class="main_box fr">
            <div class="main_tit clearfix">内容管理<span>></span><a href="stgl.aspx">试题管理</a></div>

            <div class="form_box">
                <div class="block40"></div>
                <dl class="main_form clearfix">
                    <dt class="fl">试题题型：</dt>
                    <dd class="fr">
                        <asp:TextBox ID="Text_tx" runat="server" CssClass="input_text text1"></asp:TextBox>
                        <h4><span>必填</span>最大支持200个字符，建议50个字符以内</h4>
                    </dd>
                </dl>

                <dl class="main_form clearfix">
                    <dt class="fl">试题内容：</dt>
                    <dd class="fr">
                        <asp:TextBox ID="Text_nr" runat="server" TextMode="MultiLine"></asp:TextBox>
                    </dd>
                </dl>
                
                <dl class="main_form clearfix">
                    <dt class="fl">试题答案：</dt>
                    <dd class="fr">
                        <asp:TextBox ID="Text_da" runat="server" CssClass="input_text text1"></asp:TextBox>
                        <h4><span>必填</span>最大支持200个字符，建议50个字符以内</h4>
                    </dd>
                    <div class="clear"></div>
                </dl>
                <dl class="main_form clearfix">
                    <dt class="fl">试题难度：</dt>
                    <dd class="fr">
                        <asp:TextBox ID="Text_nd" runat="server" CssClass="input_text text1"></asp:TextBox>
                        <h4><span>必填</span>最大支持200个字符，建议50个字符以内</h4>
                    </dd>
                    <div class="clear"></div>
                </dl>
                <dl class="main_form clearfix">
                    <dt class="fl">试题章节：</dt>
                    <dd class="fr">
                        <asp:TextBox ID="Text_zj" runat="server" CssClass="input_text text1"></asp:TextBox>
                        <h4><span>必填</span>最大支持200个字符，建议50个字符以内</h4>
                    </dd>
                    <div class="clear"></div>
                </dl>
                <dl class="main_form clearfix">
                    <dt class="fl">试题分数：</dt>
                    <dd class="fr">
                        <asp:TextBox ID="Text_fz" runat="server" CssClass="input_text text1"></asp:TextBox>
                        <h4><span>必填</span>最大支持200个字符，建议50个字符以内</h4>
                    </dd>
                    <div class="clear"></div>
                </dl>
                
                <dl class="main_form clearfix">
                    <dt class="fl">试题标识：</dt>
                    <dd class="fr">
                        <asp:TextBox ID="Text_bz" runat="server" CssClass="input_text text1"></asp:TextBox>
                        <h4><span>必填</span>最大支持200个字符，建议50个字符以内</h4>
                    </dd>
                    <div class="clear"></div>
                </dl>
                
                

                <dl class="main_form clearfix">
                    <dt class="fl"></dt>
                    <dd class="fr">
                        <asp:Button ID="butt_ok" runat="server" Text="数据提交" 
                        CssClass="input_butt butt1" onclick="butt_ok_Click" />
                     </dd>
                     <dt class="fl">
                     </dt>
                     <dd class="fr"> 
                        <asp:Button ID="butt_input" runat="server" Text="批量导入" 
                        CssClass="input_butt butt1" onclick="butt_Click"/>
                        <asp:FileUpload ID="fileId" runat="server" />
                    </dd>
                </dl>
            </div>
        </div>
    </div>

    <div class="block40"></div>
    <ascx:foot id="foot" runat="server" />
    </form>
</body>
</html>
