using Microsoft.EntityFrameworkCore;

namespace Template.Models
{
    public class TemplateContext : DbContext
    {
        // public virtual DbSet<Object> Objects { get; set; }

        public TemplateContext(DbContextOptions options) : base(options) { }
    }
}