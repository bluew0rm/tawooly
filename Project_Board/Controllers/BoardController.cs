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
                    while(reader.Read())
                    {
                        boardsModel.Add(new Boards(int.Parse(reader[0].ToString()), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), Convert.ToDateTime(reader[5])));
                    }
                    return View(boardsModel);
                }
            }
            catch(Exception ex)
            {
                ViewData["DB接続不可"] = "接続不可";
            }
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}