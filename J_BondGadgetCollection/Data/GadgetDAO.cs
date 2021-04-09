using J_BondGadgetCollection.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace J_BondGadgetCollection.Data
     
{
    internal class GadgetDAO
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BondGadget;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        
        
        
        //Performs all operations on the database such as get all, create, delete,search etc.
        public List<GadgetModel> FetchAll()
        {

            List<GadgetModel> returnList = new List<GadgetModel>();

            //access database

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * from dbo.Gadgets";
                SqlCommand command = new SqlCommand(sqlQuery,connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //create a new gadget object and add that to the list to return
                        GadgetModel gadget = new GadgetModel();

                        gadget.Id = reader.GetInt32(0);
                        gadget.Name = reader.GetString(1);
                        gadget.Description = reader.GetString(2);
                        gadget.AppearsIn = reader.GetString(3);
                        gadget.WithThisActor = reader.GetString(4);

                        returnList.Add(gadget);

                    }
                }
            }




            return returnList;
        }
    }
}