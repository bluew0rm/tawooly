using Project_Board.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Project_Board.Adepters.Core;

namespace Project_Board.Service.Adepter
{
    public class PostBoardAdapter : BoardAdapter
    {

        //SelectAll ok
        public DataTable GetDataByAll()
        {
            DataTable data = new DataTable();
            try
            {
                using (var command = Connection.CreateCommand())
                {
                    Connection.Open();
                    command.CommandText = "SELECT * FROM PostBoard";

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

        //Create ok
        public DataTable Create(BoardItem item)
        {
            DataTable table = new DataTable();
            try
            {
                using (var command = Connection.CreateCommand())
                {
                    Connection.Open();
                    var createQuary = command.CommandText;
                    // SQLの設定
                    command.CommandText = "INSERT INTO PostBoard VALUES(@param1, @param2, @param3, @param4, @param5, @param6)";
                    
                    // SQLの実行
                    command.Parameters.AddWithValue("@param1", item.Title);
                    command.Parameters.AddWithValue("@param2", item.Writer);
                    command.Parameters.AddWithValue("@param5", item.Date);
                    command.Parameters.AddWithValue("@param6", item.Text);

                    //command.ExecuteNonQuery();

                    var adapter = new SqlDataAdapter(command);
                    adapter.Fill(table);
                }
            }
            catch (Exception ex)
            {
            }
            return table;
        }

        //AllDelete  ok
        public DataTable AllDelete()
        {
            DataTable table = new DataTable();
            try
            {
                Connection.Open();
                using (var command = Connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM PostBoard";

                    var adapter = new SqlDataAdapter(command);
                    adapter.Fill(table);
                }
            }
            catch (Exception ex)
            {
            }
            return table;
        }
        
        //Delete ok
        public DataTable Delete(string id)
        {
            DataTable table = new DataTable();
            try
            {
                Connection.Open();

                using (var command = Connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM PostBoard WHERE [Id] = @param1";

                    command.Parameters.AddWithValue("@param1", id);

                    var adapter = new SqlDataAdapter(command);
                    adapter.Fill(table);
                }
            }
            catch (Exception ex)
            {
            }
            return table;
        }

        //Detail  ok
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

        //Update  ok
        public DataTable Update(BoardItem item)
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
                    command.Parameters.AddWithValue("@param4", item.Date);
                    command.Parameters.AddWithValue("@param5", item.Text);

                    var adapter = new SqlDataAdapter(command);
                    adapter.Fill(table);
                }
            }
            catch (Exception ex)
            {
            }
            return table;
        }

        //Search
        public DataTable Search(BoardItem item)
        {
            DataTable table = new DataTable();
            using (var command = Connection.CreateCommand())
            {
                int id = item.Id;
                string writer = item.Writer;
                string title = item.Title;
                DateTime formDate = item.Date;
                DateTime toDate = item.Date;

                try
                {
                    Connection.Open();
                    command.CommandText = @"SELECT * FROM PostBoard WHERE Id = @param1 AND Writer = @param2 AND Title LIKE N'%' + @param3 + N'%' AND Date = @param4 AND Date = @param5 ";

                    command.Parameters.AddWithValue("@param1", id);
                    command.Parameters.AddWithValue("@param2", writer);
                    command.Parameters.AddWithValue("@param3", title);
                    command.Parameters.AddWithValue("@param4", formDate);
                    command.Parameters.AddWithValue("@param5", toDate);

                    // SQLの実行
                    var adapter = new SqlDataAdapter(command);
                    adapter.Fill(table);

                }
                catch (Exception exception)
                {
                }
                finally
                {
                    Connection.Close();
                }
                return table;
            }
        }

        /*public List<BoardItem> GetBoardItems(SearchBoardItem searchBoardItem)
        {
            var result = new List<BoardItem>();


            return result;
        }*/

        /*public void GetWithPageInfo(Paging pageInfo)
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
        }*/
    }
}