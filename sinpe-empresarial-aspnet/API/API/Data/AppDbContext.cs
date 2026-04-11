using API.Model;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        //Establcemos los modelos de datos.

        //      CREATE TABLE `u484426513_pac325`.`Producto` (
        //`Id` INT NOT NULL AUTO_INCREMENT,
        //`Nombre` VARCHAR(45) NOT NULL,
        //`Descripcion` VARCHAR(45) NOT NULL,
        //`Precio` DECIMAL NOT NULL,
        //`Cantidad` INT NOT NULL,
        //PRIMARY KEY(`Id`));
        public DbSet<ProductoModel> Producto { get; set; }

        public DbSet<ComerciosModel> Comercios { get; set; }

        public DbSet<CajasModel> Cajas { get; set; }
        public DbSet<SinpeModel> Sinpe { get; set; }
        public DbSet<BitacoraEventosModel> BitacoraEventos { get; set; }

    }
}
