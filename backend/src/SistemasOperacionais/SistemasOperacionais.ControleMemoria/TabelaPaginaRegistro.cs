using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemasOperacionais.ControleMemoria
{
    public class RegistroTabelaPagina
    {
        public RegistroTabelaPagina()
        {
            Bit = false;
        }

        public bool Bit { get; private set; }

        public int EnderecoMemoriaFisica { get; private set; }

        public void AtualizarEnderecoMemoria(int enderecoMemoria) 
        {
            EnderecoMemoriaFisica = enderecoMemoria;
            Bit = true;
        }
    }
}
