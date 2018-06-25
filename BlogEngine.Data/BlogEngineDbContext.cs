using BlogEngine.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogEngine.Data
{
    public class BlogEngineDbContext : DbContext
    {
        #region BlogEngineDbContext
        public BlogEngineDbContext() : base("BlogEngineConnectionString")
        {
        }
        #endregion

        #region Entity Set
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostTag> PostTags { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        #endregion

        #region On Model Creating
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
        #endregion
    }
}
