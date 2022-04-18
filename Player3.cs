using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Truco
{
    public class Player3 : Players
    {
        public Player1 Player1 { get; set; }

        public Player3():base("A", 3)
        {

        }


    }
}
