using MySql.Data.MySqlClient;
using Mysqlx.Connection;
using ProgramacaoDoZero.Entites;

namespace ProgramacaoDoZero.Repositories
{
    public class UsuarioRepository
    {
        private string _connectionString;
        private usuario usuario;

        public UsuarioRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int Inserir(Usuario usuario)
        {
            var cnn = new MySqlConnection(_connectionString);
            var cmd = new MySqlCommand();
            cmd.Connection = cnn;
            cmd.CommandText = " INSERT INTO usuario\r\n(nome, sobrenome, telefone, email, genero, senha, usuarioGuid) \r\nVALUES \r\n( @nome,  @sobrenome,  @telefone,  @email,@genero, @senha, @usuarioGuid)";

            cmd.Parameters.AddWithValue("nome", usuario.nome);
            cmd.Parameters.AddWithValue("sobrenome", usuario.sobrenome);
            cmd.Parameters.AddWithValue("telefone", usuario.telefone);
            cmd.Parameters.AddWithValue("email", usuario.email);
            cmd.Parameters.AddWithValue("genero", usuario.genero);
            cmd.Parameters.AddWithValue("senha", usuario.senha);
            cmd.Parameters.AddWithValue("usuarioGuid", usuario.usuarioGuid);


            cnn.Open();

             var affectedRows = cmd.ExecuteNonQuery();

            cnn.Close();

            return affectedRows;
        }

        public Usuario ObterUsuarioPorEmail(string email)
        {
            MySqlConnection cnn = new MySqlConnection(_connectionString);

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "SELECT * FROM usuario WHERE email = @email";
            cmd.Parameters.AddWithValue("email", email);
            cnn.Open();
            var reader = cmd.ExecuteReader();
            Usuario usuario = null;

            if (reader.Read())
            {
                usuario = new Usuario();
                usuario.nome = reader["nome"].ToString();
                usuario.sobrenome = reader["sobrenome"].ToString();
                usuario.telefone = reader["telefone"].ToString();
                usuario.email = reader["email"].ToString();
                usuario.genero = reader["genero"].ToString();
                usuario.senha = reader["senha"].ToString();

                var usuarioGuid = reader["usuarioGuid"].ToString();

                usuario.usuarioGuid = new Guid(usuarioGuid);
            }

            cnn.Close();

            return usuario;
        }

        public Usuario ObterPorGuid(Guid usuarioGuid)
        {
            Usuario usuario = null;

            

                var cnn = new MySqlConnection(_connectionString);
                var cmd = new MySqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "SELECT * FROM usuario WHERE usuarioGuid = @usuarioGuid";

                cmd.Parameters.AddWithValue("usuarioGuid", usuarioGuid);

                cnn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    usuario = new Usuario();
                    usuario.nome = reader["nome"].ToString();
                    usuario.sobrenome = reader["sobrenome"].ToString();
                    usuario.telefone = reader["telefone"].ToString();
                    usuario.email = reader["email"].ToString();
                    usuario.genero = reader["genero"].ToString();
                    usuario.senha = reader["senha"].ToString();

                    var guid = reader["usuarioGuid"].ToString();

                    usuario.usuarioGuid = new Guid(guid);
                }
                cnn.Close();


                return usuario;

            }

        }
    }