using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Nodes.@abstract;

namespace Lab1.Nodes
{
    public class CNumberNode : CNode
    {
        public CNumberNode()
        {
            this.Name = "C <1>";
        }
        public Token? Number { get; set; }
        public CPrimeNode? CPrime { get; set; }
        public override TreeNode Accept(IVisitor v)
        {
            return v.Visit(this);
        }
    }
}
