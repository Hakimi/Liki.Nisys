using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Liki.Infrastructure.Data.Seedwork;
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
            Database.SetInitializer<LikiDbContext>(null);
            var ctx = new LikiDbContext();
            var DBName = ctx.Database.Connection.Database;
            Console.Write(DBName);
        }
        #endregion
    }
}
