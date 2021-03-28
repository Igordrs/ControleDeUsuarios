using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projeto.Services.Models;
using Projeto.Entities;
using AutoMapper; //fazer o mapeamento da troca de dados entre as ViewModels e Entities


namespace Projeto.Services.Mappings
{
    public class ViewModelToEntity : Profile
    {
        public ViewModelToEntity()
        {
            CreateMap<UsuarioCadastroViewModel, Usuario>();
            CreateMap<UsuarioEdicaoViewModel, Usuario>();
        }
    }
}