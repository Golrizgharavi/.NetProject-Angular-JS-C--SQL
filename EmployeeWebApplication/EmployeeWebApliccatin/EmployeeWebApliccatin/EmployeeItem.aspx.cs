using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeWebApliccatin
{
    public partial class EmployeeItem : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
           Test employee= Test.Get(1);


            int eID = Convert.ToInt32(2);
            //Employee em = Employee.GetEmployee(eID);
            //em.Tittle = Convert.ToString("test update");
            //em.PhoneNumber = Convert.ToString("777-777-7777");

            //Employee.UpdateEmployee(em);
        }
    }
}