using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using POC.ADONET.DAL;

namespace POC.TESTE.UNITARIO
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestarInsertNaTabelaCliente()
        {
            ClienteDAL clienteDAL = new ClienteDAL();

            //clienteDAL.Add("CHAVES DA SILVA", "chaves@chaves.com.br",
            //    "Mora proximo da Vila da Chiquinha");
             
            Assert.IsTrue(clienteDAL.Add("CHAVES DA SILVA", "chaves@chaves.com.br",
                "Mora proximo da Vila da Chiquinha"));
                
        }
    }
}
