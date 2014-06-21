namespace King.Mapper.Integration.Model
{
    using King.Mapper.Data.Sql;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SimulatedSelectStatement : IStoredProcedure
    {
        public string Name
        {
            get
            {
                return "[dbo].[SimulatedSelectStatement]";
            }
        }
        public int? TestInt
        {
            get;
            set;
        }
    }
}
