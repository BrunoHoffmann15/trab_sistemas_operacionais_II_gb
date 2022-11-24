namespace SistemasOperacionais.ControleMemoria
{
    public class RegistroTabelaPagina
    {
        public RegistroTabelaPagina()
        {
            Bit = false;
        }

        public bool Bit { get; private set; }

        public int EnderecoMemoriaFisica { get; private set; }

        public void AtualizarEnderecoMemoriaFisica(int enderecoMemoria) 
        {
            EnderecoMemoriaFisica = enderecoMemoria;
            Bit = true;
        }
    }
}
