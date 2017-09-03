using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Configuration;

public partial class admin_pega : System.Web.UI.UserControl
{
     protected int _pageNow=1 ;//当前页码
     protected int _pageTotle=1;//总页数
      protected string _otherQuery ="";//传递页数参数

      public int pageNow
      {
          get
          {
              return _pageNow;
          }
          set
          {
              _pageNow = value;
          }
      }
      public int pageTotle
      {
          get
          {
              return _pageTotle;
          }
          set
          {
              _pageTotle = value;
          }
      }
      public string otherQuery
      {
          get
          {
              return _otherQuery;
          }
          set
          {
              _otherQuery = value;
          }
      }

    //pageurl
    protected void Page_Load(object sender, EventArgs e)
    {
         this.Load += new System.EventHandler(Page_Load);
         string urlstr = System.Convert.ToString(Request.ServerVariables["path_info"]);//这是用来获取当前网页的客户端路径的
         string pageUrl = urlstr.Substring(urlstr.LastIndexOf("/") + 1);
         string pageStr = "";
      

         if (_pageNow - 1 > 0)
         {
             pageStr = pageStr + "<a href='" + pageUrl + "?p=0" + System.Convert.ToString(_pageNow - 1) + _otherQuery + "' class='bigA'>上一页</a>";
         }

         if (_pageNow - 2 > 0)
         {
         }

           
         if (_pageNow - 1 > 3)
         {
             pageStr = pageStr + "<a href='" + pageUrl + "?p=1" + _otherQuery + "' class='smallA'>" + System.Convert.ToString(1) + "</a>";
             pageStr = pageStr + "<span>…</span>";
             pageStr = pageStr + "<a href='" + pageUrl + "?p=" + System.Convert.ToString(_pageNow - 2) + _otherQuery + "' class=\'smallA'>" + System.Convert.ToString(_pageNow - 2) + "</a>";
             pageStr = pageStr + "<a href='" + pageUrl + "?p=" + System.Convert.ToString(_pageNow - 1) + _otherQuery + "' class=\'smallA'>" + System.Convert.ToString(_pageNow - 1) + "</a>";
         }
         else if (true == (_pageNow - 1 == 3))
         {
             pageStr = pageStr + "<a href='" + pageUrl + "?p=1" + _otherQuery + "' class='smallA'>" + System.Convert.ToString(1) + "</a>";
             pageStr = pageStr + "<a href='" + pageUrl + "?p=" + System.Convert.ToString(_pageNow - 2) + _otherQuery + "' class='smallA'>" + System.Convert.ToString(_pageNow - 2) + "</a>";
             pageStr = pageStr + "<a href='" + pageUrl + "?p=" + System.Convert.ToString(_pageNow - 1) + _otherQuery + "' class='smallA'>" + System.Convert.ToString(_pageNow - 1) + "</a>";
         }
         else if (_pageNow - 1 == 2)
         {
             pageStr = pageStr + "<a href='" + pageUrl + "?p=" + System.Convert.ToString(_pageNow - 2) + _otherQuery + "' class='smallA'>" + System.Convert.ToString(_pageNow - 2) + "</a>";
             pageStr = pageStr + "<a href='" + pageUrl + "?p=" + System.Convert.ToString(_pageNow - 1) + _otherQuery + "' class='smallA'>" + System.Convert.ToString(_pageNow - 1) + "</a>";
         }
         else if (_pageNow - 1 == 1)
         {
             pageStr = pageStr + "<a href='" + pageUrl + "?p=" + System.Convert.ToString(_pageNow - 1) + _otherQuery + "' class='smallA'>" + System.Convert.ToString(_pageNow - 1) + "</a>";
         }
         else if (_pageNow - 1 == 0)//
         {
             pageStr = pageStr + "";
         }

         pageStr = pageStr + "<a class='smallA curr'>" + System.Convert.ToString(_pageNow) + "</a>";

         if (_pageTotle - _pageNow > 3)
         {
             pageStr = pageStr + "<a href='" + pageUrl + "?p=" + System.Convert.ToString(_pageNow + 1) + _otherQuery + "' class='smallA'>" + System.Convert.ToString(_pageNow + 1) + "</a>";
             pageStr = pageStr + "<a href='" + pageUrl + "?p=" + System.Convert.ToString(_pageNow + 2) + _otherQuery + "' class='smallA'>" + System.Convert.ToString(_pageNow + 2) + "</a>";
             pageStr = pageStr + "<span>…</span>";
             pageStr = pageStr + "<a href='" + pageUrl + "?p=" + System.Convert.ToString(_pageTotle) + _otherQuery + "' class='smallA'>" + System.Convert.ToString(_pageTotle) + "</a>";
         }
         else if (_pageTotle - _pageNow == 3)
         {
             pageStr = pageStr + "<a href='" + pageUrl + "?p=" + System.Convert.ToString(_pageNow + 1) + _otherQuery + "' class='smallA'>" + System.Convert.ToString(_pageNow + 1) + "</a>";
             pageStr = pageStr + "<a href='" + pageUrl + "?p=" + System.Convert.ToString(_pageNow + 2) + _otherQuery + "' class='smallA'>" + System.Convert.ToString(_pageNow + 2) + "</a>";
             pageStr = pageStr + "<a href='" + pageUrl + "?p=" + System.Convert.ToString(_pageTotle) + _otherQuery + "' class='smallA'>" + System.Convert.ToString(_pageTotle) + "</a>";
         }
         else if (_pageTotle - _pageNow == 2)
         {
             pageStr = pageStr + "<a href='" + pageUrl + "?p=" + System.Convert.ToString(_pageNow + 1) + _otherQuery + "' class=\'smallA\'>" + System.Convert.ToString(_pageNow + 1) + "</a>";
             pageStr = pageStr + "<a href='" + pageUrl + "?p=" + System.Convert.ToString(_pageNow + 2) + _otherQuery + "' class=\'smallA\'>" + System.Convert.ToString(_pageNow + 2) + "</a>";
         }
         else if (_pageTotle - _pageNow == 1)
         {
             pageStr = pageStr + "<a href='" + pageUrl + "?p=" + System.Convert.ToString(_pageNow + 1) + _otherQuery + "' class='smallA\'>" + System.Convert.ToString(_pageNow + 1) + "</a>";
         }
         else
         {
             pageStr = pageStr + "";
         }

         if (_pageNow < _pageTotle)
         {
             pageStr = pageStr + "<a href='" + pageUrl + "?p=" + System.Convert.ToString(_pageNow + 1) + _otherQuery + "' class='bigA'>下一页</a>";
         }
         pegaBox.InnerHtml = pageStr;
       
        
        
     }
    }
        


    