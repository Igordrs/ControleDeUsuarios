using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Projeto.Services.Models;
using Projeto.Services.Validations;
using Projeto.Entities;
using Projeto.Business;
using AutoMapper;


namespace Projeto.Services.Controllers
{
    [RoutePrefix("api/usuario")]
    public class UsuarioController : ApiController
    {
        //atributo
        private readonly UsuarioBusiness usuarioBusiness;

        public UsuarioController()
        {
            usuarioBusiness = new UsuarioBusiness();
        }
        
        [HttpPost]
        [Route("cadastrar")] //ENDPOINT: api/usuario/cadastrar
        [ResponseType(typeof(string))] //conteúdo retornado pelo serviço
        public HttpResponseMessage Cadastrar(UsuarioCadastroViewModel model)
        {
            //verificar se os dados da model estão corretos
            if (ModelState.IsValid)
            {
                try
                {
                    Usuario usuario = Mapper.Map<Usuario>(model);
                    usuarioBusiness.Cadastrar(usuario);

                    //retornar um status de sucesso...
                    return Request.CreateResponse(HttpStatusCode.OK, $"Usuário {model.Nome} cadastrado com sucesso.");
                }
                catch (Exception e)
                {
                    //retorna um status de erro...
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
                }
            }
            else
            {
                //retornar um status de erro...
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelStationValidation.GetErrors(ModelState));
            }
        }

        [HttpPut]
        [Route("atualizar")] //ENDPOINT: api/usuario/atualizar
        [ResponseType(typeof(string))] //conteúdo retornado pelo serviço
        public HttpResponseMessage Atualizar(UsuarioEdicaoViewModel model)
        {
            //verificar se os dados da model estão corretos
            if (ModelState.IsValid)
            {
                try
                {
                    Usuario usuario = Mapper.Map<Usuario>(model);
                    usuarioBusiness.Atualizar(usuario);

                    //retornar um status de sucesso...
                    return Request.CreateResponse(HttpStatusCode.OK,
                    $"Usuário {model.Nome} atualizado com sucesso.");
                }
                catch (Exception e)
                {
                    //retorna um status de erro...
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
                }
                
            }
            else
            {
                //retornar um status de erro..
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelStationValidation.GetErrors(ModelState));
            }
        }

        [HttpDelete]
        [Route("excluir")] //api/usuario/excluir
        [ResponseType(typeof(string))]
        public HttpResponseMessage Excluir(int idUsuario)
        {
            try
            {
                Usuario usuario = usuarioBusiness.ObterPorId(idUsuario);

                //Verificar se usuário foi encontrado
                if (usuario != null)
                {
                    usuarioBusiness.Excluir(idUsuario);
                    //retornar um status de sucesso...
                    return Request.CreateResponse(HttpStatusCode.OK, "Usuário excluído com sucesso.");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Função não encontrado.");
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }

        }

        [HttpGet]
        [Route("obtertodos")] //api/usuario/obtertodos
        [ResponseType(typeof(List<UsuarioConsultaViewModel>))]
        public HttpResponseMessage ObterTodos()
        {
            try
            {
                //executar a consulta de usuários na base
                List<Usuario> lista = usuarioBusiness.ObterTodos();
                //converter para UsuarioConsultaViewModel
                List<UsuarioConsultaViewModel> model =
                Mapper.Map<List<UsuarioConsultaViewModel>>(lista);
                //retornar um status de sucesso..
                return Request.CreateResponse(HttpStatusCode.OK, model);
            }
            catch (Exception e)
            {
                return Request.CreateResponse
                (HttpStatusCode.InternalServerError, e.Message);
            }
        }
        
        [HttpGet]
        [Route("obter")] //api/usuario/obter
        [ResponseType(typeof(UsuarioConsultaViewModel))]
        public HttpResponseMessage Obter(int idUsuario)
        {
            try
            {
                Usuario usuario = usuarioBusiness.ObterPorId(idUsuario);
                if (usuario != null)
                {
                    UsuarioConsultaViewModel model =
                    Mapper.Map<UsuarioConsultaViewModel>(usuario);
                    //retornar um status de sucesso..
                    return Request.CreateResponse(HttpStatusCode.OK, model);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Usuário não encontrado.");
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse
                (HttpStatusCode.InternalServerError, e.Message);
            }
        }

    }
}
