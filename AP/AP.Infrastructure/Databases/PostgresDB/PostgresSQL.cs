using AP.Infrastructure.Databases.Base;
using AP.Infrastructure.Databases.Base.Conditions;
using AP.Infrastructure.Utility;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;

namespace AP.Infrastructure.Databases.PostgresDB
{
    public class PostgresSQL : IDisposable, IDbContext
    {
        public enum DBPosition
        {
            Manual = -1,

            [Description("ConnectionString")] Default = 0,

            [Description("MasterConnection")] Master = 1,

            [Description("SlaveConnection")] Slave = 2,

            [Description("ExternalConnection")] External = 3
        }

        private static Dictionary<Type, DbType> typeMap;

        private static Dictionary<string, int> _dictConnection;

        private static Dictionary<Type, NpgsqlDbType> npgsqlDbTypeMap;

        protected NpgsqlConnection _connection;

        /// <summary>
        ///     Postgres is a class that will handle the postgres datbase.
        /// </summary>
        private string _connectionString;

        protected DBPosition _dbPosition = DBPosition.Default;
        protected DbTransaction _transaction;

        public PostgresSQL(bool isInit = true)
        {
            _connectionString = GetConnectionString(_dbPosition);

            if (null == _dictConnection) _dictConnection = new Dictionary<string, int>();

            if (isInit) InitConnection();
        }

        public PostgresSQL(string connectionString, bool isInit = true)
        {
            _connectionString = connectionString;

            if (isInit) InitConnection();
        }

        public PostgresSQL(DBPosition dbPosition, bool isInit = true)
        {
            _dbPosition = dbPosition;

            _connectionString = GetConnectionString(_dbPosition);

            if (isInit) InitConnection();
        }

        public static Dictionary<Type, DbType> TypeMap
        {
            get
            {
                if (typeMap == null)
                    CreateTypeMap();
                return typeMap;
            }
        }

        public Dictionary<Type, NpgsqlDbType> NpgsqlDbTypeMap
        {
            get
            {
                if (npgsqlDbTypeMap == null)
                    CreateNpgsqlDbTypeMap();
                return npgsqlDbTypeMap;
            }
        }

        public void Dispose()
        {
            Close();
            if (null != _connection)
                _connection.Dispose();
        }

        private static void CreateTypeMap()
        {
            typeMap = new Dictionary<Type, DbType>
            {
                [typeof(byte)] = DbType.Byte,
                [typeof(sbyte)] = DbType.SByte,
                [typeof(short)] = DbType.Int16,
                [typeof(ushort)] = DbType.UInt16,
                [typeof(int)] = DbType.Int32,
                [typeof(uint)] = DbType.UInt32,
                [typeof(long)] = DbType.Int64,
                [typeof(ulong)] = DbType.UInt64,
                [typeof(float)] = DbType.Single,
                [typeof(double)] = DbType.Double,
                [typeof(decimal)] = DbType.Decimal,
                [typeof(bool)] = DbType.Boolean,
                [typeof(string)] = DbType.String,
                [typeof(char)] = DbType.StringFixedLength,
                [typeof(Guid)] = DbType.Guid,
                [typeof(CustomDateTime)] = DbType.DateTime,
                [typeof(DateTime)] = DbType.DateTime,
                [typeof(DateTimeOffset)] = DbType.DateTimeOffset,
                [typeof(byte[])] = DbType.Binary,
                [typeof(byte?)] = DbType.Byte,
                [typeof(sbyte?)] = DbType.SByte,
                [typeof(short?)] = DbType.Int16,
                [typeof(ushort?)] = DbType.UInt16,
                [typeof(int?)] = DbType.Int32,
                [typeof(uint?)] = DbType.UInt32,
                [typeof(long?)] = DbType.Int64,
                [typeof(ulong?)] = DbType.UInt64,
                [typeof(float?)] = DbType.Single,
                [typeof(double?)] = DbType.Double,
                [typeof(decimal?)] = DbType.Decimal,
                [typeof(bool?)] = DbType.Boolean,
                [typeof(char?)] = DbType.StringFixedLength,
                [typeof(Guid?)] = DbType.Guid,
                [typeof(DateTime?)] = DbType.DateTime,
                [typeof(DateTimeOffset?)] = DbType.DateTimeOffset
            };
            //typeMap[typeof(System.Data.Linq.Binary)] = DbType.Binary;
        }

        protected void InitConnection()
        {
            try
            {
                _connection = CreateConnection();
                _connection.Open();
            }
            catch
            {
            }
        }

        protected string GetConnectionString(DBPosition dbPosition, string defaultValue = "ConnectionString")
        {
            var connectionName = string.Empty;
            if (dbPosition == DBPosition.Manual)
            {
                if (!string.IsNullOrEmpty(defaultValue)) connectionName = defaultValue;
            }
            else
            {
                connectionName = StringUtils.GetEnumDescription(dbPosition);
            }

            if (string.IsNullOrEmpty(connectionName)) connectionName = "ConnectionString";

            return AppSettings.Instance.GetConnection(connectionName);
        }

        /// <summary>
        ///     GetConnectionString - will get the connection string for use.
        /// </summary>
        /// <returns>The connection string</returns>
        public string GetConnectionString()
        {
            if (string.IsNullOrEmpty(_connectionString))
                _connectionString = GetConnectionString(_dbPosition);
            return _connectionString;
        }

        public NpgsqlConnection CreateConnection()
        {
            var conn = new NpgsqlConnection(GetConnectionString());
            return conn;
        }

        /// <summary>
        ///     Returns a SQL statement parameter name that is specific for the data provider.
        ///     For example it returns ? for OleDb provider, or @paramName for MS SQL provider.
        /// </summary>
        /// <param name="paramName">The data provider neutral SQL parameter name.</param>
        /// <returns>The SQL statement parameter name.</returns>
        protected internal string CreateSqlParameterName(string paramName)
        {
            return "@" + paramName;
        }

        /// <summary>
        ///     Creates a .Net data provider specific name that is used by the
        ///     <see cref="AddParameter" /> method.
        /// </summary>
        /// <param name="baseParamName">The base name of the parameter.</param>
        /// <returns>The full data provider specific parameter name.</returns>
        protected string CreateCollectionParameterName(string baseParamName)
        {
            return "@" + baseParamName;
        }

        /// <summary>
        ///     Creates <see cref="System.Data.IDataReader" /> for the specified DB command.
        /// </summary>
        /// <param name="command">The <see cref="System.Data.IDbCommand" /> object.</param>
        /// <returns>A reference to the <see cref="System.Data.IDataReader" /> object.</returns>
        public virtual IDataReader ExecuteReader(IDbCommand command)
        {
            return command.ExecuteReader();
        }

        ///// <summary>
        ///// Creates <see cref="System.Data.IDataReader"/> for the specified DB command.
        ///// </summary>
        ///// <param name="commandType"></param>
        ///// <param name="commandText"></param>
        ///// <param name="parameters"></param>
        ///// <returns>A reference to the <see cref="System.Data.IDataReader"/> object.</returns>
        //protected internal virtual IDataReader ExecuteReader(CommandType commandType, string commandText, params SqlParameter[] parameters)
        //{
        //    var command = CreateCommand(commandType, commandText, parameters);
        //    return command.ExecuteReader();
        //}

        /// <summary>
        ///     Creates <see cref="System.Data.IDataReader" /> for the specified DB command.
        /// </summary>
        /// <param name="command">The <see cref="System.Data.IDbCommand" /> object.</param>
        /// <returns>A reference to the <see cref="System.Data.IDataReader" /> object.</returns>
        public virtual int ExecuteNonQuery(IDbCommand command)
        {
            return command.ExecuteNonQuery();
        }

        ///// <summary>
        ///// Creates <see cref="System.Data.IDataReader"/> for the specified DB command.
        ///// </summary>
        ///// <param name="commandType"></param>
        ///// <param name="commandText"></param>
        ///// <param name="parameters"></param>
        ///// <returns>A reference to the <see cref="System.Data.IDataReader"/> object.</returns>
        //protected internal virtual int ExecuteNonQuery(CommandType commandType, string commandText, params SqlParameter[] parameters)
        //{
        //    var command = CreateCommand(commandType, commandText, parameters);
        //    return command.ExecuteNonQuery();
        //}

        /// <summary>
        ///     Map records from the DataReader
        /// </summary>
        /// <param name="reader">The <see cref="System.Data.IDataReader" /> object.</param>
        /// <returns>List entity of records.</returns>
        protected List<T> MapRecords<T>(IDataReader reader)
        {
            throw new Exception();
        }

        /// <summary>
        ///     Map records from the DataReader
        /// </summary>
        /// <param name="command">The <see cref="System.Data.IDbCommand" /> command.</param>
        /// <returns>List entity of records.</returns>
        public List<T> GetList<T>(IDbCommand command)
        {
            List<T> returnValue;
            using (var reader = ExecuteReader(command))
            {
                returnValue = MapRecords<T>(reader);
            }

            return returnValue;
        }

        public object GetFirtDataRecord(IDbCommand command)
        {
            object returnValue = null;
            using (var reader = ExecuteReader(command))
            {
                if (reader.Read()) returnValue = reader[0];
            }

            return returnValue;
        }

        /// <summary>
        ///     Adds a new parameter to the specified command. It is not recommended that
        ///     you use this method directly from your custom code. Instead use the
        ///     <c>AddParameter</c> method of the PostgresSQL classes.
        /// </summary>
        /// <param name="cmd">The <see cref="System.Data.IDbCommand" /> object to add the parameter to.</param>
        /// <param name="paramName">The name of the parameter.</param>
        /// <param name="value">The value of the parameter.</param>
        /// <returns>A reference to the added parameter.</returns>
        public IDbDataParameter AddParameter(NpgsqlCommand cmd, string paramName, object value)
        {
            IDbDataParameter parameter = cmd.CreateParameter();
            parameter.ParameterName = CreateCollectionParameterName(paramName);
            if (value is DateTime)
                parameter.Value = DateTime.MinValue == DateTime.Parse(value.ToString()) ? DBNull.Value : value;
            else
                parameter.Value = value ?? DBNull.Value;
            cmd.Parameters.Add(parameter);
            return parameter;
        }

        public void AddParameter(NpgsqlCommand cmd, string paramName, object value, Type sourceType)
        {
            if (sourceType.IsList())
            {
                var elementType = sourceType.GetGenericArguments()[0];
                var elementMappedType = GetMappedType(elementType);
                cmd.Parameters.Add(paramName, NpgsqlDbType.Array | elementMappedType).Value = value ?? DBNull.Value;
            }
            else if (sourceType.IsArray)
            {
                var elementType = sourceType.GetElementType();
                var elementMappedType = GetMappedType(elementType);
                cmd.Parameters.Add(paramName, NpgsqlDbType.Array | elementMappedType).Value = value ?? DBNull.Value;
            }
            else
            {
                var dbType = GetMappedType(sourceType);
                cmd.Parameters.Add(paramName, dbType).Value = value ?? DBNull.Value;
            }
        }

        public void AddParameter(NpgsqlCommand cmd, string paramName, object value, NpgsqlDbType dataType)
        {
            cmd.Parameters.Add(paramName, dataType).Value = value;
        }

        /// <summary>
        ///     Adds a new parameter to the specified command. It is not recommended that
        ///     you use this method directly from your custom code. Instead use the
        ///     <c>AddParameter</c> method of the PostgresSQL classes.
        /// </summary>
        /// <param name="cmd">The <see cref="System.Data.IDbCommand" /> object to add the parameter to.</param>
        /// <param name="paramName">The name of the parameter.</param>
        /// <param name="value">The value of the parameter.</param>
        /// <param name="dataType">The DbType of the parameter.</param>
        /// <returns>A reference to the added parameter.</returns>
        public IDbDataParameter AddParameter(NpgsqlCommand cmd, string paramName, object value, DbType dataType)
        {
            IDbDataParameter parameter = cmd.CreateParameter();
            parameter.ParameterName = CreateCollectionParameterName(paramName);
            parameter.DbType = dataType;

            if (value is DateTime)
                parameter.Value = DateTime.MinValue == DateTime.Parse(value.ToString()) ? DBNull.Value : value;
            else
                parameter.Value = value ?? DBNull.Value;
            cmd.Parameters.Add(parameter);
            return parameter;
        }

        /// <summary>
        ///     Adds a new parameter to the specified command. It is not recommended that
        ///     you use this method directly from your custom code. Instead use the
        ///     <c>AddParameter</c> method of the PostgresSQL classes.
        /// </summary>
        /// <param name="cmd">The <see cref="System.Data.IDbCommand" /> object to add the parameter to.</param>
        /// <param name="paramName">The name of the parameter.</param>
        /// <param name="value">The value of the parameter.</param>
        /// <param name="paraDirection">The direction of the parameter.</param>
        /// <returns>A reference to the added parameter.</returns>
        public IDbDataParameter AddParameter(IDbCommand cmd, string paramName, object value,
            ParameterDirection paraDirection)
        {
            var parameter = cmd.CreateParameter();
            parameter.ParameterName = CreateCollectionParameterName(paramName);
            if (value is DateTime)
                parameter.Value = DateTime.MinValue == DateTime.Parse(value.ToString()) ? DBNull.Value : value;
            else
                parameter.Value = value ?? DBNull.Value;
            parameter.Direction = paraDirection;
            cmd.Parameters.Add(parameter);
            return parameter;
        }

        /// <summary>
        ///     Begins a new database transaction.
        /// </summary>
        /// <seealso cref="CommitTransaction" />
        /// <seealso cref="RollbackTransaction" />
        /// <returns>An object representing the new transaction.</returns>
        public IDbTransaction BeginTransaction()
        {
            CheckTransactionState(false);
            _transaction = _connection.BeginTransaction();
            return _transaction;
        }

        /// <summary>
        ///     Begins a new database transaction with the specified
        ///     transaction isolation level.
        ///     <seealso cref="CommitTransaction" />
        ///     <seealso cref="RollbackTransaction" />
        /// </summary>
        /// <param name="isolationLevel">The transaction isolation level.</param>
        /// <returns>An object representing the new transaction.</returns>
        public IDbTransaction BeginTransaction(IsolationLevel isolationLevel)
        {
            CheckTransactionState(false);
            _transaction = _connection.BeginTransaction(isolationLevel);
            return _transaction;
        }

        /// <summary>
        ///     Commits the current database transaction.
        ///     <seealso cref="BeginTransaction" />
        ///     <seealso cref="RollbackTransaction" />
        /// </summary>
        public void CommitTransaction()
        {
            CheckTransactionState(true);
            _transaction.Commit();
            _transaction = null;
        }

        /// <summary>
        ///     Rolls back the current transaction from a pending state.
        ///     <seealso cref="BeginTransaction" />
        ///     <seealso cref="CommitTransaction" />
        /// </summary>
        public void RollbackTransaction()
        {
            CheckTransactionState(true);
            _transaction.Rollback();
            _transaction = null;
        }

        // Checks the state of the current transaction
        private void CheckTransactionState(bool mustBeOpen)
        {
            if (mustBeOpen)
            {
                if (null == _transaction)
                    throw new InvalidOperationException("Transaction is not open.");
            }
            else
            {
                if (null != _transaction)
                    throw new InvalidOperationException("Transaction is already open.");
            }
        }

        /// <summary>
        ///     Creates and returns a new <see cref="System.Data.IDbCommand" /> object.
        /// </summary>
        /// <param name="sqlText">The text of the query.</param>
        /// <returns>An <see cref="System.Data.IDbCommand" /> object.</returns>
        public NpgsqlCommand CreateCommand(string sqlText)
        {
            return CreateCommand(sqlText, false);
        }

        public NpgsqlCommand StoreProcedure(string sqlText)
        {
            return CreateCommand(sqlText, true);
        }

        public NpgsqlCommand StoreProcedure(string sqlText, object condition)
        {
            var command = StoreProcedure(sqlText);
            var conditionPropertyDetails = ObjectUtils.GetPropertyDetails(condition);
            if (conditionPropertyDetails.Count == 0)
                return command;

            foreach (var prop in conditionPropertyDetails)
                //AddParameter(command, prop.Name, prop.Value, GetMappedType(prop.Type));
                AddParameter(command, prop.Name, prop.Value, prop.Type);

            return command;
        }

        public NpgsqlCommand StoreProcedureWithCurrentTransaction(string sqlText, ICondition condition = null)
        {
            var command = StoreProcedure(sqlText, condition);
            command.Transaction = (NpgsqlTransaction)_transaction;
            return command;
        }

        public NpgsqlCommand StoreProcedureWithCurrentTransaction(string sqlText, object condition)
        {
            var command = StoreProcedure(sqlText, condition);
            command.Transaction = (NpgsqlTransaction)_transaction;
            return command;
        }

        public NpgsqlCommand StoreProcedure(string sqlText, ICondition condition)
        {
            var command = StoreProcedure(sqlText);
            if (condition != null)
                foreach (var key in condition.Conditions.Keys)
                    AddParameter(command, key, condition.Conditions[key].Item2,
                        TypeMap[condition.Conditions[key].Item1]);
            return command;
        }

        public IList<T> Mapper<T>(NpgsqlDataReader reader, bool close = true) where T : class
        {
            IList<T> entities = new List<T>();
            if (reader != null && reader.HasRows)
            {
                while (reader.Read())
                {
                    T item = default;
                    if (item == null)
                        item = Activator.CreateInstance<T>();
                    Mapper(reader, item);
                    entities.Add(item);
                }

                if (close) reader.Close();
            }

            return entities;
        }

        public bool Mapper<T>(IDataRecord reader, T entity) where T : class
        {
            var type = typeof(T);

            if (entity != null)
            {
                for (var i = 0; i < reader.FieldCount; i++)
                {
                    var fieldName = reader.GetName(i);
                    var propertyInfo = type.GetProperties().FirstOrDefault(info =>
                        info.Name.Equals(fieldName, StringComparison.InvariantCultureIgnoreCase));

                    if (propertyInfo != null)
                    {
                        if (reader[i] != null && reader[i] != DBNull.Value)
                        {
                            propertyInfo.SetValue(entity, reader[i], null);
                        }
                        else
                        {
                            if (propertyInfo.PropertyType.IsGenericType)
                                if (propertyInfo.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                                    propertyInfo.SetValue(entity, null);
                        }
                    }
                }

                return true;
            }

            return false;
        }

        /// <summary>
        ///     Creates and returns a new <see cref="System.Data.IDbCommand" /> object.
        /// </summary>
        /// <param name="sqlText">The text of the query.</param>
        /// <param name="procedure">
        ///     Specifies whether the sqlText parameter is
        ///     the name of a stored procedure.
        /// </param>
        /// <returns>An <see cref="System.Data.IDbCommand" /> object.</returns>
        public NpgsqlCommand CreateCommand(string sqlText, bool procedure)
        {
            var cmd = new NpgsqlCommand(sqlText, _connection)
            {
                CommandText = sqlText
            };
            if (procedure)
                cmd.CommandType = CommandType.StoredProcedure;
            return cmd;
        }

        public object GetParameterValueFromCommand(IDbCommand command, int paramterIndex)
        {
            return command.Parameters[paramterIndex] is SqlParameter parameter ? parameter.Value : null;
        }

        public virtual void Close()
        {
            if (null != _connection)
                _connection.Close();
        }

        public void CreateNpgsqlDbTypeMap()
        {
            npgsqlDbTypeMap = new Dictionary<Type, NpgsqlDbType>
            {
                [typeof(byte)] = NpgsqlDbType.Smallint,
                [typeof(sbyte)] = NpgsqlDbType.Smallint,
                [typeof(short)] = NpgsqlDbType.Smallint,
                [typeof(ushort)] = NpgsqlDbType.Smallint,
                [typeof(int)] = NpgsqlDbType.Integer,
                [typeof(uint)] = NpgsqlDbType.Integer,
                [typeof(long)] = NpgsqlDbType.Bigint,
                [typeof(ulong)] = NpgsqlDbType.Bigint,
                [typeof(float)] = NpgsqlDbType.Real,
                [typeof(double)] = NpgsqlDbType.Double,
                [typeof(decimal)] = NpgsqlDbType.Numeric,
                [typeof(bool)] = NpgsqlDbType.Boolean,
                [typeof(string)] = NpgsqlDbType.Text,
                [typeof(char)] = NpgsqlDbType.Text,
                [typeof(Guid)] = NpgsqlDbType.Uuid,
                [typeof(CustomDateTime)] = NpgsqlDbType.Timestamp,
                [typeof(DateTime)] = NpgsqlDbType.Timestamp,
                [typeof(DateTimeOffset)] = NpgsqlDbType.TimestampTz,
                [typeof(byte[])] = NpgsqlDbType.Bytea,
                [typeof(byte?)] = NpgsqlDbType.Smallint,
                [typeof(sbyte?)] = NpgsqlDbType.Smallint,
                [typeof(short?)] = NpgsqlDbType.Smallint,
                [typeof(ushort?)] = NpgsqlDbType.Smallint,
                [typeof(int?)] = NpgsqlDbType.Integer,
                [typeof(uint?)] = NpgsqlDbType.Integer,
                [typeof(long?)] = NpgsqlDbType.Bigint,
                [typeof(ulong?)] = NpgsqlDbType.Bigint,
                [typeof(float?)] = NpgsqlDbType.Real,
                [typeof(double?)] = NpgsqlDbType.Double,
                [typeof(decimal?)] = NpgsqlDbType.Numeric,
                [typeof(bool?)] = NpgsqlDbType.Boolean,
                [typeof(char?)] = NpgsqlDbType.Text,
                [typeof(Guid?)] = NpgsqlDbType.Uuid,
                [typeof(DateTime?)] = NpgsqlDbType.Timestamp,
                [typeof(DateTimeOffset?)] = NpgsqlDbType.TimestampTz
            };
        }

        public NpgsqlDbType GetMappedType(Type type)
        {
            if (NpgsqlDbTypeMap.ContainsKey(type))
                return NpgsqlDbTypeMap[type];

            if (type.IsArray)
                return NpgsqlDbType.Array;
            if (type.IsList())
                return NpgsqlDbType.Array;

            return NpgsqlDbType.Unknown;
        }

        public void SetTransaction(DbTransaction dbTransaction)
        {
            _transaction = dbTransaction;
        }
    }
}