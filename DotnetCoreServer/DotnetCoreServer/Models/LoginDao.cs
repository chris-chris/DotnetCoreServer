using MySql.Data.MySqlClient;
using System;

namespace DotnetCoreServer.Models
{
    public class LoginDao
    {
        public static User Login(User user){
            using (MySqlConnection conn = DB.GetDB())
            {   
                string query = String.Format(
                    "SELECT UserID, FacebookUserID, FacebookName, FacebookPhotoURL, Point  FROM tb_user WHERE FacebookUserID = {0}",
                     user.FacebookUserID);

                Console.WriteLine(query);

                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (MySqlDataReader reader = (MySqlDataReader)cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user.UserID = reader.GetInt64(0);
                        user.FacebookUserID = reader.GetString(1);
                        user.FacebookName = reader.GetString(2);
                        user.FacebookPhotoURL = reader.GetString(3);
                        user.Point = reader.GetInt32(4);
                    }
                }
            }
            return user;
        }

    }
}