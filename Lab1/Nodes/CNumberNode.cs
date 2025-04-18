using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Nodes
{
    public class CNumberNode : CNode
    {
        public CNumberNode()
        {
            this.name = "C <1>";
        }
        public Token? Id { get; set; }
        public CPrimeNode? CPrime { get; set; }
        public override void Accept(IVisitor v)
        {
            v.Visit(this);
        }
    }
}
