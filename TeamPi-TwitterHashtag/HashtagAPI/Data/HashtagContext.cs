using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HashtagAPI.Models
{
    public partial class HashtagContext : DbContext
    {
        public HashtagContext()
        {
        }

        public HashtagContext(DbContextOptions<HashtagContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TweetLog> TweetLog { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer("server=DESKTOP-00RON3V;user=sa;password=12345;database=Hashtag");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TweetLog>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Party)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Tweet).IsRequired();

                entity.Property(e => e.TweetDateTime).HasColumnType("datetime");

                entity.Property(e => e.TweetId)
                    .IsRequired()
                    .HasColumnName("TweetID")
                    .HasMaxLength(50);

                entity.Property(e => e.TwitterHandle)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
