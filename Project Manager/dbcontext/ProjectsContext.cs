using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project_Manager.models;
using Microsoft.EntityFrameworkCore;
namespace Project_Manager.dbcontext
{
    public class ProjectsContext:DbContext
    {
        public DbSet<Projects> Projects{ get; set;}
        public DbSet<Issues> Issues{ get; set;}
        public DbSet<Users> Users{get; set;}

        public ProjectsContext(DbContextOptions options):base(options){
            
        }
    }
}