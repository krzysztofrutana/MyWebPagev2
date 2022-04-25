using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebPageV2.Data.Interfaces.Dapper
{
    public interface IDapperContext
    {
        Task<SqlConnection> GetConnectionAsync();
    }
}
