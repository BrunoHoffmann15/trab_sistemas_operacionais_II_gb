namespace SistemasOperacionais.ControleMemoria.Api.Repositories
{
    public class MMURepository
    {
        private readonly MMU _mmu;

        public MMURepository()
        {
            _mmu = new();
        }

        public void CriarProcesso(Processo processo)
        {
            _mmu.AdicionarProcesso(processo);
        }

        public MemoriaFisica ObterMemoriaFisica()
        {
            return _mmu.MemoriaFisica;
        }

        public MemoriaVirtual ObterMemoriaVirtual()
        {
            return _mmu.MemoriaVirtual;
        }

        public void ExecutarProcesso(Processo processo)
        {
            _mmu.ExecutarProcesso(processo);
        }

        public void ExecutarPaginaProcesso(Processo processo, string pagina)
        {
            _mmu.ExecutarProcesso(processo, pagina);
        }
    }
}
