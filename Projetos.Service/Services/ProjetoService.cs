using AutoMapper;
using Projetos.Domain.DTos;
using Projetos.Domain.Interfaces.Repositories;
using Projetos.Infra.CrossCutting.Handlers.Notifications;
using Projetos.Service.Helpers;
using Projetos.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projetos.Service.Services
{
    public class ProjetoService : IProjetoService
    {
        private readonly IMapper _mapper;
        private readonly INotificationHandler _notificationHandler;
        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly IProjetoRepository _projetoRepository;

        public ProjetoService(INotificationHandler notificationHandler, IMapper mapper, IFuncionarioRepository funcionarioRepository, IProjetoRepository projetoRepository)
        {
            this._mapper = mapper;
            this._funcionarioRepository = funcionarioRepository;
            this._projetoRepository = projetoRepository;
        }

        public async Task<bool> Remover(long projetoId)
        {
            var projeto = await _projetoRepository.BuscarPorId(projetoId);
            if (projeto.Status == Domain.Enums.StatusEnum.Iniciado || projeto.Status == Domain.Enums.StatusEnum.EmAndamento || projeto.Status == Domain.Enums.StatusEnum.Encerrado)
            {
                _notificationHandler.AddNotification($"Projeto não foi excluído pois ele tem o status {projeto.Status.GetAttribute<DisplayAttribute>()}");
                return false;
            }
            _projetoRepository.Remover(projeto);
            return true;
        }

        public async Task<bool> MudarStatus(ProjetoMudaStatusDTo status)
        {
            var projeto = await _projetoRepository.BuscarPorId(status.ProjetoId);
            if(projeto == null)
            {
                _notificationHandler.AddNotification($"Projeto com Id {status.ProjetoId} não foi localizado.");
                return false;
            }
            projeto.Status = status.Status;
            return _projetoRepository.AlterarStatus(projeto);
        }

        public async Task<bool> Salvar(ProjetoDTo model)
        {
            try
            {
                return await _projetoRepository.Salvar(_mapper.Map<Projeto>(model));
            }
            catch (Exception ex)
            {
                _notificationHandler.AddNotification(ex.Message);
                throw new Exception(ex.Message);
            }
        }

    }
}



