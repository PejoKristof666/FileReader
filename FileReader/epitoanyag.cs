using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileReader
{
    public class epitoanyag
    {
        public double suly { get; set; }
        public string nev { get; set; }
        public int ar { get; set; }
    }

    public class tegla : epitoanyag
    {
        public string tipus { get; set; }
        public string szin { get; set; }
    }
    public class fa : epitoanyag
    {
        public string faanyag { get; set; }
        public float kemenyseg { get; set; }

    }
    public class vas : epitoanyag
    {
        public string femtipus { get; set; }
        public float suruseg { get; set; }

    }
}
