using SistemasOperacionais.ControleMemoria.Exceptions;
using System;

namespace SistemasOperacionais.ControleMemoria
{
    public class MemoriaVirtual
    {
        public Pagina[] Paginas { get; private set; }

        private int indiceUltimaPagina;
        
        public int Tamanho { get; private set; }

        public int QuantidadePaginas { get; private set; }

        public int PaginasUsadas { get; private set; }


        public MemoriaVirtual(int tamanho) 
        {
            Tamanho = tamanho;
            QuantidadePaginas = Pagina.ObterQuantidadePaginasPorTamanho(tamanho);
            PaginasUsadas = 0;

            indiceUltimaPagina = -1;
            Paginas = new Pagina[QuantidadePaginas];
        }

        public void AdicionarProcesso(Processo processo) 
        {
            var paginasProcesso = processo.CriarPaginas();

            if (!PossuiPaginasSuficientes(processo.QuantidadePaginas))
                throw new DomainException("Memória virtual não possui espaço suficiente.");

            foreach (Pagina p in paginasProcesso)
            {
                Paginas[++indiceUltimaPagina] = p;
                PaginasUsadas++;
            }
        }

        public int ObterIndicePagina(string identificadorPagina) 
        {
            for (int i = 0; i < Paginas.Length; i++)
                if (Paginas[i].Identificador == identificadorPagina) return i;

            return 0;
        }

        public Pagina ObterPagina(int indicePagina) 
        {
            return Paginas[indicePagina];
        }

        public int ObterQuantidadePaginasUsadas() => indiceUltimaPagina + 1;

        private bool PossuiPaginasSuficientes(int quantidadePaginasProcesso) 
        {
            return QuantidadePaginas - PaginasUsadas - quantidadePaginasProcesso >= 0;
        }
    }
}
