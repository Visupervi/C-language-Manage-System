using Microsoft.CSharp; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Data;

/// <summary>
///function_all 的摘要说明
/// </summary>
public class function_all
{
    public static string GetMd5Str(string InPutString)
    {
        string returnValue = "";
        MD5 Key = MD5.Create();
        byte[] Bytes = Key.ComputeHash(Encoding.Default.GetBytes(InPutString));
        StringBuilder Sbuilter = new StringBuilder();
        for (int i = 0; i <= Bytes.Length - 1; i++) 
        {
            Sbuilter.Append(Bytes[i].ToString("x2"));
        }
        returnValue = System.Convert.ToString(Sbuilter.ToString());
        return returnValue;
    }

    //定义跳转函数
    public static void TiaoZhuan(string Str, string Url, int Cla)
    {
        HttpResponse Response = HttpContext.Current.Response;

        Response.Write("<script language=javascript>");
        if (string.IsNullOrEmpty(Str))
        {
        }
        else
        {
            Response.Write("alert(\'" + Str + "\');");
        }
        if (Cla == 1)
        {
            Response.Write("parent.");
        }
        if (string.IsNullOrEmpty(Url))
        {
        }
        else
        {
            Response.Write("location.href=\'" + Url + "\';");
        }
        Response.Write("</script>");
    }
    public static void adminSessionLoad()
    {
        if (HttpContext.Current.Session["aid"] == "")
        {
            if (!(HttpContext.Current.Request.Cookies["cstgl"] == null))
            {
                HttpCookie Cookies = default(HttpCookie);
                Cookies = HttpContext.Current.Request.Cookies["cstgl"];
                if (Cookies.Values["aid"].ToString() != "")
                {
                    HttpContext.Current.Session["aid"] = Cookies.Values["aid"];
                }
                else
                {
                    HttpContext.Current.Session["aid"] = "";
                }
            }
            else
            {
               HttpContext.Current.Session["aid"]= "";
            }
        }
    }

    //登录验证
    public static void adminLoginChack(int isframe, string pages)
    {
        adminSessionLoad();

        if (HttpContext.Current.Session["aid"] =="")
        {
            TiaoZhuan("登录超时，请重新登录", pages, isframe);
            HttpContext.Current.Response.End();
        }
    }
    public static int StrToInt(string str, int moren)
    {
        int returnValue = 0;
        if (string.IsNullOrEmpty(str))
        {
            returnValue = moren;
        }
        else
        {
            try
            {
                returnValue = int.Parse(str);
            }
            catch (Exception)
            {
                returnValue = moren;
            }
        }
        return returnValue;
    }
    public static long StrToLon(string str, long moren)
    {
        long returnValue = 0;
        if (string.IsNullOrEmpty(str))
        {
            returnValue = moren;
        }
        else
        {
            try
            {
                returnValue = int.Parse(str);
            }
            catch (Exception )
            {
                returnValue = moren;
            }
        }
        return returnValue;
    }
    public static long DateToLng(DateTime dates)
    {
        long returnValue = 0;
        returnValue = dates.Year * 10000000000 + dates.Month * 100000000 + dates.Day * 1000000 + dates.Hour * 10000 + dates.Minute * 100 + dates.Second - 20000000000000;
        return returnValue;
    }
	
	
	public function_all()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    public static void fileDelete(string path)
    {
        if (File.Exists(path) == true)
        {
            File.Delete(path);
        }
    }
    public static string GetYesOrNo(int @int, string ys, string ns)
    {
        string returnValue = "";
        returnValue = ns;
        if (@int == 1)
        {
            returnValue = ys;
        }
        return returnValue;
    }
    //定义时间函数，用来计算时间
    public static string GetMyDate(string  datetime, string datetype)
    {
       string returnValue = "";
        returnValue = "";
        try
        {
            DateTime todatetime = DateTime.Parse(datetime);

            switch (datetype)
            {
                case "YMD":
                    returnValue = todatetime.Year + "-" + todatetime.Month + "-" + todatetime.Day;
                    break;
                case "MD":
                    returnValue = todatetime.Month + "-" + todatetime.Day;
                    break;
                case "YMDHMS":
                    returnValue = todatetime.Year + "-" + todatetime.Month+ "-" + todatetime.Day + " " + todatetime.Hour+ ":" + todatetime.Minute + ":" + todatetime.Second;
                    break;
                case "YMDHM":
                    returnValue = todatetime.Year + "-" + todatetime.Month+ "-" + todatetime.Day + " " + todatetime.Hour+ ":" + todatetime.Minute;
                    break;
                case "MDHM":
                   returnValue= todatetime.Month+ "-" + todatetime.Day + " " + todatetime.Hour+ ":" + todatetime.Minute;
                   break;
            }
        }
        catch (Exception)
        {
            returnValue = "";
        }
        return returnValue;
    }

  
}
