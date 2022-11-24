using SistemasOperacionais.ControleMemoria.Constants;
using System;
using System.Collections.Generic;

namespace SistemasOperacionais.ControleMemoria
{
    public class Processo
    {
        private static int _identificador = 0;
        public int Tamanho { get; private set; }
        public string Identificador { get; private set; }
        public string[] IdentificadorPaginas { get; private set; }
        public int QuantidadePaginas { get; private set; }

        public Stack<HistoricoProcesso> HistoricoProcesso { get; private set; }

        public Processo(int tamanho)
        {
            if (tamanho > MemoriaConstants.TamanhoMemoriaVirtual)
                throw new Exception("Processo ultrapassa tamanho de 1MB");

            Tamanho = tamanho;
            Identificador = (++_identificador).ToString();
            HistoricoProcesso = new Stack<HistoricoProcesso>();
        }

        public Pagina[] CriarPaginas() 
        {
            QuantidadePaginas = Pagina.ObterQuantidadePaginasPorTamanho(Tamanho);

            var paginas = new Pagina[QuantidadePaginas];
            IdentificadorPaginas = new string[QuantidadePaginas];

            for (int i = 0; i < QuantidadePaginas; i++)
            {
                var pagina = new Pagina(Guid.NewGuid().ToString());

                paginas[i] = pagina;

                IdentificadorPaginas[i] = pagina.Identificador;
            }

            return paginas;
        }

        public void Executar(Pagina pagina) 
        {
            var historicoProcesso = new HistoricoProcesso(pagina.Conteudo, pagina.Conteudo);
            HistoricoProcesso.Push(historicoProcesso);

            pagina.Acessar();
        }

        public string ObterPaginaAleatoria()
        {
            int indicePagina = (new Random()).Next(0, QuantidadePaginas - 1);
            return IdentificadorPaginas[indicePagina];
        }
    }
}
