using PipeLightsOrderManagementApp.Models;
using System.Data.SqlClient;

namespace PipeLightsOrderManagementApp.Repositories
{
    public class OperationRepository
    {
        public SqlConnection Connection { get; set; }

        public OperationRepository()
        {
            Connection = new SqlConnection("Server=tcp:afs-server.database.windows.net,1433;Initial Catalog=test;Persist Security Info=False;User ID=afs-admin;Password=autofastest1!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

        public List<OrderDto> Search(SearchModel search)
        {
            List<OrderDto> list = new List<OrderDto>();

            var sql = "SELECT * FROM PipelightsOrders WHERE OrderNumber LIKE @OrderNumber OR FirstName LIKE @FirstName OR LastName LIKE @LastName OR Email LIKE @Email OR Adress LIKE @Adress OR Lamp LIKE @Lamp OR Price LIKE @Price OR Color LIKE @Color ";

            using (SqlCommand command = new SqlCommand(sql, Connection))
            {
                Connection.Open();

                command.Parameters.AddWithValue("@OrderNumber", "%" + search.searchString + "%");
                command.Parameters.AddWithValue("@FirstName", "%" + search.searchString + "%");
                command.Parameters.AddWithValue("@LastName", "%" + search.searchString + "%");
                command.Parameters.AddWithValue("@Email", "%" + search.searchString + "%");
                command.Parameters.AddWithValue("@Adress", "%" + search.searchString + "%");
                command.Parameters.AddWithValue("@Lamp", "%" + search.searchString + "%");
                command.Parameters.AddWithValue("@Price", "%" + search.searchString + "%");
                command.Parameters.AddWithValue("@Color", "%" + search.searchString + "%");
                command.Parameters.AddWithValue("@DeliveryDate", "%" + search.searchString + "%");
                command.Parameters.AddWithValue("@OrderDate", "%" + search.searchString + "%");
                command.Parameters.AddWithValue("@Channel", "%" + search.searchString + "%");
                command.Parameters.AddWithValue("@Characteristics", "%" + search.searchString + "%");


                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        OrderDto order = new OrderDto()
                        {
                            Id = (int)reader["Id"],
                            OrderNumber = (int)reader["OrderNumber"],
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            Email = reader["Email"].ToString(),
                            Adress = reader["Adress"].ToString(),
                            Lamp = reader["Lamp"].ToString(),
                            Price = (int)reader["Price"],
                            Color = reader["Color"].ToString(),
                            DeliveryDate = (DateTime)reader["DeliveryDate"],
                            OrderDate = (DateTime)reader["OrderDate"],
                            Channel = reader["Channel"].ToString(),
                            Characteristics = reader["Characteristics"].ToString(),
                        };
                        list.Add(order);
                    }
                    reader.Close();
                }
                Connection.Close();
            }
            return list;
        }


        public List<OrderDto> SortByFirstName()
        {

            List<OrderDto> list = new List<OrderDto>();


            var sql = "SELECT * FROM PipelightsOrders ORDER BY FirstName";

            using (SqlCommand command = new SqlCommand(sql, Connection))
            {
                Connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        OrderDto order = new OrderDto()
                        {
                            Id = (int)reader["Id"],
                            OrderNumber = (int)reader["OrderNumber"],
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            Email = reader["Email"].ToString(),
                            Adress = reader["Adress"].ToString(),
                            Lamp = reader["Lamp"].ToString(),
                            Price = (int)reader["Price"],
                            Color = reader["Color"].ToString(),
                            DeliveryDate = (DateTime)reader["DeliveryDate"],
                            OrderDate = (DateTime)reader["OrderDate"],
                            Channel = reader["Channel"].ToString(),
                            Characteristics = reader["Characteristics"].ToString(),
                        };
                        list.Add(order);
                    }
                    reader.Close();
                }
                Connection.Close();
            }
            return list;

        }


        public List<OrderDto> SortByFirstNameDesc()
        {

            List<OrderDto> list = new List<OrderDto>();


            var sql = "SELECT * FROM PipelightsOrders ORDER BY FirstName DESC";

            using (SqlCommand command = new SqlCommand(sql, Connection))
            {
                Connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        OrderDto order = new OrderDto()
                        {
                            Id = (int)reader["Id"],
                            OrderNumber = (int)reader["OrderNumber"],
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            Email = reader["Email"].ToString(),
                            Adress = reader["Adress"].ToString(),
                            Lamp = reader["Lamp"].ToString(),
                            Price = (int)reader["Price"],
                            Color = reader["Color"].ToString(),
                            DeliveryDate = (DateTime)reader["DeliveryDate"],
                            OrderDate = (DateTime)reader["OrderDate"],
                            Channel = reader["Channel"].ToString(),
                            Characteristics = reader["Characteristics"].ToString(),
                        };
                        list.Add(order);
                    }
                    reader.Close();
                }
                Connection.Close();
            }
            return list;

        }


        public List<OrderDto> SortByPrice()
        {

            List<OrderDto> list = new List<OrderDto>();


            var sql = "SELECT * FROM PipelightsOrders ORDER BY Price ";

            using (SqlCommand command = new SqlCommand(sql, Connection))
            {
                Connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        OrderDto order = new OrderDto()
                        {
                            Id = (int)reader["Id"],
                            OrderNumber = (int)reader["OrderNumber"],
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            Email = reader["Email"].ToString(),
                            Adress = reader["Adress"].ToString(),
                            Lamp = reader["Lamp"].ToString(),
                            Price = (int)reader["Price"],
                            Color = reader["Color"].ToString(),
                            DeliveryDate = (DateTime)reader["DeliveryDate"],
                            OrderDate = (DateTime)reader["OrderDate"],
                            Channel = reader["Channel"].ToString(),
                            Characteristics = reader["Characteristics"].ToString(),
                        };
                        list.Add(order);
                    }
                    reader.Close();
                }
                Connection.Close();
            }
            return list;

        }

        public List<OrderDto> SortByPriceDesc()
        {

            List<OrderDto> list = new List<OrderDto>();


            var sql = "SELECT * FROM PipelightsOrders ORDER BY Price DESC ";

            using (SqlCommand command = new SqlCommand(sql, Connection))
            {
                Connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        OrderDto order = new OrderDto()
                        {
                            Id = (int)reader["Id"],
                            OrderNumber = (int)reader["OrderNumber"],
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            Email = reader["Email"].ToString(),
                            Adress = reader["Adress"].ToString(),
                            Lamp = reader["Lamp"].ToString(),
                            Price = (int)reader["Price"],
                            Color = reader["Color"].ToString(),
                            DeliveryDate = (DateTime)reader["DeliveryDate"],
                            OrderDate = (DateTime)reader["OrderDate"],
                            Channel = reader["Channel"].ToString(),
                            Characteristics = reader["Characteristics"].ToString(),
                        };
                        list.Add(order);
                    }
                    reader.Close();
                }
                Connection.Close();
            }
            return list;

        }

    }
}
