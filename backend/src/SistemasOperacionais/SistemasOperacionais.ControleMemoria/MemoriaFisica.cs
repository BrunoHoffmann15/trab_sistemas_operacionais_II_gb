namespace SistemasOperacionais.ControleMemoria
{
    public class MemoriaFisica
    {
        public int Tamanho { get; private set; }
        public int QuantidadePaginas { get; private set; }
        public int UltimaPagina { get; private set; }

        public Pagina[] Paginas;

        public MemoriaFisica()
        {
            Paginas = new Pagina[2];
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
            for (int i = 0; i < Paginas.Length; i++) {
                if (Paginas[i] == null) return i;
            }

            return -1;
        }

        private int FazerSwapOut() 
        {

            // TODO: Adicionar lógica para remover fila.
            return 0;
        }
    }
}
