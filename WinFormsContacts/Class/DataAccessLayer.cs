using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsContacts.Models;

namespace WinFormsContacts.Class
{
    class DataAccessLayer
    {
        private SqlConnection conn = new SqlConnection("");//Agregar la conecxion a la Bd

        public void InsertContact( ContactModel contactModel)
        {
            try
            {
                conn.Open();
                string query = @"INSERT INTO Contacts (FirstName, LastName, Phone, Address)
                                 VALUES(@FirstName, @LastName, @Phone, @Address)";
                SqlParameter firstName = new SqlParameter();
                firstName.ParameterName = "@FirstName";
                firstName.Value = contactModel.FirstName;
                firstName.DbType = System.Data.DbType.String;

                SqlParameter lastName = new SqlParameter("@LastName", contactModel.LastName);
                SqlParameter phone = new SqlParameter("@Phone", contactModel.Phone);
                SqlParameter address = new SqlParameter("@Address", contactModel.Address);

                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.Add(firstName);
                command.Parameters.Add(lastName);
                command.Parameters.Add(phone);
                command.Parameters.Add(address);

                command.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public List<ContactModel> GetContacts(string search = null)
        {
            List<ContactModel> contacts = new List<ContactModel>();
            try
            {
                conn.Open();
                string query = @"SELECT  id,FirstName, LastName, Phone, Address
                                    FROM Contacts";
                SqlCommand command = new SqlCommand();

                if (!string.IsNullOrEmpty(search))
                {
                    query += @" WHERE id LIKE @searchFirstName LIKE @search OR LastName LIKE @search OR Phone LIKE @search OR 
                                Address LIKE @search";
                    command.Parameters.Add(new SqlParameter("@Search", $"%{search}%"));
                }

                command.CommandText = query;
                command.Connection = conn;

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    contacts.Add(new ContactModel
                    {
                        id = int.Parse(reader["id"].ToString()),
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        Phone = reader["Phone"].ToString(),
                        Address =reader["Address"].ToString()
                    });
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }
            return contacts;
        }

        public void UpdateContact (ContactModel contactModel)
        {
            try
            {
                conn.Open();
                string query = @"UPDATE Contacts
                                    SET FirstName = @FirstName,
                                        LastName = @LastName,
                                        Phone = @Phone,
                                        Address = @Address
                                        WHERE id = @id";
                SqlParameter id = new SqlParameter("@id", contactModel.id);
                SqlParameter firstName = new SqlParameter("@FirstName", contactModel.FirstName);
                SqlParameter lastName = new SqlParameter("@LastName", contactModel.LastName);
                SqlParameter phone = new SqlParameter("@Phone", contactModel.Phone);
                SqlParameter address = new SqlParameter("@Address", contactModel.Address);

                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.Add(id);
                command.Parameters.Add(firstName);
                command.Parameters.Add(lastName);
                command.Parameters.Add(phone);
                command.Parameters.Add(address);

                command.ExecuteNonQuery();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public void DeleteContact(int id)
        {
            try
            {
                conn.Open();
                string query = @"DELETE FROM Contacts WHERE id=@id";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.Add(new SqlParameter("@id",id));
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
