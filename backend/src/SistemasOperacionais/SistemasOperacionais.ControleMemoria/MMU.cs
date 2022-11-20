namespace SistemasOperacionais.ControleMemoria
{
    public class MMU
    {
        private readonly static MemoriaFisica _memoriaFisica;
        private readonly static MemoriaVirtual _memoriaVirtual;
        private readonly static RegistroTabelaPagina[] _tabelaPaginas;

        static MMU() {
            _memoriaFisica = new MemoriaFisica();
            _memoriaVirtual = new MemoriaVirtual();
        }

        public static void AdicionarProcessor(Processo processo)
        {
            _memoriaVirtual.AdicionarProcesso(processo);
        }

        public static void ExecutarProcesso(Processo processo)
        {
            Pagina pagina = processo.ObterPagina();
            int indicePagina = _memoriaVirtual.ObterIndicePagina(pagina);

            if (!_tabelaPaginas[indicePagina].Bit)
            {
                AdicionarPaginaMemoriaFisica(indicePagina);
            }

            Pagina paginaMemoriaFisica = _memoriaFisica.ObterPagina(_tabelaPaginas[indicePagina].EnderecoMemoriaFisica);
            paginaMemoriaFisica.Acessar();
            
            processo.Executar();
        }

        private static void AdicionarPaginaMemoriaFisica(int indicePagina) 
        {
            var registroPagina = new RegistroTabelaPagina();

            int indiceDisponivel = _memoriaFisica.FazerSwapIn(_memoriaVirtual.ObterPagina(indicePagina));

            registroPagina.AtualizarEnderecoMemoria(indiceDisponivel);
            _tabelaPaginas[indicePagina] = registroPagina;
        }
    }
}
