using Microsoft.Data.SqlClient;
using ProductStoreClassLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProductStoreClassLibrary
{
    public partial class ServerRequests
    {
        static string connectionString = @"Data Source=.\SQLEXPRESS; Initial Catalog=PP2023_KozlovS_ISP3120; Integrated Security=True; TrustServerCertificate=True";

        

        public static bool RegisterUser(User user, string secondPassword, bool enterIntoDB)
        {
            bool isProcessed = false;
            // Если в номере телефона не имеются символы, перечисленные в регулярном выражении
            if (!Regex.IsMatch(user.PhoneNumber, @"^\+7\d{10}$"))
            {
                throw new Exception("Номер телефона неверен!");
            }
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand($"SELECT PhoneNumber FROM [User] WHERE PhoneNumber = \'{user.PhoneNumber}\'", sqlConnection);

                // Если пользователь под данным номером телефона уже существует
                if (sqlCommand.ExecuteScalar() != null)
                {
                    throw new Exception("Пользователь с данным номером телефона уже существует!");
                }
            }
            // Если пароль не введён
            if (string.IsNullOrEmpty(user.Password))
            {
                throw new Exception("Пароль не введён!");
            }
            // Если длина пароля не находится в промежутке от 8 до 32 включительно
            else if (user.Password.Length < 8 || user.Password.Length > 32)
            {
                throw new Exception("Длина пароля должна находится в промежутке от 8 до 32 включительно!");
            }
            // Если в пароле отсутствуют строчные, прописные, не алфавитно-числовые символы или цифры
            else if (!(Regex.IsMatch(user.Password, @"\W") &&
                       Regex.IsMatch(user.Password, @"\d") &&
                       (Regex.IsMatch(user.Password, @"[a-z]")
                       || Regex.IsMatch(user.Password, @"[а-я]")) &&
                       (Regex.IsMatch(user.Password, @"[A-Z]")
                       || Regex.IsMatch(user.Password, @"[А-Я]"))))
            {
                throw new Exception("В пароле отсутствуют строчные, прописные, не алфавитно-числовые символы или цифры!");
            }
            // Если поле с повторным вводом пароля пустое
            else if (string.IsNullOrEmpty(secondPassword))
            {
                throw new Exception("Повторите пароль");
            }
            // Если пароль не соответствует повторному вводу пароля
            else if (user.Password != secondPassword)
            {
                throw new Exception("Пароли не совпадают!");
            }
            else
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    // Нужно ли добавлять новую запись в бд (для теста)
                    if (enterIntoDB)
                    {
                        // Шифрование пароля в MD5
                        MD5 md5 = new MD5CryptoServiceProvider();
                        byte[] checkSum = md5.ComputeHash(Encoding.UTF8.GetBytes(user.Password));
                        string PasswordResult = BitConverter.ToString(checkSum).Replace("-", string.Empty);

                        // Создание аккаунта
                        SqlCommand sqlCommand = new SqlCommand($"INSERT INTO [User](PhoneNumber, Password, FullName, RoleID) VALUES (@PhoneNumber, @Password, @FullName, @RoleID)", sqlConnection);

                        sqlCommand.Parameters.Add("@PhoneNumber", SqlDbType.NVarChar).Value = user.PhoneNumber;
                        sqlCommand.Parameters.Add("@Password", SqlDbType.NChar).Value = PasswordResult;
                        sqlCommand.Parameters.Add("@FullName", SqlDbType.NVarChar).Value = user.FullName;
                        sqlCommand.Parameters.Add("@RoleID", SqlDbType.Int).Value = 2;

                        try
                        {
                            sqlCommand.ExecuteNonQuery();
                        }
                        catch (Exception)
                        {
                            throw new Exception("Произошла ошибка на стороне сервера");
                        }
                    }
                }
                isProcessed = true;
            }
            return isProcessed;
        }

        public static bool UserAuthorization(User user, out ServerRequests serverRequests)
        {
            if (!Regex.IsMatch(user.PhoneNumber, @"^\+7\d{10}$"))
            {
                throw new Exception("Номер телефона неверен");
            }
            else if (user.Password == string.Empty)
            {
                throw new Exception("Пароль не введён!");
            }
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand command = new SqlCommand($"SELECT * FROM [User] WHERE PhoneNumber = \'{user.PhoneNumber}\'", sqlConnection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    reader.Read();
                    // Если пользователя с введённым номером телефона не существует
                    if (!reader.HasRows)
                    {
                        throw new Exception("Такого пользователя не существует!");
                    }

                    string password = reader["Password"].ToString();

                    // Шифрование пароля в MD5
                    MD5 md5 = new MD5CryptoServiceProvider();
                    byte[] checkSum = md5.ComputeHash(Encoding.UTF8.GetBytes(user.Password));
                    string passResult = BitConverter.ToString(checkSum).Replace("-", string.Empty);

                    // Если пароль из базы данных соответствует введённому паролю
                    if (password == passResult)
                    {
                        user = new User()
                        {
                            ID = Convert.ToInt32(reader["ID"]),
                            PhoneNumber = user.PhoneNumber,
                            Password = password,
                            FullName = reader["FullName"].ToString(),
                            RoleID = Convert.ToInt32(reader["RoleID"])
                        };
                        serverRequests = new ServerRequests(user);
                        return true;
                    }
                    else
                    {
                        throw new Exception("Неверный пароль!");
                    }
                }
            }
        }

        public static object GetObject(string entity, string objectString, int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand($"SELECT {objectString} FROM [{entity}] WHERE ID = {id}", sqlConnection);

                return sqlCommand.ExecuteScalar();
            }
        }
    }
}
