using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebPageV2.Migrations
{
    public interface IMigrationManager
    {
        void Execute();
    }
}
