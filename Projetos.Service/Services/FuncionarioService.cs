using AutoMapper;
using Projetos.Domain.DTos;
using Projetos.Domain.Entities;
using Projetos.Domain.Interfaces.Repositories;
using Projetos.Infra.CrossCutting.Handlers.Notifications;
using Projetos.Service.Interfaces;
using System;
using System.Threading.Tasks;

namespace Projetos.Service.Services
{
    public class FuncionarioService : IFuncionarioService
    {

        private readonly IMapper _mapper;
        private readonly INotificationHandler _notificationHandler;
        private readonly IFuncionarioRepository _funcionarioRepository;

        public FuncionarioService(INotificationHandler notificationHandler, IMapper mapper, IFuncionarioRepository funcionarioRepository)
        {
            this._mapper = mapper;
            this._funcionarioRepository = funcionarioRepository;
        }

        public async Task<bool> Salvar(FuncionarioDTo model)
        {
            try
            {
                return await _funcionarioRepository.Salvar(_mapper.Map<Funcionario>(model));
            }
            catch (Exception ex)
            {
                _notificationHandler.AddNotification(ex.Message);
                throw new Exception(ex.Message);
            }
        }
    }
}
