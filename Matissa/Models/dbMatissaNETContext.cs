using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Matissa.Models
{
    public partial class dbMatissaNETContext : DbContext
    {
        public dbMatissaNETContext()
        {
        }

        public dbMatissaNETContext(DbContextOptions<dbMatissaNETContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Citum> Cita { get; set; } = null!;
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Compra> Compras { get; set; } = null!;
        public virtual DbSet<DetalleCitum> DetalleCita { get; set; } = null!;
        public virtual DbSet<DetallePedido> DetallePedidos { get; set; } = null!;
        public virtual DbSet<Empleado> Empleados { get; set; } = null!;
        public virtual DbSet<Pedido> Pedidos { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<Servicio> Servicios { get; set; } = null!;
        public virtual DbSet<TipoServicio> TipoServicios { get; set; } = null!;
        public virtual DbSet<VentaServicio> VentaServicios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=(localdb)\\prueba;Initial Catalog=dbMatissaNET;integrated security=True; TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Citum>(entity =>
            {
                entity.HasKey(e => e.IdCita)
                    .HasName("PK__cita__814F31263DA04DE3");

                entity.ToTable("cita");

                entity.Property(e => e.IdCita)
                    .ValueGeneratedNever()
                    .HasColumnName("idCita");

                entity.Property(e => e.CostoTotal).HasColumnName("costoTotal");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("date")
                    .HasColumnName("fechaRegistro");

                entity.Property(e => e.IdCliente).HasColumnName("idCliente");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Cita)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__cita__idCliente__4F7CD00D");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK__cliente__885457EE5A51A261");

                entity.ToTable("cliente");

                entity.Property(e => e.IdCliente)
                    .ValueGeneratedNever()
                    .HasColumnName("idCliente");

                entity.Property(e => e.ApellidoCliente)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("apellidoCliente");

                entity.Property(e => e.Correo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("correo");

                entity.Property(e => e.Dirección)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("dirección");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.Nacimiento)
                    .HasColumnType("date")
                    .HasColumnName("nacimiento");

                entity.Property(e => e.NombreCliente)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombreCliente");

                entity.Property(e => e.Teléfono)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("teléfono");
            });

            modelBuilder.Entity<Compra>(entity =>
            {
                entity.HasKey(e => e.IdCompra)
                    .HasName("PK__compra__48B99DB7A13325F8");

                entity.ToTable("compra");

                entity.Property(e => e.IdCompra)
                    .ValueGeneratedNever()
                    .HasColumnName("idCompra");

                entity.Property(e => e.CostoTotalCompra).HasColumnName("costoTotalCompra");

                entity.Property(e => e.Descripción)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("descripción");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.Factura)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("factura");

                entity.Property(e => e.FechaCompra)
                    .HasColumnType("date")
                    .HasColumnName("fechaCompra");
            });

            modelBuilder.Entity<DetalleCitum>(entity =>
            {
                entity.HasKey(e => e.IdDetalleCita)
                    .HasName("PK__detalleC__031271117A36A6BB");

                entity.ToTable("detalleCita");

                entity.Property(e => e.IdDetalleCita)
                    .ValueGeneratedNever()
                    .HasColumnName("idDetalleCita");

                entity.Property(e => e.CostoServicio).HasColumnName("costoServicio");

                entity.Property(e => e.Descuento).HasColumnName("descuento");

                entity.Property(e => e.DuraciónServicio).HasColumnName("duraciónServicio");

                entity.Property(e => e.Estado)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("estado");

                entity.Property(e => e.FechaCita)
                    .HasColumnType("date")
                    .HasColumnName("fechaCita");

                entity.Property(e => e.HoraFin).HasColumnName("horaFin");

                entity.Property(e => e.HoraInicio).HasColumnName("horaInicio");

                entity.Property(e => e.IdCita).HasColumnName("idCita");

                entity.Property(e => e.IdEmpleado).HasColumnName("idEmpleado");

                entity.Property(e => e.IdServicio).HasColumnName("idServicio");

                entity.HasOne(d => d.IdCitaNavigation)
                    .WithMany(p => p.DetalleCita)
                    .HasForeignKey(d => d.IdCita)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__detalleCi__idCit__52593CB8");

                entity.HasOne(d => d.IdEmpleadoNavigation)
                    .WithMany(p => p.DetalleCita)
                    .HasForeignKey(d => d.IdEmpleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__detalleCi__idEmp__534D60F1");

                entity.HasOne(d => d.IdServicioNavigation)
                    .WithMany(p => p.DetalleCita)
                    .HasForeignKey(d => d.IdServicio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__detalleCi__idSer__5441852A");
            });

            modelBuilder.Entity<DetallePedido>(entity =>
            {
                entity.HasKey(e => e.IdDetallePedido)
                    .HasName("PK__detalleP__610F0056E942CCDA");

                entity.ToTable("detallePedido");

                entity.Property(e => e.IdDetallePedido)
                    .ValueGeneratedNever()
                    .HasColumnName("idDetallePedido");

                entity.Property(e => e.CantidadProducto).HasColumnName("cantidadProducto");

                entity.Property(e => e.IdPedido).HasColumnName("idPedido");

                entity.Property(e => e.IdProducto).HasColumnName("idProducto");

                entity.Property(e => e.PrecioUnitario).HasColumnName("precioUnitario");

                entity.HasOne(d => d.IdPedidoNavigation)
                    .WithMany(p => p.DetallePedidos)
                    .HasForeignKey(d => d.IdPedido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__detallePe__idPed__628FA481");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.DetallePedidos)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__detallePe__idPro__619B8048");
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasKey(e => e.IdEmpleado)
                    .HasName("PK__empleado__5295297C9779403D");

                entity.ToTable("empleado");

                entity.Property(e => e.IdEmpleado)
                    .ValueGeneratedNever()
                    .HasColumnName("idEmpleado");

                entity.Property(e => e.ApellidoEmpleado)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("apellidoEmpleado");

                entity.Property(e => e.Correo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("correo");

                entity.Property(e => e.Dirección)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("dirección");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.FechaContrato)
                    .HasColumnType("date")
                    .HasColumnName("fechaContrato");

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnType("date")
                    .HasColumnName("fechaNacimiento");

                entity.Property(e => e.Genero)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("genero");

                entity.Property(e => e.NombreEmpleado)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombreEmpleado");

                entity.Property(e => e.Teléfono)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("teléfono");
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.HasKey(e => e.IdPedido)
                    .HasName("PK__pedido__A9F619B752D55725");

                entity.ToTable("pedido");

                entity.Property(e => e.IdPedido)
                    .ValueGeneratedNever()
                    .HasColumnName("idPedido");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.FechaPedido)
                    .HasColumnType("date")
                    .HasColumnName("fechaPedido");

                entity.Property(e => e.IdCliente).HasColumnName("idCliente");

                entity.Property(e => e.PrecioTotalPedido).HasColumnName("precioTotalPedido");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__pedido__idClient__5EBF139D");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProducto)
                    .HasName("PK__producto__07F4A132E6BA3F28");

                entity.ToTable("producto");

                entity.Property(e => e.IdProducto)
                    .ValueGeneratedNever()
                    .HasColumnName("idProducto");

                entity.Property(e => e.Descripción)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("descripción");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.FechaCaducidad)
                    .HasColumnType("date")
                    .HasColumnName("fechaCaducidad");

                entity.Property(e => e.NombreProducto)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombreProducto");

                entity.Property(e => e.PrecioVenta).HasColumnName("precioVenta");

                entity.Property(e => e.SaldoInventario).HasColumnName("saldoInventario");
            });

            modelBuilder.Entity<Servicio>(entity =>
            {
                entity.HasKey(e => e.IdServicio)
                    .HasName("PK__servicio__CEB98119B2088B0F");

                entity.ToTable("servicio");

                entity.Property(e => e.IdServicio)
                    .ValueGeneratedNever()
                    .HasColumnName("idServicio");

                entity.Property(e => e.Descripción)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("descripción");

                entity.Property(e => e.Duración).HasColumnName("duración");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.IdTipoServicio).HasColumnName("idTipoServicio");

                entity.Property(e => e.NombreServicio)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombreServicio");

                entity.Property(e => e.Precio).HasColumnName("precio");

                entity.HasOne(d => d.IdTipoServicioNavigation)
                    .WithMany(p => p.Servicios)
                    .HasForeignKey(d => d.IdTipoServicio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__servicio__idTipo__4CA06362");
            });

            modelBuilder.Entity<TipoServicio>(entity =>
            {
                entity.HasKey(e => e.IdTipoServicio)
                    .HasName("PK__tipoServ__278616767C8DCAAE");

                entity.ToTable("tipoServicio");

                entity.Property(e => e.IdTipoServicio)
                    .ValueGeneratedNever()
                    .HasColumnName("idTipoServicio");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<VentaServicio>(entity =>
            {
                entity.HasKey(e => e.IdVentaServicio)
                    .HasName("PK__ventaSer__59B03D9C75C79989");

                entity.ToTable("ventaServicio");

                entity.Property(e => e.IdVentaServicio)
                    .ValueGeneratedNever()
                    .HasColumnName("idVentaServicio");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.FechaVenta)
                    .HasColumnType("date")
                    .HasColumnName("fechaVenta");

                entity.Property(e => e.FormaPago)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("formaPago");

                entity.Property(e => e.IdCita).HasColumnName("idCita");

                entity.Property(e => e.ValorVenta).HasColumnName("valorVenta");

                entity.HasOne(d => d.IdCitaNavigation)
                    .WithMany(p => p.VentaServicios)
                    .HasForeignKey(d => d.IdCita)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ventaServ__idCit__68487DD7");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        internal object BuscarPorFecha(string searchText)
        {
            throw new NotImplementedException();
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
