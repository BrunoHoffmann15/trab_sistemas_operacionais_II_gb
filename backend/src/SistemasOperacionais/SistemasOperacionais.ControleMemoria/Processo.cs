using SistemasOperacionais.ControleMemoria.Constants;
using SistemasOperacionais.ControleMemoria.Exceptions;
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
            if (tamanho > MemoriaConstants.TamanhoMemoriaVirtual || tamanho < MemoriaConstants.TamanhoMinimoProcesso)
                throw new DomainException($"Processo deve ter entre {MemoriaConstants.TamanhoMemoriaVirtual} e {MemoriaConstants.TamanhoMinimoProcesso} bytes.");

            Tamanho = tamanho;
            Identificador = (++_identificador).ToString();
            HistoricoProcesso = new Stack<HistoricoProcesso>();
        }

        public void AdicionarHistorico(string titulo, string conteudo)
        {
            var historicoProcesso = new HistoricoProcesso(titulo, conteudo);
            HistoricoProcesso.Push(historicoProcesso);
        }

        public Pagina[] CriarPaginas() 
        {
            QuantidadePaginas = Pagina.ObterQuantidadePaginasPorTamanho(Tamanho);

            var paginas = new Pagina[QuantidadePaginas];
            IdentificadorPaginas = new string[QuantidadePaginas];

            for (int i = 0; i < QuantidadePaginas; i++)
            {
                var pagina = new Pagina(Guid.NewGuid().ToString(), Identificador);

                paginas[i] = pagina;

                IdentificadorPaginas[i] = pagina.Identificador;
            }

            return paginas;
        }

        public void Executar(Pagina pagina) 
        {
            AdicionarHistorico($"Execução da Página {pagina.Identificador}", $"Retorno: {pagina.Conteudo}");
            pagina.Acessar();
        }

        public string ObterPaginaAleatoria()
        {
            int indicePagina = (new Random()).Next(0, QuantidadePaginas);
            return IdentificadorPaginas[indicePagina];
        }
    }
}
