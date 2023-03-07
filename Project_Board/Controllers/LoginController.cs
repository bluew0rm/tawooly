using Project_Board.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Web.Mvc;

namespace Project_Board.Controllers
{
    public class LoginController : Controller
    {
        protected static string Connstring
            = ConfigurationManager.ConnectionStrings["MemberConnectionString"].ConnectionString;

        List<Members> membersModel = new List<Members>();

        SqlConnection conn = new SqlConnection(Connstring);
        //会員情報
        public ActionResult Index()
        {
            try
            {
                conn.Open(); //DB接続

                string queryStr = "SELECT * FROM Members;";

                SqlCommand cmd = new SqlCommand(queryStr, conn);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    //ViewData["DB接続"] = "接続完了";
                    //ViewData["DB"] = memversModel;
                    while (reader.Read())
                    {
                        membersModel.Add(new Members(int.Parse(reader[0].ToString()), reader[1].ToString(), int.Parse(reader[2].ToString()), reader[3].ToString(), reader[4].ToString(), reader[5].ToString()));
                    }
                    return View(membersModel);
                }

            }
            catch (Exception ex)
            {
                ViewData["DB接続不可"] = "接続不可";
            }
            return View();
        }

        [HttpGet]
        public ActionResult AddGet()
        {
            return View();
        }

        [HttpPost]

        public ActionResult AddPost()
        {
            try
            {
                conn.Open(); //DB接続
                using (var connection = conn.CreateCommand())
                {
                    //ViewData["DB接続"] = "接続完了";
                    //ViewData["DB"] = memversModel;

                    string queryStr = "INSERT INTO Members VALUES(@param1, @param2, @param3, @param4, @param5, @param6);";
                    using (SqlCommand cmd = new SqlCommand(queryStr, conn))
                    {
                        if (ModelState.IsValid)
                        {
                            var id = Request.Form["_id"];
                            var name = Request.Form["_name"];
                            var age = Request.Form["_age"];
                            var gender = Request.Form["_gender"];
                            var job = Request.Form["_job"];
                            var password = Request.Form["_pw"];

                            cmd.Parameters.Add(new SqlParameter("@param1", id));
                            cmd.Parameters.Add(new SqlParameter("@param2", name));
                            cmd.Parameters.Add(new SqlParameter("@param3", age));
                            cmd.Parameters.Add(new SqlParameter("@param4", gender));
                            cmd.Parameters.Add(new SqlParameter("@param5", job));
                            cmd.Parameters.Add(new SqlParameter("@param6", password));

                            var result = cmd.ExecuteNonQuery();
                            if (result != 1)
                            {
                                ViewData["データ登録"] = "データが登録できませんでした。";
                            }
                            return View();
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                ViewData["DB接続不可"] = "接続不可";
            }
            return View();
        }

        public ActionResult Join()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login()
        {
            conn.Open(); //DB接続
            string querystr = "SELECT * FROM Members WHERE [Id] = @param1 OR [Password] = @param2;";

            using (SqlCommand cmd = new SqlCommand(querystr, conn))
            {
                if (ModelState.IsValid)
                {
                    var loginId = Request.Form["_loginId"];
                    var loginPw = Request.Form["_loginPw"];

                    cmd.Parameters.Add(new SqlParameter("@param1", loginId));
                    cmd.Parameters.Add(new SqlParameter("@param2", loginPw));

                    var result = cmd.ExecuteNonQuery();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            return View();
                        }
                        else
                        {
                            ViewData["ログイン失敗"] = "ログインに失敗しました。もう一度お試しください。";
                        }
                    }
                }
                return RedirectToAction("Failure", "Home");
            }
        }

        public ActionResult FindInputId()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SuccessFindId()
        {
            try
            {
                conn.Open();

                string queryStr = "SELECT * FROM Members WHERE [Name] = @param1 AND [Age] = @param2 AND [Job] = @param3;";

                using (SqlCommand cmd = new SqlCommand(queryStr, conn))
                {
                    if (ModelState.IsValid)
                    {
                        var _findName = Request.Form["_findByName"];
                        var _findByAge = Request.Form["_findByAge"];
                        var _findByJob = Request.Form["_findByJob"];

                        cmd.Parameters.Add(new SqlParameter("@param1", _findName));
                        cmd.Parameters.Add(new SqlParameter("@param2", _findByAge));
                        cmd.Parameters.Add(new SqlParameter("@param3", _findByJob));

                        var result = cmd.ExecuteNonQuery();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                membersModel.Add(new Members(int.Parse(reader[0].ToString()), reader[1].ToString(), int.Parse(reader[2].ToString()), reader[3].ToString(), reader[4].ToString(), reader[5].ToString()));
                            }
                            return View(membersModel);
                        }
                    }

                }
                conn.Close();
            }
            catch (Exception ex)
            {
                
            }
            return RedirectToAction("Failure", "Home");
        }

        public ActionResult FindInputPw()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SuccessFindPw()
        {
            try
            {
                conn.Open();

                string queryStr = "SELECT * FROM Members WHERE [Id] = @param1;" ;

                using (SqlCommand cmd = new SqlCommand(queryStr, conn))
                {
                    if (ModelState.IsValid)
                    {
                        var _findId = Request.Form["_findById"];

                        cmd.Parameters.Add(new SqlParameter("@param1", _findId));

                        var result = cmd.ExecuteNonQuery();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                membersModel.Add(new Members(int.Parse(reader[0].ToString()), reader[1].ToString(), int.Parse(reader[2].ToString()), reader[3].ToString(), reader[4].ToString(), reader[5].ToString()));
                            }
                            return View(membersModel);
                        }
                    }

                }
                conn.Close();
            }
            catch (Exception ex)
            {

            }
            return RedirectToAction("Failure", "Home");
        }
    }
}