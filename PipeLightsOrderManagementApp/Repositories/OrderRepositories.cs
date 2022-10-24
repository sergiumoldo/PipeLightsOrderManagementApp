using PipeLightsOrderManagementApp.Models;
using System.Data.SqlClient;


namespace PipeLightsOrderManagementApp.Repositories
{
    public class OrderRepositories
    {
        public SqlConnection Connection { get; set; }

        public OrderRepositories()
        {
             Connection = new SqlConnection("Server=tcp:afs-server.database.windows.net,1433;Initial Catalog=test;Persist Security Info=False;User ID=afs-admin;Password=autofastest1!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

        public List<OrderDto> GetAll()
        {

            List<OrderDto> list = new List<OrderDto>();


            var sql = "SELECT * FROM PipelightsOrders";

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


        public OrderDto GetById(int Id)
        {
            OrderDto sys = null;
            try
            {
                var sql = "Select * From PipelightsOrders Where Id=@Id";
                using (SqlCommand command = new SqlCommand(sql, Connection))
                {
                    command.Parameters.AddWithValue("@Id", Id);
                    Connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            sys = new OrderDto()
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

                        }
                        reader.Close();
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return sys;
        }


        public int Insert(OrderDto model)
        {
            var sql = "INSERT INTO PipelightsOrders([OrderNumber],[FirstName],[LastName],[Email],[Adress],[Lamp],[Price],[Color],[OrderDate],[DeliveryDate],[Channel],[Characteristics]) VALUES(@OrderNumber, @FirstName, @LastName, @Email, @Adress, @Lamp, @Price, @Color, @DeliveryDate, @OrderDate, @Channel, @Characteristics ) ";

            using (SqlCommand command = new SqlCommand(sql, Connection))
            {

                {
                    command.Parameters.AddWithValue("@OrderNumber", model.OrderNumber);
                    command.Parameters.AddWithValue("@FirstName", model.FirstName);
                    command.Parameters.AddWithValue("@LastName", model.LastName);
                    command.Parameters.AddWithValue("@Email", model.Email);
                    command.Parameters.AddWithValue("@Adress", model.Adress);
                    command.Parameters.AddWithValue("@Lamp", model.Lamp);
                    command.Parameters.AddWithValue("@Price", model.Price);
                    command.Parameters.AddWithValue("@Color", model.Color);
                    command.Parameters.AddWithValue("@DeliveryDate", model.DeliveryDate);
                    command.Parameters.AddWithValue("@OrderDate", model.OrderDate);
                    command.Parameters.AddWithValue("@Channel", model.Channel);
                    command.Parameters.AddWithValue("@Characteristics", model.Characteristics);


                    Connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        reader.Close();
                    }

                    Connection.Close();
                }
                return 0;

            }

        }

        public void Delete(int id)
        {
            try
            {
                var sql = "DELETE FROM PipelightsOrders Where Id = @Id";

                using (SqlCommand command = new SqlCommand(sql, Connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    Connection.Open();
                    var result = command.ExecuteNonQuery();

                    return;
                }
            }
            catch (Exception)
            {
                return;
            }
            finally
            {
                Connection.Close();
            }
        }


        public void Update(OrderDto model)
        {
            var sql = "UPDATE PipelightsOrders SET OrderNumber=@OrderNumber, " +
                "FirstName=@FirstName, LastName=@LastName, Email=@Email," +
                " Adress=@Adress, Lamp=@Lamp, Price=@Price, Color=@Color, " +
                "DeliveryDate=@DeliveryDate, OrderDate=@OrderDate, " +
                "Channel=@Channel,Characteristics=@Characteristics Where Id=@Id";

            using (SqlCommand command = new SqlCommand(sql, Connection))
            {

                {
                    command.Parameters.AddWithValue("@Id", model.Id);
                    command.Parameters.AddWithValue("@OrderNumber", model.OrderNumber);
                    command.Parameters.AddWithValue("@FirstName", model.FirstName);
                    command.Parameters.AddWithValue("@LastName", model.LastName);
                    command.Parameters.AddWithValue("@Email", model.Email);
                    command.Parameters.AddWithValue("@Adress", model.Adress);
                    command.Parameters.AddWithValue("@Lamp", model.Lamp);
                    command.Parameters.AddWithValue("@Price", model.Price);
                    command.Parameters.AddWithValue("@Color", model.Color);
                    command.Parameters.AddWithValue("@DeliveryDate", model.DeliveryDate);
                    command.Parameters.AddWithValue("@OrderDate", model.OrderDate);
                    command.Parameters.AddWithValue("@Channel", model.Channel);
                    command.Parameters.AddWithValue("@Characteristics", model.Characteristics);


                    Connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        reader.Close();
                    }

                    Connection.Close();
                }
                return;
            }

        }


    }
}
