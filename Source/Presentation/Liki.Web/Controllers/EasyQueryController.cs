using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;
using Korzh.EasyQuery.Mvc;
using Korzh.EasyQuery.Db;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace Korzh.EasyQuery.Mvc3Demo
{
    public class EasyQueryController : EqDbMvcController
    {
        #region Members
        
        public static DbModel Model { get; set; }

        static private string dataPath;
        static private string dataModelPath;
        static private string queriesPath;
        static private string connectionString;
        #endregion

        #region Constructors
        static EasyQueryController()
        {

            dataPath = System.Web.HttpContext.Current.Server.MapPath("~/App_Data");
            dataModelPath = System.IO.Path.Combine(dataPath, "Customer.xml");

         
            //connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.IO.Path.Combine(dataPath, "NWind.mdb"); 
            //connectionString = "Data Source=.; Initial Catalog=LikiDB; User id=sa; Password=sa@123;";
            connectionString = ConfigurationManager.ConnectionStrings["likidbContext"].ToString();
            queriesPath = System.IO.Path.Combine(dataPath, "Queries");

            if (!Directory.Exists(queriesPath))
                Directory.CreateDirectory(queriesPath);

            Model = new DbModel();
            Model.LoadFromFile(dataModelPath);

        }

        #endregion

        #region Method
        

        protected override DataModel GainModel() { 
            return Model;
        }

        protected override Query CreateQuery() {
            DbQuery dbQuery = new DbQuery();
            dbQuery.Formats.SetDefaultFormats(FormatType.MsSqlServer);

            return dbQuery;
        }


        /// <summary>
        /// Generates a correct query statement by Query object. Must be overriden in descendants to generate an appropriate statement (e.g. SQL)
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns></returns>
        protected override string GenerateQueryStatement(Query query) {
            SqlQueryBuilder builder = new SqlQueryBuilder((DbQuery)query);
            //if (builder.CanBuild) {
                builder.BuildSQL();
                return builder.Result.SQL;
            //}
            //return string.Empty;
        }

        /// <summary>
        /// Loads query by its name. The actual behavior must be implemented in the descendant
        /// </summary>
        /// <param name="query">A Query object.</param>
        /// <param name="queryName">Name of the query.</param>
        protected override void LoadQueryByName(Query query, string queryName) {
            string queriesFolderPath = queriesPath;
            query.LoadFromFile(System.IO.Path.Combine(queriesFolderPath, queryName + ".xml"));

        }

        /// <summary>
        /// Saves query by its name. The actual behavior must be implemented in the descendant
        /// </summary>
        /// <param name="query">A Query object.</param>
        /// <param name="queryName">Name of the query.</param>
        protected override void SaveQueryByName(Query query, string queryName) {
            string queriesFolderPath = queriesPath;
            query.SaveToFile(System.IO.Path.Combine(queriesFolderPath, queryName + ".xml"));
        }


        /// <summary>
        /// Creates and returns a DataSet object by SQL statement.
        /// </summary>
        /// <param name="sql">The SQL.</param>
        /// <returns></returns>
        protected override DataSet GetDataSetBySql(string sql) {
            try 
            {
                DataSet dataSet = new DataSet();
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = connectionString;
                conn.Open();
                SqlCommand command = new SqlCommand(sql, conn);
                SqlDataAdapter dbAdapter = new SqlDataAdapter(command);
                dbAdapter.Fill(dataSet);

                //Start
                //List<Liki.App.Service.DTO.CustomerDTO> lstCustomers = new List<Liki.App.Service.DTO.CustomerDTO>();
                //if (dataSet.Tables[0].Rows.Count > 0)
                //{

                //    lstCustomers = (from DataRow row in dataSet.Tables[0].Rows

                //           select new Liki.App.Service.DTO.CustomerDTO
                //           {
                //               CustomerID = Convert.ToInt32(row["Customers CustomerID"]),
                //               FirstName = row["Customers FirstName"].ToString(),
                //               LastName = row["Customers LastName"].ToString(),
                //               EmailAddress = row["Customers EmailAddress"].ToString()
                //           }).ToList();
                //    RedirectToAction("RedirectToSearchResult", lstCustomers);
                //}
                //End

                return dataSet;
            }
            catch (Exception e) {
                DataSet errorDataSet = new DataSet();
                DataTable errorTable = new DataTable("Error");
                string errorColumnHeader = e.GetType().Name;
                errorTable.Columns.Add(errorColumnHeader);
                errorDataSet.Tables.Add(errorTable);
                DataRow errorRow = errorTable.NewRow();
                errorRow[errorColumnHeader] = e.Message;
                errorTable.Rows.Add(errorRow);
                return errorDataSet;
            }
        }

        public ActionResult RedirectToSearchResult(List<Liki.App.Service.DTO.CustomerDTO> lstCustomers)
        {
            return View("SearchResult", lstCustomers);
        }

        protected override List<ListItem> CoreGetNamedList(string listName) {
            List<ListItem> list = new List<ListItem>();
            list.Add(new ListItem("11", "AAAA"));
            list.Add(new ListItem("22", "BBBB"));
            list.Add(new ListItem("33", "CCCC"));
            list.Add(new ListItem("44", "DDDD"));
            return list;
        }
        #endregion


    }
}
