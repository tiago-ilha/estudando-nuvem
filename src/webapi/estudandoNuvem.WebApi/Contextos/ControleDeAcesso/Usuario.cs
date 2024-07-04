using estudandoNuvem.WebApi.Contextos.RecursosCompartilhados;
using Flunt.Validations;

namespace estudandoNuvem.WebApi.Contextos.ControleDeAcesso
{
	public class Usuario : Entidade
	{
		protected Usuario() : base() { }

		public Usuario(string login, string senha, string confirmarSenha) : this()
		{
			Login = login;
			Senha = senha;
			ConfirmarSenha = confirmarSenha;
		}

		public string Login { get; set; }
		public string Senha { get; set; }
		public string ConfirmarSenha { get; set; }

		public static Usuario Criar(string login, string senha, string confirmarSenha)
		{
			return new Usuario(login, senha, confirmarSenha);
		}

		internal void Atualizar(string login, string senha, string confirmarSenha)
		{
			Login = login;
			Senha = senha;
			ConfirmarSenha = confirmarSenha;
		}
	}
}