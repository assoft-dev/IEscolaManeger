namespace IEscolaEntity.Controllers.Helps
{
    using IEscolaEntity.Models.Helps;
    using ServiceStack.OrmLite;
    using System;
    using System.Data;
    using System.Linq;

    public class DataColunsAsync<T>
    {
        public static void AsyncColuns(IDbConnection db)
        {
            //Adicionar se nao existe tabelas
            var resultCreate = db.CreateTableIfNotExists<T>();

            if (!resultCreate)
            {
                //Actualizacao de colunas
                var ModelsClasse = typeof(T).GetProperties().Where(x => x.CanWrite && IsPrimitive(x.PropertyType));
                var ModelsDatabase = db.GetTableColumns<T>();

                // COlunas existentes na classe passar para a Db
                foreach (var item in ModelsClasse)
                {
                    if (!db.ColumnExists(item.Name, typeof(T).Name))
                    {
                        db.AddColumn(typeof(T), typeof(T).GetModelMetadata().GetFieldDefinition(item.Name));
                    }
                }

                // Colunas existentes na Db que não existem na Classe Eliminar
                foreach (var item in ModelsDatabase)
                {
                    if (!ModelsClasse.Any(x => x.Name == item.ColumnName))
                    {
                        #region Ciclos
                        //foreach (var prop in ModelsClasse)
                        //{
                        //    if (prop.Name == item.ColumnName)
                        //    {
                        //        var T = prop.GetCustomAttributes(true);
                        //        if (T.Length > 0)
                        //        {
                        //            var y = T.FirstOrDefault().GetType() == typeof(ForeignKeyAttribute);
                        //            if (y)
                        //                db.DropForeignKey<T>(item.ColumnName);
                        //            else
                        //                db.DropIndex<T>(item.ColumnName);
                        //        }
                        //    }             
                        //}
                        #endregion

                        try
                        {
                            db.DropColumn<T>(item.ColumnName);
                        }
                        catch (Exception)
                        {
                            try
                            {
                                db.DropForeignKey<T>(item.ColumnName);
                            }
                            catch (Exception)
                            {
                                db.DropIndex<T>(item.ColumnName);
                            }              
                        }
                    }
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
                     typeof(Guid),
                     typeof(Guid?),
                     typeof(Enum),

                     typeof(Estado),
                     typeof(ProvinciasCodigo),
                     typeof(Disponibilidade),
                     typeof(Escolaridade),
                     typeof(Sexo),
                     typeof(UsuariosRetorno),
                     typeof(PedidosEstado),
                     typeof(PedidosDocuments),

                     typeof(EstadoEstudantes),
                     typeof(Nacionalidade),
                     typeof(GrauParentesco),
                     typeof(EstadoCivil),
                     typeof(DocType),
                     typeof(FAZES),
                     typeof(ProvinciasLocal),
                     typeof(Meses),
                     typeof(DisciplinasComponentesType),
                     typeof(AbilitacoesLiterarias),
                     typeof(Anos),
                };
                return primary.Contains(t);
            }
            else
                return primary.Contains(t);
        }
    }
}
