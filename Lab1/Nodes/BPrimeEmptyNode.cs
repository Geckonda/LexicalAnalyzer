using Lab1.Nodes.@abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Nodes
{
    public class BPrimeEmptyNode : BPrimeNode
    {
        public BPrimeEmptyNode()
        {
            this.Name = "S' ε";
        }
        public override TreeNode Accept(IVisitor v)
        {
            return v.Visit(this);
        }

        public override string Accept(IGenerator v, int offset)
        {
            return v.Visit(this, offset);
        }
    }
}
