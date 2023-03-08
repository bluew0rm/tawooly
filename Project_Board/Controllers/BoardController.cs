using Project_Board.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace Project_Board.Controllers
{
    public class BoardController : Controller
    {
        protected static string connstring
            = ConfigurationManager.ConnectionStrings["MemberConnectionString"].ConnectionString;

        List<Boards> boardsModel = new List<Boards>();

        SqlConnection conn = new SqlConnection(connstring);

        public ActionResult Index()
        {
            try
            {
                conn.Open();
                string queryStr = "SELECT * FROM PostBoard";

                SqlCommand cmd = new SqlCommand(queryStr, conn);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        boardsModel.Add(new Boards(int.Parse(reader[0].ToString()), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString()));
                    }
                    return View(boardsModel);
                }
            }
            catch (Exception ex)
            {
                ViewData["DB接続不可"] = "接続不可";
            }
            return View();
        }

        public ActionResult Create()
        {
            try
            {
                conn.Open();
                using (var connection = conn.CreateCommand())
                {
                    string queryStrInsert = "INSERT INTO PostBoard VALUES(@param1, @param2, @param3, @param4)";
                    using (SqlCommand cmdIn = new SqlCommand(queryStrInsert, conn))
                    {
                        if (ModelState.IsValid)
                        {
                            var title = Request.Form["_title"];
                            var text = Request.Form["_text"];
                            var writer = Request.Form["_writer"];
                            var date = Request.Form["_date"];

                            cmdIn.Parameters.Add(new SqlParameter("@param1", title));
                            cmdIn.Parameters.Add(new SqlParameter("@param2", text));
                            cmdIn.Parameters.Add(new SqlParameter("@param3", writer));
                            cmdIn.Parameters.Add(new SqlParameter("@param4", date));

                            var excution = cmdIn.ExecuteNonQuery();
                        }
                        return View();
                    }
                }
            }
            catch (Exception ex)
            {
                ViewData["DB接続不可"] = "接続不可";
            }
            return View();
        }
        public ActionResult Delete()
        {
            try
            {
                conn.Open();
                using (var connection = conn.CreateCommand())
                {
                    string queryStrInsert = "DELETE FROM PostBoard WHERE [Id] = @param1";
                    using (SqlCommand cmdIn = new SqlCommand(queryStrInsert, conn))
                    {
                        if (ModelState.IsValid)
                        {
                            var id = Request.Form["_delete"];

                            cmdIn.Parameters.Add(new SqlParameter("@param1", id));

                            var excution = cmdIn.ExecuteNonQuery();
                        }
                        return Redirect("Index");
                    }
                }
            }
            catch (Exception ex)
            {
                ViewData["DB接続不可"] = "接続不可";
            }
            return Redirect("Index");
        }
    }
}