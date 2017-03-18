using MySql.Data.MySqlClient;
using System;

namespace DotnetCoreServer.Models
{
    public class UserDao
    {

        public static User FindUserByFUID(string FacebookUserID){
            User user = new User();
            using (MySqlConnection conn = DB.GetDB())
            {   
                string query = String.Format(
                    "SELECT UserID, FacebookUserID, FacebookName, FacebookPhotoURL, Point, CreatedAt FROM tb_user WHERE FacebookUserID = '{0}'",
                     FacebookUserID);

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
                        user.CreatedAt = reader.GetDateTime(5);
                        return user;
                    }
                }
            }
            return null;
        }
        
        public static User GetUser(Int64 UserID){
            User user = new User();
            using (MySqlConnection conn = DB.GetDB())
            {   
                string query = String.Format(
                    "SELECT UserID, FacebookUserID, FacebookName, FacebookPhotoURL, Point  FROM tb_user WHERE UserID = {0}",
                     UserID);

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

        public static User InsertUser(User user){
            using (MySqlConnection conn = DB.GetDB())
            {   
                string query = String.Format(
                    "INSERT INTO tb_user (FacebookUserID, FacebookName, FacebookPhotoURL, Point, CreatedAt) VALUES ('{0}','{1}','{2}',{3}, now())",
                     user.FacebookUserID, user.FacebookName, user.FacebookPhotoURL, 0);

                Console.WriteLine(query);

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            return user;
        }

    }
}