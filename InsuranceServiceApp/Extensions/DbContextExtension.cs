using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace InsuranceServiceApp.Extensions
{

    internal static class DbContextExtension
    {
        public static DbCommand LoadStoredProc(this DbContext context, string storedProcName)
        {
            var cmd = context.Database.GetDbConnection().CreateCommand();
            cmd.CommandText = storedProcName;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            return cmd;
        }
        public static DbCommand WithSqlParam(this DbCommand cmd, string paramName, object paramValue)
        {
            if (string.IsNullOrEmpty(cmd.CommandText))
                throw new InvalidOperationException("Call LoadStoredProc before using this method");

            var param = cmd.CreateParameter();
            param.ParameterName = paramName;
            param.Value = paramValue;
            cmd.Parameters.Add(param);
            return cmd;
        }

        public static DbCommand WithSqlParamOutput(this DbCommand cmd, string paramName, object paramValue)
        {
            if (string.IsNullOrEmpty(cmd.CommandText))
                throw new InvalidOperationException("Call LoadStoredProc before using this method");

            var param = cmd.CreateParameter();
            param.ParameterName = paramName;
            param.Value = paramValue;
            param.DbType = DbType.Int64;
            param.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(param);
            return cmd;
        }

        private static IList<T> MapToList<T>(this DbDataReader dr)
        {
            var objList = new List<T>();
            var props = typeof(T).GetRuntimeProperties();

            var colMapping = dr.GetColumnSchema()
                .Where(x => props.Any(y => y.Name.ToLower() == x.ColumnName.ToLower()))
                .ToDictionary(key => key.ColumnName.ToLower());

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    T obj = Activator.CreateInstance<T>();
                    foreach (var prop in props)
                    {
                        if (!colMapping.Any(x => x.Key.ToLower() == prop.Name.ToLower()))
                            continue;
                        //try
                        //{
                        var val = dr.GetValue(colMapping[prop.Name.ToLower()].ColumnOrdinal.Value);
                        prop.SetValue(obj, val == DBNull.Value ? null : val);
                        //}
                        //catch
                        //{

                        //}
                    }
                    objList.Add(obj);
                }
            }
            return objList;
        }

        public static IList<T> ExecuteStoredProc<T>(this DbCommand command)
        {
            using (command)
            {
                if (command.Connection.State == System.Data.ConnectionState.Closed)
                    command.Connection.Open();
                try
                {
                    using (var reader = command.ExecuteReader())
                    {
                        return reader.MapToList<T>();
                    }
                }
                finally
                {
                    command.Connection.Close();
                }
            }
        }

        public static (IList<T>, IList<U>) ExecuteStoredProc<T, U>(this DbCommand command)
        {
            using (command)
            {
                if (command.Connection.State == System.Data.ConnectionState.Closed)
                    command.Connection.Open();
                try
                {
                    using (var reader = command.ExecuteReader())
                    {
                        var objectOne = reader.MapToList<T>();

                        reader.NextResult();

                        var objectTwo = reader.MapToList<U>();

                        return (objectOne, objectTwo);
                    }
                }
                finally
                {
                    command.Connection.Close();
                }
            }
        }

        /// <summary>
        /// Execution that takes OUTPUT PARAMETERS into consideration
        /// </summary
        /// <typeparam name="T"></typeparam>
        /// <param name="command"></param>
        /// <param name="outputParameters"></param>
        /// <returns></returns>
        public static (IList<T> returnObject, IList<KeyValuePair<string, object>> outputObject) ExecuteStoredProc<T>(this DbCommand command, List<string> outputParameters)
        {
            using (command)
            {
                if (command.Connection.State == System.Data.ConnectionState.Closed)
                    command.Connection.Open();
                try
                {
                    using (var reader = command.ExecuteReader())
                    {
                        List<KeyValuePair<string, object>> outputs = new List<KeyValuePair<string, object>>();
                        foreach (var outputParam in outputParameters)
                        {
                            var obj = command.Parameters[outputParam].Value;
                            outputs.Add(new KeyValuePair<string, object>(outputParam, obj));
                        }
                        return (reader.MapToList<T>(), outputs);
                    }
                }
                finally
                {
                    command.Connection.Close();
                }
            }
        }



    }

    class StringResponse
    {
        public string Value { get; set; }
    }

    class IntegerResponse
    {
        public int Value { get; set; }
    }

    class LongResponse
    {
        public long Value { get; set; }
    }

    class DynamicObjectResponse
    {
        public object Value { get; set; }
    }



}

