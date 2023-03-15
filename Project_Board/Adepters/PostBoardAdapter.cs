using Project_Board.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Project_Board.Models.Paging;
using Project_Board.Models.Search;
using Project_Board.Adepters.Core;
using static System.Net.Mime.MediaTypeNames;
using System.Web.UI;

namespace Project_Board.Service.Adepter
{
    public class PostBoardAdapter : BoardAdapter
    {
        public DataTable GetDataByAll()
        {
            DataTable data = new DataTable();
            try
            {
                using (var command = Connection.CreateCommand())
                {
                    Connection.Open();
                    string queryStr = "SELECT * FROM PostBoard";

                    SqlCommand cmd = new SqlCommand(queryStr, Connection);

                    var adapter = new SqlDataAdapter(command);
                    adapter.Fill(data);
                }
            }
            catch (Exception exception)
            {
                throw;
            }
            finally
            {
                // データベースの接続終了
                Connection.Close();
            }
            return data;
        }


        public void GetWithPageInfo(Paging pageInfo)
        {
            DataTable data = new DataTable();
            try
            {

                Connection.Open();
                string queryStr = "SELECT * FROM PostBoard";

                SqlCommand cmd = new SqlCommand(queryStr, Connection);

                var adapter = new SqlDataAdapter(cmd);
                adapter.Fill(data);

                DataRow totalPage = data.Rows[0];
            }
            catch (Exception exception)
            {
                throw;
            }
            finally
            {
                // データベースの接続終了
                Connection.Close();
            }
        }

        public void Create(string title, string text, string writer, string date)
        {
            DataTable data = new DataTable();
            try
            {
                using (var command = Connection.CreateCommand())
                {
                    Connection.Open();

                    command.CommandText = "INSERT INTO PostBoard VALUES(@param1, @param2, @param3, @param4)";

                    command.Parameters.AddWithValue("@param1", title);
                    command.Parameters.AddWithValue("@param2", text);
                    command.Parameters.AddWithValue("@param3", writer);
                    command.Parameters.AddWithValue("@param4", date);

                    var adapter = new SqlDataAdapter(command);
                    adapter.Fill(data);
                }
            }
            catch (Exception exception)
            {
                throw;
            }
            finally
            {
                // データベースの接続終了
                Connection.Close();
            }
        }

        public int Create(BoardItem newItem)
        {
            return 0;
        }

        public void AllDelete()
        {
            DataTable data = new DataTable();
            try
            {
                Connection.Open();
                using (var command = Connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM PostBoard";

                    var adapter = new SqlDataAdapter(command);
                    adapter.Fill(data);
                }
            }
            catch (Exception ex)
            {
            }

        }

        public void DeleteById(string id)
        {
            DataTable data = new DataTable();
            try
            {
                Connection.Open();
                using (var command = Connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM PostBoard WHERE [Id] = @param1;";

                    command.Parameters.AddWithValue("@param1", id);

                    var adapter = new SqlDataAdapter(command);
                    adapter.Fill(data);
                }
            }
            catch (Exception ex)
            {
            }
        }

        public void Detail(string id)
        {
            DataTable data = new DataTable();
            try
            {
                Connection.Open();
                using (var command = Connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM PostBoard WHERE [Id] = @param1";

                    command.Parameters.AddWithValue("@param1", id);

                    var adapter = new SqlDataAdapter(command);
                    adapter.Fill(data);
                }
            }
            catch (Exception ex)
            {
            }
        }

        public DataTable GetDataById(string id)
        {
            DataTable table = new DataTable();
            try
            {
                Connection.Open();

                using (var command = Connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM PostBoard WHERE [Id] = @param1";

                    command.Parameters.AddWithValue("@param1", id);

                    var adapter = new SqlDataAdapter(command);
                    adapter.Fill(table);
                }
            }
            catch (Exception ex)
            {
                //ex.Message;
            }
            return table;
        }

        public void Update(BoardItem item)
        {
            DataTable table = new DataTable();
            try
            {
                using (var command = Connection.CreateCommand())
                {
                    Connection.Open();
                    // SQLの設定
                    command.CommandText = "UPDATE PostBoard SET [Title] = @param2, [Writer] = @param3, [Update] = @param4, [Text] = @param5 WHERE [Id] = @param1";

                    // SQLの実行
                    command.Parameters.AddWithValue("@param1", item.Id);
                    command.Parameters.AddWithValue("@param2", item.Title);
                    command.Parameters.AddWithValue("@param3", item.Writer);
                    command.Parameters.AddWithValue("@param4", item.Update);
                    command.Parameters.AddWithValue("@param5", item.Text);

                    command.ExecuteNonQuery();

                    var adapter = new SqlDataAdapter(command);
                    adapter.Fill(table);
                }
            }
            catch (Exception ex)
            {
            }
        }
        public void Search(SearchBoardItem searchBoardItem)
        {
            DataTable table = new DataTable();
            using (var command = Connection.CreateCommand())
                {
                    try
                    {
                        // データベースの接続開始
                        Connection.Open();
                        //テキストボックスのキーワード
                        // SQLの設定
                        command.CommandText = @"SELECT * FROM PostBoard WHERE Title LIKE N'%' + @title + N'%'";

                        command.Parameters.AddWithValue("@title", searchBoardItem.Title);
                        // SQLの実行
                        var adapter = new SqlDataAdapter(command);
                        adapter.Fill(table);

                    }
                    catch (Exception exception)
                    {
                        throw;
                    }
                    finally
                    {
                        // データベースの接続終了
                        Connection.Close();
                    }
                }
        }

        public List<BoardItem> GetBoardItems(SearchBoardItem searchBoardItem)
        {
            var result = new List<BoardItem>();


            return result;
        }
    }
}