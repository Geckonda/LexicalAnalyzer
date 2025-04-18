using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Nodes
{
    public class SPrimeNode : Node
    {
        public SPrimeNode()
        {
            this.name = "S'";
        }
        public bool IsEmpty { get; set; }
        public BNode? B { get; set; }
        public SPrimeNode? SPrimeNext { get; set; }
        public override void Accept(IVisitor v)
        {
            v.Visit(this);
        }
    }
}
