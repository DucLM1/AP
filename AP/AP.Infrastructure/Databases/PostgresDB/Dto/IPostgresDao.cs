using AP.Infrastructure.Databases.Base;
using System.Collections.Generic;

namespace AP.Infrastructure.Databases.PostgresDB.Dto
{
    public interface IPostgreDao
    {
        void SetWriteContext(IDbContext dbContext);

        /// <summary>
        ///     Gọi postgre function
        /// </summary>
        /// <typeparam name="T">Kiểu của phần tử trong danh sách trả về</typeparam>
        /// <param name="spName"></param>
        /// <param name="condition"></param>
        /// <returns>Danh sách phần tử</returns>
        List<T> QuerySP<T>(string spName, object condition) where T : class;

        List<T> QuerySP<T>(string spName, object condition, string connectionString) where T : class;

        /// <summary>
        ///     Gọi postgre function và trả về số bản ghi bị thay đổi
        /// </summary>
        /// <param name="spName"></param>
        /// <param name="param"></param>
        /// <returns>Số bản ghi bị thay đổi</returns>
        int ExecuteSP(string spName, object param);

        int ExecuteSP(string spName, object param, string connectionString);

        /// <summary>
        ///     Gọi postgre function và trả về giá trị của cột đầu tiên của row đầu tiền trong kết quả của function đó
        /// </summary>
        /// <param name="spName"></param>
        /// <param name="param"></param>
        /// <param name="connectionString"></param>
        /// <returns>Giá trị của cột đầu tiên của row đầu tiền trong kết quả của postgre function</returns>
        object ExecuteScalarSP(string spName, object param);

        object ExecuteScalarSP(string spName, object param, string connectionString);

        /// <summary>
        ///     Trực tiếp chạy postgre statement (hạn chế dùng cách này, cố gắng thay thế bằng postgre function)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="statement"></param>
        /// <returns></returns>
        List<T> QueryStatement<T>(string statement) where T : class;

        List<T> QueryStatement<T>(string statement, string connectionString) where T : class;

        /// <summary>
        ///     Trực tiếp chạy postgre statement (hạn chế dùng cách này, cố gắng thay thế bằng postgre function)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="statement"></param>
        /// <returns>Giá trị của cột đầu tiên của hàng đầu tiên trong tập kết quả trả về của function</returns>
        object ExecuteScalarStatement(string spName, string connectionString);

        object ExecuteScalarStatement(string spName);
    }
}