namespace SistemasOperacionais.ControleMemoria
{
    public class Pagina
    {
        public Pagina(string conteudo)
        {
            Conteudo = conteudo;
            VezesAcessada = 0;
        }
        
        public string Identificador { get; private set; }
        public string Conteudo { get; private set; }
        public int VezesAcessada { get; private set; }

        public void Acessar() {
            VezesAcessada++;
        }
    }
}
