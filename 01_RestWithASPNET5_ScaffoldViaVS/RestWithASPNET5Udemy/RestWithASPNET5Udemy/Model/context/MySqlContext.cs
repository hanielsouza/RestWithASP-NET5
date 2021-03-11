using Microsoft.EntityFrameworkCore;

namespace RestWithASPNET5Udemy.Model.context
{
    public class MySqlContext: DbContext
    {

        public MySqlContext()
        {

        }


        public MySqlContext(DbContextOptions<MySqlContext> options):base(options)
        {

        }

        public DbSet<Person> people { get; set; }

        public DbSet<Book> books { get; set; }


    }
}
