using System;

namespace SistemasOperacionais.ControleMemoria
{
    public class MemoriaVirtual
    {
        private readonly Pagina[] _paginas;

        private int indiceUltimaPagina;
        
        public int Tamanho { get; private set; }
        public int QuantidadePaginas { get; private set; }


        public MemoriaVirtual(int tamanho) 
        {
            Tamanho = tamanho;
            QuantidadePaginas = Pagina.ObterQuantidadePaginasPorTamanho(tamanho);

            indiceUltimaPagina = -1;
            _paginas = new Pagina[QuantidadePaginas];
        }

        public void AdicionarProcesso(Processo processo) 
        {
            var paginasProcesso = processo.CriarPaginas();

            if (!PossuiPaginasSuficientes(processo.QuantidadePaginas))
                throw new Exception("Memória virtual não possui espaço suficiente.");

            foreach (Pagina p in paginasProcesso)
                _paginas[++indiceUltimaPagina] = p;
        }

        public int ObterIndicePagina(string identificadorPagina) 
        {
            for (int i = 0; i < _paginas.Length; i++)
                if (_paginas[i].Identificador == identificadorPagina) return i;

            return 0;
        }

        public Pagina ObterPagina(int indicePagina) 
        {
            return _paginas[indicePagina];
        }

        public int ObterQuantidadePaginasUsadas() => indiceUltimaPagina + 1;

        private bool PossuiPaginasSuficientes(int quantidadePaginasProcesso) 
        {
            return QuantidadePaginas - ObterQuantidadePaginasUsadas() - quantidadePaginasProcesso >= 0;
        }
    }
}
