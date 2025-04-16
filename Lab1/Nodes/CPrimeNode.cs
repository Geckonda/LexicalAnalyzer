using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Nodes
{
    public class CPrimeNode : Node
    {
        public bool IsEmpty { get; set; }
        public CPrimeNode CPrimeNext { get; set; }

        public override void Accept(IVisitor v)
        {
            v.Visit(this);
        }
    }
}
