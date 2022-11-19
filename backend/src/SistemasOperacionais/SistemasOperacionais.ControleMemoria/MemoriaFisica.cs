using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemasOperacionais.ControleMemoria
{
    public class MemoriaFisica
    {
        public int Tamanho { get; private set; }
        public int QuantidadePaginas { get; private set; }
        public int UltimaPagina { get; private set; }

        public Pagina[] Paginas;

        public MemoriaFisica()
        {
            Paginas = new Pagina[2];
        }


    }
}
