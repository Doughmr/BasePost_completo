using Microsoft.EntityFrameworkCore;
using muitosparamuitos.Models;

namespace BasePost.Data
{
    public class BasePostContext : DbContext
    {
        public BasePostContext(DbContextOptions<BasePostContext> options) : base (options) 
        { }

        public DbSet<PostTag>? PostTags { get; set; }

        public DbSet<Post> posts { get; set; }

        public DbSet<Tag> Tags { get; set; }
    }
}
