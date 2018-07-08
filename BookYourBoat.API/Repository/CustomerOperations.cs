using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using BookYourBoat.API.Model;
using Microsoft.Extensions.Options;

namespace BookYourBoat.API.Repository
{
    public class CustomerOperations : ICustomerOperations
    {
        private readonly ConnectionStrings connectionStrings;
        public CustomerOperations(IOptions<ConnectionStrings> options)
        {
            connectionStrings = options.Value;
        }
        public List<Customer> GetListOfCustomers()
        {
            var listOfCustomers = new List<Customer>();
            try
            {
                string connString = connectionStrings.DbConnection;
                using (var sqlCn = new SqlConnection(connString))
                {
                    using (SqlCommand cmd = new SqlCommand("GETCUSTOMERLIST", sqlCn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        sqlCn.Open();
                        using (SqlDataReader sqdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            while (sqdr.Read())
                            {
                                listOfCustomers.Add(
                                    new Customer
                                    {
                                        Name = sqdr["Name"].ToString(),
                                        Address = new Address { AddressLine1 = sqdr["Address"].ToString() },
                                        Email = sqdr["Email"].ToString(),
                                        Phone = new Phone { Number = sqdr["Phone"].ToString() },
                                        IsActive = sqdr["IsActive"].ToString()
                                    }
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listOfCustomers;
        }

        public void SaveCustomer(Customer customer)
        {
            var result = "";
            var outParam = new SqlParameter("@ReturnCode", SqlDbType.NVarChar, 20)
            {
                Direction = ParameterDirection.Output
            };
            var sqParams = new SqlParameter[]{
                new SqlParameter("@Id", customer.Id),
                new SqlParameter("@Name", customer.Name),
                new SqlParameter("@Password", customer.Password),
                new SqlParameter("@Phone", customer.Phone.Number),
                new SqlParameter("@Email", customer.Email),
                new SqlParameter("@Address", customer.Address.AddressLine1),
                outParam
            };
            try
            {
                string connString = connectionStrings.DbConnection;
                using (SqlConnection sq = new SqlConnection(connString))
                {
                    sq.Open();
                    using (SqlCommand cmd = new SqlCommand("SaveCustomers", sq))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddRange(sqParams);
                        // cmd.ExecuteScalar();
                        var ret = cmd.ExecuteScalar();
                        if (ret != null)
                            result = Convert.ToString(ret);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
