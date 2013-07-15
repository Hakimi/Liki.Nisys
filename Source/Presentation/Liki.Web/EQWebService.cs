using System.Configuration;
using Korzh.EasyQuery;
using Korzh.EasyQuery.Db;
using System.Data;
using System.Data.SqlClient;

namespace Liki.Web
{
    public class EQWebService : Korzh.EasyQuery.WebServices.EQDbWebService
    {
        static private string connectionString;

        protected override DataModel GainModel()
        {
            string dataPath = System.Web.HttpContext.Current.Server.MapPath("~/App_Data");

            DbModel model = new DbModel();
            model.LoadFromFile(System.IO.Path.Combine(dataPath, "Customer.xml"));

            return model;
        }

        protected override Query CreateQuery()
        {
            DbQuery dbQuery = new DbQuery();
            dbQuery.Formats.DateFormat = "#yyyy-MM-dd#";
            dbQuery.Formats.DateTimeFormat = "#yyyy-MM-dd hh:mm:ss#";
            dbQuery.Formats.QuoteBool = false;
            dbQuery.Formats.QuoteTime = false;
            dbQuery.Formats.SqlQuote1 = '[';
            dbQuery.Formats.SqlQuote2 = ']';
            dbQuery.Formats.SqlSyntax = Korzh.EasyQuery.SqlSyntax.SQL2;
            dbQuery.Formats.TimeFormat = "#hh:mm:ss#";
            return dbQuery;
        }

        protected override string GenerateQueryStatement(Query query)
        {
            SqlQueryBuilder builder = new SqlQueryBuilder((DbQuery)query);
            builder.BuildSQL();
            return builder.Result.SQL;
        }

        protected override void LoadQueryByName(Query query, string queryName)
        {
            string queriesFolderPath = ""; //queriesPath;
            query.LoadFromFile(queryName + ".xml");
        }

        protected override DataSet GetDataSetBySql(string sql)
        {
            connectionString = ConfigurationManager.ConnectionStrings["likidbContext"].ToString();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            DataSet dataSet = new DataSet();

            conn.Open();
            SqlCommand command = new SqlCommand(sql, conn);
            SqlDataAdapter dbAdapter = new SqlDataAdapter(command);
            dbAdapter.Fill(dataSet);

            return dataSet;
        }
    }
}