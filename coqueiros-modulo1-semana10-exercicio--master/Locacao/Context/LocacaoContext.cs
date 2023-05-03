using Locacao.Model;
using Microsoft.EntityFrameworkCore;

namespace Locacao.Context
{
    public class LocacaoContext:DbContext
    {
        public DbSet <CarroModel> Carros { get; set; }
        public DbSet<MarcaModel> Marcas { get; set; }

        public LocacaoContext() { }
        public LocacaoContext(DbContextOptions<LocacaoContext> optionsBuider):base(optionsBuider)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
