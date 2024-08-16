using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BillGenerator.Models;

namespace BillGenerator.Repository
{
    interface IData
    {
        void saveBillDetails(BillDetails details);

        void saveBillItems(List<Items> items,SqlConnection con, int id); 
    }
}
