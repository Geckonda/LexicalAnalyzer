using Lab1.Nodes.@abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Nodes
{
    public class CPrimeEmptyNode : CPrimeNode
    {
        public CPrimeEmptyNode()
        {
            this.Name = "C' ε";
        }
        public override TreeNode Accept(IVisitor v)
        {
            return v.Visit(this);
        }
    }
}
