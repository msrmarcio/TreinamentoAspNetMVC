using System.Data.Entity;
using ViagensOnline.Cap4Lab1.Web.Models;

namespace ViagensOnline.Cap4Lab1.Web.Db
{
    public class ViagensOnLineDb : DbContext
    {
        private const string conexao =
        @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Marcio\gitHub\TreinamentoAspNetMVC\ViagensOnline.Cap4Lab1.Web\ViagensOnline.Cap4Lab1.Web\App_Data\ViagensOnLineDb.mdf;Integrated Security = True";

        public ViagensOnLineDb() : base(conexao)
        {
        }

        public DbSet<Destino> Destinos { get; set; }
    }
}