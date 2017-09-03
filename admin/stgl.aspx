<%@ Page Language="C#" AutoEventWireup="true" CodeFile="stgl.aspx.cs" Inherits="admin_stgl" %>
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
                    <dd class="web_lnk"><a href="sjgl.aspx">�Ծ����</a></dd>
                </dl>
                <dl class="side_nav set" isok="0">
                    <dt class="clearfix">
                    <i class="side_icon_l fl"></i><i class="side_icon_r fr"></i>ϵͳ����</dt>
                    <dd class="set_pwd"><a href="password.aspx">����Ա�����޸�</a></dd>
                </dl>
            </div>
        <div class="main_box fr">
            <div class="main_tit clearfix">���ݹ���<span>></span>�������<span>></span>�����б����</div>
            <div class="main_head clearfix">
                <a href="stgl_edit.aspx?c=<%=c%>" class="input_href fr main_head_add">�������</a>
                <asp:DropDownList ID="drop_cla" runat="server" AutoPostBack="true" 
                    CssClass="main_head_select" 
                    onselectedindexchanged="drop_cla_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
            
            <div class="sty2_box">
                <ul class="sty2_list sty2_tit clearfix">
                    <li class="sty2_lie fl br"><p class="cp">���</p></li>
                    <li class="sty2_lie fl br "><p class="cp">����</p></li>
                    <li class="sty2_lib fl bl "><p class="left">��������</p></li>
                    <li class="sty2_lic fr bl"><p class="cp">����</p></li>
                    <li class="sty2_lid fl bl "><p class="left">����</p></li>
                </ul>
                <asp:Repeater ID="Rep_list" runat="server" onitemcommand="Rep_list_ItemCommand">
                    <ItemTemplate>
                        <ul class="sty2_list clearfix">
                            <li class="sty2_lie fl"><p class="cp"><asp:Label ID="labe_id" runat="server" Text='<%#Eval("stID")%>'></asp:Label></p></li>
                            <li class="sty2_lie fl"><p class="cp"><%#Eval("stlx")%></p></li>
                            <li class="sty2_lib fl"><p class="left"><%#Eval("stnr")%></p></li>
                            <li class="sty2_lie fr"><a href="stgl_edit.aspx?i=<%#Eval("stID")%>&p=<%=p%>" class="sty2_edit show_add">�༭</a></li>
                            <li class="sty2_lie fr"><asp:LinkButton ID="link_dele" runat="server" CommandName="dele" CommandArgument='<%#Eval("stID")%>'  CssClass="sty2_edit">ɾ��</asp:LinkButton></li>
                            <li class="sty2_lid fl"><p class="left"><%# function_all.GetMyDate( Eval("stsj").ToString(), "YMD")%></p></li>
                        </ul>
                    </ItemTemplate>
                </asp:Repeater>
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
