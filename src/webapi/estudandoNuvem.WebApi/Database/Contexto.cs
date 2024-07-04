using estudandoNuvem.WebApi.Contextos.ControleDeAcesso;
using Microsoft.EntityFrameworkCore;

namespace estudandoNuvem.WebApi.Database
{
	public class Contexto : DbContext
	{
		public Contexto(DbContextOptions<Contexto> options) : base(options) { }

		public DbSet<Usuario> Usuarios { get; set; }

	}
}
