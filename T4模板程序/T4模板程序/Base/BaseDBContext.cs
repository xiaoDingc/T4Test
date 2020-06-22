
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
namespace Repository
{
    public class BaseDBContext:DbContext
    {
        public BaseDBContext():base("name=BaseDBContext")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}