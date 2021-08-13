using Martian_Robots.Dtos;
using Martian_Robots.Services.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;

namespace Martian_Robots.Services
{
    public class SQLiteService : ISQLiteService
    {
        public SQLiteService()
        {
            SetupDatabase();
        }

        #region CRUD robot log

        public void CreateRobotLog(RobotLogJsonDto robotLogJsonDto)
        {
            using SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MartianRobots.sqlite;Version=3;");
            m_dbConnection.Open();
            string sql = $"insert into robotLogs (log) values ('{JsonConvert.SerializeObject(robotLogJsonDto)}')";

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            m_dbConnection.Close();
        }

        public List<RobotLogDto> GetRobotLogs(int maxItemsPerPage, int skipPage)
        {
            using SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MartianRobots.sqlite;Version=3;");
            m_dbConnection.Open();
            string sql = $"select * from robotLogs limit {maxItemsPerPage} offset {skipPage}";

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            var reader = command.ExecuteReader();

            List<RobotLogDto> resuls = new List<RobotLogDto>();
            while (reader.Read())
            {
                resuls.Add(new RobotLogDto((long)reader["id"], JsonConvert.DeserializeObject<RobotLogJsonDto>((string)reader["log"])));
            }
            m_dbConnection.Close();
            return resuls;
        }

        #endregion CRUD robot log

        private void SetupDatabase()
        {
            if (!File.Exists("MartianRobots.sqlite"))
            {
                SQLiteConnection.CreateFile("MartianRobots.sqlite");

                using SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MartianRobots.sqlite;Version=3;");
                m_dbConnection.Open();

                string sql = "create table robotLogs (id integer primary key , log varchar(500))";
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();

                sql = "create table stats (name text, value text)";
                command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();

                m_dbConnection.Close();
            }
        }
    }
}