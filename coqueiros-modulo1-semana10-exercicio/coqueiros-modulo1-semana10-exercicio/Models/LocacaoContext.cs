using Microsoft.EntityFrameworkCore;

namespace coqueiros_modulo1_semana10_exercicio.Models
{
    public class LocacaoContext : DbContext
    {

        public LocacaoContext(DbContextOptions<LocacaoContext> options) : base(options)
        {}
        public DbSet<CarroModel> Carro { get; set; }
        public DbSet<MarcaModel> Marca { get; set; }  
    }
}
