using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.Office.Interop.Excel;
using System.Data.OleDb;
using System.Drawing;

public partial class admin_stgl_edit : System.Web.UI.Page
{
    protected string f_nav = "";
    protected string c_nav = "";
    protected string _nav_cla = "none_none";
    db_help obj;
    public string nav_cla
    {
        get
        {
            return _nav_cla;
        }
        set
        {
            _nav_cla = value;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!(_nav_cla == ""))
        {

            string[] navs = _nav_cla.Split('_');
            f_nav = navs[0];
            c_nav = _nav_cla;
        }

    }

    protected void butt_ok_Click(object sender, EventArgs e)
    {
        string sql = "";
        obj = new db_help();
        sql = "insert into stk (stlx,stnr,stda,stnd,zj,stfz,txbz) values('" + Text_tx.Text.ToString() + "','" + Text_nr.Text.ToString() + "','" + Text_da.Text.ToString() + "','" + Text_nd.Text.ToString() + "','" + Text_zj.Text.ToString() + "', '" + System.Convert.ToInt32(Text_fz.Text) + "' ,'" + Text_bz.Text.ToString() + "')";
        obj.ExecNonSql(sql);
        obj.Close();
        function_all.TiaoZhuan("更新成功", "stgl_edit.aspx", 0);
    }
    protected void butt_Click(object sender, EventArgs e)
    {
        string filePath = @"F:\Microsoft\Excel\stk.xls"; 
        if (filePath != "")
        {
            if (filePath.Contains("xls"))//判断文件是否存在  
            {
                InputExcel(filePath);
            }
            else
            {
                Response.Write("请检查您选择的文件是否为Excel文件！谢谢！");
            }
        }

        else
        {
            Response.Write("请先选择导入文件后，再执行导入！谢谢！");
        }
    }

    private void InputExcel(string pPath)
    {
        string conn = "Provider = Microsoft.Jet.OLEDB.4.0 ; Data Source =" + pPath + ";Extended Properties='Excel 8.0;HDR=False;IMEX=1'";
        OleDbConnection oleCon = new OleDbConnection(conn);
        oleCon.Open();
        string Sql = "select * from [Sheet1$]";
        OleDbDataAdapter mycommand = new OleDbDataAdapter(Sql, oleCon);
        DataSet ds = new DataSet();
        mycommand.Fill(ds, "[Sheet1$]");
        oleCon.Close();
        int count = ds.Tables["[Sheet1$]"].Rows.Count;
        for (int i = 0; i < count; i++)
        {
            string stlx, stnr, stda, stnd, zj, stfz, txbz;
            stlx = ds.Tables["[Sheet1$]"].Rows[i]["stlx"].ToString().Trim();
            stnr = ds.Tables["[Sheet1$]"].Rows[i]["stnr"].ToString().Trim();
            stda = ds.Tables["[Sheet1$]"].Rows[i]["stda"].ToString().Trim();
            stnd = ds.Tables["[Sheet1$]"].Rows[i]["stnd"].ToString().Trim();
            zj   = ds.Tables["[Sheet1$]"].Rows[i]["zj"].ToString().Trim();
            stfz = ds.Tables["[Sheet1$]"].Rows[i]["stfz"].ToString().Trim();
            txbz = ds.Tables["[Sheet1$]"].Rows[i]["txbz"].ToString().Trim();
            string excelsql = "insert into stk(stlx, stnr, stda,stnd,zj,stfz,txbz) values ('" + stlx + "','" + stnr + "','" + stda + "','" + stnd + "','" + zj + "','"+stfz+"','"+txbz+"')";
            try
            {
                //导入到SQL Server中  
                db_help dm = new db_help();
                dm.ExecReaderSql(excelsql);
               // Response.Write("<script language='javascript'>Alert('数据导入成功!');window.location='stgl_edit.aspx'</script>");
                function_all.TiaoZhuan("数据导入成功", "stgl_edit.aspx", 0);
            }
            catch (Exception)
            {
                //Response.Write("<script language='javascript'>Alert('数据导入失败!');window.location='stgl_edit.aspx'</script>");
                function_all.TiaoZhuan("数据导入失败", "stgl_sdit.aspx", 0);
            }
        }
    }
} 
 
    
