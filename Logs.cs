using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Logs
{
    public ulong LogChannelID;
    public ulong ServerID;

    string connectionString = @"Server=ALEX_DESKTOP;Database=Discord Bot;Trusted_Connection=True;";

    SqlConnection connection;

    public void SetLogs()
    {
        SqlCommand command;
        string insertCommand = "INSERT INTO dbo.LogChannel (GuildID, ChannelID) VALUES (" + ServerID + ", " + LogChannelID + ")";
        string checkCommand = "SELECT COUNT(*) FROM [Discord Bot].[dbo].[LogChannel] WHERE [GuildID]=" + ServerID;
        connection = new SqlConnection(connectionString);

        bool flag = false;
        command = new SqlCommand(checkCommand);
        using (SqlCommand cmd = new SqlCommand(checkCommand, connection))
        {

            try
            {
                Console.WriteLine("[info] Opening server");
                connection.Open();
                Console.WriteLine("[info] Server open");
                int count = (int)cmd.ExecuteScalar();
                if (count > 0)
                    flag = true;

                if (flag == true)
                    Console.WriteLine("[ERROR] Current server already has log channel");
                else
                {
                    command = new SqlCommand(insertCommand, connection);
                    Console.WriteLine("[info] Setting log channel of server " + ServerID);
                    command.ExecuteNonQuery();
                    Console.WriteLine("[info] Set the long channel");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[ERROR] " + ex.Message);
            }
        }
        Console.WriteLine("[info] Closing connection");
        connection.Close();
        Console.WriteLine("[info] Connection closed");
    }
}