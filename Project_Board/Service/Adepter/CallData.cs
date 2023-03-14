using Project_Board.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Hosting;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Board.Service.Adepter
{
    public class CallData
    {
        //데이터
        protected static string connstring
            = ConfigurationManager.ConnectionStrings["MemberConnectionString"].ConnectionString;


        SqlConnection conn = new SqlConnection(connstring);
        public void Index(DataTable itemTable)
        {
            try
            {
                conn.Open();
                string queryStr = "SELECT * FROM PostBoard";

                SqlCommand cmd = new SqlCommand(queryStr, conn);

                var adapter = new SqlDataAdapter(cmd);
                adapter.Fill(itemTable);
                /*using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        boardsModel.Add(new Boards(int.Parse(reader[0].ToString()), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString()));
                    }
                }*/
            }
            catch (Exception ex)
            {

            }
        }

        public void Paging(DataTable itemTable)
        {
            try
            {
                conn.Open();
                string queryStr = "SELECT * FROM PostBoard";

                SqlCommand cmd = new SqlCommand(queryStr, conn);

                var adapter = new SqlDataAdapter(cmd);
                adapter.Fill(itemTable);

                DataRow totalPage = itemTable.Rows[0]; //現在のレコード数



            }
            catch (Exception ex)
            {

            }
        }

    }
}
/*


        public void AllDelete()
        {
            DataTable itemTable = new DataTable();
            try
            {
                conn.Open();
                using (var connection = conn.CreateCommand())
                {
                    connection.CommandText = "DELETE FROM PostBoard";

                    var adapter = new SqlDataAdapter(connection);
                    adapter.Fill(itemTable);
                }
            }
            catch (Exception ex)
            {
            }
        }

        [HttpPost]
        public void SingleDelete()
        {
            DataTable itemTable = new DataTable();
            try
            {
                conn.Open();
                using (var connection = conn.CreateCommand())
                {
                    connection.CommandText = "DELETE FROM PostBoard WHERE [Id] = @param1;";

                    var ID = Request.Form["_id"];

                    connection.Parameters.AddWithValue("@param1", ID);

                    var adapter = new SqlDataAdapter(connection);
                    adapter.Fill(itemTable);
                }
            }
            catch (Exception ex)
            {
            }
        }

        [HttpPost]
        public void Detail()
        {
            try
            {
                conn.Open();
                using (var connection = conn.CreateCommand())
                {
                    connection.CommandText = "SELECT * FROM PostBoard WHERE [Id] = @param1";

                    var id = this.Request.Form["_id"];

                    connection.Parameters.AddWithValue("@param1", id);

                    //var excution = cmdDetail.ExecuteNonQuery();

                    using (SqlDataReader reader = connection.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            boardsModel.Add(new Boards(int.Parse(reader[0].ToString()), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString()));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        [HttpPost]
        public void Update()
        {
            DataTable itemTable = new DataTable();
            try
            {
                conn.Open();
                using (var connection = conn.CreateCommand())
                {

                    //テキストボックスのキーワード
                    var id = Request.Form["_id"];
                    var title = Request.Form["_title"];
                    var Writer = Request.Form["_Writer"];
                    var Update = Request.Form["_Update"];
                    var Text = Request.Form["_Text"];

                    // SQLの設定
                    connection.CommandText = "UPDATE PostBoard SET [Title] = @param2, [Writer] = @param3, [Update] = @param4, [Text] = @param5 WHERE [Id] = @param1"; ;

                    // SQLの実行
                    connection.Parameters.AddWithValue("@param1", id);
                    connection.Parameters.AddWithValue("@param2", title);
                    connection.Parameters.AddWithValue("@param3", Writer);
                    connection.Parameters.AddWithValue("@param4", Update);
                    connection.Parameters.AddWithValue("@param5", Text);

                    var adapter = new SqlDataAdapter(connection);
                    adapter.Fill(itemTable);
                }
            }
            catch (Exception ex)
            {
            }
        }

        [HttpPost]
        public void Search()
        {
            DataTable itemTable = new DataTable();
            // 接続文字列の取得
            var connectionString = ConfigurationManager.ConnectionStrings["MemberConnectionString"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))

            using (var command = connection.CreateCommand())
            {
                try
                {
                    // データベースの接続開始
                    connection.Open();
                    //テキストボックスのキーワード
                    string keywordText = Request.Form["_searchTitle"];


                    // SQLの設定
                    command.CommandText = @"SELECT * FROM PostBoard WHERE Title LIKE N'%' + @Keyword + N'%'";
                    //command.CommandText = @"SELECT * FROM PostBoard WHERE Title LIKE N'%@Keyword%'";

                    command.Parameters.AddWithValue("@Keyword", keywordText);      // SQLの実行
                    var adapter = new SqlDataAdapter(command);
                    adapter.Fill(itemTable);

                }
                catch (Exception exception)
                {
                    throw;
                }
                finally
                {
                    // データベースの接続終了
                    connection.Close();
                }
            }
        }
    }
}*/