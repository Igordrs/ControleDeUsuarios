using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration; //importando -ConnectionString
using System.Data.SqlClient; //importando - Acesso ao SQL Server
using Dapper; //importando - framework para mapeamento de banco de dados
using Projeto.Entities; //importando - Entidades

namespace Projeto.Data.Repositories
{
    public class UsuarioRepository
    {
        //atributo
        private readonly string connectionString;

        //construtor -> ctor + 2x[tab]
        public UsuarioRepository()
        {
            //inicializar o atributo readonly
            connectionString = ConfigurationManager
            .ConnectionStrings["BancoDados"].ConnectionString;
        }

        //método para inserir um usuário na base
        public void Insert(Usuario usuario)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                var query = "insert into Usuario(Nome, Email, DataCadastro) "
                          + "values(@Nome, @Email, getDate())";
                //executando...
                conn.Execute(query, usuario);
            }
        }

        //método para atualizar um usuário na base
        public void Update(Usuario usuario)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                var query = "update Usuario set Nome = @Nome, Email = @Email "
                          + "where IdUsuario = @IdUsuario";
                //executando...
                conn.Execute(query, usuario);
            }
        }

        //método para excluir um usuário na base
        public void Delete(int id)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                var query = "delete from Usuario where IdUsuario = @IdUsuario";
                //executando...
                conn.Execute(query, new { IdUsuario = id });
            }
        }

        //método para consultar todos os usuários
        public List<Usuario> SelectAll()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                var query = "select * from Usuario";
                //executando..
                return conn.Query<Usuario>(query).ToList();
            }
        }

        //método para consultar 1 usuário pelo id
        public Usuario SelectById(int id)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                var query = "select * from Usuario where IdUsuario = @IdUsuario";
                
                //SingleOrDefault -> retorna apenas 1 registro e se nenhum for
                //encontrado retorna null. Se a consulta obtiver
                //mais de 1 registro o SingleOrDefault lança uma exceção
                
                return conn.QuerySingleOrDefault<Usuario>(query, new { IdUsuario = id });
            }
        }

    }
}
