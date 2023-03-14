/*using System.Data.SqlClient;
using System;

namespace Project_Board.Service.Adepter
{
    public partial class FormData
    {
        public void Create()
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
                        return Redirect("Index");
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return View();
        }
    }
}*/