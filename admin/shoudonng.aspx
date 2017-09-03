<%@ Page Language="C#" AutoEventWireup="true" CodeFile="shoudonng.aspx.cs" Inherits="admin_shoudonng" %>
<%@ Register Src="pega.ascx" TagName="pega" TagPrefix="ascx" %>
<%@ Register Src="head.ascx" TagName="head" TagPrefix="ascx" %>
<%@ Register Src="foot.ascx" TagName="foot" TagPrefix="ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
            <div class="main_tit clearfix">内容管理<span>>手动组卷</span></div>
            <div class="main_head clearfix">
                <asp:DropDownList ID="drop_cla" runat="server" AutoPostBack="true" 
                    CssClass="main_head_select" 
                    onselectedindexchanged="drop_cla_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
            
            <div class="sty2_box">
                <ul class="sty2_list sty2_tit clearfix">
                    <li class="sty2_lie fl br"><p class="cp">编号</p></li>
                    <li class="sty2_lie fl br "><p class="cp">题型</p></li>
                    <li class="sty2_lib fl bl "><p class="left">试题内容</p></li>
                    <li class="sty2_lic fr bl"><p class="cp">操作</p></li>
                    <li class="sty2_lid fl bl "><p class="left">日期</p></li>
                </ul>
                <asp:Repeater ID="Rep_list" runat="server" onitemcommand="Rep_list_ItemCommand">
                    <ItemTemplate>
                        <ul class="sty2_list clearfix">
                            <li class="sty2_lie fl"><p class="cp"><asp:Label ID="labe_id" runat="server" Text='<%#Eval("stID")%>'></asp:Label></p></li>
                            <li class="sty2_lie fl"><p class="cp"><%#Eval("stlx")%></p></li>
                            <li class="sty2_lib fl"><p class="left"><%#Eval("stnr")%></p></li>
                            <li class="sty2_lie fr"><asp:LinkButton ID="link_tianjia" runat="server" CommandName="tianjia" CommandArgument='<%#Eval("stID") %>' CssClass="sty2_edit" >添加组卷</asp:LinkButton></li>
                            <li class="sty2_lie fr"><asp:LinkButton ID="link_dele" runat="server" CommandName="dele" CommandArgument='<%#Eval("stID")%>'  CssClass="sty2_edit">删除</asp:LinkButton></li>
                            <li class="sty2_lid fl"><p class="left"><%# function_all.GetMyDate( Eval("stsj").ToString(), "YMD")%></p></li>
                        </ul>
                    </ItemTemplate>
                </asp:Repeater>
                 <dl class="main_form clearfix">
                    <dt class="fl">试卷内容：</dt>
                        <dd class="fr">
                            <asp:TextBox ID="Text_nr" runat="server" TextMode="MultiLine"></asp:TextBox>
                        </dd>
                 </dl>
                 <dl  class="main_form clearfix">
                 <dt class="fl">试卷导出：</dt>
                    <dd class="fr">
                        <asp:Button ID="butt_ok" runat="server" Text="导出试卷" 
                        CssClass="input_butt butt1" onclick="butt_ok_Click" />
                    </dd>
                  </dl>
            </div>

            <div class="block40"></div>
           <div class="main_foot"><ascx:pega id="pega" runat="server" /></div>
        </div>
    </div>

    <div class="block40"></div>
    <ascx:foot id="foot" runat="server" />
    </form>
</body>
</html>
