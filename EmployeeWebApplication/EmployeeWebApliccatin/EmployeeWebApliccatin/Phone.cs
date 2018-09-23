using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EmployeeWebApliccatin
{
    public class Phone
    {

        #region MyVAriables

        public static string connStr = ConfigurationManager.ConnectionStrings["ProductsWeb"].ConnectionString;

        private int id = 1;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string name = "";
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private Brands brand = Brands.Samsung;
        public Brands Brand
        {
            get { return brand; }
            set { brand = value; }
        }

        private Boolean available;
        public Boolean Available
        {
            get { return available; }
            set { available = value; }
        }


        private DateTime? publishDate = null;
        public DateTime? PublishDate
        {
            get { return publishDate; }
            set { publishDate = value; }
        }

        private string imgUrl = "";
        public string ImgURL
        {
            get { return imgUrl; }
            set { imgUrl = value; }
        }

        private OsType os = OsType.Android;
        public OsType OS
        {
            get { return os; }
            set { os = value; }
        }

        private ProductType prType = ProductType.Phone;
        public ProductType PrType
        {
            get { return prType; }
            set { prType = value; }
        }


        private Boolean sale;
        public Boolean Sale
        {
            get { return sale; }
            set { sale = value; }
        }
        #endregion


        public static List<Phone> GetPhoneList()
        {
            
            List<Phone> phoneList = new List<Phone>();
          
            SqlConnection con = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand("GetPhonesList", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader dr;


            try
            {
                con.Open();
                dr = cmd.ExecuteReader();


                while (dr.Read())
                {
                    Phone PH = new Phone();
                    PH.Id = Convert.ToInt32(dr["ID"]);
                    PH.Name = dr["Name"].ToString();
                    PH.Brand = (Brands)Convert.ToByte( dr["Brand"]);
                    PH.Available = Convert.ToBoolean(dr["Available"]);
                    if (dr["PublishDate"] == DBNull.Value)
                        PH.PublishDate = null;
                    else
                        PH.PublishDate = Convert.ToDateTime(dr["PublishDate"]);

                    if (dr["ImgUrl"] == DBNull.Value)
                        PH.ImgURL = null;
                    else
                        PH.ImgURL = dr["ImgUrl"].ToString();
                    PH.PrType = (ProductType)Convert.ToByte(dr["PrType"]);
                    PH.OS =(OsType)Convert.ToByte(dr["OS"]);
                    phoneList.Add(PH);
                }

                dr.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return phoneList;
        }



        public static Phone GetPhoneByID(int id)
        {

            Phone output = null;
            SqlConnection con = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand("GetPhoneByID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            SqlDataReader dtr;

            try
            {
                param = new SqlParameter("Id", id);
                cmd.Parameters.Add(param);
                con.Open();
                dtr = cmd.ExecuteReader();

                while (dtr.Read())
                {

                    output = new Phone();
                    output.Id = (int)dtr["Id"];
                    output.Name = dtr["Name"].ToString();
                    output.brand =(Brands)dtr["Brand"];
                    //DBNull.Value ? null : Convert.ToDateTime(reader[3])
                }
                dtr.Close();
                con.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return output;

        }

        public static List<Phone> GetPhoneByFilter(int id, Brands myBraand, ProductType myType,string myName,OsType myOs)
        {

            List<Phone> phoneList = new List<Phone>();
            Phone PH = null;
            SqlConnection con = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand("GetPhoneListByFilter", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            SqlDataReader dr;

            try
            {
                param = new SqlParameter("ID", id);
                cmd.Parameters.Add(param);
                param = new SqlParameter("Brand", myBraand);
                cmd.Parameters.Add(param);
                param = new SqlParameter("PrType", myType);
                cmd.Parameters.Add(param);
                param = new SqlParameter("Name", myName);
                cmd.Parameters.Add(param);
                param = new SqlParameter("OS", myOs);
                cmd.Parameters.Add(param);
                con.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {

               

                    PH = new Phone();
                    PH.Id = Convert.ToInt32(dr["ID"]);
                    PH.Name = dr["Name"].ToString();
                    PH.Brand = (Brands)dr["Brand"];
                    PH.Available = Convert.ToBoolean(dr["Available"]);
                    if (dr["PublishDate"] == DBNull.Value)
                        PH.PublishDate = null;
                    else
                        PH.PublishDate = Convert.ToDateTime(dr["PublishDate"]);

                    if (dr["ImgUrl"] == DBNull.Value)
                        PH.ImgURL = null;
                    else
                        PH.ImgURL = dr["ImgUrl"].ToString();
                    PH.PrType = (ProductType)dr["PrType"];
                    PH.OS = (OsType)dr["OS"];
                    phoneList.Add(PH);
                }
                dr.Close();
                con.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return phoneList;

        }

        public static int CreatePhone (Phone myPhone)
        {

            SqlConnection con = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand("CreatePhone", con);
            cmd.CommandType = CommandType.StoredProcedure;
            int created;

            try
            {


                con.Open();

                cmd.Parameters.AddWithValue("@ID", (int)myPhone.Id);
                cmd.Parameters.AddWithValue("@Name", myPhone.Name.ToString());
                cmd.Parameters.AddWithValue("@Brand",(Brands)myPhone.Brand);
                cmd.Parameters.AddWithValue("@Available",Convert.ToBoolean(myPhone.Available));
                if (myPhone.PublishDate == null)
                    cmd.Parameters.AddWithValue("@PublishDate", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@PublishDate", Convert.ToDateTime(myPhone.PublishDate));
                cmd.Parameters.AddWithValue("@ImgURL", myPhone.ImgURL.ToString());
                cmd.Parameters.AddWithValue("@OS",(OsType)myPhone.OS);
                cmd.Parameters.AddWithValue("@PrType", (ProductType)myPhone.PrType);
                created = cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception)
            {
                throw;
            }
            return created;

        }

        public static int GetPhoneCount()
        {

            int MyPhoneCount = 0;

            SqlConnection con = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand("GetPhoneCount", con);
            cmd.CommandType = CommandType.StoredProcedure;
            
            SqlDataReader dr;

            
            try
            {
                con.Open();

                MyPhoneCount = (int)cmd.ExecuteScalar();

                con.Close();
              
            }
            catch (Exception)
            {
                throw;
            }
            return MyPhoneCount;
        }

    }
}