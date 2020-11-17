using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Task3.Models;

namespace Task3.Services
{
    public class SqlQuery
    {
		string   connectionString = @"Data Source=(local);Initial Catalog=test1;Integrated Security=True";

		public SubmissionResponse	QuerySave(string query, SqlParameter[] parameters)
		{
			using (var connection = new SqlConnection(connectionString))
			{
				using (var cmd = new SqlCommand(query, connection))
				{
					if (parameters != null && parameters.Length != 0)
					{
						cmd.Parameters.AddRange(parameters);
					}

					connection.Open();

					cmd.ExecuteNonQuery();

					return new SubmissionResponse { Success = true };
				}

			}
		}
		public  DataTable ExecuteReader(string query,params SqlParameter[] parameters)
        {
			using (var connection = new SqlConnection(connectionString))
			{
				using (var cmd = new SqlDataAdapter(query, connection))
				{
					if(parameters!=null ||parameters.Any() )
                    {
						cmd.SelectCommand.Parameters.AddRange(parameters);
					}
					var datatable = new DataTable();
					cmd.Fill(datatable);
					return datatable;



				}
			}
				}
	}
}
