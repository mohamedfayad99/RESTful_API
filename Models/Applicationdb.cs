using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
namespace Rstfulapi.Models
{
    public class Applicationdb : DbContext
    {
        public Applicationdb(DbContextOptions<Applicationdb> options):base(options)
        {

        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<Villa>().HasData(
        //        new Villa
        //        {
        //            id= 1,
        //            Name="Mohamed"
        //         },
        //        new Villa
        //        {
        //            id = 2,
        //            Name = "Ali"
        //        },
        //        new Villa
        //        {
        //            id = 3,
        //            Name = "Kedr"
        //        },
        //        new Villa
        //        {
        //            id = 4,
        //            Name = "Samir"
        //        },
        //        new Villa
        //        {
        //            id = 5,
        //            Name = "fady"
        //        }
        //        );

        //}
        public DbSet<Villa> villas { get; set; }
    }
}
