using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Nodes.@abstract;

namespace Lab1.Nodes
{
    public class CIdentifierNode : CNode
    {
        public CIdentifierNode()
        {
            this.Name = "C <2>";
        }
        public Token? Id { get; set; }
        public CPrimeNode? CPrime { get; set; }
        public override TreeNode Accept(IVisitor v)
        {
            return v.Visit(this);
        }
    }
}
