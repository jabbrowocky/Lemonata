using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeFoSale
{
    static class db
    {
        private static void ExecuteSqlTransaction(string connectionString)
        {
            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    connection.Open();

            //    SqlCommand command = connection.CreateCommand();
            //    SqlTransaction transaction;

                // Start a local transaction.
                //transaction = connection.BeginTransaction("SampleTransaction");

                // Must assign both transaction object and connection
                // to Command object for a pending local transaction
                //command.Connection = connection;
                //command.Transaction = transaction;

            }
        }
}
