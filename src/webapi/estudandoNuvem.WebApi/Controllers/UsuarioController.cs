using estudandoNuvem.WebApi.Contextos.ControleDeAcesso;
using estudandoNuvem.WebApi.Contextos.ControleDeAcesso.Comandos;
using estudandoNuvem.WebApi.Database;
using Microsoft.AspNetCore.Mvc;

namespace estudandoNuvem.WebApi.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class UsuarioController : ControllerBase
	{
		private readonly Contexto _contexto;

        public UsuarioController(Contexto contexto)
        {
            _contexto = contexto;
        }

        [HttpPost]
		public IActionResult Registrar(RegistrarUsuarioComando comando)
		{
			var usuario = Usuario.Criar(comando.Login,
										comando.Senha,
										comando.ConfirmarSenha);

			_contexto.Usuarios.Add(usuario);
			_contexto.SaveChanges();

			return Ok();
		}

		[HttpPut("{id:guid}")]
		public IActionResult Atualizar(Guid id, AtualizarUsuarioComando comando)
		{
			var usuario = _contexto.Usuarios.FirstOrDefault(x => x.Id == id);

			if (usuario == null)
			{
				return NotFound();
			}

			usuario.Atualizar(comando.Login, comando.Senha, comando.ConfirmarSenha);

			_contexto.SaveChanges();

			return Ok();
		}
	}
}
