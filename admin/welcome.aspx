<%@ Page Language="C#" AutoEventWireup="true" CodeFile="welcome.aspx.cs" Inherits="welcome" %>
<%@ Register Src="pega.ascx" TagName="pega" TagPrefix="ascx" %>
<%@ Register Src="head.ascx" TagName="head" TagPrefix="ascx" %>
<%@ Register Src="foot.ascx" TagName="foot" TagPrefix="ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>C������������ϵͳ</title>
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
                    <dt class="clearfix"><i class="side_icon_l fl"></i><i class="side_icon_r fr"></i>���ݹ���</dt>
                    <dd class="web_lnk"><a href="stgl.aspx">�������</a></dd>
                    <dd class="web_lnk"><a href="sjgl.aspx">�Ծ����</a></dd>
                </dl>
                <dl class="side_nav set" isok="0">
                    <dt class="clearfix">
                    <i class="side_icon_l fl"></i><i class="side_icon_r fr"></i>ϵͳ����</dt>
                    <dd class="set_pwd"><a href="password.aspx">����Ա�����޸�</a></dd>
                </dl>
            </div>

         <div class="main_box fr">
            <div class="main_tit clearfix"><i></i>ϵͳ����</div>
            <div class="main_des">
                ��ӭʹ��C�����������ϵͳ��
                ��ϵͳ�ṩC���������Ľ������Ծ����ɡ���������������������<br/>
                ���ñ�ϵͳ�ον�ʦ����ͨ��һЩ�򵥵Ĳ��������ã��ڶ�ʱ��������һ����������ĩ�����Ծ�<br/>
                ��ϵͳ�ܹ������ον�ʦ�Ĺ����������ҽ���һ������Ժã����޸ġ�����չ����������<br/>
                ϵͳ��Ҫ��������������������Ծ����ϵͳ���õ����ݡ�<br/>
                �����ǲ���ʹ��ע�����<br />
                1��ϵͳδ���ie6��ie7����������ݲ��ԣ�����ʹ��firefox��chrome��ie8��������������<br />
                2������ϵͳ���õ������ֲ��ִ�txt�ĵ��и��ƻ��ִ�<br />
                3����ϵͳ֧��һ���������⣬�����ʽΪ.xls��
                <br /><br />
                �������ʹ�ù����������κ����⣬������ϵQQ:1109358872��MB:18605484771
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
