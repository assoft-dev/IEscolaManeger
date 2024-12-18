using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEscolaEntity.Controllers.Helps
{
    public class DataColunsAsync<T>
    {
        public static void AsyncColuns(IDbConnection db)
        {
            //Adicionar se nao existe tabelas
            var resultDb = db.CreateTableIfNotExists<T>();

            //Actualizacao de colunas
            var models = typeof(T).GetProperties().Where(x => x.CanWrite && IsPrimitive(x.PropertyType));
            foreach (var item in models)
            {
                if (!db.ColumnExists(item.Name, typeof(T).Name))
                {
                    db.AddColumn(typeof(T), typeof(T).GetModelMetadata().GetFieldDefinition(item.Name));
                }
            }

            var sqlModels = db.GetTableColumns<T>();
            foreach (var item in sqlModels)
            {
                if (!models.Any(x => x.Name.Equals(item.ColumnName)))
                {
                    db.DropColumn<T>(item.ColumnName);
                }
            }
        }

        private static Type[] primary;
        private static bool IsPrimitive(Type t)
        {
            if (primary == null)
            {
                primary = new Type[]
                {
                     typeof(long),
                     typeof(long?),
                     typeof(string),
                     typeof(char),
                     typeof(byte),
                     typeof(sbyte),
                     typeof(ushort),
                     typeof(short),
                     typeof(uint),
                     typeof(int),
                     typeof(int?),
                     typeof(ulong),
                     typeof(long),
                     typeof(float),
                     typeof(double),
                     typeof(decimal),
                     typeof(decimal?),
                     typeof(bool),
                     typeof(bool?),
                     typeof(TimeSpan),
                     typeof(TimeSpan?),
                     typeof(DateTime),
                     typeof(DateTime?),
                     typeof(byte[]),
                };
                return primary.Contains(t);
            }
            else
                return primary.Contains(t);
        }
    }
}
