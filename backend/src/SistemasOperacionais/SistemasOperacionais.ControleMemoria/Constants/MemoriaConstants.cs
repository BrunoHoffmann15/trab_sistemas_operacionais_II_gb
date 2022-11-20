using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemasOperacionais.ControleMemoria.Constants
{
    public class MemoriaConstants
    {
        public const int TamanhoMemoriaVirtual = 1024;
        public const int TamanhoMemoriaFisica = 64;
        public const int TamanhoPagina = 8;

        public const int QuantidadePaginaMemoriaFisica = TamanhoMemoriaFisica / TamanhoPagina;
        public const int QuantidadePaginaMemoriaVirtual = TamanhoMemoriaVirtual / TamanhoPagina;

    }
}
