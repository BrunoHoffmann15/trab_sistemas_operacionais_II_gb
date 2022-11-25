namespace SistemasOperacionais.ControleMemoria
{
    public class MemoriaFisica
    {
        public int Tamanho { get; private set; }
        public int QuantidadePaginas { get; private set; }
        public Pagina[] Paginas { get; private set; }

        private int indiceFilaPrimeiroAtual = 0;

        public MemoriaFisica(int tamanho)
        {
            indiceFilaPrimeiroAtual = 0;
            Tamanho = tamanho;

            QuantidadePaginas = Pagina.ObterQuantidadePaginasPorTamanho(tamanho);
            Paginas = new Pagina[QuantidadePaginas];
        }

        public Pagina ObterPagina(int indicePagina) 
        {
            return Paginas[indicePagina];
        }

        public int FazerSwapIn(Pagina pagina) 
        { 
            int indiceDisponivel = ObterIndiceDisponivel();

            if (indiceDisponivel == -1) {
                indiceDisponivel = FazerSwapOut();
            }

            Paginas[indiceDisponivel] = pagina;

            return indiceDisponivel;
        }

        private int ObterIndiceDisponivel()
        {
            for (int i = 0; i < QuantidadePaginas; i++) {
                if (Paginas[i] == null) return i;
            }

            return -1;
        }

        private int FazerSwapOut() 
        {
            int indiceLiberado = indiceFilaPrimeiroAtual;
            
            Paginas[indiceLiberado] = null;

            indiceFilaPrimeiroAtual++;

            if (indiceFilaPrimeiroAtual == QuantidadePaginas)
                indiceFilaPrimeiroAtual = 0;

            return indiceLiberado;
        }
    }
}
