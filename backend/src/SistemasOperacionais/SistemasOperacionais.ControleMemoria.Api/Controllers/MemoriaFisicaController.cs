using Microsoft.AspNetCore.Mvc;
using SistemasOperacionais.ControleMemoria.Api.Models;
using SistemasOperacionais.ControleMemoria.Api.Repositories;

namespace SistemasOperacionais.ControleMemoria.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemoriaFisicaController
    {
        private readonly MMURepository _mmuRepository;

        public MemoriaFisicaController(MMURepository mmuRepository)
        {
            _mmuRepository = mmuRepository;
        }

        [HttpGet]
        public RespostaBase<MemoriaFisica> ObterMemoriaFisica()
        {
            var memoriaFisica = _mmuRepository.ObterMemoriaFisica();
            return new RespostaBase<MemoriaFisica>(memoriaFisica);
        }
    }
}
