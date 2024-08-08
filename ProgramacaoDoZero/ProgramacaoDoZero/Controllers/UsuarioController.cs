
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Security;
using ProgramacaoDoZero.Models;
using ProgramacaoDoZero.Service;


namespace ProgramacaoDoZero.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IConfiguration  _configuration;
        public UsuarioController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPost]
        [Route("login")]

        public LoginResult Login(Models.LoginRequest request)

        {
            var result = new LoginResult();

            if (request == null)
            {
                result.sucesso = false;
                result.mensagem = "Os dados estão nulos";
            }
            else if (request.email == null)
            {
                result.sucesso = false;
                result.mensagem = "E-mail obrigatório.";
            }
            else if (request.senha == null)
            {
                result.sucesso = false;
                result.mensagem = "Senha obrigatória.";
            }
         else
            {
                var connectionString = _configuration.GetConnectionString("programacao_do_zero_db");
                var usuarioService = new UsuarioService(connectionString);

                result = usuarioService.Login(request.email, request.senha);
            }

            return result;

            }

        [Route("cadastro")]
        [HttpPost]
        public IActionResult Cadastro(CadastroRequest request)
        {
            var result = new CadastroResult();

            if (request == null ||
                string.IsNullOrEmpty(request.nome) ||
                string.IsNullOrEmpty(request.sobrenome) ||
                string.IsNullOrEmpty(request.telefone) ||
                string.IsNullOrEmpty(request.genero) ||
                string.IsNullOrEmpty(request.email) ||
                string.IsNullOrEmpty(request.senha))
            {
                result.sucesso = false;
                result.mensagem = "Todos os campos são obrigatórios";
            }
            else
            {
                var connectionString = _configuration.GetConnectionString("programacao_do_zero_db");
                var usuarioService = new UsuarioService(connectionString);

                result = usuarioService.Cadastro(request.nome, request.sobrenome, request.telefone, request.email,
                    request.genero, request.senha);
            }

            return Ok(result);
        }

        [Route("esqueceuSenha")]
        [HttpPost]
        public  EsqueceuSenhaResult EsqueceuSenha(EsqueceuSenhaRequest request)
        {
            var result = new EsqueceuSenhaResult();

            if (request == null ||
                string.IsNullOrEmpty(request.email))
            {
                result.mensagem = "Email obrigatório";
                return result;
            }

            var connectionString = _configuration.GetConnectionString("programacao_do_zero_db");

            result = new UsuarioService(connectionString).esqueceuSenha(request.email);

            return result;
        }

          
        

        [Route("obterUsuario")]
        [HttpGet]
        public ObterUsuarioResult ObterUsuario(Guid usuarioGuid)
        {
            var result = new ObterUsuarioResult();

            if (usuarioGuid == Guid.Empty)
            {
                result.mensagem = "Guid vazio";
            }
            else
            {
                var connectionString = _configuration.GetConnectionString("programacao_do_zero_db");

                var usuario = new UsuarioService(connectionString).ObterUsuario(usuarioGuid);

                if (usuario == null)
                {
                    result.mensagem = "Usuario não existe";
                }
                else
                {
                    result.sucesso = true;
                    result.nome = usuario.nome;
                }

            }
            return result;
        }

    }
}


