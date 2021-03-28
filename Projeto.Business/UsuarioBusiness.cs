using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Entities; // Entidades
using Projeto.Data.Repositories; // Repositório de dados

namespace Projeto.Business
{
    public class UsuarioBusiness
    {
        //atributo..
        private readonly UsuarioRepository repository;
        //construtor
        public UsuarioBusiness()
        {
            repository = new UsuarioRepository();
        }
        public void Cadastrar(Usuario usuario)
        {
            repository.Insert(usuario);
        }
        public void Atualizar(Usuario usuario)
        {
            repository.Update(usuario);
        }

        public void Excluir(int id)
        {
            repository.Delete(id);
        }
        public List<Usuario> ObterTodos()
        {
            return repository.SelectAll();
        }

        public Usuario ObterPorId(int id)
        {
            return repository.SelectById(id);
        }

    }
}
