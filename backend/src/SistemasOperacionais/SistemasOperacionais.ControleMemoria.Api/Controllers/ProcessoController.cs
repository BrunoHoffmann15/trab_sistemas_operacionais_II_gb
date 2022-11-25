using Microsoft.AspNetCore.Mvc;
using SistemasOperacionais.ControleMemoria.Api.Models;
using SistemasOperacionais.ControleMemoria.Api.Repositories;
using System;

namespace SistemasOperacionais.ControleMemoria.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessoController : ControllerBase
    {
        private readonly ProcessoRepository _processoRepository;
        private readonly MMURepository _mmuRepository;

        public ProcessoController(ProcessoRepository processoRepository, MMURepository mmuRepository) 
        {
            _processoRepository = processoRepository;
            _mmuRepository = mmuRepository;
        }

        [HttpGet("{id}")]
        public RespostaBase<Processo> ObterProcesso(string id) 
        {
            var processo = _processoRepository.ObterPorId(id);
            return new RespostaBase<Processo>(processo);
        }

        [HttpPost]
        public RespostaBase<Processo> CriarProcesso(ProcessoModel processoModel)
        {
            try
            {
                var processo = new Processo(processoModel.Tamanho);

                _processoRepository.Adicionar(processo);
                _mmuRepository.CriarProcesso(processo);

                return new RespostaBase<Processo>(processo);
            } 
            catch (Exception ex)
            {
                return new RespostaBase<Processo>(null, ex.Message);
            }
        }

        [HttpPost("{id}/executar")]
        public RespostaBase<Processo> ExecutarProcesso(string id) 
        { 
            try
            {
                var processo = _processoRepository.ObterPorId(id);
                _mmuRepository.ExecutarProcesso(processo);
                return new RespostaBase<Processo>(processo);
            } 
            catch (Exception ex)
            {
                return new RespostaBase<Processo>(null, ex.Message);
            }
        }

        [HttpPost("{id}/executar/{idPagina}")]
        public RespostaBase<Processo> ExecutarPaginaProcesso(string id, string idPagina)
        {
            try
            {
                var processo = _processoRepository.ObterPorId(id);
                _mmuRepository.ExecutarPaginaProcesso(processo, idPagina);
                return new RespostaBase<Processo>(processo);
            }
            catch (Exception ex)
            {
                return new RespostaBase<Processo>(null, ex.Message);
            }
        }
    }
}
