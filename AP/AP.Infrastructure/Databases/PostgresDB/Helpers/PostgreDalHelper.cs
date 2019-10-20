using AP.Infrastructure.Databases.Base;
using AP.Infrastructure.Databases.Base.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AP.Infrastructure.Databases.PostgresDB.Helpers
{
    public class PostgreDalHelper
    {
      
        public static string GetTableName<TEntity>() where TEntity : class
        {
            return typeof(TEntity).Name.Replace("Entity", string.Empty);
        }

        public static string GetDtoName<TDto>() where TDto : IDto
        {
            return typeof(TDto).Name.Replace("Dto", string.Empty).ToLower();
        }

        public static void ExecuteCommandEntityStore(string storeName, ICondition condition,
            IDbContext commandDbContext)
        {
            try
            {
                var db = commandDbContext as PostgresSQL;
                using (var command = db.StoreProcedureWithCurrentTransaction(storeName, condition))
                {
                    command.ExecuteNonQuery();
                }
            }
            catch 
            {
               
            }
        }

        internal static void ExecuteCommandEntityStore<TId>(string storeName, TId id, IDbContext commandDbContext)
        {
            try
            {
                var db = commandDbContext as PostgresSQL;
                using (var command = db.StoreProcedureWithCurrentTransaction(storeName))
                {
                    db.AddParameter(command, "_id", id, PostgresSQL.TypeMap[id.GetType()]);
                    command.ExecuteNonQuery();
                }
            }
            catch 
            {
               
            }
        }

        public static void ExecuteCommandEntityStore<TEntity, TId>(string storeName, TEntity entity,
            IDbContext commandDbContext) where TEntity : IDbEntity<TId>
        {
            try
            {
                var db = commandDbContext as PostgresSQL;
                using (var command = db.StoreProcedureWithCurrentTransaction(storeName, entity))
                {
                    command.ExecuteNonQuery();
                    //  result = (int)command.ExecuteScalar();
                }
            }
            catch 
            {
                
            }
        }

        public static int ExecuteScalarEntityStore<TEntity, TId>(string storeName, TEntity entity,
            IDbContext commandDbContext) where TEntity : IDbEntity<TId>
        {
            var result = 0;
            try
            {
                var db = commandDbContext as PostgresSQL;
                using (var command = db.StoreProcedureWithCurrentTransaction(storeName, entity))
                {
                    result = (int)command.ExecuteScalar();
                }
            }
            catch 
            {
               
            }

            return result;
        }

        public static IEnumerable<TEntity> GetAll<TEntity>(string tableName) where TEntity : class
        {
            try
            {
                using (var db = new PostgresSQL(PostgresSQL.DBPosition.Slave))
                {
                    using (var command = db.CreateCommand("select * from " + tableName))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                var entities = db.Mapper<TEntity>(reader);
                                reader.Close();
                                return entities;
                            }
                        }
                    }
                }

                return new List<TEntity>();
            }
            catch 
            {
               
                return new List<TEntity>();
            }
        }

        public static TEntity GetById<TEntity, TId>(string tableName, TId id, string idName)
            where TEntity : class, IDbEntity<TId>
        {
            try
            {
                using (var db = new PostgresSQL(PostgresSQL.DBPosition.Slave))
                {
                    using (var command =
                        db.CreateCommand("select * from " + tableName + " where " + idName + " = " + id))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                var entities = db.Mapper<TEntity>(reader);
                                reader.Close();
                                return entities.FirstOrDefault();
                            }
                        }
                    }
                }

                return default;
            }
            catch 
            {
                
                return default;
            }
        }

        public static TEntity GetById<TEntity, TId>(string tableName, TId id, string idName,
            PostgresSQL.DBPosition dbPosition) where TEntity : class, IDbEntity<TId>
        {
            try
            {
                using (var db = new PostgresSQL(dbPosition))
                {
                    using (var command =
                        db.CreateCommand("select * from " + tableName + " where " + idName + " = " + id))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                var entities = db.Mapper<TEntity>(reader);
                                reader.Close();
                                return entities.FirstOrDefault();
                            }
                        }
                    }
                }

                return default;
            }
            catch 
            {               
                return default;
            }
        }

        public static IEnumerable<T> List<T>(string storeName, ICondition condition) where T : class, IDto
        {
            IEnumerable<T> entities = new List<T>();
            try
            {
                using (var db = new PostgresSQL(PostgresSQL.DBPosition.Slave))
                {
                    using (var command = db.StoreProcedure(storeName, condition))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                entities = db.Mapper<T>(reader);
                                reader.Close();
                            }
                        }

                        //Logger.WriteLog(Logger.LogType.Info, "List<T> 2: " + ""+ "ms");
                    }
                }

                return entities;
            }
            catch 
            {               
                return entities;
            }
        }

        public static IEnumerable<T> List<T>(string storeName, ICondition condition, PostgresSQL.DBPosition dbPosition)
            where T : class, IDto
        {
            IEnumerable<T> entities = new List<T>();
            try
            {
                using (var db = new PostgresSQL(dbPosition))
                {
                    using (var command = db.StoreProcedure(storeName, condition))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                entities = db.Mapper<T>(reader);

                                reader.Close();
                            }
                        }
                    }
                }
            }
            catch 
            {
               
            }

            return entities;
        }

        public static int CountTotalRecord(string storeName, ICondition condition)
        {
            try
            {
                using (var db = new PostgresSQL(PostgresSQL.DBPosition.Slave))
                {
                    using (var command = db.StoreProcedure(storeName, condition))
                    {
                        return (int)command.ExecuteScalar();
                    }
                }
            }
            catch 
            {
               
                return 0;
            }
        }

        /// <summary>
        ///     Gọi postgre function và trả ra danh sách phần tử
        /// </summary>
        /// <typeparam name="T">Kiểu của phần tử trong danh sách trả về</typeparam>
        /// <param name="spName"></param>
        /// <param name="condition"></param>
        /// <param name="connectionString"></param>
        /// <returns>>Danh sách phần tử</returns>
        public static IEnumerable<T> QuerySP<T>(string spName, object condition, string connectionString)
            where T : class
        {
            IEnumerable<T> entities = new List<T>();
            using (var db = new PostgresSQL(connectionString))
            {
                using (var command = db.StoreProcedure(spName, condition))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            entities = db.Mapper<T>(reader);

                            reader.Close();
                        }
                    }
                }
            }

            return entities;
        }

        /// <summary>
        ///     Gọi postgre function thực thi một cái gì đó và trả về số bản ghi bị thay đổi
        /// </summary>
        /// <param name="spName"></param>
        /// <param name="condition"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static int ExecuteSP(string spName, object condition, string connectionString)
        {
            using (var db = new PostgresSQL(connectionString))
            {
                using (var command = db.StoreProcedure(spName, condition))
                {
                    var result = command.ExecuteNonQuery();
                    return result;
                }
            }
        }

        public static int ExecuteTransactionSP(string spName, object condition, PostgresSQL dbContext)
        {
            using (var command = dbContext.StoreProcedureWithCurrentTransaction(spName, condition))
            {
                var result = command.ExecuteNonQuery();
                return result;
            }
        }

        /// <summary>
        ///     Gọi postgre function và trả về giá trị của cột đầu tiên của hàng đầu tiên của danh sách phần tử (thường dùng trong
        ///     các hàm count, hoặc trả về id vừa được insert...)
        /// </summary>
        /// <param name="spName"></param>
        /// <param name="condition"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static object ExecuteScalarSP(string spName, object condition, string connectionString)
        {
            using (var db = new PostgresSQL(connectionString))
            {
                using (var command = db.StoreProcedure(spName, condition))
                {
                    var result = command.ExecuteScalar();
                    return result;
                }
            }
        }

        public static object ExecuteScalarTransactionSP(string spName, object condition, PostgresSQL dbContext)
        {
            using (var command = dbContext.StoreProcedureWithCurrentTransaction(spName, condition))
            {
                var result = command.ExecuteScalar();
                return result;
            }
        }

        /// <summary>
        ///     Chạy trực tiếp postgre statement
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="statement"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        [Obsolete("Hạn chế sử dụng trong dự án này, nên thay thế bằng gọi postgre function")]
        public static IEnumerable<T> QueryRaw<T>(string statement, string connectionString) where T : class
        {
            IEnumerable<T> entities = new List<T>();
            using (var db = new PostgresSQL(connectionString))
            {
                using (var command = db.CreateCommand(statement))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            entities = db.Mapper<T>(reader);
                            reader.Close();
                        }
                    }
                }
            }

            return entities;
        }

        [Obsolete("Hạn chế sử dụng, nên thay thế bằng gọi postgre function")]
        public static object QueryScalarRaw(string statement, string connectionString)
        {
            using (var db = new PostgresSQL(connectionString))
            {
                using (var command = db.CreateCommand(statement))
                {
                    var result = command.ExecuteScalar();
                    return result;
                }
            }
        }
    }
}