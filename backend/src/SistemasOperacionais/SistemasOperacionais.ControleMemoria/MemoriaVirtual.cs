namespace SistemasOperacionais.ControleMemoria
{
    public class MemoriaVirtual
    {
        public int Tamanho { get; private set; }
        public Pagina[] Paginas;

        public MemoriaVirtual()
        {
            Tamanho = 4;
            Paginas = new Pagina[1];
        }


        public void AdicionarProcesso(Processo processo) 
        {
        }
    }
}
