using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication1Personen_EF.Data
{
    public class WebApplication1Personen_EFContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public WebApplication1Personen_EFContext() : base("name=WebApplication1Personen_EFContext")
        {
        }

        public System.Data.Entity.DbSet<WebApplication1Personen_EF.Models.Personen> Personens { get; set; }

        public System.Data.Entity.DbSet<WebApplication1Personen_EF.Models.Firmen> Firmen { get; set; }
    }
}
