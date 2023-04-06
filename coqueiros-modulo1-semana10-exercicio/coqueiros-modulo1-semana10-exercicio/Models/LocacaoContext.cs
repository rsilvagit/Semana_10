using Microsoft.EntityFrameworkCore;


namespace coqueiros_modulo1_semana10_exercicio.Models
{
    public class LocacaoContext : DbContext
    {
        public DbSet<CarroModel> Carro { get; set; }
        public DbSet<MarcaModel> Marca { get; set; }  
        public LocacaoContext(DbContextOptions<LocacaoContext> options) : base(options)
        {}
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            base.OnConfiguring(options);
        }

    }
}
