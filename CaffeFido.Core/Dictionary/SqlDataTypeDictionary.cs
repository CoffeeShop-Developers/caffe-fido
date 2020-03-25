using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CaffeFido.Core.Dictionary
{
    public class SqlDataTypeDictionary
    {
        private static Dictionary<Type, DbType> _instance;

        public static Dictionary<Type, DbType> Select =>
            _instance ?? (_instance = new Dictionary<Type, DbType>
            {
                {typeof(DateTime), DbType.DateTime},
                {typeof(DateTime?), DbType.DateTime},
                {typeof(System.Int32), DbType.Int32},
                {typeof(System.Int32?), DbType.Int32},
                {typeof(System.Int64), DbType.Int64},
                {typeof(System.Int64?), DbType.Int64},
                {typeof(string), DbType.String}
            });

    }
}
