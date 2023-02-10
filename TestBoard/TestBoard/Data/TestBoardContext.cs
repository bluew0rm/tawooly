using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestBoard.Models;

namespace TestBoard.Data
{
    public class TestBoardContext : DbContext
    {
        public TestBoardContext (DbContextOptions<TestBoardContext> options)
            : base(options)
        {
        }

        public DbSet<TestBoard.Models.BoardDB> BoardDB { get; set; } = default!;
    }
}
