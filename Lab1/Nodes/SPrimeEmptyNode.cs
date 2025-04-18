using Lab1.Nodes.@abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Nodes
{
    public class SPrimeEmptyNode : SPrimeNode
    {
        public SPrimeEmptyNode()
        {
            this.name = "S' ε";
        }
        public override void Accept(IVisitor v)
        {
            v.Visit(this);
        }
    }
}
