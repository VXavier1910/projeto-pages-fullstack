using ProgramacaoDoZero.Common;
using ProgramacaoDoZero.Entites;
using ProgramacaoDoZero.Models;
using ProgramacaoDoZero.Repositories;

namespace ProgramacaoDoZero.Service
{
    public class UsuarioService
    {
        private string _connectionString;
      
        public UsuarioService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public LoginResult Login(string email, string senha)
        {
            var result = new LoginResult();

            var usuarioExistente = new UsuarioRepository(_connectionString).ObterUsuarioPorEmail(email);



            if (usuarioExistente != null)
            {
                if (usuarioExistente.senha == senha)
                {
                    //faz login 

                    result.sucesso = true;
                    result.usuarioGuid = usuarioExistente.usuarioGuid;
                }

            }

            else
            {
                result.sucesso = false;
                result.mensagem = "Usuario ou Senha inválidos";
            }



            return result;
        }

        public CadastroResult Cadastro(string nome, string sobrenome, string telefone, string email, string genero, string senha)
        {
            var result = new CadastroResult();

            var repositorio = new UsuarioRepository(_connectionString);
            var usuario = repositorio.ObterUsuarioPorEmail(email);

            if (usuario != null)
            {
                //usuario já existe

                result.sucesso = false;
                result.mensagem = "Usuario já existe no sistema";
            }

            else
            {
                //não existe 
                usuario = new Usuario();

                usuario.nome = nome;
                usuario.sobrenome = sobrenome;
                usuario.telefone = telefone;
                usuario.email = email;
                usuario.genero = genero;
                usuario.senha = senha;
                usuario.usuarioGuid = Guid.NewGuid();


                var affectedRows = repositorio.Inserir(usuario);



                if (affectedRows > 0)
                {
                    //inseriu com sucesso
                    result.sucesso = true;
                    result.usuarioGuid = usuario.usuarioGuid;
                }

                else
                {
                    //erro ao inserir

                    result.sucesso = false;
                    result.mensagem = "Erro ao inserir usuário, tente novamente.";
                }
            }

            return result;
        }

        public EsqueceuSenhaResult esqueceuSenha(string email)
        {
            var result = new EsqueceuSenhaResult();

            var usuarioRepository = new UsuarioRepository(_connectionString);

            var usuario = usuarioRepository.ObterUsuarioPorEmail(email);

            if (usuario == null)
            {
                //usuario NÃO EXISTE

                result.mensagem = "Usuário inexistente";
            }

            else
            {
                //usuario existe

                var assunto = "Recuperação de Senha";

                var corpo = "Sua senha é " + usuario.senha;

                var emailSender = new EmailSender();

                emailSender.EnviarEmail(assunto, corpo, usuario.email);

                result.sucesso = true;
            }

            return result;
        }

        public Usuario ObterUsuario(Guid usuarioGuid)
        {
            
           var usuario = new UsuarioRepository(_connectionString).ObterPorGuid(usuarioGuid);

            return usuario;
        }

        
    }
}


