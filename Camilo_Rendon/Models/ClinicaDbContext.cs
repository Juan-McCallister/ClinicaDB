using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Camilo_Rendon.Models;

public partial class ClinicaDbContext : IdentityDbContext
{
    public ClinicaDbContext()
    {
    }

    public ClinicaDbContext(DbContextOptions<ClinicaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CitasMedica> CitasMedicas { get; set; }

    public virtual DbSet<Medico> Medicos { get; set; }

    public virtual DbSet<Paciente> Pacientes { get; set; }

    public virtual DbSet<Reporte> Reportes { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=DESKTOP-OD9TBKF\\SQLEXPRESS;Initial Catalog=ClinicaDB;integrated security=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CitasMedica>(entity =>
        {
            entity.HasKey(e => e.IdCita).HasName("PK__CitasMed__6AEC3C09F73290BF");

            entity.ToTable(tb =>
                {
                    tb.HasTrigger("trg_UpdateCitasEstado");
                    tb.HasTrigger("trg_UpdatePacientesFrecuentes");
                    tb.HasTrigger("trg_UpdateTotalCitas");
                });

            entity.HasIndex(e => new { e.IdMedico, e.FechaHora }, "UQ_Cita_Unica").IsUnique();

            entity.Property(e => e.IdCita).HasColumnName("id_cita");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("Agendada")
                .HasColumnName("estado");
            entity.Property(e => e.FechaHora)
                .HasColumnType("datetime")
                .HasColumnName("fecha_hora");
            entity.Property(e => e.IdMedico).HasColumnName("id_medico");
            entity.Property(e => e.IdPaciente).HasColumnName("id_paciente");

            entity.HasOne(d => d.IdMedicoNavigation).WithMany(p => p.CitasMedicas)
                .HasForeignKey(d => d.IdMedico)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CitasMedi__id_me__534D60F1");

            entity.HasOne(d => d.IdPacienteNavigation).WithMany(p => p.CitasMedicas)
                .HasForeignKey(d => d.IdPaciente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CitasMedi__id_pa__52593CB8");
        });

        modelBuilder.Entity<Medico>(entity =>
        {
            entity.HasKey(e => e.IdMedico).HasName("PK__Medicos__E038EB438DD6A80C");

            entity.HasIndex(e => e.CorreoElectronico, "UQ__Medicos__5B8A06827A34AFA0").IsUnique();

            entity.Property(e => e.IdMedico).HasColumnName("id_medico");
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("correo_electronico");
            entity.Property(e => e.Especialidad)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("especialidad");
            entity.Property(e => e.HorarioAtencion)
                .HasColumnType("text")
                .HasColumnName("horario_atencion");
            entity.Property(e => e.NombreCompleto)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre_completo");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.HasKey(e => e.IdPaciente).HasName("PK__Paciente__2C2C72BB5CFE1ED9");

            entity.HasIndex(e => e.NumeroIdentificacion, "UQ__Paciente__C6DD4D32C5A6D1D5").IsUnique();

            entity.Property(e => e.IdPaciente).HasColumnName("id_paciente");
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.HistorialMedico)
                .HasColumnType("text")
                .HasColumnName("historial_medico");
            entity.Property(e => e.NombreCompleto)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre_completo");
            entity.Property(e => e.NumeroIdentificacion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("numero_identificacion");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Reporte>(entity =>
        {
            entity.HasKey(e => e.IdReporte).HasName("PK__Reportes__87E4F5CBD74FE01E");

            entity.Property(e => e.IdReporte).HasColumnName("id_reporte");
            entity.Property(e => e.CitasCanceladas)
                .HasDefaultValue(0)
                .HasColumnName("citas_canceladas");
            entity.Property(e => e.CitasReprogramadas)
                .HasDefaultValue(0)
                .HasColumnName("citas_reprogramadas");
            entity.Property(e => e.IdMedico).HasColumnName("id_medico");
            entity.Property(e => e.PacientesFrecuentes)
                .HasColumnType("text")
                .HasColumnName("pacientes_frecuentes");
            entity.Property(e => e.TotalCitas)
                .HasDefaultValue(0)
                .HasColumnName("total_citas");

            entity.HasOne(d => d.IdMedicoNavigation).WithMany(p => p.Reportes)
                .HasForeignKey(d => d.IdMedico)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Reportes__id_med__59063A47");
            base.OnModelCreating(modelBuilder);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
