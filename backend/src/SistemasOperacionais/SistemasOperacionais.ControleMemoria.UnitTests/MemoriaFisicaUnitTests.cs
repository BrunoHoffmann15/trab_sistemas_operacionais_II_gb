using NUnit.Framework;

namespace SistemasOperacionais.ControleMemoria.UnitTests
{
    class MemoriaFisicaUnitTests
    {
        private MemoriaVirtual memoriaVirtual;

        [SetUp]
        public void SetUp() 
        {
            memoriaVirtual = new MemoriaVirtual(16000);
        }

        [Test]
        public void Deve_AdicionarPagina_SemSwapOut() 
        {
            var memoriaFisica = new MemoriaFisica(8000);
            var pagina = CriarPagina();

            memoriaFisica.FazerSwapIn(pagina);
        }

        [Test]
        public void Deve_AdicionarPagina_ComSwapOut()
        {
            var memoriaFisica = new MemoriaFisica(8000);
            var pagina = CriarPagina();
            memoriaFisica.FazerSwapIn(pagina);

            var pagina2 = CriarPagina();
            memoriaFisica.FazerSwapIn(pagina2);

            Assert.AreEqual(pagina2.Identificador, memoriaFisica.ObterPagina(0).Identificador);
        }

        public Pagina CriarPagina() 
        {
            var processo = new Processo(2);
            memoriaVirtual.AdicionarProcesso(processo);

            int indicePagina = memoriaVirtual.ObterIndicePagina(processo.IdentificadorPaginas[0]);
            return memoriaVirtual.ObterPagina(indicePagina);
        }
    }
}
