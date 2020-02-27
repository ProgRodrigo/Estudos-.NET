using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagers
{
    class Banco
    {
        public static string conexao()
        {
            return @"Data Source=NOT-R1812\SQLEXPRESS;Initial Catalog=Pagers;Integrated Security=True";
        }
    }
}
