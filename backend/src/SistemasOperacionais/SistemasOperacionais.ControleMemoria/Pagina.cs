using SistemasOperacionais.ControleMemoria.Constants;
using System;

namespace SistemasOperacionais.ControleMemoria
{
    public class Pagina
    {
        public Pagina(string conteudo, string identificadorProcesso)
        {
            Identificador = (++_identificador).ToString();
            IdentificadorProcesso = identificadorProcesso;
            Conteudo = conteudo;
            VezesAcessada = 0;
        }

        private static int _identificador = 0;
        public string Identificador { get; private set; }
        public string IdentificadorProcesso { get; private set; }
        public string Conteudo { get; private set; }
        public int VezesAcessada { get; private set; }

        public void Acessar() {
            VezesAcessada++;
        }

        public static int ObterQuantidadePaginasPorTamanho(int tamanho) 
        {
            int quantidadePaginas = 0;

            for (; tamanho > 0; quantidadePaginas++) 
            {
                tamanho -= MemoriaConstants.TamanhoPagina;
            }

            return quantidadePaginas;
        }
    }
}
