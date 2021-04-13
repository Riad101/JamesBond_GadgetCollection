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

        internal int Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
               
                string sqlQuery =  "DELETE FROM dbo.Gadgets WHERE Id = @Id";
               

                //associate @id with Id parameter

                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;
               
                connection.Open();

                var deletedID = command.ExecuteNonQuery();

                return deletedID;

            }
;
        }

        internal List<GadgetModel> SearchForName(string searchPhrase)
        {
            List<GadgetModel> returnList = new List<GadgetModel>();

            //access database

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * from dbo.Gadgets WHERE NAME LIKE @searchForMe";                


                SqlCommand command = new SqlCommand(sqlQuery, connection);

                command.Parameters.Add("@searchForMe", System.Data.SqlDbType.NVarChar).Value = "%" + searchPhrase + "%";

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

        public GadgetModel FetchOne(int Id)
        {

             //access database

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * from dbo.Gadgets WHERE Id = @id";
                //associate @id with Id parameter

                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = Id;

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                GadgetModel gadget = new GadgetModel();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //create a new gadget object and add that to the list to return
                        

                        gadget.Id = reader.GetInt32(0);
                        gadget.Name = reader.GetString(1);
                        gadget.Description = reader.GetString(2);
                        gadget.AppearsIn = reader.GetString(3);
                        gadget.WithThisActor = reader.GetString(4);

                        
                    }
                }
                return gadget;

            }

            
        }


        //create one

        public int CreateOrUpdate(GadgetModel gadgetModel)
        {
            //if gadgetModel.id <=1 then create
            //if gadgetModel.id > 1 then update
            //access database

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "";

                if(gadgetModel.Id <= 0)
                {
                    sqlQuery = "INSERT INTO dbo.Gadgets Values(@Name, @Description, @AppearsIn, @WithThisActor)";
                }

                else
                {
                    sqlQuery = "UPDATE dbo.Gadgets SET Name = @Name, Description = @Description, AppearsIn = @AppearsIn, withThisActor = @WithThisActor WHERE Id = @Id";
                }
                    
                    
                
                //associate @id with Id parameter

                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = gadgetModel.Id;
                command.Parameters.Add("@Name", System.Data.SqlDbType.VarChar,1000).Value = gadgetModel.Name;
                command.Parameters.Add("@Description", System.Data.SqlDbType.VarChar, 1000).Value = gadgetModel.Description;
                command.Parameters.Add("@AppearsIn", System.Data.SqlDbType.VarChar, 1000).Value = gadgetModel.AppearsIn;
                command.Parameters.Add("@WithThisActor", System.Data.SqlDbType.VarChar, 1000).Value = gadgetModel.WithThisActor;

                connection.Open();

                var newID = command.ExecuteNonQuery();
                
                return newID;

            }

        }

        //delete one

        //update one

        //search for name

        //search for description
    }
}