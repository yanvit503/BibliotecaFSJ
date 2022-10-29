using Microsoft.VisualStudio.TestTools.UnitTesting;
using BibliotecaFSJ.DAO;
using BibliotecaFSJ.DAO.DAO;
using System.Threading.Tasks;

namespace BibliotecaFSJ.Testes
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task TestMethod1()
        {
            await MensagensDAO.GetConversasByUsuario("afb6b485-9f7c-456a-afc2-1ba1a511c352");
        }
    }
}
