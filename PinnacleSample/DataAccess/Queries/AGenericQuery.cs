using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PinnacleSample.DataAccess.Queries
{
    public abstract class AGenericQuery<TReturnType> where TReturnType : new()
    {
        protected SqlParameter[] __Parameters;
        protected string __ConnectionString;

        public AGenericQuery()
        {
        }

        public AGenericQuery(string ConnectionString)
        {
            __ConnectionString = ConnectionString;
        }

        protected List<TReturnType> ExecuteQuery(string commandText)
        {
            using (SqlCommand _Command = DatabaseHelper.ConfigureStoredProcedureCommand(commandText, __Parameters, __ConnectionString))
            {
                return DatabaseHelper.MapResults<TReturnType>(_Command, Mapper);
            }
        }

        protected void ExecuteNonQuery(string commandText)
        {
            using (SqlCommand _Command = DatabaseHelper.ConfigureStoredProcedureCommand(commandText, __Parameters, __ConnectionString))
            {
                _Command.ExecuteNonQuery();
                DatabaseHelper.DisposeOfConnection(_Command);
            }
        }

        public virtual TReturnType ExecuteQuery()
        {
            throw new NotImplementedException();
        }

        public virtual void ExecuteNonQuery()
        {
            throw new NotImplementedException();
        }


        public virtual TReturnType Mapper(IDataRecord reader)
        {
            throw new NotImplementedException();
        }
    }
}
