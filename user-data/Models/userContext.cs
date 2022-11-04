using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace user_service.Models
{
    public partial class userContext : DbContext
    {
        public userContext()
        {
        }

        public userContext(DbContextOptions<userContext> options)
            : base(options)
        {
        }

        public virtual DbSet<UserInfo> UserInfos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Database=test;Username=postgres;Password=G0fishing");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("user_info_pkey");

                entity.ToTable("user_info");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("user_name")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("full_name")
                    .HasDefaultValueSql("''::character varying");

             
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
