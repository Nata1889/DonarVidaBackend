using Microsoft.EntityFrameworkCore;
using BackendFinal.Models;

namespace BackendFinal.DataContext
{
    public class BackendContext : DbContext
    {
        public BackendContext(DbContextOptions<BackendContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            string cadenaConexion = configuration.GetConnectionString("mysqlremoto");

            //optionsBuilder.UseSqlServer(cadenaConexion) ;
            optionsBuilder.UseMySql(cadenaConexion,
                                    ServerVersion.AutoDetect(cadenaConexion));
        }

        public virtual DbSet<Donante> Donantes { get; set; }
        public virtual DbSet<Donacion> Donaciones { get; set; }
        public virtual DbSet<CentroDonacion> CentrosDonacion { get; set; }
        public virtual DbSet<ProgramaDonacion> ProgramasDonacion { get; set; }

        /*
        ///ESTE CÓDIGO LO DEBEN AGREGAR A LA CLASE DBCONTEXT DESPUÉS DE HABER CREADO EL MODELO MATERIA
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
        */
    }
}
