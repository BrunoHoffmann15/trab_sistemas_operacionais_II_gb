using System;

namespace SistemasOperacionais.ControleMemoria
{
    public class HistoricoProcesso
    {
        public HistoricoProcesso(string titulo, string conteudo)
        {
            DataExecucao = DateTime.Now;
            Titulo = titulo;
            Conteudo = conteudo;
        }

        public DateTime DataExecucao { get; private set; }

        public string Titulo { get; private set; }

        public string Conteudo { get; private set; }
    }
}
