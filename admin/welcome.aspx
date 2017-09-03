<%@ Page Language="C#" AutoEventWireup="true" CodeFile="welcome.aspx.cs" Inherits="welcome" %>
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
<body background="images/bg.gif";>
    <form id="form1" runat="server">
    <ascx:head id="head" runat="server" />
    <div class="center" style=" margin:30px auto 0px auto">
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
            <div class="main_tit clearfix"><i></i>系统介绍</div>
            <div class="main_des">
                欢迎使用C语言试题管理系统，
                本系统提供C语言试题库的建立、试卷生成、试题库管理等完整解决方案<br/>
                利用本系统任课教师可以通过一些简单的操作和设置，在短时间内生成一套期中与期末考试试卷<br/>
                该系统能够减轻任课教师的工作量，并且建立一种灵活性好，可修改、可扩展的试题库机制<br/>
                系统主要包括试题库管理、试题管理、试卷管理、系统设置等内容。<br/>
                以下是部分使用注意事项：<br />
                1、系统未针对ie6、ie7浏览器做兼容测试，建议使用firefox、chrome、ie8及以上浏览器浏览<br />
                2、建议系统中用到的文字部分从txt文档中复制或手打<br />
                3、本系统支持一键导入试题，导入格式为.xls。
                <br /><br />
                如果您在使用过程中遇到任何问题，可以联系QQ:1109358872、MB:18605484771
            </div>
        </div>
    </div>    
    <div>
    <span class="clear"></span>
    </div>
    <ascx:foot id="foot" runat="server" />
</form>
</body>

</html>
