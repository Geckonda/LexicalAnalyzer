using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Nodes
{
    public class CNode : Node
    {
        public CNode()
        {
            this.name = "C";
        }
        public Token? Id {  get; set; }
        public CPrimeNode? CPrime { get; set; }
        public override void Accept(IVisitor v)
        {
            v.Visit(this);
        }
    }
}
