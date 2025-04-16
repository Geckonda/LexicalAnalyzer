using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Nodes
{
    public class SNode : Node
    {
        public BNode B {  get; set; }
        public SPrimeNode SPrime { get; set; }
        public override void Accept(IVisitor v)
        {
            v.Visit(this);
        }
    }
}
