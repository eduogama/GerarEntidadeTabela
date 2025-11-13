using System.Data;
using System.Reflection;

namespace GerarCodigoBanco.Uitls
{
    public class Metodos
    {
        public static List<T> GetDados<T>(IDataReader dr)
        {
            List<T> list = [];

            while (dr.Read())
            {
                T obj = Activator.CreateInstance<T>();

                foreach (PropertyInfo prop in obj.GetType().GetProperties())
                {
                    try
                    {
                        if (!object.Equals(dr[prop.Name], DBNull.Value))
                        {
                            prop.SetValue(obj, dr[prop.Name], null);
                        }
                    }
                    catch { }
                }

                list.Add(obj);
            }

            return list;
        }

        /// <summary>
        /// Converte DataReader para Propriedade
        /// </summary>
        public static T GetItem<T>(IDataReader dr)
        {
            T obj = default;

            while (dr.Read())
            {
                obj = Activator.CreateInstance<T>();
                foreach (PropertyInfo prop in obj.GetType().GetProperties())
                {
                    try
                    {
                        if (!object.Equals(dr[prop.Name], DBNull.Value))
                        {
                            prop.SetValue(obj, dr[prop.Name], null);
                        }
                    }
                    catch { }
                }
            }

            return obj;
        }

        /// <summary>
        /// Converte um DataRow para Propriedade
        /// </summary>
        public static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    try
                    {
                        if (pro.Name.Equals(column.ColumnName, StringComparison.CurrentCultureIgnoreCase))
                        { pro.SetValue(obj, dr[column.ColumnName], null); }
                        else
                        { continue; }
                    }
                    catch { }
                }
            }

            return obj;
        }

        public static Dictionary<string, string> ObterTiposDados()
        {
            return new Dictionary<string, string>
            {
                { "bigint", "long" },
                { "binary", "byte[]" },
                { "bit", "bool" },
                { "char", "string" },
                { "date", "DateTime" },
                { "datetime", "DateTime" },
                { "datetime2", "DateTime" },
                { "datetimeoffset", "DateTimeOffset" },
                { "decimal", "decimal" },
                { "float", "double" },
                { "image", "byte[]" },
                { "int", "int" },
                { "money", "decimal" },
                { "nchar", "string" },
                { "ntext", "string" },
                { "numeric", "decimal" },
                { "nvarchar", "string" },
                { "real", "float" },
                { "smalldatetime", "DateTime" },
                { "smallint", "short" },
                { "smallmoney", "decimal" },
                { "text", "string" },
                { "time", "TimeSpan" },
                { "timestamp", "byte[]" },
                { "tinyint", "byte" },
                { "uniqueidentifier", "Guid" },
                { "varbinary", "byte[]" },
                { "varchar", "string" },
                { "xml", "string" }
            };
        }
    }
}
