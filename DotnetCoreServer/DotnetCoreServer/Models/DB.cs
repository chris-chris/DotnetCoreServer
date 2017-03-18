using System;
using MySql.Data.MySqlClient;

public class DB
{
    public static MySqlConnection GetDB()
    {
        MySqlConnection connection = new MySqlConnection
        {
            ConnectionString = "server=girlaction.czzkqlp6lf2e.ap-northeast-1.rds.amazonaws.com;user id=sjhshy;password=dbslxlzoavm1;persistsecurityinfo=True;port=3306;database=girlaction"
        };
        connection.Open();
        return connection;
    }
}