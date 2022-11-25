namespace SistemasOperacionais.ControleMemoria.Api.Models
{
    public class RespostaBase<T>
    {
        public RespostaBase(T retorno, string mensagemErro)
        {
            Retorno = retorno;
            MensagemErro = mensagemErro;
        }
        
        public RespostaBase(T retorno)
        {
            Retorno = retorno;
        }

        public T Retorno { get; private set; }

        public bool PossuiErro => !string.IsNullOrEmpty(MensagemErro);

        public string MensagemErro { get; private set; }
    }
}
