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

    connection
}