using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CeoWebServices.Models
{
    public partial class ceoContext : DbContext
    {
        public ceoContext()
        {
        }

        public ceoContext(DbContextOptions<ceoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Abonos> Abonos { get; set; }
        public virtual DbSet<Actas> Actas { get; set; }
        public virtual DbSet<Archivos> Archivos { get; set; }
        public virtual DbSet<AreaProyecto> AreaProyecto { get; set; }
        public virtual DbSet<Areas> Areas { get; set; }
        public virtual DbSet<CategoriaContratistas> CategoriaContratistas { get; set; }
        public virtual DbSet<CategoriaContratos> CategoriaContratos { get; set; }
        public virtual DbSet<CategoriaDocumento> CategoriaDocumento { get; set; }
        public virtual DbSet<CategoriaEmpresas> CategoriaEmpresas { get; set; }
        public virtual DbSet<Categorias> Categorias { get; set; }
        public virtual DbSet<Ciudades> Ciudades { get; set; }
        public virtual DbSet<Consorcio> Consorcio { get; set; }
        public virtual DbSet<Contactos> Contactos { get; set; }
        public virtual DbSet<ContactosEme> ContactosEme { get; set; }
        public virtual DbSet<Contratistas> Contratistas { get; set; }
        public virtual DbSet<ContratistasEspecialidad> ContratistasEspecialidad { get; set; }
        public virtual DbSet<ContratistasTitulo> ContratistasTitulo { get; set; }
        public virtual DbSet<ContratosDetalle> ContratosDetalle { get; set; }
        public virtual DbSet<ContratosProveedor> ContratosProveedor { get; set; }
        public virtual DbSet<Departamentos> Departamentos { get; set; }
        public virtual DbSet<Direcciones> Direcciones { get; set; }
        public virtual DbSet<EmpProductoServicio> EmpProductoServicio { get; set; }
        public virtual DbSet<Empresas> Empresas { get; set; }
        public virtual DbSet<Facturas> Facturas { get; set; }
        public virtual DbSet<Foto> Foto { get; set; }
        public virtual DbSet<Galeria> Galeria { get; set; }
        public virtual DbSet<Grupos> Grupos { get; set; }
        public virtual DbSet<Iva> Iva { get; set; }
        public virtual DbSet<LibretaDirecciones> LibretaDirecciones { get; set; }
        public virtual DbSet<Marcas> Marcas { get; set; }
        public virtual DbSet<Parametros> Parametros { get; set; }
        public virtual DbSet<Polizas> Polizas { get; set; }
        public virtual DbSet<ProductoServicio> ProductoServicio { get; set; }
        public virtual DbSet<Proyectos> Proyectos { get; set; }
        public virtual DbSet<Retefuente> Retefuente { get; set; }
        public virtual DbSet<Rup> Rup { get; set; }
        public virtual DbSet<Smmlv> Smmlv { get; set; }
        public virtual DbSet<SubcategoriaContratistas> SubcategoriaContratistas { get; set; }
        public virtual DbSet<SubcategoriaContratos> SubcategoriaContratos { get; set; }
        public virtual DbSet<Telefonos> Telefonos { get; set; }
        public virtual DbSet<TelfCont> TelfCont { get; set; }
        public virtual DbSet<TipoPoliza> TipoPoliza { get; set; }
        public virtual DbSet<Unidades> Unidades { get; set; }
        public virtual DbSet<VehAbastecimiento> VehAbastecimiento { get; set; }
        public virtual DbSet<VehDesplazamiento> VehDesplazamiento { get; set; }
        public virtual DbSet<VehDocumentos> VehDocumentos { get; set; }
        public virtual DbSet<Vehiculos> Vehiculos { get; set; }
        public virtual DbSet<VehMantenimientos> VehMantenimientos { get; set; }
        public virtual DbSet<VehmantVehtpm> VehmantVehtpm { get; set; }
        public virtual DbSet<VehTipomant> VehTipomant { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=192.168.0.118;Port=5432;Database=ceo;Username=postgres;Password=elprimero");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("dblink");

            modelBuilder.Entity<Abonos>(entity =>
            {
                entity.HasKey(e => new { e.AboIdAbono, e.AboIdFact });

                entity.ToTable("abonos");

                entity.ForNpgsqlHasComment("Registra los Abonos ralizados a las Facturas.");

                entity.Property(e => e.AboIdAbono)
                    .HasColumnName("abo_id_abono")
                    .HasColumnType("numeric(5,0)");

                entity.Property(e => e.AboIdFact)
                    .HasColumnName("abo_id_fact")
                    .HasColumnType("numeric(5,0)");

                entity.Property(e => e.AboFecha)
                    .HasColumnName("abo_fecha")
                    .HasColumnType("date");

                entity.Property(e => e.AboObs)
                    .HasColumnName("abo_obs")
                    .HasMaxLength(100);

                entity.Property(e => e.AboValor)
                    .HasColumnName("abo_valor")
                    .HasColumnType("numeric(14,2)");

                entity.HasOne(d => d.AboIdFactNavigation)
                    .WithMany(p => p.Abonos)
                    .HasForeignKey(d => d.AboIdFact)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("abo_fac_fk");
            });

            modelBuilder.Entity<Actas>(entity =>
            {
                entity.HasKey(e => new { e.ActIdActa, e.ActIdProyecto });

                entity.ToTable("actas");

                entity.ForNpgsqlHasComment("Registra las Actas de los Pryectos.");

                entity.HasIndex(e => e.ActId)
                    .HasName("act_uk")
                    .IsUnique();

                entity.Property(e => e.ActIdActa)
                    .HasColumnName("act_id_acta")
                    .HasColumnType("numeric(5,0)");

                entity.Property(e => e.ActIdProyecto)
                    .HasColumnName("act_id_proyecto")
                    .HasColumnType("numeric(4,0)");

                entity.Property(e => e.ActConcepto)
                    .IsRequired()
                    .HasColumnName("act_concepto")
                    .HasMaxLength(30);

                entity.Property(e => e.ActDiasAmpliacion)
                    .HasColumnName("act_dias_ampliacion")
                    .HasColumnType("numeric(4,0)");

                entity.Property(e => e.ActDiasSuspension)
                    .HasColumnName("act_dias_suspension")
                    .HasColumnType("numeric(4,0)");

                entity.Property(e => e.ActDigitalizado)
                    .HasColumnName("act_digitalizado")
                    .HasMaxLength(1);

                entity.Property(e => e.ActFactura)
                    .HasColumnName("act_factura")
                    .HasMaxLength(12);

                entity.Property(e => e.ActFecTerminaContraactual)
                    .HasColumnName("act_fec_termina_contraactual")
                    .HasColumnType("date");

                entity.Property(e => e.ActFechaActa)
                    .HasColumnName("act_fecha_acta")
                    .HasColumnType("date");

                entity.Property(e => e.ActFechaFactura)
                    .HasColumnName("act_fecha_factura")
                    .HasColumnType("date");

                entity.Property(e => e.ActFechaInicio)
                    .HasColumnName("act_fecha_inicio")
                    .HasColumnType("date");

                entity.Property(e => e.ActFechaReinicio)
                    .HasColumnName("act_fecha_reinicio")
                    .HasColumnType("date");

                entity.Property(e => e.ActFechaSuspension)
                    .HasColumnName("act_fecha_suspension")
                    .HasColumnType("date");

                entity.Property(e => e.ActFechaTermina)
                    .HasColumnName("act_fecha_termina")
                    .HasColumnType("date");

                entity.Property(e => e.ActId)
                    .HasColumnName("act_id")
                    .HasColumnType("numeric(7,0)");

                entity.Property(e => e.ActIdActaEme)
                    .HasColumnName("act_id_acta_eme")
                    .HasMaxLength(11);

                entity.Property(e => e.ActNuevaFinalizacion)
                    .HasColumnName("act_nueva_finalizacion")
                    .HasColumnType("date");

                entity.Property(e => e.ActNuevoValorContrato)
                    .HasColumnName("act_nuevo_valor_contrato")
                    .HasColumnType("numeric(14,2)");

                entity.Property(e => e.ActPlazo)
                    .HasColumnName("act_plazo")
                    .HasColumnType("numeric(4,0)");

                entity.Property(e => e.ActSusDependeReinicio)
                    .IsRequired()
                    .HasColumnName("act_sus_depende_reinicio")
                    .HasMaxLength(1);

                entity.Property(e => e.ActTipoValorNeto)
                    .HasColumnName("act_tipo_valor_neto")
                    .HasMaxLength(14);

                entity.Property(e => e.ActTipofg)
                    .HasColumnName("act_tipofg")
                    .HasMaxLength(14);

                entity.Property(e => e.ActValorAdicion)
                    .HasColumnName("act_valor_adicion")
                    .HasColumnType("numeric(14,2)");

                entity.Property(e => e.ActValorAdicionAe)
                    .HasColumnName("act_valor_adicion_ae")
                    .HasColumnType("numeric(14,2)");

                entity.Property(e => e.ActValorAmortizaAnticipo)
                    .HasColumnName("act_valor_amortiza_anticipo")
                    .HasColumnType("numeric(14,2)");

                entity.Property(e => e.ActValorAntesiva)
                    .HasColumnName("act_valor_antesiva")
                    .HasColumnType("numeric(14,2)");

                entity.Property(e => e.ActValorAnticipo)
                    .HasColumnName("act_valor_anticipo")
                    .HasColumnType("numeric(14,2)");

                entity.Property(e => e.ActValorEjecutado)
                    .HasColumnName("act_valor_ejecutado")
                    .HasColumnType("numeric(14,2)");

                entity.Property(e => e.ActValorExtraAe)
                    .HasColumnName("act_valor_extra_ae")
                    .HasColumnType("numeric(14,2)");

                entity.Property(e => e.ActValorIva)
                    .HasColumnName("act_valor_iva")
                    .HasColumnType("numeric(14,2)");

                entity.Property(e => e.ActValorNetoEjecutado)
                    .HasColumnName("act_valor_neto_ejecutado")
                    .HasColumnType("numeric(14,2)");

                entity.Property(e => e.ActValorReajuste)
                    .HasColumnName("act_valor_reajuste")
                    .HasColumnType("numeric(14,2)");

                entity.Property(e => e.ActValorfg)
                    .HasColumnName("act_valorfg")
                    .HasColumnType("numeric(14,2)");

                entity.HasOne(d => d.ActIdProyectoNavigation)
                    .WithMany(p => p.Actas)
                    .HasForeignKey(d => d.ActIdProyecto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("act_pry_fk");
            });

            modelBuilder.Entity<Archivos>(entity =>
            {
                entity.HasKey(e => e.AcvIdArchivo);

                entity.ToTable("archivos");

                entity.ForNpgsqlHasComment("Registra los Archivos de los Documentos de Scado.");

                entity.Property(e => e.AcvIdArchivo)
                    .HasColumnName("acv_id_archivo")
                    .HasColumnType("numeric(6,0)");

                entity.Property(e => e.AcvIdCategoria)
                    .HasColumnName("acv_id_categoria")
                    .HasColumnType("numeric(2,0)");

                entity.Property(e => e.AcvIdDocumento)
                    .HasColumnName("acv_id_documento")
                    .HasColumnType("numeric(8,0)");

                entity.Property(e => e.AcvNroPaginas)
                    .HasColumnName("acv_nro_paginas")
                    .HasColumnType("numeric(3,0)");

                entity.HasOne(d => d.AcvIdCategoriaNavigation)
                    .WithMany(p => p.Archivos)
                    .HasForeignKey(d => d.AcvIdCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("acv_cdo_fk");
            });

            modelBuilder.Entity<AreaProyecto>(entity =>
            {
                entity.HasKey(e => new { e.ApyIdArea, e.ApyIdProyecto });

                entity.ToTable("area_proyecto");

                entity.ForNpgsqlHasComment("Registra los Porcentajes de las Areas por Proyectos.");

                entity.Property(e => e.ApyIdArea)
                    .HasColumnName("apy_id_area")
                    .HasColumnType("numeric(4,0)");

                entity.Property(e => e.ApyIdProyecto)
                    .HasColumnName("apy_id_proyecto")
                    .HasColumnType("numeric(4,0)");

                entity.Property(e => e.ApyPorcentaje)
                    .HasColumnName("apy_porcentaje")
                    .HasColumnType("numeric(3,0)");

                entity.HasOne(d => d.ApyIdAreaNavigation)
                    .WithMany(p => p.AreaProyecto)
                    .HasForeignKey(d => d.ApyIdArea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("apy_are_fk");

                entity.HasOne(d => d.ApyIdProyectoNavigation)
                    .WithMany(p => p.AreaProyecto)
                    .HasForeignKey(d => d.ApyIdProyecto)
                    .HasConstraintName("apy_pry_fk");
            });

            modelBuilder.Entity<Areas>(entity =>
            {
                entity.HasKey(e => e.AreIdArea);

                entity.ToTable("areas");

                entity.ForNpgsqlHasComment("Registra las Areas de los Proyectos.");

                entity.HasIndex(e => e.AreDescripcionArea)
                    .HasName("are_uk")
                    .IsUnique();

                entity.Property(e => e.AreIdArea)
                    .HasColumnName("are_id_area")
                    .HasColumnType("numeric(4,0)");

                entity.Property(e => e.AreDescripcionArea)
                    .IsRequired()
                    .HasColumnName("are_descripcion_area")
                    .HasMaxLength(30);

                entity.Property(e => e.AreIdCategoriaContrato)
                    .HasColumnName("are_id_categoria_contrato")
                    .HasColumnType("numeric(2,0)");

                entity.HasOne(d => d.AreIdCategoriaContratoNavigation)
                    .WithMany(p => p.Areas)
                    .HasForeignKey(d => d.AreIdCategoriaContrato)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("are_cco_fk");
            });

            modelBuilder.Entity<CategoriaContratistas>(entity =>
            {
                entity.HasKey(e => e.CacId);

                entity.ToTable("categoria_contratistas");

                entity.ForNpgsqlHasComment("Registra las Categorias de los Contratistas.");

                entity.Property(e => e.CacId)
                    .HasColumnName("cac_id")
                    .HasColumnType("numeric(2,0)");

                entity.Property(e => e.CacCategoria)
                    .IsRequired()
                    .HasColumnName("cac_categoria")
                    .HasMaxLength(80);
            });

            modelBuilder.Entity<CategoriaContratos>(entity =>
            {
                entity.HasKey(e => e.CcoIdCategoriaContrato);

                entity.ToTable("categoria_contratos");

                entity.ForNpgsqlHasComment("Registra las Categorias de los Contratos.");

                entity.HasIndex(e => e.CcoDescripcion)
                    .HasName("cco_uk")
                    .IsUnique();

                entity.Property(e => e.CcoIdCategoriaContrato)
                    .HasColumnName("cco_id_categoria_contrato")
                    .HasColumnType("numeric(2,0)");

                entity.Property(e => e.CcoDescripcion)
                    .IsRequired()
                    .HasColumnName("cco_descripcion")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<CategoriaDocumento>(entity =>
            {
                entity.HasKey(e => e.CdoIdCategoria);

                entity.ToTable("categoria_documento");

                entity.ForNpgsqlHasComment("Registra las categorias de los Documentos.");

                entity.Property(e => e.CdoIdCategoria)
                    .HasColumnName("cdo_id_categoria")
                    .HasColumnType("numeric(2,0)");

                entity.Property(e => e.CdoDescripcion)
                    .IsRequired()
                    .HasColumnName("cdo_descripcion")
                    .HasMaxLength(50);

                entity.Property(e => e.CdoIdAdministrador)
                    .HasColumnName("cdo_id_administrador")
                    .HasColumnType("numeric(2,0)");

                entity.Property(e => e.CdoRuta)
                    .IsRequired()
                    .HasColumnName("cdo_ruta")
                    .HasMaxLength(50);

                entity.HasOne(d => d.CdoIdAdministradorNavigation)
                    .WithMany(p => p.CategoriaDocumento)
                    .HasForeignKey(d => d.CdoIdAdministrador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cdo_cee_fk");
            });

            modelBuilder.Entity<CategoriaEmpresas>(entity =>
            {
                entity.HasKey(e => e.CaeIdCategoria);

                entity.ToTable("categoria_empresas");

                entity.ForNpgsqlHasComment("Registra las Categorias de las Empresas.");

                entity.HasIndex(e => e.CaeDescripcion)
                    .HasName("cae_uk")
                    .IsUnique();

                entity.Property(e => e.CaeIdCategoria)
                    .HasColumnName("cae_id_categoria")
                    .HasColumnType("numeric(2,0)");

                entity.Property(e => e.CaeDescripcion)
                    .IsRequired()
                    .HasColumnName("cae_descripcion")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Categorias>(entity =>
            {
                entity.HasKey(e => e.CodCat);

                entity.ToTable("categorias");

                entity.ForNpgsqlHasComment("Registra las Categorias de los Insumos.");

                entity.HasIndex(e => e.DesCat)
                    .HasName("des_cat_uk")
                    .IsUnique();

                entity.Property(e => e.CodCat)
                    .HasColumnName("cod_cat")
                    .HasColumnType("numeric(3,0)");

                entity.Property(e => e.DesCat)
                    .HasColumnName("des_cat")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Ciudades>(entity =>
            {
                entity.HasKey(e => new { e.CieIdCiudad, e.CieIdDepartamento });

                entity.ToTable("ciudades");

                entity.ForNpgsqlHasComment("Registra las ciudades para los Aplicativos.");

                entity.Property(e => e.CieIdCiudad)
                    .HasColumnName("cie_id_ciudad")
                    .HasColumnType("numeric(4,0)");

                entity.Property(e => e.CieIdDepartamento)
                    .HasColumnName("cie_id_departamento")
                    .HasColumnType("numeric(4,0)");

                entity.Property(e => e.CieCodigo)
                    .HasColumnName("cie_codigo")
                    .HasMaxLength(5)
                    .ForNpgsqlHasComment("Codigo Departamento y Ciudad.");

                entity.Property(e => e.CieIndicativo)
                    .HasColumnName("cie_indicativo")
                    .HasColumnType("numeric(4,0)");

                entity.Property(e => e.CieNombre)
                    .IsRequired()
                    .HasColumnName("cie_nombre")
                    .HasMaxLength(50);

                entity.HasOne(d => d.CieIdDepartamentoNavigation)
                    .WithMany(p => p.Ciudades)
                    .HasForeignKey(d => d.CieIdDepartamento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cie_dep_fk");
            });

            modelBuilder.Entity<Consorcio>(entity =>
            {
                entity.HasKey(e => e.ConIdConsorcio);

                entity.ToTable("consorcio");

                entity.ForNpgsqlHasComment("Registra los Consorcios de los diferentes Proyectos.");

                entity.Property(e => e.ConIdConsorcio)
                    .HasColumnName("con_id_consorcio")
                    .HasColumnType("numeric(6,0)");

                entity.Property(e => e.ConIdEmpresa)
                    .HasColumnName("con_id_empresa")
                    .HasColumnType("numeric(4,0)");

                entity.Property(e => e.ConIdProyecto)
                    .HasColumnName("con_id_proyecto")
                    .HasColumnType("numeric(4,0)");

                entity.Property(e => e.ConNomcon)
                    .HasColumnName("con_nomcon")
                    .HasMaxLength(200);

                entity.Property(e => e.ConPorcentaje)
                    .HasColumnName("con_porcentaje")
                    .HasColumnType("numeric(3,0)");

                entity.Property(e => e.ConTipcon)
                    .HasColumnName("con_tipcon")
                    .HasMaxLength(20);

                entity.HasOne(d => d.ConIdEmpresaNavigation)
                    .WithMany(p => p.Consorcio)
                    .HasForeignKey(d => d.ConIdEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("con_emp_fk");

                entity.HasOne(d => d.ConIdProyectoNavigation)
                    .WithMany(p => p.Consorcio)
                    .HasForeignKey(d => d.ConIdProyecto)
                    .HasConstraintName("con_pry_fk");
            });

            modelBuilder.Entity<Contactos>(entity =>
            {
                entity.HasKey(e => e.CooIdContacto);

                entity.ToTable("contactos");

                entity.ForNpgsqlHasComment("Registra los Contactos de las Empresas o Clientes.");

                entity.Property(e => e.CooIdContacto)
                    .HasColumnName("coo_id_contacto")
                    .HasColumnType("numeric(4,0)");

                entity.Property(e => e.CooApellidos)
                    .IsRequired()
                    .HasColumnName("coo_apellidos")
                    .HasMaxLength(50);

                entity.Property(e => e.CooCargo)
                    .HasColumnName("coo_cargo")
                    .HasMaxLength(60);

                entity.Property(e => e.CooCedula)
                    .HasColumnName("coo_cedula")
                    .HasMaxLength(10);

                entity.Property(e => e.CooCelular)
                    .HasColumnName("coo_celular")
                    .HasMaxLength(10);

                entity.Property(e => e.CooEmail)
                    .HasColumnName("coo_email")
                    .HasMaxLength(60);

                entity.Property(e => e.CooExtension)
                    .HasColumnName("coo_extension")
                    .HasMaxLength(10);

                entity.Property(e => e.CooIdDireccion)
                    .HasColumnName("coo_id_direccion")
                    .HasColumnType("numeric(4,0)");

                entity.Property(e => e.CooIdEmpresa)
                    .HasColumnName("coo_id_empresa")
                    .HasColumnType("numeric(4,0)");

                entity.Property(e => e.CooNombres)
                    .IsRequired()
                    .HasColumnName("coo_nombres")
                    .HasMaxLength(50);

                entity.Property(e => e.CooTelDirecto)
                    .HasColumnName("coo_tel_directo")
                    .HasColumnType("numeric(11,0)");

                entity.Property(e => e.CooTelResid)
                    .HasColumnName("coo_tel_resid")
                    .HasColumnType("numeric(11,0)");

                entity.HasOne(d => d.CooIdDireccionNavigation)
                    .WithMany(p => p.Contactos)
                    .HasForeignKey(d => d.CooIdDireccion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("coo_dir_fk");

                entity.HasOne(d => d.CooIdEmpresaNavigation)
                    .WithMany(p => p.Contactos)
                    .HasForeignKey(d => d.CooIdEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("coo_emp_fk");
            });

            modelBuilder.Entity<ContactosEme>(entity =>
            {
                entity.HasKey(e => e.CeeIdContactoEme);

                entity.ToTable("contactos_eme");

                entity.ForNpgsqlHasComment("Registra Los Empleados de EME ING.");

                entity.HasIndex(e => e.CeeCedula)
                    .HasName("cee1_uk")
                    .IsUnique();

                entity.HasIndex(e => e.CeeIdUsuario)
                    .HasName("cee2_uk")
                    .IsUnique();

                entity.HasIndex(e => new { e.CeeNombres, e.CeeApellidos })
                    .HasName("cee_uk")
                    .IsUnique();

                entity.Property(e => e.CeeIdContactoEme)
                    .HasColumnName("cee_id_contacto_eme")
                    .HasColumnType("numeric(3,0)");

                entity.Property(e => e.CeeAcceso)
                    .IsRequired()
                    .HasColumnName("cee_acceso")
                    .HasMaxLength(1);

                entity.Property(e => e.CeeActivo)
                    .IsRequired()
                    .HasColumnName("cee_activo")
                    .HasMaxLength(1);

                entity.Property(e => e.CeeApellidos)
                    .IsRequired()
                    .HasColumnName("cee_apellidos")
                    .HasMaxLength(50);

                entity.Property(e => e.CeeAvantel)
                    .HasColumnName("cee_avantel")
                    .HasMaxLength(10);

                entity.Property(e => e.CeeCargoActual)
                    .IsRequired()
                    .HasColumnName("cee_cargo_actual")
                    .HasMaxLength(100);

                entity.Property(e => e.CeeCedula)
                    .IsRequired()
                    .HasColumnName("cee_cedula")
                    .HasMaxLength(20);

                entity.Property(e => e.CeeCelular)
                    .HasColumnName("cee_celular")
                    .HasMaxLength(10);

                entity.Property(e => e.CeeDigitalizado)
                    .HasColumnName("cee_digitalizado")
                    .HasMaxLength(1);

                entity.Property(e => e.CeeDireccionResidencia)
                    .IsRequired()
                    .HasColumnName("cee_direccion_residencia")
                    .HasMaxLength(150);

                entity.Property(e => e.CeeEmail)
                    .HasColumnName("cee_email")
                    .HasMaxLength(150);

                entity.Property(e => e.CeeFechaIngreso)
                    .HasColumnName("cee_fecha_ingreso")
                    .HasColumnType("date");

                entity.Property(e => e.CeeFechaNacimiento)
                    .HasColumnName("cee_fecha_nacimiento")
                    .HasColumnType("date");

                entity.Property(e => e.CeeFecret)
                    .HasColumnName("cee_fecret")
                    .HasColumnType("date");

                entity.Property(e => e.CeeIdGrupo)
                    .HasColumnName("cee_id_grupo")
                    .HasColumnType("numeric(3,0)");

                entity.Property(e => e.CeeIdUsuario)
                    .IsRequired()
                    .HasColumnName("cee_id_usuario")
                    .HasMaxLength(20);

                entity.Property(e => e.CeeNombreConyuge)
                    .HasColumnName("cee_nombre_conyuge")
                    .HasMaxLength(150);

                entity.Property(e => e.CeeNombres)
                    .IsRequired()
                    .HasColumnName("cee_nombres")
                    .HasMaxLength(50);

                entity.Property(e => e.CeeNroDocumentos)
                    .HasColumnName("cee_nro_documentos")
                    .HasColumnType("numeric(4,0)");

                entity.Property(e => e.CeeNrocont)
                    .HasColumnName("cee_nrocont")
                    .HasMaxLength(20);

                entity.Property(e => e.CeeNumeroHijos)
                    .HasColumnName("cee_numero_hijos")
                    .HasColumnType("numeric(1,0)");

                entity.Property(e => e.CeePassword)
                    .IsRequired()
                    .HasColumnName("cee_password")
                    .HasMaxLength(50);

                entity.Property(e => e.CeePerfil)
                    .IsRequired()
                    .HasColumnName("cee_perfil")
                    .HasMaxLength(20);

                entity.Property(e => e.CeeSalarioActual)
                    .HasColumnName("cee_salario_actual")
                    .HasColumnType("numeric(8,0)");

                entity.Property(e => e.CeeTelefonoResidencia)
                    .HasColumnName("cee_telefono_residencia")
                    .HasMaxLength(8);

                entity.Property(e => e.CeeTipcont)
                    .HasColumnName("cee_tipcont")
                    .HasMaxLength(30);

                entity.HasOne(d => d.CeeIdGrupoNavigation)
                    .WithMany(p => p.ContactosEme)
                    .HasForeignKey(d => d.CeeIdGrupo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cee_gru_fk");
            });

            modelBuilder.Entity<Contratistas>(entity =>
            {
                entity.HasKey(e => e.CttIdContratista);

                entity.ToTable("contratistas");

                entity.ForNpgsqlHasComment("Registra los Contratistas de Control de Obra.");

                entity.HasIndex(e => e.CttRut)
                    .HasName("ctt_rut_UK")
                    .IsUnique();

                entity.Property(e => e.CttIdContratista).HasColumnName("ctt_id_contratista");

                entity.Property(e => e.CttApellido)
                    .IsRequired()
                    .HasColumnName("ctt_apellido")
                    .HasMaxLength(250);

                entity.Property(e => e.CttBarrio)
                    .HasColumnName("ctt_barrio")
                    .HasMaxLength(150);

                entity.Property(e => e.CttCedula).HasColumnName("ctt_cedula");

                entity.Property(e => e.CttDireccion)
                    .HasColumnName("ctt_direccion")
                    .HasMaxLength(150);

                entity.Property(e => e.CttEstado)
                    .HasColumnName("ctt_estado")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.CttIdCiudad).HasColumnName("ctt_id_ciudad");

                entity.Property(e => e.CttIdDepartamento).HasColumnName("ctt_id_departamento");

                entity.Property(e => e.CttMovil)
                    .HasColumnName("ctt_movil")
                    .HasColumnType("numeric(10,0)");

                entity.Property(e => e.CttNombre)
                    .IsRequired()
                    .HasColumnName("ctt_nombre")
                    .HasMaxLength(250);

                entity.Property(e => e.CttRazonsocial)
                    .IsRequired()
                    .HasColumnName("ctt_razonsocial")
                    .HasMaxLength(100);

                entity.Property(e => e.CttRegimen)
                    .IsRequired()
                    .HasColumnName("ctt_regimen")
                    .HasMaxLength(12);

                entity.Property(e => e.CttRut)
                    .IsRequired()
                    .HasColumnName("ctt_rut")
                    .HasMaxLength(15);

                entity.Property(e => e.CttTelefono)
                    .HasColumnName("ctt_telefono")
                    .HasColumnType("numeric(10,0)");

                entity.HasOne(d => d.Ctt)
                    .WithMany(p => p.Contratistas)
                    .HasForeignKey(d => new { d.CttIdCiudad, d.CttIdDepartamento })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ctt_id_ciudad_departamento_fk");
            });

            modelBuilder.Entity<ContratistasEspecialidad>(entity =>
            {
                entity.HasKey(e => e.CesId);

                entity.ToTable("contratistas_especialidad");

                entity.ForNpgsqlHasComment("Registra las Especialidades de los Contratistas.");

                entity.Property(e => e.CesId)
                    .HasColumnName("ces_id")
                    .HasColumnType("numeric(3,0)");

                entity.Property(e => e.CesDescripcion)
                    .IsRequired()
                    .HasColumnName("ces_descripcion")
                    .HasMaxLength(75);
            });

            modelBuilder.Entity<ContratistasTitulo>(entity =>
            {
                entity.HasKey(e => e.CtiId);

                entity.ToTable("contratistas_titulo");

                entity.ForNpgsqlHasComment("Registra los Titulos de los Contratistas.");

                entity.Property(e => e.CtiId)
                    .HasColumnName("cti_id")
                    .HasColumnType("numeric(2,0)");

                entity.Property(e => e.CtiTitulo)
                    .IsRequired()
                    .HasColumnName("cti_titulo")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ContratosDetalle>(entity =>
            {
                entity.HasKey(e => e.CpdIdCpd);

                entity.ToTable("contratos_detalle");

                entity.ForNpgsqlHasComment("Registra los Detalles de los Contratos a Proveedores.");

                entity.HasIndex(e => e.CpdIdCpv)
                    .HasName("fki_cpv_id");

                entity.Property(e => e.CpdIdCpd)
                    .HasColumnName("cpd_id_cpd")
                    .HasColumnType("numeric(4,0)");

                entity.Property(e => e.CpdArchivo)
                    .IsRequired()
                    .HasColumnName("cpd_archivo")
                    .HasMaxLength(100);

                entity.Property(e => e.CpdIdCpv)
                    .HasColumnName("cpd_id_cpv")
                    .HasColumnType("numeric(4,0)");

                entity.Property(e => e.CpdTipo)
                    .IsRequired()
                    .HasColumnName("cpd_tipo")
                    .HasMaxLength(30);

                entity.HasOne(d => d.CpdIdCpvNavigation)
                    .WithMany(p => p.ContratosDetalle)
                    .HasForeignKey(d => d.CpdIdCpv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cpv_id_cpv");
            });

            modelBuilder.Entity<ContratosProveedor>(entity =>
            {
                entity.HasKey(e => e.CpvIdCpv);

                entity.ToTable("contratos_proveedor");

                entity.ForNpgsqlHasComment("Registra los Contratos a los Proveedores especiales.");

                entity.Property(e => e.CpvIdCpv)
                    .HasColumnName("cpv_id_cpv")
                    .HasColumnType("numeric(4,0)")
                    .HasDefaultValueSql("nextval('contratos_proveedor_cpv_id_cpv_seq'::regclass)")
                    .ForNpgsqlHasComment("Secuencia Autonumerica de Identificacion.");

                entity.Property(e => e.CpvAnexos)
                    .HasColumnName("cpv_anexos")
                    .HasColumnType("character varying");

                entity.Property(e => e.CpvCedRepLegal)
                    .HasColumnName("cpv_ced_rep_legal")
                    .HasMaxLength(20);

                entity.Property(e => e.CpvCiuVen)
                    .HasColumnName("cpv_ciu_ven")
                    .HasMaxLength(30);

                entity.Property(e => e.CpvCiudadEnt)
                    .HasColumnName("cpv_ciudad_ent")
                    .HasMaxLength(150);

                entity.Property(e => e.CpvClausulaPenal)
                    .HasColumnName("cpv_clausula_penal")
                    .HasColumnType("character varying");

                entity.Property(e => e.CpvCodPrv)
                    .HasColumnName("cpv_cod_prv")
                    .HasMaxLength(8);

                entity.Property(e => e.CpvEmpVen)
                    .HasColumnName("cpv_emp_ven")
                    .HasMaxLength(80);

                entity.Property(e => e.CpvFecOferta)
                    .HasColumnName("cpv_fec_oferta")
                    .HasColumnType("date");

                entity.Property(e => e.CpvFechaContrato)
                    .HasColumnName("cpv_fecha_contrato")
                    .HasMaxLength(80);

                entity.Property(e => e.CpvFechaEnt)
                    .HasColumnName("cpv_fecha_ent")
                    .HasMaxLength(80);

                entity.Property(e => e.CpvFormaEnt)
                    .HasColumnName("cpv_forma_ent")
                    .HasColumnType("character varying");

                entity.Property(e => e.CpvFormaPago)
                    .HasColumnName("cpv_forma_pago")
                    .HasColumnType("character varying");

                entity.Property(e => e.CpvInsumoVen)
                    .HasColumnName("cpv_insumo_ven")
                    .HasMaxLength(100);

                entity.Property(e => e.CpvNitVen)
                    .HasColumnName("cpv_nit_ven")
                    .HasMaxLength(20);

                entity.Property(e => e.CpvNomRepLegal)
                    .HasColumnName("cpv_nom_rep_legal")
                    .HasMaxLength(100);

                entity.Property(e => e.CpvNotiVen)
                    .HasColumnName("cpv_noti_ven")
                    .HasColumnType("character varying");

                entity.Property(e => e.CpvNumContrato)
                    .IsRequired()
                    .HasColumnName("cpv_num_contrato")
                    .HasMaxLength(20);

                entity.Property(e => e.CpvPaisVen)
                    .HasColumnName("cpv_pais_ven")
                    .HasMaxLength(30);

                entity.Property(e => e.CpvPolizaCum)
                    .HasColumnName("cpv_poliza_cum")
                    .HasColumnType("character varying");

                entity.Property(e => e.CpvPolizaGar)
                    .HasColumnName("cpv_poliza_gar")
                    .HasColumnType("character varying");

                entity.Property(e => e.CpvTrm)
                    .HasColumnName("cpv_trm")
                    .HasColumnType("character varying");

                entity.Property(e => e.CpvValorCont)
                    .HasColumnName("cpv_valor_cont")
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Departamentos>(entity =>
            {
                entity.HasKey(e => e.DepIdDepartamento);

                entity.ToTable("departamentos");

                entity.ForNpgsqlHasComment("Registra los Departamentos de Colombia.");

                entity.HasIndex(e => e.DepNombre)
                    .HasName("dep_uk")
                    .IsUnique();

                entity.Property(e => e.DepIdDepartamento)
                    .HasColumnName("dep_id_departamento")
                    .HasColumnType("numeric(4,0)");

                entity.Property(e => e.DepNombre)
                    .IsRequired()
                    .HasColumnName("dep_nombre")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Direcciones>(entity =>
            {
                entity.HasKey(e => e.DirIdDireccion);

                entity.ToTable("direcciones");

                entity.ForNpgsqlHasComment("Registra las Direcciones de las Empresas.");

                entity.Property(e => e.DirIdDireccion)
                    .HasColumnName("dir_id_direccion")
                    .HasColumnType("numeric(4,0)");

                entity.Property(e => e.DirDireccion)
                    .IsRequired()
                    .HasColumnName("dir_direccion")
                    .HasMaxLength(100);

                entity.Property(e => e.DirIdCiudad)
                    .HasColumnName("dir_id_ciudad")
                    .HasColumnType("numeric(4,0)");

                entity.Property(e => e.DirIdDepartamento)
                    .HasColumnName("dir_id_departamento")
                    .HasColumnType("numeric(4,0)");

                entity.Property(e => e.DirIdEmpresa)
                    .HasColumnName("dir_id_empresa")
                    .HasColumnType("numeric(4,0)");

                entity.HasOne(d => d.DirIdEmpresaNavigation)
                    .WithMany(p => p.Direcciones)
                    .HasForeignKey(d => d.DirIdEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("dir_emp_fk");

                entity.HasOne(d => d.Dir)
                    .WithMany(p => p.Direcciones)
                    .HasForeignKey(d => new { d.DirIdCiudad, d.DirIdDepartamento })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("dir_cie_fk");
            });

            modelBuilder.Entity<EmpProductoServicio>(entity =>
            {
                entity.HasKey(e => new { e.EpsIdProductoServicio, e.EpsIdEmpresa });

                entity.ToTable("emp_producto_servicio");

                entity.ForNpgsqlHasComment("Registra los productos de las Diferentes Empresas.");

                entity.Property(e => e.EpsIdProductoServicio)
                    .HasColumnName("eps_id_producto_servicio")
                    .HasColumnType("numeric(3,0)");

                entity.Property(e => e.EpsIdEmpresa)
                    .HasColumnName("eps_id_empresa")
                    .HasColumnType("numeric(4,0)");

                entity.HasOne(d => d.EpsIdEmpresaNavigation)
                    .WithMany(p => p.EmpProductoServicio)
                    .HasForeignKey(d => d.EpsIdEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("eps_emp_fk");

                entity.HasOne(d => d.EpsIdProductoServicioNavigation)
                    .WithMany(p => p.EmpProductoServicio)
                    .HasForeignKey(d => d.EpsIdProductoServicio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("eps_ps_fk");
            });

            modelBuilder.Entity<Empresas>(entity =>
            {
                entity.HasKey(e => e.EmpIdEmpresa);

                entity.ToTable("empresas");

                entity.ForNpgsqlHasComment("Registra las Empresas de los Proyectos.");

                entity.HasIndex(e => e.EmpRazonSocial)
                    .HasName("emp_uk")
                    .IsUnique();

                entity.Property(e => e.EmpIdEmpresa)
                    .HasColumnName("emp_id_empresa")
                    .HasColumnType("numeric(4,0)");

                entity.Property(e => e.CieCodigo)
                    .HasColumnName("cie_codigo")
                    .HasMaxLength(5)
                    .ForNpgsqlHasComment("Codigo Departamento y Ciudad.");

                entity.Property(e => e.EmpCorreo)
                    .HasColumnName("emp_correo")
                    .HasMaxLength(100);

                entity.Property(e => e.EmpEsAutoretenedor)
                    .HasColumnName("emp_es_autoretenedor")
                    .HasMaxLength(1);

                entity.Property(e => e.EmpEsCliente)
                    .HasColumnName("emp_es_cliente")
                    .HasMaxLength(1);

                entity.Property(e => e.EmpEsProveedor)
                    .HasColumnName("emp_es_proveedor")
                    .HasMaxLength(1);

                entity.Property(e => e.EmpFechaInactiva)
                    .HasColumnName("emp_fecha_inactiva")
                    .HasColumnType("date");

                entity.Property(e => e.EmpIdCategoriaEmpresa)
                    .HasColumnName("emp_id_categoria_empresa")
                    .HasColumnType("numeric(2,0)");

                entity.Property(e => e.EmpInactiva)
                    .HasColumnName("emp_inactiva")
                    .HasMaxLength(1);

                entity.Property(e => e.EmpInactivaObservacion)
                    .HasColumnName("emp_inactiva_observacion")
                    .HasMaxLength(150);

                entity.Property(e => e.EmpNit)
                    .HasColumnName("emp_nit")
                    .HasMaxLength(20);

                entity.Property(e => e.EmpRazonSocial)
                    .IsRequired()
                    .HasColumnName("emp_razon_social")
                    .HasMaxLength(150);

                entity.Property(e => e.EmpRegimenTributario)
                    .HasColumnName("emp_regimen_tributario")
                    .HasMaxLength(30);

                entity.Property(e => e.EmpSitioWeb)
                    .HasColumnName("emp_sitio_web")
                    .HasMaxLength(150);

                entity.Property(e => e.EmpTipoIden)
                    .HasColumnName("emp_tipo_iden")
                    .HasMaxLength(50);

                entity.Property(e => e.EmpTipoPersona)
                    .HasColumnName("emp_tipo_persona")
                    .HasMaxLength(50);

                entity.HasOne(d => d.EmpIdCategoriaEmpresaNavigation)
                    .WithMany(p => p.Empresas)
                    .HasForeignKey(d => d.EmpIdCategoriaEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("emp_cae_fk");
            });

            modelBuilder.Entity<Facturas>(entity =>
            {
                entity.HasKey(e => e.FacIdFact);

                entity.ToTable("facturas");

                entity.ForNpgsqlHasComment("Registra las Facturas asociados a los Proyectos.");

                entity.Property(e => e.FacIdFact)
                    .HasColumnName("fac_id_fact")
                    .HasColumnType("numeric(5,0)");

                entity.Property(e => e.FacAnticipo)
                    .HasColumnName("fac_anticipo")
                    .HasColumnType("numeric(14,2)");

                entity.Property(e => e.FacCancelo)
                    .IsRequired()
                    .HasColumnName("fac_cancelo")
                    .HasMaxLength(2);

                entity.Property(e => e.FacCree)
                    .HasColumnName("fac_cree")
                    .HasColumnType("numeric(14,2)");

                entity.Property(e => e.FacDigi)
                    .HasColumnName("fac_digi")
                    .HasMaxLength(1);

                entity.Property(e => e.FacFechaFact)
                    .HasColumnName("fac_fecha_fact")
                    .HasColumnType("date");

                entity.Property(e => e.FacFechaPago)
                    .HasColumnName("fac_fecha_pago")
                    .HasColumnType("date");

                entity.Property(e => e.FacFechaRadic)
                    .HasColumnName("fac_fecha_radic")
                    .HasColumnType("date");

                entity.Property(e => e.FacFechaVenc)
                    .HasColumnName("fac_fecha_venc")
                    .HasColumnType("date");

                entity.Property(e => e.FacIdActa)
                    .HasColumnName("fac_id_acta")
                    .HasColumnType("numeric(7,0)");

                entity.Property(e => e.FacIdEmpresa)
                    .HasColumnName("fac_id_empresa")
                    .HasColumnType("numeric(4,0)");

                entity.Property(e => e.FacIdProyecto)
                    .HasColumnName("fac_id_proyecto")
                    .HasColumnType("numeric(4,0)");

                entity.Property(e => e.FacNumFact)
                    .HasColumnName("fac_num_fact")
                    .HasColumnType("numeric(5,0)");

                entity.Property(e => e.FacObs)
                    .HasColumnName("fac_obs")
                    .HasMaxLength(300);

                entity.Property(e => e.FacReteIca)
                    .HasColumnName("fac_rete_ica")
                    .HasColumnType("numeric(14,2)");

                entity.Property(e => e.FacReteIva)
                    .HasColumnName("fac_rete_iva")
                    .HasColumnType("numeric(14,2)");

                entity.Property(e => e.FacReteOtros)
                    .HasColumnName("fac_rete_otros")
                    .HasColumnType("numeric(14,2)");

                entity.Property(e => e.FacRetefuent)
                    .HasColumnName("fac_retefuent")
                    .HasColumnType("numeric(14,2)");

                entity.Property(e => e.FacRetegarantia)
                    .HasColumnName("fac_retegarantia")
                    .HasColumnType("numeric(14,2)");

                entity.Property(e => e.FacTipoDoc)
                    .HasColumnName("fac_tipo_doc")
                    .HasMaxLength(3);

                entity.Property(e => e.FacValorAntesiva)
                    .HasColumnName("fac_valor_antesiva")
                    .HasColumnType("numeric(14,2)");

                entity.Property(e => e.FacValorCancelado)
                    .HasColumnName("fac_valor_cancelado")
                    .HasColumnType("numeric(14,2)");

                entity.Property(e => e.FacValorIva)
                    .HasColumnName("fac_valor_iva")
                    .HasColumnType("numeric(14,2)");

                entity.Property(e => e.FacValorNeto)
                    .HasColumnName("fac_valor_neto")
                    .HasColumnType("numeric(14,2)");

                entity.Property(e => e.FacValorTotal)
                    .HasColumnName("fac_valor_total")
                    .HasColumnType("numeric(14,2)");

                entity.HasOne(d => d.FacIdEmpresaNavigation)
                    .WithMany(p => p.Facturas)
                    .HasForeignKey(d => d.FacIdEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fac_emp_fk");

                entity.HasOne(d => d.FacIdProyectoNavigation)
                    .WithMany(p => p.Facturas)
                    .HasForeignKey(d => d.FacIdProyecto)
                    .HasConstraintName("fac_pry_fk");
            });

            modelBuilder.Entity<Foto>(entity =>
            {
                entity.HasKey(e => e.FotIdFoto);

                entity.ToTable("foto");

                entity.ForNpgsqlHasComment("Registra las Fotos de las Galerias asociadas a los Proyectos.");

                entity.Property(e => e.FotIdFoto).HasColumnName("fot_id_foto");

                entity.Property(e => e.FotDescripcion)
                    .HasColumnName("fot_descripcion")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'Descripción'::character varying");

                entity.Property(e => e.FotEstado)
                    .HasColumnName("fot_estado")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.FotFecha).HasColumnName("fot_fecha");

                entity.Property(e => e.FotIdGaleria).HasColumnName("fot_id_galeria");

                entity.Property(e => e.FotNombre)
                    .IsRequired()
                    .HasColumnName("fot_nombre")
                    .HasMaxLength(250);

                entity.HasOne(d => d.FotIdGaleriaNavigation)
                    .WithMany(p => p.Foto)
                    .HasForeignKey(d => d.FotIdGaleria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_fot_id_galeria");
            });

            modelBuilder.Entity<Galeria>(entity =>
            {
                entity.HasKey(e => e.GalIdGaleria);

                entity.ToTable("galeria");

                entity.ForNpgsqlHasComment("Registra las Galerias de los Proyectos.");

                entity.Property(e => e.GalIdGaleria).HasColumnName("gal_id_galeria");

                entity.Property(e => e.GalDescripcion)
                    .IsRequired()
                    .HasColumnName("gal_descripcion")
                    .HasMaxLength(250);

                entity.Property(e => e.GalEstado)
                    .HasColumnName("gal_estado")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.GalFecha).HasColumnName("gal_fecha");

                entity.Property(e => e.GalIdProyecto).HasColumnName("gal_id_proyecto");

                entity.Property(e => e.GalTitulo)
                    .IsRequired()
                    .HasColumnName("gal_titulo")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Grupos>(entity =>
            {
                entity.HasKey(e => e.GruIdGrupo);

                entity.ToTable("grupos");

                entity.ForNpgsqlHasComment("Registra los Grupos para los Contactos EME.");

                entity.Property(e => e.GruIdGrupo)
                    .HasColumnName("gru_id_grupo")
                    .HasColumnType("numeric(3,0)");

                entity.Property(e => e.GruDescripcion)
                    .IsRequired()
                    .HasColumnName("gru_descripcion")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Iva>(entity =>
            {
                entity.HasKey(e => e.IvaIdIva);

                entity.ToTable("iva");

                entity.ForNpgsqlHasComment("Registra los Diferentes Valores de IVA.");

                entity.Property(e => e.IvaIdIva).HasColumnName("iva_id_iva");

                entity.Property(e => e.IvaFechaDesde)
                    .HasColumnName("iva_fecha_desde")
                    .HasColumnType("date");

                entity.Property(e => e.IvaPorcentaje)
                    .HasColumnName("iva_porcentaje")
                    .HasColumnType("numeric(4,2)");
            });

            modelBuilder.Entity<LibretaDirecciones>(entity =>
            {
                entity.HasKey(e => e.LbdIdLibreta);

                entity.ToTable("libreta_direcciones");

                entity.Property(e => e.LbdIdLibreta).HasColumnName("lbd_id_libreta");

                entity.Property(e => e.LbdCorreo)
                    .IsRequired()
                    .HasColumnName("lbd_correo")
                    .HasMaxLength(100);

                entity.Property(e => e.LbdEmpresa)
                    .HasColumnName("lbd_empresa")
                    .HasMaxLength(100);

                entity.Property(e => e.LbdNombre)
                    .IsRequired()
                    .HasColumnName("lbd_nombre")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Marcas>(entity =>
            {
                entity.HasKey(e => e.CodMarca);

                entity.ToTable("marcas");

                entity.ForNpgsqlHasComment("Registra las Marcas de los Insumos.");

                entity.HasIndex(e => e.Marca)
                    .HasName("desc_marca_uk")
                    .IsUnique();

                entity.Property(e => e.CodMarca)
                    .HasColumnName("cod_marca")
                    .HasColumnType("numeric(3,0)");

                entity.Property(e => e.Marca)
                    .HasColumnName("marca")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Parametros>(entity =>
            {
                entity.HasKey(e => e.PmtIdParametro);

                entity.ToTable("parametros");

                entity.ForNpgsqlHasComment("Registra los Parametros de Configuracion.");

                entity.Property(e => e.PmtIdParametro)
                    .HasColumnName("pmt_id_parametro")
                    .HasColumnType("numeric(2,0)");

                entity.Property(e => e.PmtDescripcion)
                    .HasColumnName("pmt_descripcion")
                    .HasMaxLength(100);

                entity.Property(e => e.PmtValorChar)
                    .HasColumnName("pmt_valor_char")
                    .HasMaxLength(100);

                entity.Property(e => e.PmtValorNum)
                    .HasColumnName("pmt_valor_num")
                    .HasColumnType("numeric(6,0)");
            });

            modelBuilder.Entity<Polizas>(entity =>
            {
                entity.HasKey(e => new { e.PolIdPoliza, e.PolIdProyecto });

                entity.ToTable("polizas");

                entity.ForNpgsqlHasComment("Registra las Polizas de los Proyectos.");

                entity.HasIndex(e => e.PolId)
                    .HasName("pol_uk")
                    .IsUnique();

                entity.Property(e => e.PolIdPoliza)
                    .HasColumnName("pol_id_poliza")
                    .HasColumnType("numeric(4,0)");

                entity.Property(e => e.PolIdProyecto)
                    .HasColumnName("pol_id_proyecto")
                    .HasColumnType("numeric(4,0)");

                entity.Property(e => e.PolAlertaActiva)
                    .HasColumnName("pol_alerta_activa")
                    .HasMaxLength(1);

                entity.Property(e => e.PolAnexo)
                    .HasColumnName("pol_anexo")
                    .HasColumnType("numeric(2,0)")
                    .ForNpgsqlHasComment("numero");

                entity.Property(e => e.PolDigitalizado)
                    .HasColumnName("pol_digitalizado")
                    .HasMaxLength(1);

                entity.Property(e => e.PolEsmodificacion)
                    .IsRequired()
                    .HasColumnName("pol_esmodificacion")
                    .HasMaxLength(1);

                entity.Property(e => e.PolFechaexp)
                    .HasColumnName("pol_fechaexp")
                    .HasColumnType("date");

                entity.Property(e => e.PolId)
                    .HasColumnName("pol_id")
                    .HasColumnType("numeric(7,0)");

                entity.Property(e => e.PolIdAseguradora)
                    .HasColumnName("pol_id_aseguradora")
                    .HasColumnType("numeric(4,0)");

                entity.Property(e => e.PolNroPoliza)
                    .IsRequired()
                    .HasColumnName("pol_nro_poliza")
                    .HasMaxLength(20);

                entity.Property(e => e.PolRiesgoamp)
                    .HasColumnName("pol_riesgoamp")
                    .HasColumnType("numeric(2,0)");

                entity.Property(e => e.PolValorcob)
                    .HasColumnName("pol_valorcob")
                    .HasColumnType("numeric(12,2)");

                entity.Property(e => e.PolVigenciafin)
                    .HasColumnName("pol_vigenciafin")
                    .HasColumnType("date");

                entity.Property(e => e.PolVigenciaini)
                    .HasColumnName("pol_vigenciaini")
                    .HasColumnType("date");

                entity.HasOne(d => d.PolIdProyectoNavigation)
                    .WithMany(p => p.Polizas)
                    .HasForeignKey(d => d.PolIdProyecto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pol_pry_fk");

                entity.HasOne(d => d.PolRiesgoampNavigation)
                    .WithMany(p => p.Polizas)
                    .HasForeignKey(d => d.PolRiesgoamp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pol_tpa_fk");
            });

            modelBuilder.Entity<ProductoServicio>(entity =>
            {
                entity.HasKey(e => e.PsIdProductoServicio);

                entity.ToTable("producto_servicio");

                entity.ForNpgsqlHasComment("Registra los Productos para los Servicios.");

                entity.HasIndex(e => e.PsDescripcion)
                    .HasName("ps_uk")
                    .IsUnique();

                entity.Property(e => e.PsIdProductoServicio)
                    .HasColumnName("ps_id_producto_servicio")
                    .HasColumnType("numeric(3,0)");

                entity.Property(e => e.PsDescripcion)
                    .IsRequired()
                    .HasColumnName("ps_descripcion")
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<Proyectos>(entity =>
            {
                entity.HasKey(e => e.PryIdProyecto);

                entity.ToTable("proyectos");

                entity.ForNpgsqlHasComment("Registra los Proyecto o Contratos  de EME ING S.A.");

                entity.Property(e => e.PryIdProyecto)
                    .HasColumnName("pry_id_proyecto")
                    .HasColumnType("numeric(4,0)")
                    .HasDefaultValueSql("nextval('proyectos_pry_id_proyecto_seq'::regclass)")
                    .ForNpgsqlHasComment("Identificador Numerico del Proyecto.");

                entity.Property(e => e.PryActCon)
                    .HasColumnName("pry_act_con")
                    .HasMaxLength(1)
                    .ForNpgsqlHasComment("Acta Consorcial (S/N).");

                entity.Property(e => e.PryAdicionesNumero)
                    .HasColumnName("pry_adiciones_numero")
                    .HasColumnType("numeric(2,0)")
                    .ForNpgsqlHasComment("Numero de Adiciones al Proyecto o Contrato.");

                entity.Property(e => e.PryAdicionesValor)
                    .HasColumnName("pry_adiciones_valor")
                    .HasColumnType("numeric(14,2)")
                    .ForNpgsqlHasComment("Valor de las Adiciones al Proyecto o Contrato.");

                entity.Property(e => e.PryAlertaActiva)
                    .HasColumnName("pry_alerta_activa")
                    .HasMaxLength(1)
                    .ForNpgsqlHasComment("Alerta Activa (S/N)");

                entity.Property(e => e.PryAntiporc)
                    .HasColumnName("pry_antiporc")
                    .HasColumnType("numeric(6,4)")
                    .ForNpgsqlHasComment("Porcentaje de Anticipo.");

                entity.Property(e => e.PryCertObra)
                    .HasColumnName("pry_cert_obra")
                    .HasMaxLength(1)
                    .ForNpgsqlHasComment("Certificacion de Obra del Proyecto o Contrato (S/N).");

                entity.Property(e => e.PryCertTimbre)
                    .HasColumnName("pry_cert_timbre")
                    .HasMaxLength(1)
                    .ForNpgsqlHasComment("Certificaciond de Timbre del Proyecto o Contrato (S/N).");

                entity.Property(e => e.PryCodConta)
                    .HasColumnName("pry_cod_conta")
                    .HasMaxLength(12)
                    .ForNpgsqlHasComment("Codigo relacionado con la Contabilidad.");

                entity.Property(e => e.PryCodRup)
                    .HasColumnName("pry_cod_rup")
                    .HasColumnType("numeric(4,0)")
                    .ForNpgsqlHasComment("Codigo del Contrato en el RUP.");

                entity.Property(e => e.PryCostoteje)
                    .HasColumnName("pry_costoteje")
                    .HasColumnType("numeric(14,2)")
                    .ForNpgsqlHasComment("Costo Total de Ejecucion.");

                entity.Property(e => e.PryDiasTerminacion)
                    .HasColumnName("pry_dias_terminacion")
                    .HasColumnType("numeric(4,0)");

                entity.Property(e => e.PryDigitalizado)
                    .HasColumnName("pry_digitalizado")
                    .HasMaxLength(1)
                    .ForNpgsqlHasComment("Proyecto o Contrato Digitalizado (S/N).");

                entity.Property(e => e.PryEjecutado)
                    .IsRequired()
                    .HasColumnName("pry_ejecutado")
                    .HasMaxLength(1)
                    .ForNpgsqlHasComment("Proyecto Ejecutado (S/N).");

                entity.Property(e => e.PryFechaContrato)
                    .HasColumnName("pry_fecha_contrato")
                    .HasColumnType("date")
                    .ForNpgsqlHasComment("Fecha del Contrato.");

                entity.Property(e => e.PryFechaInicio)
                    .HasColumnName("pry_fecha_inicio")
                    .HasColumnType("date")
                    .ForNpgsqlHasComment("Fecha de Terminacion del Proyecto o Contrato.");

                entity.Property(e => e.PryFechaTerminacion)
                    .HasColumnName("pry_fecha_terminacion")
                    .HasColumnType("date")
                    .ForNpgsqlHasComment("Fecha de Terminacion del Proyecto o Contrato.");

                entity.Property(e => e.PryFgporc)
                    .HasColumnName("pry_fgporc")
                    .HasColumnType("numeric(6,4)")
                    .ForNpgsqlHasComment("Porcentaje del Fondo de Garantia.");

                entity.Property(e => e.PryFormalidad)
                    .IsRequired()
                    .HasColumnName("pry_formalidad")
                    .HasMaxLength(30)
                    .ForNpgsqlHasComment("Tipo de Contrato o Proyecto (Contrato,Oferta Mercantil etc).");

                entity.Property(e => e.PryIdCategoriaContrato)
                    .HasColumnName("pry_id_categoria_contrato")
                    .HasColumnType("numeric(2,0)")
                    .ForNpgsqlHasComment("Identificador Numerico de la Categoria de Contrato.");

                entity.Property(e => e.PryIdCiudad)
                    .HasColumnName("pry_id_ciudad")
                    .HasColumnType("numeric(4,0)")
                    .ForNpgsqlHasComment("Codigo de la Ciudad.");

                entity.Property(e => e.PryIdDepartamento)
                    .HasColumnName("pry_id_departamento")
                    .HasColumnType("numeric(4,0)")
                    .ForNpgsqlHasComment("Codigo del Departamento.");

                entity.Property(e => e.PryIdEmpresa)
                    .HasColumnName("pry_id_empresa")
                    .HasColumnType("numeric(4,0)")
                    .ForNpgsqlHasComment("Identificador Nuemrico de la Empresa Contratista.");

                entity.Property(e => e.PryIdProyPadre)
                    .HasColumnName("pry_id_proy_padre")
                    .HasColumnType("numeric(4,0)")
                    .ForNpgsqlHasComment("Identificador que indica si el Proyecto es Hijo.");

                entity.Property(e => e.PryIdSubcategoriaContrato)
                    .HasColumnName("pry_id_subcategoria_contrato")
                    .HasColumnType("numeric(2,0)")
                    .ForNpgsqlHasComment("Identificador Numerico de la Sub Categoria de Contratos.");

                entity.Property(e => e.PryIvaporc)
                    .HasColumnName("pry_ivaporc")
                    .HasColumnType("numeric(6,4)")
                    .ForNpgsqlHasComment("Porcentaje de IVA que utiliza el Proyecto o Contrato.");

                entity.Property(e => e.PryNombreDelProyecto)
                    .IsRequired()
                    .HasColumnName("pry_nombre_del_proyecto")
                    .HasMaxLength(200)
                    .ForNpgsqlHasComment("Nombre del Proyecto u  Objeto del Contarto.");

                entity.Property(e => e.PryNumeroContrato)
                    .HasColumnName("pry_numero_contrato")
                    .HasMaxLength(50)
                    .ForNpgsqlHasComment("Numero o Codigo del Proyecto o Contarto");

                entity.Property(e => e.PryPlazoFinal)
                    .HasColumnName("pry_plazo_final")
                    .HasColumnType("numeric(8,2)")
                    .ForNpgsqlHasComment("Plazo Final del Ejecucion.");

                entity.Property(e => e.PryReajustesNumero)
                    .HasColumnName("pry_reajustes_numero")
                    .HasColumnType("numeric(2,0)")
                    .ForNpgsqlHasComment("Numero o Cantidad de Reajustes.");

                entity.Property(e => e.PryReajustesValor)
                    .HasColumnName("pry_reajustes_valor")
                    .HasColumnType("numeric(14,2)")
                    .ForNpgsqlHasComment("Valor en Pesos de los Reajuste.");

                entity.Property(e => e.PrySatisfaccion)
                    .HasColumnName("pry_satisfaccion")
                    .HasMaxLength(1)
                    .ForNpgsqlHasComment("Satisfacion del Proyecto o COntrato (S/N).");

                entity.Property(e => e.PryTipoanti)
                    .HasColumnName("pry_tipoanti")
                    .HasMaxLength(14)
                    .ForNpgsqlHasComment("Tipo de Anticipo.");

                entity.Property(e => e.PryUbicacion)
                    .HasColumnName("pry_ubicacion")
                    .HasMaxLength(150)
                    .ForNpgsqlHasComment("Direccion del Proyecto o Contrato.");

                entity.Property(e => e.PryValorAnticipo)
                    .HasColumnName("pry_valor_anticipo")
                    .HasColumnType("numeric(14,2)")
                    .ForNpgsqlHasComment("Valor en Pesos del Anticipo");

                entity.Property(e => e.PryValorFinal)
                    .HasColumnName("pry_valor_final")
                    .HasColumnType("numeric(14,2)")
                    .ForNpgsqlHasComment("Valor final de Proyecto o Contarto.");

                entity.Property(e => e.PryValorFinalConIva)
                    .HasColumnName("pry_valor_final_con_iva")
                    .HasColumnType("numeric(14,2)")
                    .ForNpgsqlHasComment("Valor Final en Pesos.");

                entity.Property(e => e.PryValorInicial)
                    .HasColumnName("pry_valor_inicial")
                    .HasColumnType("numeric(14,2)")
                    .ForNpgsqlHasComment("Valor Inicial del Contrato o Proyecto.");

                entity.Property(e => e.PryValorOfertado)
                    .HasColumnName("pry_valor_ofertado")
                    .HasColumnType("numeric(14,2)")
                    .ForNpgsqlHasComment("Valor Ofertado para el Proyecto o Contrato.");

                entity.HasOne(d => d.PryIdCategoriaContratoNavigation)
                    .WithMany(p => p.Proyectos)
                    .HasForeignKey(d => d.PryIdCategoriaContrato)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pry_cco_fk");

                entity.HasOne(d => d.PryIdEmpresaNavigation)
                    .WithMany(p => p.Proyectos)
                    .HasForeignKey(d => d.PryIdEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pry_emp_fk");

                entity.HasOne(d => d.PryIdSubcategoriaContratoNavigation)
                    .WithMany(p => p.Proyectos)
                    .HasForeignKey(d => d.PryIdSubcategoriaContrato)
                    .HasConstraintName("pry_sco_fk");

                entity.HasOne(d => d.Pry)
                    .WithMany(p => p.Proyectos)
                    .HasForeignKey(d => new { d.PryIdCiudad, d.PryIdDepartamento })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pry_cie_fk");
            });

            modelBuilder.Entity<Retefuente>(entity =>
            {
                entity.HasKey(e => e.RtfIdRetefuente);

                entity.ToTable("retefuente");

                entity.ForNpgsqlHasComment("Registra los Valores de la Retefuente.");

                entity.Property(e => e.RtfIdRetefuente).HasColumnName("rtf_id_retefuente");

                entity.Property(e => e.RtfFechaDesde)
                    .HasColumnName("rtf_fecha_desde")
                    .HasColumnType("date");

                entity.Property(e => e.RtfPorcentaje)
                    .HasColumnName("rtf_porcentaje")
                    .HasColumnType("numeric(4,2)");
            });

            modelBuilder.Entity<Rup>(entity =>
            {
                entity.HasKey(e => e.RupIdRup);

                entity.ToTable("rup");

                entity.ForNpgsqlHasComment("Registra los Proyectos Registrados en el RUP.");

                entity.Property(e => e.RupIdRup)
                    .HasColumnName("rup_id_rup")
                    .HasColumnType("numeric(5,0)")
                    .HasDefaultValueSql("nextval('rup_rup_id_rup_seq'::regclass)")
                    .ForNpgsqlHasComment("Secuencia Autonumerica de Identificacion.");

                entity.Property(e => e.RupClase)
                    .IsRequired()
                    .HasColumnName("rup_clase")
                    .HasMaxLength(4)
                    .ForNpgsqlHasComment("Codigo Clasificatorio de Clase.");

                entity.Property(e => e.RupFamilia)
                    .IsRequired()
                    .HasColumnName("rup_familia")
                    .HasMaxLength(4)
                    .ForNpgsqlHasComment("Codigo Clasificatorio de Familia.");

                entity.Property(e => e.RupIdEmpresa)
                    .HasColumnName("rup_id_empresa")
                    .HasColumnType("numeric(4,0)")
                    .ForNpgsqlHasComment("Identificador de la Empresa.");

                entity.Property(e => e.RupIdProyecto)
                    .HasColumnName("rup_id_proyecto")
                    .HasColumnType("numeric(4,0)")
                    .ForNpgsqlHasComment("Identificador del Proyecto.");

                entity.Property(e => e.RupSegmento)
                    .IsRequired()
                    .HasColumnName("rup_segmento")
                    .HasMaxLength(4)
                    .ForNpgsqlHasComment("Codigo Clasificatorio de Segmento.");

                entity.HasOne(d => d.RupIdEmpresaNavigation)
                    .WithMany(p => p.Rup)
                    .HasForeignKey(d => d.RupIdEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("rup_emp_fk");

                entity.HasOne(d => d.RupIdProyectoNavigation)
                    .WithMany(p => p.Rup)
                    .HasForeignKey(d => d.RupIdProyecto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("rup_pry_fk");
            });

            modelBuilder.Entity<Smmlv>(entity =>
            {
                entity.HasKey(e => e.SmmYear);

                entity.ToTable("smmlv");

                entity.ForNpgsqlHasComment("Registra los SMMLV por año.");

                entity.Property(e => e.SmmYear)
                    .HasColumnName("smm_year")
                    .HasColumnType("numeric(4,0)");

                entity.Property(e => e.SmmValue)
                    .HasColumnName("smm_value")
                    .HasColumnType("numeric(12,4)");
            });

            modelBuilder.Entity<SubcategoriaContratistas>(entity =>
            {
                entity.HasKey(e => e.SucId);

                entity.ToTable("subcategoria_contratistas");

                entity.ForNpgsqlHasComment("Registra la Subcategoria de los Contrtistas.");

                entity.Property(e => e.SucId)
                    .HasColumnName("suc_id")
                    .HasColumnType("numeric(3,0)");

                entity.Property(e => e.SucIdCategoria)
                    .HasColumnName("suc_id_categoria")
                    .HasColumnType("numeric(2,0)");

                entity.Property(e => e.SucSubcategoria)
                    .IsRequired()
                    .HasColumnName("suc_subcategoria")
                    .HasMaxLength(80);

                entity.HasOne(d => d.SucIdCategoriaNavigation)
                    .WithMany(p => p.SubcategoriaContratistas)
                    .HasForeignKey(d => d.SucIdCategoria)
                    .HasConstraintName("suc_cac_fk");
            });

            modelBuilder.Entity<SubcategoriaContratos>(entity =>
            {
                entity.HasKey(e => e.ScoIdSubcategoriaContrato);

                entity.ToTable("subcategoria_contratos");

                entity.ForNpgsqlHasComment("Registra la Subcategoria de los Contratos.");

                entity.Property(e => e.ScoIdSubcategoriaContrato)
                    .HasColumnName("sco_id_subcategoria_contrato")
                    .HasColumnType("numeric(2,0)");

                entity.Property(e => e.ScoDescripcionSubcategoria)
                    .IsRequired()
                    .HasColumnName("sco_descripcion_subcategoria")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Telefonos>(entity =>
            {
                entity.HasKey(e => e.TeoIdTelefono);

                entity.ToTable("telefonos");

                entity.ForNpgsqlHasComment("Registra los Telefonos por empresas.");

                entity.HasIndex(e => new { e.TeoTelefono, e.TeoIdDireccion })
                    .HasName("teo_uk")
                    .IsUnique();

                entity.Property(e => e.TeoIdTelefono)
                    .HasColumnName("teo_id_telefono")
                    .HasColumnType("numeric(4,0)");

                entity.Property(e => e.TeoFax)
                    .HasColumnName("teo_fax")
                    .HasMaxLength(1);

                entity.Property(e => e.TeoIdDireccion)
                    .HasColumnName("teo_id_direccion")
                    .HasColumnType("numeric(4,0)");

                entity.Property(e => e.TeoTelefono)
                    .IsRequired()
                    .HasColumnName("teo_telefono")
                    .HasMaxLength(15);

                entity.HasOne(d => d.TeoIdDireccionNavigation)
                    .WithMany(p => p.Telefonos)
                    .HasForeignKey(d => d.TeoIdDireccion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("teo_dir_fk");
            });

            modelBuilder.Entity<TelfCont>(entity =>
            {
                entity.HasKey(e => e.TctIdTelefono);

                entity.ToTable("telf_cont");

                entity.ForNpgsqlHasComment("Registra los Telefonos de los Contactos.");

                entity.HasIndex(e => new { e.TctIdCoo, e.TctTelefono, e.TctExtension })
                    .HasName("tct_uk")
                    .IsUnique();

                entity.Property(e => e.TctIdTelefono).HasColumnName("tct_id_telefono");

                entity.Property(e => e.TctExtension)
                    .HasColumnName("tct_extension")
                    .HasColumnType("numeric(6,0)");

                entity.Property(e => e.TctIdCoo)
                    .HasColumnName("tct_id_coo")
                    .HasColumnType("numeric(4,0)");

                entity.Property(e => e.TctTelefono)
                    .HasColumnName("tct_telefono")
                    .HasColumnType("numeric(15,0)");

                entity.Property(e => e.TctTipo)
                    .HasColumnName("tct_tipo")
                    .HasMaxLength(30);

                entity.HasOne(d => d.TctIdCooNavigation)
                    .WithMany(p => p.TelfCont)
                    .HasForeignKey(d => d.TctIdCoo)
                    .HasConstraintName("tct_fk");
            });

            modelBuilder.Entity<TipoPoliza>(entity =>
            {
                entity.HasKey(e => e.TpaId);

                entity.ToTable("tipo_poliza");

                entity.ForNpgsqlHasComment("Registra los Tipos de Polizas.");

                entity.HasIndex(e => e.TpaDescripcion)
                    .HasName("tpa_uk")
                    .IsUnique();

                entity.Property(e => e.TpaId)
                    .HasColumnName("tpa_id")
                    .HasColumnType("numeric(2,0)");

                entity.Property(e => e.TpaDescripcion)
                    .IsRequired()
                    .HasColumnName("tpa_descripcion")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Unidades>(entity =>
            {
                entity.HasKey(e => e.UndIdUnidad);

                entity.ToTable("unidades");

                entity.ForNpgsqlHasComment("Registra las Unidades de los Insumos.");

                entity.HasIndex(e => e.UndUnidad)
                    .HasName("und_unidad_uk")
                    .IsUnique();

                entity.Property(e => e.UndIdUnidad).HasColumnName("und_id_unidad");

                entity.Property(e => e.UndDescripcion)
                    .HasColumnName("und_descripcion")
                    .HasMaxLength(100);

                entity.Property(e => e.UndUnidad)
                    .IsRequired()
                    .HasColumnName("und_unidad")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<VehAbastecimiento>(entity =>
            {
                entity.HasKey(e => e.AbtId);

                entity.ToTable("veh_abastecimiento");

                entity.ForNpgsqlHasComment("Registra los Abastecimienos de los Vehiculos.");

                entity.Property(e => e.AbtId)
                    .HasColumnName("abt_id")
                    .HasColumnType("numeric(4,0)");

                entity.Property(e => e.AbtEstacion)
                    .HasColumnName("abt_estacion")
                    .HasColumnType("numeric(4,0)");

                entity.Property(e => e.AbtFecha)
                    .HasColumnName("abt_fecha")
                    .HasColumnType("date");

                entity.Property(e => e.AbtGalones)
                    .HasColumnName("abt_galones")
                    .HasColumnType("numeric(8,2)");

                entity.Property(e => e.AbtKilometraje)
                    .HasColumnName("abt_kilometraje")
                    .HasColumnType("numeric(8,2)");

                entity.Property(e => e.AbtPlaca)
                    .IsRequired()
                    .HasColumnName("abt_placa")
                    .HasMaxLength(8);

                entity.Property(e => e.AbtResponsable)
                    .HasColumnName("abt_responsable")
                    .HasColumnType("numeric(3,0)");

                entity.Property(e => e.AbtTipocombust)
                    .HasColumnName("abt_tipocombust")
                    .HasMaxLength(10);

                entity.Property(e => e.AbtValor)
                    .HasColumnName("abt_valor")
                    .HasColumnType("numeric(6,0)");

                entity.HasOne(d => d.AbtEstacionNavigation)
                    .WithMany(p => p.VehAbastecimiento)
                    .HasForeignKey(d => d.AbtEstacion)
                    .HasConstraintName("abt_emp_fk");

                entity.HasOne(d => d.AbtPlacaNavigation)
                    .WithMany(p => p.VehAbastecimiento)
                    .HasForeignKey(d => d.AbtPlaca)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("abt_veh_fk");

                entity.HasOne(d => d.AbtResponsableNavigation)
                    .WithMany(p => p.VehAbastecimiento)
                    .HasForeignKey(d => d.AbtResponsable)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("abt_cee_fk");
            });

            modelBuilder.Entity<VehDesplazamiento>(entity =>
            {
                entity.HasKey(e => e.DesId);

                entity.ToTable("veh_desplazamiento");

                entity.ForNpgsqlHasComment("Registra los Desplazamientos de los Vehiculos.");

                entity.Property(e => e.DesId)
                    .HasColumnName("des_id")
                    .HasColumnType("numeric(4,0)");

                entity.Property(e => e.DesDestino)
                    .IsRequired()
                    .HasColumnName("des_destino")
                    .HasMaxLength(300);

                entity.Property(e => e.DesKmregreso)
                    .HasColumnName("des_kmregreso")
                    .HasColumnType("numeric(8,2)");

                entity.Property(e => e.DesKmsalida)
                    .HasColumnName("des_kmsalida")
                    .HasColumnType("numeric(8,2)");

                entity.Property(e => e.DesObservacion)
                    .HasColumnName("des_observacion")
                    .HasColumnType("character varying");

                entity.Property(e => e.DesPlaca)
                    .IsRequired()
                    .HasColumnName("des_placa")
                    .HasMaxLength(8);

                entity.Property(e => e.DesProyecto)
                    .HasColumnName("des_proyecto")
                    .HasColumnType("numeric(4,0)");

                entity.Property(e => e.DesRegreso).HasColumnName("des_regreso");

                entity.Property(e => e.DesResponsable)
                    .HasColumnName("des_responsable")
                    .HasColumnType("numeric(3,0)");

                entity.Property(e => e.DesSalida).HasColumnName("des_salida");

                entity.HasOne(d => d.DesPlacaNavigation)
                    .WithMany(p => p.VehDesplazamiento)
                    .HasForeignKey(d => d.DesPlaca)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("des_veh_fk");

                entity.HasOne(d => d.DesProyectoNavigation)
                    .WithMany(p => p.VehDesplazamiento)
                    .HasForeignKey(d => d.DesProyecto)
                    .HasConstraintName("des_pry_fk");

                entity.HasOne(d => d.DesResponsableNavigation)
                    .WithMany(p => p.VehDesplazamiento)
                    .HasForeignKey(d => d.DesResponsable)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("des_cee_fk");
            });

            modelBuilder.Entity<VehDocumentos>(entity =>
            {
                entity.HasKey(e => e.VdtIddocumento);

                entity.ToTable("veh_documentos");

                entity.ForNpgsqlHasComment("Registra los Documentos de los Vehiculos.");

                entity.Property(e => e.VdtIddocumento)
                    .HasColumnName("vdt_iddocumento")
                    .HasColumnType("numeric(4,0)");

                entity.Property(e => e.VdtExpedidoPor)
                    .HasColumnName("vdt_expedido_por")
                    .HasColumnType("numeric(4,0)");

                entity.Property(e => e.VdtFechaExpedicion)
                    .HasColumnName("vdt_fecha_expedicion")
                    .HasColumnType("date");

                entity.Property(e => e.VdtFechaVencimiento)
                    .HasColumnName("vdt_fecha_vencimiento")
                    .HasColumnType("date");

                entity.Property(e => e.VdtIddocExterno)
                    .IsRequired()
                    .HasColumnName("vdt_iddoc_externo")
                    .HasMaxLength(20);

                entity.Property(e => e.VdtObservaciones)
                    .HasColumnName("vdt_observaciones")
                    .HasMaxLength(50);

                entity.Property(e => e.VdtPlaca)
                    .IsRequired()
                    .HasColumnName("vdt_placa")
                    .HasMaxLength(8);

                entity.Property(e => e.VdtResponsable)
                    .HasColumnName("vdt_responsable")
                    .HasColumnType("numeric(3,0)");

                entity.Property(e => e.VdtTipodoc)
                    .IsRequired()
                    .HasColumnName("vdt_tipodoc")
                    .HasMaxLength(10);

                entity.Property(e => e.VdtValor)
                    .HasColumnName("vdt_valor")
                    .HasColumnType("numeric(8,0)");

                entity.HasOne(d => d.VdtExpedidoPorNavigation)
                    .WithMany(p => p.VehDocumentos)
                    .HasForeignKey(d => d.VdtExpedidoPor)
                    .HasConstraintName("vdt_emp_fk");

                entity.HasOne(d => d.VdtPlacaNavigation)
                    .WithMany(p => p.VehDocumentos)
                    .HasForeignKey(d => d.VdtPlaca)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("vdt_veh_fk");

                entity.HasOne(d => d.VdtResponsableNavigation)
                    .WithMany(p => p.VehDocumentos)
                    .HasForeignKey(d => d.VdtResponsable)
                    .HasConstraintName("vdt_cee_fk");
            });

            modelBuilder.Entity<Vehiculos>(entity =>
            {
                entity.HasKey(e => e.VehPlaca);

                entity.ToTable("vehiculos");

                entity.ForNpgsqlHasComment("Registra los Vehiculos de la empresa.");

                entity.HasIndex(e => e.VehNrochasis)
                    .HasName("veh_uk")
                    .IsUnique();

                entity.HasIndex(e => e.VehNroserie)
                    .HasName("veh_uk1")
                    .IsUnique();

                entity.Property(e => e.VehPlaca)
                    .HasColumnName("veh_placa")
                    .HasMaxLength(8)
                    .ValueGeneratedNever();

                entity.Property(e => e.VehActivo)
                    .IsRequired()
                    .HasColumnName("veh_activo")
                    .HasMaxLength(1);

                entity.Property(e => e.VehAnno)
                    .HasColumnName("veh_anno")
                    .HasColumnType("numeric(4,0)");

                entity.Property(e => e.VehCambioAceite)
                    .HasColumnName("veh_cambio_aceite")
                    .HasMaxLength(50);

                entity.Property(e => e.VehCilindraje)
                    .IsRequired()
                    .HasColumnName("veh_cilindraje")
                    .HasMaxLength(30);

                entity.Property(e => e.VehCmt)
                    .HasColumnName("veh_cmt")
                    .HasColumnType("numeric(5,3)")
                    .ForNpgsqlHasComment("Control maximo de tanquoe");

                entity.Property(e => e.VehColor)
                    .IsRequired()
                    .HasColumnName("veh_color")
                    .HasMaxLength(15);

                entity.Property(e => e.VehFechacompra)
                    .HasColumnName("veh_fechacompra")
                    .HasColumnType("date");

                entity.Property(e => e.VehIdCiudad)
                    .HasColumnName("veh_id_ciudad")
                    .HasColumnType("numeric(4,0)");

                entity.Property(e => e.VehIdDepartamento)
                    .HasColumnName("veh_id_departamento")
                    .HasColumnType("numeric(4,0)");

                entity.Property(e => e.VehMarca)
                    .IsRequired()
                    .HasColumnName("veh_marca")
                    .HasMaxLength(30);

                entity.Property(e => e.VehModelo)
                    .IsRequired()
                    .HasColumnName("veh_modelo")
                    .HasMaxLength(30);

                entity.Property(e => e.VehNrochasis)
                    .IsRequired()
                    .HasColumnName("veh_nrochasis")
                    .HasMaxLength(20);

                entity.Property(e => e.VehNroserie)
                    .IsRequired()
                    .HasColumnName("veh_nroserie")
                    .HasMaxLength(20);

                entity.Property(e => e.VehPropietario)
                    .IsRequired()
                    .HasColumnName("veh_propietario")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Veh)
                    .WithMany(p => p.Vehiculos)
                    .HasForeignKey(d => new { d.VehIdCiudad, d.VehIdDepartamento })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("veh_cie_fk");
            });

            modelBuilder.Entity<VehMantenimientos>(entity =>
            {
                entity.HasKey(e => e.MtsId);

                entity.ToTable("veh_mantenimientos");

                entity.ForNpgsqlHasComment("Registra los Mantenimientos de los Vehiculos.");

                entity.Property(e => e.MtsId)
                    .HasColumnName("mts_id")
                    .HasColumnType("numeric(4,0)");

                entity.Property(e => e.MtsDigi)
                    .IsRequired()
                    .HasColumnName("mts_digi")
                    .HasMaxLength(1)
                    .HasDefaultValueSql("'N'::character varying");

                entity.Property(e => e.MtsFactura)
                    .HasColumnName("mts_factura")
                    .HasMaxLength(12);

                entity.Property(e => e.MtsFecha)
                    .HasColumnName("mts_fecha")
                    .HasColumnType("date");

                entity.Property(e => e.MtsKilometraje)
                    .HasColumnName("mts_kilometraje")
                    .HasColumnType("numeric(8,2)");

                entity.Property(e => e.MtsObservaciones)
                    .HasColumnName("mts_observaciones")
                    .HasMaxLength(200);

                entity.Property(e => e.MtsPlaca)
                    .IsRequired()
                    .HasColumnName("mts_placa")
                    .HasMaxLength(8);

                entity.Property(e => e.MtsResponsable)
                    .HasColumnName("mts_responsable")
                    .HasColumnType("numeric(3,0)");

                entity.Property(e => e.MtsTaller)
                    .HasColumnName("mts_taller")
                    .HasColumnType("numeric(4,0)");

                entity.Property(e => e.MtsValor)
                    .HasColumnName("mts_valor")
                    .HasColumnType("numeric(8,0)");

                entity.HasOne(d => d.MtsPlacaNavigation)
                    .WithMany(p => p.VehMantenimientos)
                    .HasForeignKey(d => d.MtsPlaca)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("mts_veh_fk");

                entity.HasOne(d => d.MtsResponsableNavigation)
                    .WithMany(p => p.VehMantenimientos)
                    .HasForeignKey(d => d.MtsResponsable)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("mts_cee_fk");

                entity.HasOne(d => d.MtsTallerNavigation)
                    .WithMany(p => p.VehMantenimientos)
                    .HasForeignKey(d => d.MtsTaller)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("mts_emp_fk");
            });

            modelBuilder.Entity<VehmantVehtpm>(entity =>
            {
                entity.HasKey(e => new { e.VvmIdMant, e.VvmIdTipoMant });

                entity.ToTable("vehmant_vehtpm");

                entity.ForNpgsqlHasComment("Registra los Mantenimientos por Vehiculos.");

                entity.Property(e => e.VvmIdMant)
                    .HasColumnName("vvm_id_mant")
                    .HasColumnType("numeric(4,0)");

                entity.Property(e => e.VvmIdTipoMant)
                    .HasColumnName("vvm_id_tipo_mant")
                    .HasColumnType("numeric(3,0)");

                entity.HasOne(d => d.VvmIdMantNavigation)
                    .WithMany(p => p.VehmantVehtpm)
                    .HasForeignKey(d => d.VvmIdMant)
                    .HasConstraintName("vvm_mts_fk");

                entity.HasOne(d => d.VvmIdTipoMantNavigation)
                    .WithMany(p => p.VehmantVehtpm)
                    .HasForeignKey(d => d.VvmIdTipoMant)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("vvm_vmt_fk");
            });

            modelBuilder.Entity<VehTipomant>(entity =>
            {
                entity.HasKey(e => e.VmtTipomant);

                entity.ToTable("veh_tipomant");

                entity.ForNpgsqlHasComment("Registra los Tipos de Mantenimientos de los Vehiculos.");

                entity.HasIndex(e => e.VmtDescripcion)
                    .HasName("vmy_uk")
                    .IsUnique();

                entity.Property(e => e.VmtTipomant)
                    .HasColumnName("vmt_tipomant")
                    .HasColumnType("numeric(3,0)");

                entity.Property(e => e.VmtDescripcion)
                    .IsRequired()
                    .HasColumnName("vmt_descripcion")
                    .HasMaxLength(50);
            });

            modelBuilder.HasSequence("contratos_proveedor_cpv_id_cpv_seq").StartsAt(3276);

            modelBuilder.HasSequence("permisos_def_cat_usu_pdu_id_seq");

            modelBuilder.HasSequence("proyectos_pry_id_proyecto_seq").StartsAt(1049);

            modelBuilder.HasSequence("rup_rup_id_rup_seq").StartsAt(1197);

            modelBuilder.HasSequence("veh_mantenimientos_mts_id_seq").StartsAt(655);
        }
    }
}
