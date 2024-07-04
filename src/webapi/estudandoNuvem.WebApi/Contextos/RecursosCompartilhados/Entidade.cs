using Flunt.Notifications;

namespace estudandoNuvem.WebApi.Contextos.RecursosCompartilhados
{
	public abstract class Entidade 
	{
		public Entidade()
		{
			Id = Guid.NewGuid();
		}

		public Guid Id { get; protected set; }
	}
}