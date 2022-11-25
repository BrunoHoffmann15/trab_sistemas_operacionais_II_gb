using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemasOperacionais.ControleMemoria.Api.Repositories
{
    public class ProcessoRepository
    {
        public List<Processo> Processos { get; private set; }

        public ProcessoRepository() 
        {
            Processos = new List<Processo>();
        }

        public void Adicionar(Processo processo) 
        {
            Processos.Add(processo);
        }

        public Processo ObterPorId(string identificador) 
        {
            return Processos.FirstOrDefault(p => p.Identificador == identificador);
        }

        public List<Processo> Listar() 
        {
            return Processos;
        }
    }
}
