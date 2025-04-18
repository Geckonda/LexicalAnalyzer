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
        public override void Accept(IVisitor v)
        {
            v.Visit(this);
        }
    }
}
