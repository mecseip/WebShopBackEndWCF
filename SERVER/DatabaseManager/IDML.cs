using SERVER.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVER.DatabaseManager
{
    internal interface IDML
    {
        string Insert(Record record);

        string Update(Record record);

        string Delete(int? id);
    }
}
