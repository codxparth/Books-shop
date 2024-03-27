using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Book.Context
{
    public class BookDbContext : DbContext

    {
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options) {

        }
        public DbSet<RegisterModel> UserTable { get; set; }

    }


}
