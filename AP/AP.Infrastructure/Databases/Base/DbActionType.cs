using AP.Infrastructure.Core.Enumerations;

namespace AP.Infrastructure.Databases.Base
{
    public class DbActionType : Enumeration
    {
        public static DbActionType Read = new DbActionType(1, nameof(Read).ToLower());
        public static DbActionType Write = new DbActionType(2, nameof(Write).ToLower());

        public DbActionType(int id, string name) : base(id, name)
        {
        }
    }
}