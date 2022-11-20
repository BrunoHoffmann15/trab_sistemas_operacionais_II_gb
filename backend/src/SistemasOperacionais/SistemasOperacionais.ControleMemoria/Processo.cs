using System;

namespace SistemasOperacionais.ControleMemoria
{
    public class Processo
    {
        public string Pid { get; private set; }
        public Pagina[] Paginas;

        public void Executar() { 
            
        }

        internal Pagina ObterPagina()
        {
            throw new NotImplementedException();
        }
    }
}
