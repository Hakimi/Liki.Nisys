using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Data;
using System.Data.OleDb;
using System.Web;   
using System.Web.Services;
using Korzh.EasyQuery;
using Korzh.EasyQuery.Db;
using Korzh.EasyQuery.WebServices;
using System.Data.SqlClient;
using System.Configuration;

namespace Korzh.EasyQuery.Mvc3Demo
{
    /// <summary>
    /// Summary description for EQService
    /// </summary>
    [WebService(Namespace = "http://korzh.com/")]
    //[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class EQService : Korzh.EasyQuery.WebServices.EQDbWebService
    {
        public static DbModel Model { get; set; }

        static private string dataPath;
        static private string dataModelPath;
        static private string queriesPath;
        static private string connectionString;

        static EQService() {

            dataPath = System.Web.HttpContext.Current.Server.MapPath("~/App_Data");
            dataModelPath = System.IO.Path.Combine(dataPath, "Users.xml");
            connectionString = ConfigurationManager.ConnectionStrings["likidbContext"].ToString();
            //ConfigurationManager.ConnectionStrings["LikiDB"].ToString();
            queriesPath = System.IO.Path.Combine(dataPath, "Queries");

            if (!Directory.Exists(queriesPath)) 
                Directory.CreateDirectory(queriesPath);

            Model = new DbModel();
            Model.LoadFromFile(dataModelPath);
        }


        protected override DataModel GainModel() { 
            return Model;
        }

        protected override Query CreateQuery() {
            DbQuery dbQuery = new DbQuery();
            dbQuery.Formats.SetDefaultFormats(FormatType.MsSqlServer);
            dbQuery.Formats.QuoteColumnAlias = true;
            dbQuery.Formats.UseColumnAliases = ColumnAliasesUsage.Always;
            return dbQuery;
        }


        protected override string GenerateQueryStatement(Query query) {
            SqlQueryBuilder builder = new SqlQueryBuilder((DbQuery)query);
            if (builder.CanBuild) {
                builder.BuildSQL();
                return builder.Result.SQL;
            }
            return string.Empty;
        }

        protected override void LoadQueryByName(Query query, string queryName) {
            string queriesFolderPath = queriesPath;
            query.LoadFromFile(System.IO.Path.Combine(queriesFolderPath, queryName + ".xml"));
            //query.LoadFromFile(System.IO.Path.Combine(queriesFolderPath, "Query3.xml"));
        }

        protected override DataSet GetDataSetBySql(string sql) {
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
