using Microsoft.AspNetCore.Mvc;
using SistemasOperacionais.ControleMemoria.Api.Models;
using SistemasOperacionais.ControleMemoria.Api.Repositories;

namespace SistemasOperacionais.ControleMemoria.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemoriaVirtualController : ControllerBase
    {
        private readonly MMURepository _mmuRepository;

        public MemoriaVirtualController(MMURepository mmuRepository) 
        {
            _mmuRepository = mmuRepository;
        }

        [HttpGet]
        public RespostaBase<MemoriaVirtual> ObterMemoriaVirtual()
        {
            var memoriaVirtual = _mmuRepository.ObterMemoriaVirtual();
            return new RespostaBase<MemoriaVirtual>(memoriaVirtual);
        }
    }
}
