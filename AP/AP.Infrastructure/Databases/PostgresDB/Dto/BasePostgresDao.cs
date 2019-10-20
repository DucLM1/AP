using System;
using System.Collections.Generic;
using System.Linq;
using AP.Infrastructure.Databases.Base;
using AP.Infrastructure.Databases.PostgresDB.Helpers;

namespace AP.Infrastructure.Databases.PostgresDB.Dto
{
    public abstract class BasePostgresDao : IPostgreDao
    {
        protected PostgresSQL dbContext;
        protected IPgDbFactory dbFactory;

        public BasePostgresDao(
            IPgDbFactory dbFactory
        )
        {
            this.dbFactory = dbFactory;
        }

        protected Type Type { get; set; }

        public virtual void SetWriteContext(IDbContext dbContext)
        {
            this.dbContext = (PostgresSQL)dbContext;
        }

        public virtual List<T> QuerySP<T>(string spName, object condition) where T : class
        {
            var connectionString = GetConnectionString(DbActionType.Read);
            var result = PostgreDalHelper.QuerySP<T>(spName, condition, connectionString).ToList();
            return result;
        }

        public virtual List<T> QuerySP<T>(string spName, object condition, string connectionString) where T : class
        {
            var result = PostgreDalHelper.QuerySP<T>(spName, condition, connectionString).ToList();
            return result;
        }

        public virtual int ExecuteSP(string spName, object param)
        {
            var connectionString = GetConnectionString(DbActionType.Write);
            var result = PostgreDalHelper.ExecuteSP(spName, param, connectionString);
            return result;
        }

        public virtual int ExecuteSP(string spName, object param, string connectionString)
        {
            var result = PostgreDalHelper.ExecuteSP(spName, param, connectionString);
            return result;
        }

        public virtual object ExecuteScalarSP(string spName, object param)
        {
            var connectionString = GetConnectionString(DbActionType.Write);
            var result = PostgreDalHelper.ExecuteScalarSP(spName, param, connectionString);
            return result;
        }

        public virtual object ExecuteScalarSP(string spName, object param, string connectionString)
        {
            var result = PostgreDalHelper.ExecuteScalarSP(spName, param, connectionString);
            return result;
        }

        public virtual List<T> QueryStatement<T>(string statement) where T : class
        {
            var connectionString = GetConnectionString(DbActionType.Read);
            var result = PostgreDalHelper.QueryRaw<T>(statement, connectionString).ToList();
            return result;
        }

        public virtual List<T> QueryStatement<T>(string statement, string connectionString) where T : class
        {
            var result = PostgreDalHelper.QueryRaw<T>(statement, connectionString).ToList();
            return result;
        }

        public virtual object ExecuteScalarStatement(string spName, string connectionString)
        {
            var result = PostgreDalHelper.QueryScalarRaw(spName, connectionString);
            return result;
        }

        public virtual object ExecuteScalarStatement(string spName)
        {
            var connectionString = GetConnectionString(DbActionType.Write);
            var result = PostgreDalHelper.QueryScalarRaw(spName, connectionString);
            return result;
        }

        public virtual int ExecuteTransactionSP(string spName, object param)
        {
            var result = PostgreDalHelper.ExecuteTransactionSP(spName, param, dbContext);
            return result;
        }

        public virtual object ExecuteScalarTransactionSP(string spName, object param)
        {
            var result = PostgreDalHelper.ExecuteScalarTransactionSP(spName, param, dbContext);
            return result;
        }

        protected virtual string GetConnectionString(DbActionType action)
        {
            if (Type != null)
                return dbFactory.GetConnectionString(Type, action);
            return dbFactory.GetDefaultConnectionString(action);
        }
    }
}