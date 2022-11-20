namespace SistemasOperacionais.ControleMemoria
{
    public class MemoriaVirtual
    {
        public int Tamanho { get; private set; }
        private Pagina[] Paginas;

        public MemoriaVirtual()
        {
            Tamanho = 4;
            Paginas = new Pagina[1];
        }


        public void AdicionarProcesso(Processo processo) 
        {
        }

        public int ObterIndicePagina(Pagina pagina) 
        {
            return 0;
        }

        public Pagina ObterPagina(int indicePagina) 
        {
            return Paginas[indicePagina];
        }
    }
}
