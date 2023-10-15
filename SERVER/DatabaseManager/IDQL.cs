using SERVER.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVER.DatabaseManager
{
    internal interface IDQL
    {
        List<Record> Select(string where);
    }
}
