using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeWebApliccatin
{

    [System.Web.Script.Services.ScriptService]
    public partial class GetData2 : System.Web.UI.Page
    {

       
        protected void Page_Load(object sender, EventArgs e)
        {


        }












        [System.Web.Services.WebMethod]
        [System.Web.Script.Services.ScriptMethod]
        public static string SearchProduct(string Name, Boolean TypePhone, Boolean TypeTab)
        {

            return "test";
        }
    }
}