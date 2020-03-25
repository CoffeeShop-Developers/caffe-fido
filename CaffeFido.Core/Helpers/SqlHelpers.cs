using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using CaffeFido.Core.Attribute;
using CaffeFido.Core.Dictionary;

namespace CaffeFido.Core.Helpers
{
    public class SqlHelpers
    {   
        public static SqlParameter[] CreateSqlParameters<P>(P parameters)
        {
            var sqlParameterArray = new List<SqlParameter>();
            var propertyInfo = typeof(P).GetProperties();

            foreach (var property in propertyInfo)
            {
                var parameterName = "@" + property.Name;
                var parameterValue = property.GetValue(parameters)?.ToString();
               
                var sqlParameter = new SqlParameter
                {
                    ParameterName = parameterName
                };

                if (parameterValue == null)
                {
                    sqlParameter.Value = DBNull.Value;
                }
                else
                {
                    sqlParameter.Value = parameterValue;
                };

                sqlParameter.DbType = SqlDataTypeDictionary.Select[property.PropertyType];

                if (property.CustomAttributes.FirstOrDefault(s => s.AttributeType == (typeof(OutPutAttribute))) != null)
                {
                    sqlParameter.Direction = System.Data.ParameterDirection.Output;
                }

                sqlParameterArray.Add(sqlParameter);
            }
            return sqlParameterArray.ToArray();
        }

        public static string StringifyParameters<P>(P parameters)
        {
            var propertyInfo = typeof(P).GetProperties();
            var parameterString = new StringBuilder();

            foreach (var property in propertyInfo)
            {
                parameterString.Append("@" + property.Name + ", ");
            }
            parameterString.Remove(parameterString.Length - 2, 2);

            return parameterString.ToString();
        }

        public static string StringifyParameters(SqlParameter[] parameters)
        {
            var parameterNames = new string[parameters.Length];
            var parameterString = new StringBuilder();
            for (var i = 0; i < parameters.Length; i++)
            {
                parameterString.Append(parameters[i].ParameterName + ", ");
                parameterNames[i] = parameters[i].ParameterName;
            }
            parameterString.Remove(parameterString.Length - 2, 2);
            return parameterString.ToString();
        }

        public static string StringifyParameters(List<SqlParameter> parameters)
        {
            var parameterNames = new string[parameters.Count];

            var parameterString = new StringBuilder();
            for (var i = 0; i < parameters.Count; i++)
            {
                parameterString.Append(parameters[i].ParameterName + ", ");
                parameterNames[i] = parameters[i].ParameterName;
            }
            parameterString.Remove(parameterString.Length - 2, 2);
            return parameterString.ToString();
        }

        public static string StringifyParametersWithOutput<P>(P parameters)
        {
            var parameterProperties = typeof(P).GetProperties();          
            var parameterString = new StringBuilder();
            
            foreach (var parameterProperty in parameterProperties)
            {              
                if (parameterProperty.CustomAttributes.FirstOrDefault(s => s.AttributeType == (typeof(OutPutAttribute))) != null)
                {                   
                    parameterString.Append("@" + parameterProperty.Name + " OUTPUT, ");
                }
                else
                {
                    parameterString.Append("@" + parameterProperty.Name + ", ");                   
                }             
            }              
            parameterString.Remove(parameterString.Length - 2, 2);
            return parameterString.ToString();       
        }

        public static string StringifyParametersWithOutput(SqlParameter[] parameters)
        {
            var parameterNames = new string[parameters.Length];
            var parameterString = new StringBuilder();
            for (int i = 0; i < parameters.Length; i++)
            {
                if (parameters[i].Direction == System.Data.ParameterDirection.Output)
                {
                    parameterString.Append(parameters[i].ParameterName + " OUTPUT, ");
                }
                else
                {
                    parameterString.Append(parameters[i].ParameterName + ", ");
                }

                parameterNames[i] = parameters[i].ParameterName;
            }
            parameterString.Remove(parameterString.Length - 2, 2);
            return parameterString.ToString();
        }
    }
}
