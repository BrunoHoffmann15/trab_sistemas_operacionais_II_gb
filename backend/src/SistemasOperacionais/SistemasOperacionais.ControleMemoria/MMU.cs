using SistemasOperacionais.ControleMemoria.Constants;

namespace SistemasOperacionais.ControleMemoria
{
    public class MMU
    {
        public MemoriaFisica MemoriaFisica { get; private set; }
        public MemoriaVirtual MemoriaVirtual { get; private set; }

        public RegistroTabelaPagina[] TabelaPaginas { get; private set; }

        public MMU() {
            MemoriaFisica = new MemoriaFisica(MemoriaConstants.TamanhoMemoriaFisica);
            MemoriaVirtual = new MemoriaVirtual(MemoriaConstants.TamanhoMemoriaVirtual);
            TabelaPaginas = new RegistroTabelaPagina[MemoriaVirtual.QuantidadePaginas];

            InicializarTabelaPaginas();
        }

        private void InicializarTabelaPaginas() {
            for (int i = 0; i < TabelaPaginas.Length; i++) 
            {
                TabelaPaginas[i] = new RegistroTabelaPagina();
            }
        }

        public void AdicionarProcesso(Processo processo)
        {
            MemoriaVirtual.AdicionarProcesso(processo);
        }

        public void ExecutarProcesso(Processo processo) 
        {
            ExecutarProcesso(processo, processo.ObterPaginaAleatoria());
        }

        public void ExecutarProcesso(Processo processo, string identificadorPagina)
        {
            int indicePagina = MemoriaVirtual.ObterIndicePagina(identificadorPagina);

            if (!TabelaPaginas[indicePagina].Bit)
            {
                AdicionarPaginaMemoriaFisica(indicePagina);
            }

            var paginaMemoriaFisica = MemoriaFisica.ObterPagina(TabelaPaginas[indicePagina].EnderecoMemoriaFisica); 
            processo.Executar(paginaMemoriaFisica);
        }

        private void AdicionarPaginaMemoriaFisica(int indicePagina) 
        {
            var registroPagina = new RegistroTabelaPagina();

            int indiceDisponivel = MemoriaFisica.FazerSwapIn(MemoriaVirtual.ObterPagina(indicePagina));

            registroPagina.AtualizarEnderecoMemoriaFisica(indiceDisponivel);
            TabelaPaginas[indicePagina] = registroPagina;
        }
    }
}
