using Lab1.Nodes.@abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Nodes
{
    public class BPrimeMultNode : BPrimeNode
    {
        public BPrimeMultNode()
        {
            Name = "B' *";
        }
        public Token? Mult { get; set; }
        public CNode? C { get; set; }
        public BPrimeNode? BPrimeNext { get; set; }
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
