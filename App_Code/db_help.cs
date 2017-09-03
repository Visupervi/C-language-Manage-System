using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Web.UI.WebControls;


/// <summary>
///db_help 的摘要说明
/// </summary>
public class db_help
{
    private DataSet ds;
    private string connectingstring;
    private SqlConnection  myConn;
    private SqlCommand myCmd;
    private SqlDataAdapter myAdapter;
	public db_help()
	{
        string connectingstring =System.Web.Configuration.WebConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
         myConn = new SqlConnection(connectingstring);
         JK1991_ChecSql();	
	}
    //数据库的打开关闭连接操作
    public void Open()
    {
        if (!(myConn.State == ConnectionState.Closed))
        {
            myConn.Close();
        }
        try
        {
            myConn.Open();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
            myConn.Close();
        }
    }
    public void Close()
    {
        myConn.Close();
    }
    //=====================================================
    //函数名：Fill
    //功能描述：填充Ds
    //输出参数：sqlstr,SQL字符串
    //返 回 值：无
    //创建时间：2016-4-12
    //修改时间：2016-4-12
    //作    者：
    //附加说明：
    //======================================================
    public void Fill(string sqlstr)
    {
        Open();
        ds = new DataSet();
        myAdapter = new SqlDataAdapter(sqlstr, myConn);
        try
        {
            myAdapter.Fill(ds);
        }
        catch (Exception)
        {
            //MessageBox.Show(ex.Message);
            Close();
        }
        Close();
    }
    //================================================
    //函数名：ExecNonSql
    //功能描述：执行无返回值的数据库操作
    //输入参数：sqlstr，查询的SQL字符串
    // 返 回 值：无
    //创建日期：2016-4-12
    //修改日期：2016-4-12
    //作    者：
    //附加说明：
    //=================================================
    public void ExecNonSql(string sqlstr)
    {
        Open();
        myCmd = new SqlCommand(sqlstr, myConn);
        myCmd.ExecuteNonQuery();
        myCmd.Dispose();
        Close();
    }

    //=============================================================
    // 函 数 名：ExecReaderSql
    // 功能描述：执行查询操作
    // 输入参数：sqlstr，查询的SQL字符串
    // 返 回 值：查询结果，返回SqlDataReader对象
    // 创建日期：2016-4-12
    // 修改日期：2016-4-12
    // 作    者：
    // 附加说明：
    //==============================================================
    public  SqlDataReader ExecReaderSql(string sqlstr)
    {
        Open();
        myCmd = new SqlCommand(sqlstr, myConn);
        SqlDataReader reader = myCmd.ExecuteReader();
        myCmd.Dispose();
        return reader;
       //Close();
    }

    //=============================================================
    // 函 数 名：Mdataset
    // 功能描述：返回DataSet
    //  输入参数：sqlstr，查询的SQL字符串
    //  返 回 值：查询结果，返回DataTable对象
    // 创建日期：2016-04-24
    //  修改日期：2011-04-24
    //作    者：
    //  附加说明：
    //==============================================================
    public DataSet Mdataset(string sqlstr)
    {
        Open();
        Fill(sqlstr);
        DataSet mydatatable = ds;
        return mydatatable;
        //Close();
    }


    //=============================================================
    // 函 数 名：MPagedDataSource
    // 功能描述：返回PagedDataSource
    // 输入参数：sqlstr，查询的SQL字符串；page，要显示的页码；pagesize，每页条数
    // 返 回 值：查询结果，返回PagedDataSource对象
    // 创建日期：2016-04-24
    // 修改日期：2016-04-24
    // 作    者：
    // 附加说明：
    //===============================================================
    public PagedDataSource MPagedDataSource(string sqlstr, int page, int pagesize)
    {
        PagedDataSource objPds = new PagedDataSource();
        ds = Mdataset(sqlstr);
        if (ds.Tables.Count != 0)
        {
            objPds.DataSource = ds.Tables[0].DefaultView;

            if (pagesize == 0)
            {
            }
            else
            {
                objPds.AllowPaging = true;
                objPds.PageSize = pagesize;

                if (page < 1)
                {
                    page = 1;
                }
                if (page > objPds.PageCount)
                {
                    page = System.Convert.ToInt32(objPds.PageCount);
                }
                objPds.CurrentPageIndex = page - 1;
            }
        }
        else
        {
           //HttpContext.Current.Response.Write(sqlstr);
        }
        return objPds;
    }

    private void JK1991_ChecSql()
    {
        string JK1986_Sql = "";
        string[] JK_Sql =null;
        string k = "";
        JK1986_Sql = "exec↓select↓alter↓exists↓union↓order↓execute↓xp_cmdshell↓insert↓update↓delete↓declare↓sp_oacreate↓wscript.shell↓xp_regwrite↓\'";
        JK_Sql = JK1986_Sql.Split('↓');
        foreach (string tempLoopVar_k in JK_Sql)
        {
            k = tempLoopVar_k;
            //-----------------------防 GET 注入-----------------------
            if (System.Web.HttpContext.Current.Request.QueryString.ToString() != "")
            {
                int jk = 0;
                string getip ="";
                for (jk = 0; jk <= System.Web.HttpContext.Current.Request.QueryString.Count - 1; jk++)
                {
                    if (System.Web.HttpContext.Current.Request.QueryString[System.Web.HttpContext.Current.Request.QueryString.Keys[jk].ToString()].ToLower().Contains(k) == true)
                    {
                        System.Web.HttpContext.Current.Response.Write("<script Language=JavaScript>alert(\'ASP.NET( C#.NET版本 )防注入程序警告您，请勿提交非法字符！\');</" + "script>");
                        System.Web.HttpContext.Current.Response.Write("非法操作！系统做了如下记录 ↓" + "<br>");
                        if (System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != "")
                        {
                            getip = System.Convert.ToString(System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"]);
                        }
                        else
                        {
                            getip = System.Convert.ToString(System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"]);
                        }
                        System.Web.HttpContext.Current.Response.Write("操 作 IP：" + getip + "<br>");
                        System.Web.HttpContext.Current.Response.Write("操 作 时 间：" + DateTime.Now.ToString() + "<br>");
                        System.Web.HttpContext.Current.Response.Write("操 作 页 面：" + System.Web.HttpContext.Current.Request.ServerVariables["URL"] + "<br>");
                        System.Web.HttpContext.Current.Response.Write("提 交 方 式：GET " + "<br>");
                        System.Web.HttpContext.Current.Response.Write("提 交 参 数：" + k + "<br>");
                        System.Web.HttpContext.Current.Response.Write("提 交 数 据：" + System.Web.HttpContext.Current.Request.QueryString[System.Web.HttpContext.Current.Request.QueryString.Keys[jk]].ToLower() + "<br>");
                        System.Web.HttpContext.Current.Response.End();
                    }
                    if (jk > System.Web.HttpContext.Current.Request.QueryString.Count)
                    {
                        break;
                    }
                }
            }
            //-----------------------防 Post 注入-----------------------
            if (System.Web.HttpContext.Current.Request.Form.ToString() != "")
            {
                int jk = 0;
                string getip = "";
                for (jk = 0; jk <= System.Web.HttpContext.Current.Request.Form.Count - 1; jk++)
                {
                    if (System.Web.HttpContext.Current.Request.Form[System.Web.HttpContext.Current.Request.Form.Keys[jk].ToString()].ToLower().Contains(k) == true)
                    {
                        System.Web.HttpContext.Current.Response.Write("<script Language=JavaScript>alert(\'ASP.NET( VB.NET版本 )防注入程序警告您，请勿提交非法字符！\');</" + "script>");
                        System.Web.HttpContext.Current.Response.Write("非法操作！系统做了如下记录 ↓" + "<br>");
                        if (System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != "")
                        {
                            getip = System.Convert.ToString(System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"]);
                        }
                        else
                        {
                            getip = System.Convert.ToString(System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"]);
                        }
                        System.Web.HttpContext.Current.Response.Write("操 作 I  P ：" + getip + "<br>");
                        System.Web.HttpContext.Current.Response.Write("操 作 时 间：" + DateTime.Now.ToString() + "<br>");
                        System.Web.HttpContext.Current.Response.Write("操 作 页 面：" + System.Web.HttpContext.Current.Request.ServerVariables["URL"] + "<br>");
                        System.Web.HttpContext.Current.Response.Write("提 交 方 式：POST " + "<br>");
                        System.Web.HttpContext.Current.Response.Write("提 交 参 数：" + k + "<br>");
                        System.Web.HttpContext.Current.Response.Write("提 交 数 据：" + System.Web.HttpContext.Current.Request.Form[System.Web.HttpContext.Current.Request.Form.Keys[jk]].ToLower() + "<br>");
                        System.Web.HttpContext.Current.Response.End();
                    }
                    if (jk > System.Web.HttpContext.Current.Request.Form.Count)
                    {
                        break;
                    }
                }
            }
            //-----------------------防 Cookies 注入-----------------------
            if (System.Web.HttpContext.Current.Request.Cookies.ToString() != "")
            {
                int jk = 0;
                string getip = null;
                for (jk = 0; jk <= System.Web.HttpContext.Current.Request.Cookies.Count - 1; jk++)
                {
                    if (System.Web.HttpContext.Current.Request.Cookies[System.Web.HttpContext.Current.Request.Cookies.Keys[jk].ToString()].Value.ToLower().Contains(k) == true)
                    {
                        System.Web.HttpContext.Current.Response.Write("<script Language=JavaScript>alert(\'ASP.NET( C#.NET版本 )防注入程序警告您，请勿提交非法字符！\');</" + "script>");
                        System.Web.HttpContext.Current.Response.Write("非法操作！系统做了如下记录 ↓" + "<br>");
                        if (System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != "")
                        {
                            getip = System.Convert.ToString(System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"]);
                        }
                        else
                        {
                            getip = System.Convert.ToString(System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"]);
                        }
                        System.Web.HttpContext.Current.Response.Write("操 作 I  P ：" + getip + "<br>");
                        System.Web.HttpContext.Current.Response.Write("操 作 时 间：" + DateTime.Now.ToString() + "<br>");
                        System.Web.HttpContext.Current.Response.Write("操 作 页 面：" + System.Web.HttpContext.Current.Request.ServerVariables["URL"] + "<br>");
                        System.Web.HttpContext.Current.Response.Write("提 交 方 式：Cookies " + "<br>");
                        System.Web.HttpContext.Current.Response.Write("提 交 参 数：" + k + "<br>");
                        System.Web.HttpContext.Current.Response.Write("提 交 数 据：" + System.Web.HttpContext.Current.Request.Cookies[System.Web.HttpContext.Current.Request.Cookies.Keys[jk]].Value.ToLower() + "<br>");
                        System.Web.HttpContext.Current.Response.End();
                    }
                    if (jk > System.Web.HttpContext.Current.Request.Cookies.Count)
                    {
                        break;
                    }
                }
            }
        }
    }
}