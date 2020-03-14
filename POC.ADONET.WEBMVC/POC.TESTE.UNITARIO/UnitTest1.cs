using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using POC.ADONET.DAL;
using POC.ADONET.MODELS;

namespace POC.TESTE.UNITARIO
{
    [TestClass]
    public class UnitTest1
    {
        // CREATE
        [TestMethod]
        public void TestarInsertNaTabelaCliente()
        {
            ClienteDAL clienteDAL = new ClienteDAL();

            //clienteDAL.Add("CHAVES DA SILVA", "chaves@chaves.com.br",
            //    "Mora proximo da Vila da Chiquinha");
             
            Assert.IsTrue(clienteDAL.Add("CHAVES DA SILVA", "chaves@chaves.com.br",
                "Mora proximo da Vila da Chiquinha"));                
        }

        // READ
        [TestMethod]
        public void TestarBuscarDadosNaTabelaCliente()
        {
            ClienteDAL clienteDAL = new ClienteDAL();

            Assert.IsNotNull(clienteDAL.SelectAll());             
        }

        // READ by ID
        [TestMethod]
        public void TestarBuscarDadosNaTabelaClientePorID()
        {
            // objetos para buscar os dados e recebe-los
            ClienteDAL clienteDAL = new ClienteDAL();
            ClienteMOD cliente = null;

            // executa o select filtrando por ID
            cliente = clienteDAL.SelectByID(1);

            // verifica se o resultado é diferente de null
            Assert.IsNotNull(cliente);
            Assert.AreNotEqual("MARCIO RODRIGUES", cliente.Nome);

        }


        // UPDATE
        [TestMethod]
        public void TestarAlteracaoNaTabelaCliente()
        {
            // objetos para buscar os dados e recebe-los
            ClienteDAL clienteDAL = new ClienteDAL();
            ClienteMOD cliente = null;
            int id = 1;

            // executa o select filtrando por ID
            cliente = clienteDAL.SelectByID(id);

            cliente.Nome = "Chiquinha da Silva";
            cliente.Email = "chiquinha@sbt.com.br";
            cliente.Observacao = "Correcao de cadastro de cliente para teste";

            clienteDAL.Update(cliente, cliente.Id);
        }

        // DELETE
        [TestMethod]
        public void TestarExcluirNaTabelaCliente()
        {
            // objetos para buscar os dados e recebe-los
            ClienteDAL clienteDAL = new ClienteDAL();
            int id = 7;

            Assert.IsTrue(clienteDAL.DeleteById(id));
        }

        [TestMethod]
        public void TestarLerAppconfig()
        {
            var appSettings = ConfigurationManager.AppSettings;
            var connectionString = appSettings["connStringLivraria"];
        }
    }
}
