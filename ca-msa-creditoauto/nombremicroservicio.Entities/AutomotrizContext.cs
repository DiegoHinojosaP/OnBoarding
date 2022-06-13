using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace nombremicroservicio.Entities
{
    public partial class AutomotrizContext : DbContext
    {
        public AutomotrizContext()
        {
        }

        public AutomotrizContext(DbContextOptions<AutomotrizContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Asignacion> Asignacions { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Credito> Creditos { get; set; }
        public virtual DbSet<Ejecutivo> Ejecutivos { get; set; }
        public virtual DbSet<Marca> Marcas { get; set; }
        public virtual DbSet<Patio> Patios { get; set; }
        public virtual DbSet<Vehiculo> Vehiculos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Asignacion>(entity =>
            {
                entity.HasKey(e => e.AsiIdAsigancion);

                entity.ToTable("asignacion");

                entity.Property(e => e.AsiIdAsigancion).HasColumnName("asi_id_asigancion");

                entity.Property(e => e.AsiFechaAsignacion)
                    .HasColumnType("datetime")
                    .HasColumnName("asi_fecha_asignacion");

                entity.Property(e => e.CliIdCliente).HasColumnName("cli_id_cliente");

                entity.Property(e => e.PatIdPatio).HasColumnName("pat_id_patio");

                entity.HasOne(d => d.CliIdClienteNavigation)
                    .WithMany(p => p.Asignacions)
                    .HasForeignKey(d => d.CliIdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_asignacion_cliente");

                entity.HasOne(d => d.PatIdPatioNavigation)
                    .WithMany(p => p.Asignacions)
                    .HasForeignKey(d => d.PatIdPatio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_asignacion_patio");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.CliIdCliente);

                entity.ToTable("cliente");

                entity.Property(e => e.CliIdCliente).HasColumnName("cli_id_cliente");

                entity.Property(e => e.CliApellidos)
                    .HasMaxLength(100)
                    .HasColumnName("cli_apellidos")
                    .IsFixedLength(true);

                entity.Property(e => e.CliDireccion)
                    .HasMaxLength(200)
                    .HasColumnName("cli_direccion")
                    .IsFixedLength(true);

                entity.Property(e => e.CliEdad).HasColumnName("cli_edad");

                entity.Property(e => e.CliEstadoCivil)
                    .HasMaxLength(10)
                    .HasColumnName("cli_estado_civil")
                    .IsFixedLength(true);

                entity.Property(e => e.CliFechaNacimiento)
                    .HasColumnType("datetime")
                    .HasColumnName("cli_fecha_nacimiento");

                entity.Property(e => e.CliIdentificacion)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("cli_identificacion")
                    .IsFixedLength(true);

                entity.Property(e => e.CliIdentificacionConyugue)
                    .HasMaxLength(10)
                    .HasColumnName("cli_identificacion_conyugue")
                    .IsFixedLength(true);

                entity.Property(e => e.CliNombreConyugue)
                    .HasMaxLength(100)
                    .HasColumnName("cli_nombre_conyugue")
                    .IsFixedLength(true);

                entity.Property(e => e.CliNombres)
                    .HasMaxLength(100)
                    .HasColumnName("cli_nombres")
                    .IsFixedLength(true);

                entity.Property(e => e.CliSujetoCredito).HasColumnName("cli_sujeto_credito");

                entity.Property(e => e.CliTelefono)
                    .HasMaxLength(10)
                    .HasColumnName("cli_telefono")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Credito>(entity =>
            {
                entity.HasKey(e => e.CreIdCredito);

                entity.ToTable("credito");

                entity.Property(e => e.CreIdCredito).HasColumnName("cre_id_credito");

                entity.Property(e => e.CliIdCliente).HasColumnName("cli_id_cliente");

                entity.Property(e => e.CreCuotas)
                    .HasColumnType("money")
                    .HasColumnName("cre_cuotas");

                entity.Property(e => e.CreEntrada)
                    .HasColumnType("money")
                    .HasColumnName("cre_entrada");

                entity.Property(e => e.CreEstado)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("cre_estado")
                    .IsFixedLength(true);

                entity.Property(e => e.CreFechaElaboracion)
                    .HasColumnType("datetime")
                    .HasColumnName("cre_fecha_elaboracion");

                entity.Property(e => e.CreMesesPlazo).HasColumnName("cre_meses_plazo");

                entity.Property(e => e.CreObservacion)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("cre_observacion")
                    .IsFixedLength(true);

                entity.Property(e => e.EjeIdEjecutivo).HasColumnName("eje_id_ejecutivo");

                entity.Property(e => e.PatIdPatio).HasColumnName("pat_id_patio");

                entity.Property(e => e.VehIdVehiculo).HasColumnName("veh_id_vehiculo");

                entity.HasOne(d => d.CliIdClienteNavigation)
                    .WithMany(p => p.Creditos)
                    .HasForeignKey(d => d.CliIdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_credito_cliente");

                entity.HasOne(d => d.EjeIdEjecutivoNavigation)
                    .WithMany(p => p.Creditos)
                    .HasForeignKey(d => d.EjeIdEjecutivo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_credito_ejecutivo");

                entity.HasOne(d => d.PatIdPatioNavigation)
                    .WithMany(p => p.Creditos)
                    .HasForeignKey(d => d.PatIdPatio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_credito_patio");

                entity.HasOne(d => d.VehIdVehiculoNavigation)
                    .WithMany(p => p.Creditos)
                    .HasForeignKey(d => d.VehIdVehiculo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_credito_vehiculo");
            });

            modelBuilder.Entity<Ejecutivo>(entity =>
            {
                entity.HasKey(e => e.EjeIdEjecutivo);

                entity.ToTable("ejecutivo");

                entity.Property(e => e.EjeIdEjecutivo).HasColumnName("eje_id_ejecutivo");

                entity.Property(e => e.EjeApellidos)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("eje_apellidos")
                    .IsFixedLength(true);

                entity.Property(e => e.EjeCelular)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("eje_celular")
                    .IsFixedLength(true);

                entity.Property(e => e.EjeDireccion)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("eje_direccion")
                    .IsFixedLength(true);

                entity.Property(e => e.EjeEdad).HasColumnName("eje_edad");

                entity.Property(e => e.EjeIdentificacion)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("eje_identificacion")
                    .IsFixedLength(true);

                entity.Property(e => e.EjeNombres)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("eje_nombres")
                    .IsFixedLength(true);

                entity.Property(e => e.EjeTelefonoConvencional)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("eje_telefono_convencional")
                    .IsFixedLength(true);

                entity.Property(e => e.PatIdPatio).HasColumnName("pat_id_patio");

                entity.HasOne(d => d.PatIdPatioNavigation)
                    .WithMany(p => p.Ejecutivos)
                    .HasForeignKey(d => d.PatIdPatio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ejecutivo_patio");
            });

            modelBuilder.Entity<Marca>(entity =>
            {
                entity.HasKey(e => e.MarIdMarca);

                entity.ToTable("marca");

                entity.Property(e => e.MarIdMarca).HasColumnName("mar_id_marca");

                entity.Property(e => e.MarNombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("mar_nombre")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Patio>(entity =>
            {
                entity.HasKey(e => e.PatIdPatio);

                entity.ToTable("patio");

                entity.Property(e => e.PatIdPatio).HasColumnName("pat_id_patio");

                entity.Property(e => e.PatDireccion)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("pat_direccion")
                    .IsFixedLength(true);

                entity.Property(e => e.PatNombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("pat_nombre")
                    .IsFixedLength(true);

                entity.Property(e => e.PatPuntoVente).HasColumnName("pat_punto_vente");

                entity.Property(e => e.PatTelefono)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("pat_telefono")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Vehiculo>(entity =>
            {
                entity.HasKey(e => e.VehIdVehiculo);

                entity.ToTable("vehiculo");

                entity.Property(e => e.VehIdVehiculo).HasColumnName("veh_id_vehiculo");

                entity.Property(e => e.MarIdMarca).HasColumnName("mar_id_marca");

                entity.Property(e => e.VehAvaluo)
                    .HasColumnType("money")
                    .HasColumnName("veh_avaluo");

                entity.Property(e => e.VehCilindraje)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("veh_cilindraje")
                    .IsFixedLength(true);

                entity.Property(e => e.VehModelo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("veh_modelo")
                    .IsFixedLength(true);

                entity.Property(e => e.VehNumeroChasis)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("veh_numero_chasis")
                    .IsFixedLength(true);

                entity.Property(e => e.VehPlaca)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("veh_placa")
                    .IsFixedLength(true);

                entity.Property(e => e.VehTipo)
                    .HasMaxLength(10)
                    .HasColumnName("veh_tipo")
                    .IsFixedLength(true);

                entity.HasOne(d => d.MarIdMarcaNavigation)
                    .WithMany(p => p.Vehiculos)
                    .HasForeignKey(d => d.MarIdMarca)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_vehiculo_marca");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
