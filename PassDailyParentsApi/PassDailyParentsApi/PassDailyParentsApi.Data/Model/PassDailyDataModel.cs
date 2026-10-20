using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace PassDailyParentsApi.Data.Model
{

    public partial class PassDailyDataModel : DbContext
    {
        public PassDailyDataModel()
            : base("name=PassDailyDataConnection")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
