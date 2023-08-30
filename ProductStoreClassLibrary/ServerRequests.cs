using Microsoft.Data.SqlClient;
using ProductStoreClassLibrary.Entities;
using System.Data;
using System.Runtime.Remoting;

namespace ProductStoreClassLibrary
{
    public partial class ServerRequests
    {
        public User CurrentUser { get; set; }
        public ServerRequests(User currentUser)
        {
            CurrentUser = currentUser;
        }

        public bool AddEntity<T>(T entity)
        {
            bool result = false;
            string sqlRequest;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                if (typeof(T) == typeof(Product))
                {
                    Product product = (Product)Convert.ChangeType(entity, typeof(Product));
                    sqlRequest = "INSERT INTO [Product] VALUES (" +
                                 "@Name, @Price, @Quantity, @MinQuantity, @Unit, @CategoryID)";
                    SqlCommand sqlCommand = new SqlCommand(sqlRequest, sqlConnection);
                    sqlCommand.Parameters.Add("@Name", SqlDbType.NVarChar).Value = product.Name;
                    sqlCommand.Parameters.Add("@Price", SqlDbType.Money).Value = product.Price;
                    sqlCommand.Parameters.Add("@Quantity", SqlDbType.Decimal).Value = product.Quantity;
                    sqlCommand.Parameters.Add("@MinQuantity", SqlDbType.Decimal).Value = product.MinQuantity;
                    sqlCommand.Parameters.Add("@Unit", SqlDbType.NVarChar).Value = product.Unit;
                    sqlCommand.Parameters.Add("@CategoryID", SqlDbType.Int).Value = product.CategoryID;

                    result = Convert.ToBoolean(sqlCommand.ExecuteNonQuery());
                }
                else if (typeof(T) == typeof(Category))
                {
                    Category category = (Category)Convert.ChangeType(entity, typeof(Category));
                    sqlRequest = "INSERT INTO [Category] VALUES (@Name)";
                    SqlCommand sqlCommand = new SqlCommand(sqlRequest, sqlConnection);
                    sqlCommand.Parameters.Add("@Name", SqlDbType.NVarChar).Value = category.Name;

                    result = Convert.ToBoolean(sqlCommand.ExecuteNonQuery());
                }
                else if (typeof(T) == typeof(Order))
                {
                    Order order = (Order)Convert.ChangeType(entity, typeof(Order));
                    sqlRequest = "INSERT INTO [Order] VALUES (@BuyerID, " +
                                 "@ProductID, @Quantity, @Price, @Date, NULL)";
                    SqlCommand sqlCommand = new SqlCommand(sqlRequest, sqlConnection);
                    sqlCommand.Parameters.Add("@BuyerID", SqlDbType.Int).Value = CurrentUser.ID;
                    sqlCommand.Parameters.Add("@ProductID", SqlDbType.Int).Value = order.ProductID;
                    sqlCommand.Parameters.Add("@Quantity", SqlDbType.Decimal).Value = order.Quantity;
                    sqlCommand.Parameters.Add("@Price", SqlDbType.Decimal).Value = order.Price;
                    sqlCommand.Parameters.Add("@Date", SqlDbType.DateTime).Value = order.Date;


                    result = Convert.ToBoolean(sqlCommand.ExecuteNonQuery());
                }
            }
            return result;
        }

        public bool EditEntity<T>(T entity)
        {
            bool result = false;
            string sqlRequest;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                if (typeof(T) == typeof(Product))
                {
                    Product product = (Product)Convert.ChangeType(entity, typeof(Product));
                    sqlRequest = "UPDATE [Product] SET " +
                                 "Name = @Name, Price = @Price, Quantity = @Quantity, " +
                                 "MinQuantity = @MinQuantity, Unit = @Unit, CategoryID = @CategoryID " +
                                 "WHERE [ID] = @ID";
                    SqlCommand sqlCommand = new SqlCommand(sqlRequest, sqlConnection);
                    sqlCommand.Parameters.Add("@Name", SqlDbType.NVarChar).Value = product.Name;
                    sqlCommand.Parameters.Add("@Price", SqlDbType.Money).Value = product.Price;
                    sqlCommand.Parameters.Add("@Quantity", SqlDbType.Decimal).Value = product.Quantity;
                    sqlCommand.Parameters.Add("@MinQuantity", SqlDbType.Decimal).Value = product.MinQuantity;
                    sqlCommand.Parameters.Add("@Unit", SqlDbType.NVarChar).Value = product.Unit;
                    sqlCommand.Parameters.Add("@CategoryID", SqlDbType.Int).Value = product.CategoryID;
                    sqlCommand.Parameters.Add("@ID", SqlDbType.Int).Value = product.ID;

                    result = Convert.ToBoolean(sqlCommand.ExecuteNonQuery());
                }
            }
            return result;
        }

        public bool EditOrderAccept(Order order, bool isAccepted)
        {
            bool result = false;
            string sqlRequest;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                if (isAccepted)
                {
                    sqlRequest = "SELECT Quantity FROM Product WHERE [ID] = @ID";
                    SqlCommand sqlCommandQuantity = new SqlCommand(sqlRequest, sqlConnection);
                    sqlCommandQuantity.Parameters.Add("@ID", SqlDbType.Int).Value = order.ProductID;

                    int quantity = Convert.ToInt32(sqlCommandQuantity.ExecuteScalar());

                    if (order.Quantity > quantity)
                    {
                        throw new Exception("Количество в заявке не должно быть больше количества на складе!");
                    }

                    sqlRequest = "UPDATE [Product] SET Quantity = @finalQuantity WHERE [ID] = @ID";
                    sqlCommandQuantity = new SqlCommand(sqlRequest, sqlConnection);
                    sqlCommandQuantity.Parameters.Add("@ID", SqlDbType.Int).Value = order.ProductID;
                    sqlCommandQuantity.Parameters.Add("@finalQuantity", SqlDbType.Decimal).Value = quantity - order.Quantity;
                    bool isExecuted = Convert.ToBoolean(sqlCommandQuantity.ExecuteNonQuery());
                    if (!isExecuted)
                    {
                        return false;
                    }
                }

                sqlRequest = "UPDATE [Order] SET IsAccepted = @IsAccepted WHERE [ID] = @ID";
                SqlCommand sqlCommand = new SqlCommand(sqlRequest, sqlConnection);
                sqlCommand.Parameters.Add("@IsAccepted", SqlDbType.Bit).Value = isAccepted;
                sqlCommand.Parameters.Add("@ID", SqlDbType.Int).Value = order.ID;

                result = Convert.ToBoolean(sqlCommand.ExecuteNonQuery());
            }
            return result;
        }

        public bool DeleteEntity<T>(T entity)
        {
            if (CurrentUser.RoleID == 2)
            {
                return false;
            }
            bool result = false;
            string sqlRequest;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                if (typeof(T) == typeof(Product))
                {
                    Product product = (Product)Convert.ChangeType(entity, typeof(Product));
                    sqlRequest = "DELETE FROM [Product] WHERE [ID] = @ID";
                    SqlCommand sqlCommand = new SqlCommand(sqlRequest, sqlConnection);
                    sqlCommand.Parameters.Add("@ID", SqlDbType.Int).Value = product.ID;

                    result = Convert.ToBoolean(sqlCommand.ExecuteNonQuery());
                }
            }
            return result;
        }

        public List<T> GetEntities<T>()
        {
            List<T> entities = new List<T>();
            string sqlRequest = "";
            if (typeof(T) == typeof(Product))
            {
                sqlRequest = "SELECT * FROM [Product]";
                switch (CurrentUser.RoleID)
                {
                    case 2:
                        sqlRequest += " WHERE Quantity > 0";
                        break;
                }
            }
            else if (typeof(T) == typeof(Category))
            {
                sqlRequest = "SELECT * FROM [Category]";
            }
            else if (typeof(T) == typeof(Order))
            {
                sqlRequest = "SELECT * FROM [Order]";
                switch(CurrentUser.RoleID)
                {
                    case 1:
                        sqlRequest += $" ORDER BY [ID] DESC";
                        break;
                    case 2:
                        sqlRequest += $" WHERE BuyerID = {CurrentUser.ID} ORDER BY [ID] DESC";
                        break;
                }
            }

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand(sqlRequest, sqlConnection);
                
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    if (typeof(T) == typeof(Product))
                    {
                        while (reader.Read())
                        {

                            object entity = new Product()
                            {
                                ID = Convert.ToInt32(reader["ID"]),
                                Name = Convert.ToString(reader["Name"]),
                                Price = Convert.ToDouble(reader["Price"]),
                                Quantity = Convert.ToInt32(reader["Quantity"]),
                                MinQuantity = Convert.ToInt32(reader["MinQuantity"]),
                                Unit = Convert.ToString(reader["Unit"]),
                                CategoryID = Convert.ToInt32(reader["CategoryID"])
                            };

                            entities.Add((T)Convert.ChangeType(entity, typeof(T)));
                        }
                    }
                    else if (typeof(T) == typeof(Order))
                    {
                        while (reader.Read())
                        {
                            bool? isAccepted;
                            if (reader["IsAccepted"] == DBNull.Value)
                            {
                                isAccepted = null;
                            }
                            else
                            {
                                isAccepted = Convert.ToBoolean(reader["IsAccepted"]);
                            }
                            object entity = new Order()
                            {
                                ID = Convert.ToInt32(reader["ID"]),
                                BuyerID = Convert.ToInt32(reader["BuyerID"]),
                                ProductID = Convert.ToInt32(reader["ProductID"]),
                                Quantity = Convert.ToInt32(reader["Quantity"]),
                                Price = Convert.ToDouble(reader["Price"]),
                                Date = Convert.ToDateTime(reader["Date"]),
                                IsAccepted = isAccepted
                            };

                            entities.Add((T)Convert.ChangeType(entity, typeof(T)));
                        }
                    }
                    else if (typeof(T) == typeof(Category))
                    {
                        while (reader.Read())
                        {

                            object entity = new Category()
                            {
                                ID = Convert.ToInt32(reader["ID"]),
                                Name = Convert.ToString(reader["Name"])
                            };

                            entities.Add((T)Convert.ChangeType(entity, typeof(T)));
                        }
                    }
                }
            }
            return entities;
        }


    }
}