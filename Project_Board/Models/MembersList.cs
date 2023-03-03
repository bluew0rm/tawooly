using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Board.Models
{
    public class MembersList
    {
        public List<Members> MemberSet()
        {
            var memberlist = new List<Members>();

            memberlist.Add(new Members(2, "Tanaka", 34, "Male", "IT"));

            /*SqlDataReader dr = Query("Members");

            if(dr.HasRows)
            {
                while(dr.Read())
                {
                    var x = new Members()
                    {
                        Id = int.Parse(dr["ID"].ToString()),
                        Name = dr["Name"].ToString(),
                        Age = int.Parse(dr["Age"].ToString()),
                        Gender = dr["Gender"].ToString(),
                        Job = dr["Job"].ToString()
                    };

                    _data.Add(x);
                }
            }*/
              

            return memberlist;
        }
    }
}