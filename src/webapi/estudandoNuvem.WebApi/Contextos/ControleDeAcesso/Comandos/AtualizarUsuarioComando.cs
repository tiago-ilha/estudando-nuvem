using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace estudandoNuvem.WebApi.Contextos.ControleDeAcesso.Comandos
{
    public class AtualizarUsuarioComando
    {
        public string Login { get; set; }
		public string Senha { get; set; }
		public string ConfirmarSenha { get; set; }
    }
}