using Project_Board.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Project_Board.Controllers
{
    public class HomeController : Controller
    {
        protected static string ConnStr = ConfigurationManager.ConnectionStrings["MemberConnectionString"].ConnectionString;
        public ActionResult Index()
        {
            var model = new List<Members>();

            model.Add(new Members(2, "Tanaka", 34, "male", "IT"));
            model.Add(new Members(3, "Sasaki", 34, "female", "IT"));


            SqlConnection conn = new SqlConnection(ConnStr);
            try
            {
                conn.Open(); // DB접속
                
                ViewData["DB"] = "接続完了";

                string queryStr = "SELECT * FROM Members;";
                SqlCommand cmd = new SqlCommand(queryStr, conn);
                //クエリを実行します。
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        model.Add(new Members(Convert.ToInt32(reader[0]), reader[1].ToString(), Convert.ToInt32(reader[2]), reader[3].ToString(), reader[4].ToString()));

                        //데이터를 추가한 "model"에 ViewData를 사용해서 View로 넘겨주기
                        ViewData["DB接続"] = model;

                        //Debug.WriteLine(string.Format("###############{0} / {1} / {2} / {3} / {4}", reader[0], reader[1], reader[2], reader[3], reader[4])); 
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex+"接続エラー");
            }
            finally
            {
                conn.Close(); 
                conn.Dispose();
            }

            return View();

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}