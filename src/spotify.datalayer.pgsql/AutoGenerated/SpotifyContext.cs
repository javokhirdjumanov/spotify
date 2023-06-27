using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace spotify.datalayer.pgsql;

public partial class SpotifyContext : DbContext
{
    public SpotifyContext()
    {
    }

    public SpotifyContext(DbContextOptions<SpotifyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<EnumOtpCodeStatus> EnumOtpCodeStatuses { get; set; }

    public virtual DbSet<EnumSessionStatus> EnumSessionStatuses { get; set; }

    public virtual DbSet<EnumState> EnumStates { get; set; }

    public virtual DbSet<EnumStatus> EnumStatuses { get; set; }

    public virtual DbSet<EnumUserRole> EnumUserRoles { get; set; }

    public virtual DbSet<HlOtpCode> HlOtpCodes { get; set; }

    public virtual DbSet<HlUser> HlUsers { get; set; }

    public virtual DbSet<SysUserSession> SysUserSessions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Username=postgres;Password=0803;Database=Spotify;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EnumOtpCodeStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("enum_otp_code_status_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<EnumSessionStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("enum_session_status_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<EnumState>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("enum_state_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<EnumStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("enum_status_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<EnumUserRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("enum_user_role_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<HlOtpCode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("hl_otp_code_pkey");

            entity.HasOne(d => d.Status).WithMany(p => p.HlOtpCodes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("hl_otp_code_status_id_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.HlOtpCodes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("hl_otp_code_user_id_fkey");
        });

        modelBuilder.Entity<HlUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("hl_user_pkey");

            entity.HasOne(d => d.Role).WithMany(p => p.HlUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("hl_user_role_id_fkey");

            entity.HasOne(d => d.State).WithMany(p => p.HlUsers).HasConstraintName("hl_user_state_id_fkey");

            entity.HasOne(d => d.Status).WithMany(p => p.HlUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("hl_user_status_id_fkey");
        });

        modelBuilder.Entity<SysUserSession>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sys_user_session_pkey");

            entity.HasOne(d => d.Status).WithMany(p => p.SysUserSessions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sys_user_session_status_id_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.SysUserSessions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sys_user_session_user_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
