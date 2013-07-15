using NUnit.Framework;

namespace Infrastructure.Data.Seedwork.Test
{
    [TestFixture]
    public class SchemaTests
    {
        #region SetUp / TearDown

        [SetUp]
        public void Init()
        { }

        [TearDown]
        public void Dispose()
        { }

        #endregion

        #region Tests

        [Test]
        public void Can_generate_schema()
        {
            //Database.SetInitializer<MainBCUnitOfWork>(null);
            //var ctx = new MainBCUnitOfWork();
            //var DBName = ctx.Database.Connection.Database;
            //Console.Write(DBName);
        }

        #endregion
    }
}
