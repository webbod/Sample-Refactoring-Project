using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace PinnacleSample.DataAccess.Queries
{
    public static class DatabaseHelper
    {
        public static string ConfigureConnectionString(string connectionString = null)
        {
            return connectionString ?? ConfigurationManager.ConnectionStrings["appDatabase"].ConnectionString;
        }

        public static SqlConnection CreateConnection(string connectionString = null)
        {
            return new SqlConnection(ConfigureConnectionString(connectionString));
        }

        public static SqlConnection EstablishOpenConnection(string connectionString = null)
        {
            var _Connection = CreateConnection(connectionString);
            _Connection.Open();

            return _Connection;
        }

        public static SqlCommand CreateCommand(string commandText, CommandType commandType, string connectionString = null)
        {
            return new SqlCommand
            {
                Connection = EstablishOpenConnection(connectionString),
                CommandType = commandType,
                CommandText = commandText
            };
        }

        public static SqlCommand CommandWithParameters(SqlCommand command, SqlParameter[] parameters)
        {
            command.Parameters.AddRange(parameters);
            return command;
        }

        public static SqlCommand ConfigureStoredProcedureCommand(string commandText, SqlParameter[] parameters = null, string connectionString = null)
        {
            return CommandWithParameters(
                CreateCommand(commandText, CommandType.StoredProcedure, connectionString), 
                parameters
            );
        }

        public static SqlDataReader CreateReader(SqlCommand command, CommandBehavior commandBehavior = CommandBehavior.CloseConnection)
        {
            return command.ExecuteReader(commandBehavior);
        }

        public static List<T> MapResults<T>(SqlCommand command, Func<IDataRecord, T> mapper) where T: new()
        {
            var _Output = new List<T>();
            
            using (var _Reader = CreateReader(command))
            {
                while (_Reader.Read())
                {
                    _Output.Add(mapper(_Reader));
                }
            }

            DisposeOfConnection(command);
            return _Output;
        }

        public static void DisposeOfConnection(SqlCommand command)
        {
            command.Connection.Dispose();
        }
    }
}
