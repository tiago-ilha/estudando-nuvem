using estudandoNuvem.WebApi.Contextos.ControleDeAcesso;
using estudandoNuvem.WebApi.Contextos.ControleDeAcesso.Comandos;
using estudandoNuvem.WebApi.Database;
using Microsoft.AspNetCore.Mvc;

namespace estudandoNuvem.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AutenticarController : ControllerBase
	{
		private readonly Contexto _contexto;

		public AutenticarController(Contexto contexto)
		{
			_contexto = contexto;
		}

		[HttpPost]
		public IActionResult Login(LoginComando comando)
		{
			var resultado = (from usuario in _contexto.Usuarios
							 where
								usuario.Login.Trim() == comando.Login.Trim() &&
								usuario.Senha.Trim() == comando.Senha.Trim()
							 select new
							 {
								 Login = usuario.Login,
							 }).FirstOrDefault();

			if (resultado == null)
			{
				return NotFound();
			}

			return Ok(resultado);
		}		

		[HttpPost]
		[Route("recuperar-senha")]
		public IActionResult RecuperarSenha()
		{
			return Ok();
		}

		[HttpPost("deslogar")]
		public IActionResult Deslogar()
		{
			return Ok();
		}
	}
}

