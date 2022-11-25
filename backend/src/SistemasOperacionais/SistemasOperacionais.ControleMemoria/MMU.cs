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
                processo.AdicionarHistorico("Swap-in", $"Página {identificadorPagina} do processo não estava na memória física, e fez swap-in.");
                AdicionarPaginaMemoriaFisica(indicePagina);
            } 
            else
            {
                processo.AdicionarHistorico("Obter Página", $"Página {identificadorPagina} do processo já estava na memória física.");
            }

            var paginaMemoriaFisica = MemoriaFisica.ObterPagina(TabelaPaginas[indicePagina].EnderecoMemoriaFisica); 
            processo.Executar(paginaMemoriaFisica);
            processo.AdicionarHistorico("Execução", $"Processo teve a página {paginaMemoriaFisica.Identificador} executada com sucesso.");
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
