using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeWebApliccatin
{
    public partial class GetData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.Params["q"] != null && Request.Params["q"] == "1")
            {

                

                //do stuff
                List<Employee> empLst = Employee.GetEmployeeList();


                //string json = "{\"name\":\"Joe\"}";
                var javaScriptSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                string myEmpLst = javaScriptSerializer.Serialize(empLst);
                string json = empLst.ToString();
                Response.Clear();
                Response.ContentType = "application/json";
                Response.Write(myEmpLst);
                Response.End();

            }

            else if (Request.Params["q"] != null && Request.Params["q"] == "2" )
            {

                //do stuff
                List<Phone> phList = Phone.GetPhoneList();

                string myJson = "[";
                int i = 1;
                foreach (Phone myPh in phList) {
                    myJson += "{\"Id\":" + myPh.Id.ToString() + ",\"Name\":" + "\"" + myPh.Name.ToString() + "\"" + ",\"Brand\":";
                    #region Brand Name SC
                    switch (myPh.Brand)
                    {
                        case Brands.Apple:

                            myJson += "\"Apple\"";
                            break;
                        case Brands.Microsoft:
                            myJson += "\"Microsoft\"";
                            break;
                        case Brands.Samsung:
                            myJson += "\"Samsung\"";
                            break;
                        case Brands.Sony:
                            myJson += "\"Sony\"";
                            break;
                        case Brands.HTC:
                            myJson += "\"HTC\"";
                            break;
                    }
                    #endregion
                    myJson += ",\"PublishDate\":" + (myPh.PublishDate == null ? "null" : "\"" + myPh.PublishDate.ToString() + "\"");
                    myJson += ",\"ImgUrl\":" + (myPh.ImgURL == null ? "null" : "\"" + myPh.ImgURL.ToString() + "\"");
                    myJson += ",\"PrType\":";
                    #region Product Type SC
                    switch (myPh.PrType)
                    {
                        case ProductType.Phone:
                            myJson += "\"Phone\"";
                            break;
                        case ProductType.Tablet:
                            myJson += "\"Tablet\"";
                            break;

                    }
                    #endregion
                    if (i == phList.Count())
                        myJson += "}";
                    else {
                        myJson += "},";
                        i++;
                    }

                }
                myJson += "]";
                var javaScriptSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                string myPhoneList = javaScriptSerializer.Serialize(myJson);

                Response.Clear();
                Response.ContentType = "application/json";
                Response.Write(myJson);
                Response.End();

            }

            if (Request.Params["q"] != null && Request.Params["q"] == "3")
            {

              int MyProductsCount = Phone.GetPhoneCount();
               
                Response.Clear();
                Response.ContentType = "application/json";
                Response.Write(MyProductsCount);
                Response.End();

            }
        }



  

    }




}
