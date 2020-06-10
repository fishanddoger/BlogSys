using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace Blog.Models
{
    public class BlogDbContext : DbContext
    {
        //您的上下文已配置为从您的应用程序的配置文件(App.config 或 Web.config)
        //使用“BlogDbContext”连接字符串。默认情况下，此连接字符串针对您的 LocalDb 实例上的
        //“Blog.Models.BlogDbContext”数据库。
        // 
        //如果您想要针对其他数据库和/或数据库提供程序，请在应用程序配置文件中修改“BlogDbContext”
        //连接字符串。
        public BlogDbContext()
            : base("name=con")
        {
            Database.SetInitializer<BlogDbContext>(null);
        }

        //为您要在模型中包含的每种实体类型都添加 DbSet。有关配置和使用 Code First  模型
        //的详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=390109。

        // public virtual DbSet<MyEntity> MyEntities { get; set; }

        public DbSet<UserInfo> UserInfos { get; set; }

        public DbSet<Article> Articles { get; set; }

        public DbSet<ArticleToCategory> ArticleToCategory { get; set; }

        public DbSet<CategoryInfo> CategoryInfos { get; set; }

        public DbSet<ArticleToUserInfo> ArticleToUser { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<FansInfo> FansInfos { get; set; }


        //public void FixEfProviderServicesProblem()
        //{ //The Entity Framework provider type 'System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer' 
        //    //for the 'System.Data.SqlClient' ADO.NET provider could not be loaded. 
        //    //Make sure the provider assembly is available to the running application. 
        //    //See http://go.microsoft.com/fwlink/?LinkId=260882 for more information. 
        //    var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        //}

        //public class MyEntity
        //{
        //    public int Id { get; set; }
        //    public string Name { get; set; }
        //}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }
    }
}