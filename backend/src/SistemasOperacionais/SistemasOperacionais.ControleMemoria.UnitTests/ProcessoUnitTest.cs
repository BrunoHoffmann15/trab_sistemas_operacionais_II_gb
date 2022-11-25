using NUnit.Framework;
using SistemasOperacionais.ControleMemoria.Exceptions;
using System;

namespace SistemasOperacionais.ControleMemoria.UnitTests
{
    public class ProcessoUnitTests
    {

        [Test(Description = "Deve criar processo com tamanho de 1 byte")]
        public void Deve_CriarProcesso_Tamanho1Byte()
        {
            var processo = new Processo(1);

            processo.CriarPaginas();

            Assert.AreEqual(1, processo.IdentificadorPaginas.Length);
        }

        [Test(Description = "Deve criar processo com tamanho de 9 Kbytes")]
        public void Deve_CriarProcesso_Tamanho9KByte()
        {
            var processo = new Processo(9000);

            processo.CriarPaginas();

            Assert.AreEqual(2, processo.IdentificadorPaginas.Length);
        }

        [Test(Description = "Deve criar processo com tamanho de 1 Mbytes")]
        public void Deve_CriarProcesso_Tamanho1MByte()
        {
            var processo = new Processo(1000000);

            processo.CriarPaginas();


            Assert.AreEqual(125, processo.IdentificadorPaginas.Length);
        }

        [Test(Description = "Deve estourar excessão ao criar processo com tamanho maior que 1 Mbytes")]
        public void Deve_CriarProcesso_MaiorQueTamanho1MByte()
        {
            Assert.Throws<DomainException>(() => new Processo(1000001));
        }

        [Test(Description = "Deve criar processos com identificadores diferentes")]
        public void Deve_CriarProcessos_ComIdentificadoresDiferentes() 
        {
            var processo1 = new Processo(1);
            var processo2 = new Processo(1);

            Assert.That(processo1.Identificador != processo2.Identificador);
        }
    }
}