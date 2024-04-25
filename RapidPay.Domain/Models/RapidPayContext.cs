using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace RapidPay.Domain.Models
{
    public partial class RapidPayContext : IdentityDbContext<ApplicationUser>
    {
        public RapidPayContext()
        {
        }

        public RapidPayContext(DbContextOptions<RapidPayContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Card> Cards { get; set; } = null!;
        public virtual DbSet<Payment> Payments { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost\\\\\\\\docker,1433;Database=RapidPay;User ID=sa;Password=admin123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // modelBuilder.Entity<Card>(entity =>
            // {
            //     entity.ToTable("Card");

            //     entity.Property(e => e.Balance)
            //         .HasColumnType("numeric(10, 5)")
            //         .HasDefaultValueSql("((0))");

            //     entity.Property(e => e.CardNumber)
            //         .HasMaxLength(15)
            //         .IsUnicode(false);
            // });

            // modelBuilder.Entity<Payment>(entity =>
            // {
            //     entity.Property(e => e.Fee)
            //         .HasColumnType("numeric(10, 5)")
            //         .HasDefaultValueSql("((0))");

            //     entity.HasOne(d => d.Card)
            //         .WithMany(p => p.Payments)
            //         .HasForeignKey(d => d.CardId)
            //         .OnDelete(DeleteBehavior.ClientSetNull)
            //         .HasConstraintName("FK__Payments__CardId__4BAC3F29");
            // });

            // OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
