using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Nodes.@abstract;

namespace Lab1.Nodes
{
    public class BNode : Node
    {
        public BNode()
        {
            this.Name = "B";
        }
        public CNode? C {  get; set; }
        public BPrimeNode? BPrime { get; set; }
        public override void Accept(IVisitor v)
        {
            v.Visit(this);
        }
    }
}
