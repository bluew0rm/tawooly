﻿using Project_Board.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Project_Board.Adepters.Core;
using Project_Board.Models.Search;
using Project_Board.Models.Paging;
using System.Web.UI;

namespace Project_Board.Service.Adepter
{
    public class PostBoardAdapter : BoardAdapter
    {

        //SelectAll
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

        public DataTable GetData(PagingInfo page)
        {
            DataTable data = new DataTable();

            try
            {
                using (var command = Connection.CreateCommand())
                {
                    int NumberOfRowsPerPage = page.PageCount;
                    int PageNumber = page.PageIndex;
                    int OffsetRowCount = (PageNumber - 1) * NumberOfRowsPerPage;

                    command.CommandText = "SELECT * FROM PostBoard ORDER BY Id OFFSET " + OffsetRowCount + " ROWS FETCH NEXT " + NumberOfRowsPerPage + " ROWS ONLY;";
                    SqlDataAdapter adapter = new SqlDataAdapter(command);

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

        public DataTable Create(BoardItem item)
        {
            DataTable table = new DataTable();
            try
            {
                using (var command = Connection.CreateCommand())
                {
                    string title = item.Title;
                    string text = item.Text;
                    string writer = item.Writer;
                    string udatedDate = item.UpdatedDate.ToString("MM/dd/yyyy");

                    Connection.Open();
                    var createQuary = command.CommandText;
                    // SQLの設定
                    command.CommandText = "INSERT INTO PostBoard([Title],[Text],[Writer],[Update]) VALUES(@param1, @param2, @param3, @param4)";

                    // SQLの実行
                    command.Parameters.AddWithValue("@param1", title);
                    command.Parameters.AddWithValue("@param2", text);
                    command.Parameters.AddWithValue("@param3", writer);
                    command.Parameters.AddWithValue("@param4", udatedDate);

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

        //AllDelete
        public DataTable DeleteAll()
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

        //Delete
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

        //Detail
        public DataTable GetDataById(BoardItem item)
        {
            DataTable table = new DataTable();
            try
            {
                int id = item.Id;

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

        //Update
        public DataTable Detail(string id)
        {
            DataTable table = new DataTable();
            try
            {
                using (var command = Connection.CreateCommand())
                {
                    Connection.Open();
                    // SQLの設定
                    command.CommandText = "SELECT * FROM PostBoard WHERE [Id] = @param1";

                    // SQLの実行
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

        public DataTable Update(BoardItem item)
        {
            DataTable table = new DataTable();
            try
            {
                using (var command = Connection.CreateCommand())
                {
                    string udatedDate = item.UpdatedDate.ToString("MM/dd/yyyy");
                    Connection.Open();
                    // SQLの設定
                    command.CommandText = "UPDATE PostBoard SET [Title] = @param2, [Writer] = @param3,[Text] = @param4 WHERE [Id] = @param1";

                    // SQLの実行
                    command.Parameters.AddWithValue("@param1", item.Id);
                    command.Parameters.AddWithValue("@param2", item.Title);
                    command.Parameters.AddWithValue("@param3", item.Writer);
                    command.Parameters.AddWithValue("@param4", item.Text);

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
        //public DataTable Search(BoardItem item)
        public DataTable Search(PageAndItemData pageAndItemData)
        {
            DataTable table = new DataTable();
            using (var command = Connection.CreateCommand())
            {
                int id = pageAndItemData.SearchItem.Id;
                string writer = pageAndItemData.SearchItem.Writer ?? "";
                string title = pageAndItemData.SearchItem.Title ?? "";
                DateTime formDate = pageAndItemData.SearchItem.FromDate == DateTime.MinValue ? Convert.ToDateTime("1/1/1753 12:00:00 PM") : pageAndItemData.SearchItem.FromDate;
                DateTime toDate = pageAndItemData.SearchItem.ToDate == DateTime.MinValue ? DateTime.MaxValue : pageAndItemData.SearchItem.ToDate;

                int NumberOfRowsPerPage = pageAndItemData.PagingInfo.PageCount;
                int PageNumber = pageAndItemData.PagingInfo.PageIndex;
                int OffsetRowCount = (PageNumber - 1) * NumberOfRowsPerPage;

                try
                {
                    Connection.Open();
                    command.CommandText = @"SELECT
	                                            * 
                                            FROM
	                                            PostBoard
                                            WHERE
	                                            (@param1 = 0 OR Id = @param1) AND 
	                                            (@param2 = '' OR Writer = @param2) AND 
	                                            (@param3 = '' OR (Title LIKE N'%' + @param3 + N'%')) AND 
	                                            ((@param4= '' OR @param5 = '') OR ([Update] BETWEEN @param4 AND @param5))
                                            ORDER BY Id OFFSET " + OffsetRowCount + " ROWS FETCH NEXT " + NumberOfRowsPerPage + " ROWS ONLY;";

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

        public DataTable SearchRows(SearchCondition searchCondition)
        {
            DataTable table = new DataTable();
            using (var command = Connection.CreateCommand())
            {
                int id = searchCondition.Id;
                string writer = searchCondition.Writer ?? "";
                string title = searchCondition.Title ?? "";
                DateTime formDate = searchCondition.FromDate == DateTime.MinValue ? Convert.ToDateTime("1/1/1753 12:00:00 PM") : searchCondition.FromDate;
                DateTime toDate = searchCondition.ToDate == DateTime.MinValue ? DateTime.MaxValue : searchCondition.ToDate;

                try
                {
                    Connection.Open();
                    command.CommandText = @"SELECT
	                                            * 
                                            FROM
	                                            PostBoard
                                            WHERE
	                                            (@param1 = 0 OR Id = @param1) AND 
	                                            (@param2 = '' OR Writer = @param2) AND 
	                                            (@param3 = '' OR (Title LIKE N'%' + @param3 + N'%')) AND 
	                                            ((@param4= '' OR @param5 = '') OR ([Update] BETWEEN @param4 AND @param5))";

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
    }
}