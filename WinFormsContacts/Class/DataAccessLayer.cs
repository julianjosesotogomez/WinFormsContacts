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
        private SqlConnection conn = new SqlConnection("Data Source=LOCALHOST;Initial Catalog=WinFormsContacts;Integrated Security=True");

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

        public List<ContactModel> GetContacts()
        {
            List<ContactModel> contacts = new List<ContactModel>();
            try
            {
                conn.Open();
                string query = @"SELECT id, FirstName, LastName, Phone, Address
                                    FROM Contacts";
                SqlCommand command = new SqlCommand(query, conn);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    contacts.Add(new ContactModel
                    {
                        id = int.Parse(reader["id"].ToString()),
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        Phone = reader["Phone"].ToString(),

                    });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
