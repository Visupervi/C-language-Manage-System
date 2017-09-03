using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class welcome : System.Web.UI.Page
{
    protected string f_nav = "";
    protected string c_nav = "";
    protected string _nav_cla = "none_none";
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
        function_all.adminLoginChack(0, "Default.aspx");
    }
}