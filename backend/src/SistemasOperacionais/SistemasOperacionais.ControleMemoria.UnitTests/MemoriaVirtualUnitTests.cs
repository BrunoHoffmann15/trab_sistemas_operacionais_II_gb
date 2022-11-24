using NUnit.Framework;
using SistemasOperacionais.ControleMemoria.Constants;
using System;

namespace SistemasOperacionais.ControleMemoria.UnitTests
{
    class MemoriaVirtualUnitTests
    {
        [Test]
        public void Deve_AdicionarProcesso_ComTamanhoDisponivel() 
        {
            var processo = new Processo(9000);
            MemoriaVirtual memoriaVirtual = new MemoriaVirtual(MemoriaConstants.TamanhoMemoriaVirtual);

            memoriaVirtual.AdicionarProcesso(processo);
            Assert.AreEqual(2, memoriaVirtual.ObterQuantidadePaginasUsadas());
        }

        [Test]
        public void Deve_AdicionarProcesso_ComTamanhoIndisponivel()
        {
            var processo = new Processo(9000);
            MemoriaVirtual memoriaVirtual = new MemoriaVirtual(8000);

            Assert.Throws<Exception>(() => memoriaVirtual.AdicionarProcesso(processo), "Memória virtual não possui espaço suficiente.");
        }
    }
}
