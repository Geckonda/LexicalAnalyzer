using Lab1.Nodes.@abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Nodes
{
    public class SPrimePlusNode : SPrimeNode
    {
        public SPrimePlusNode()
        {
            this.name = "S' +";
        }

        public Token? Plus;
        public BNode? B { get; set; }
        public SPrimeNode? SPrimeNext { get; set; }
        public override void Accept(IVisitor v)
        {
            v.Visit(this);
        }
    }
}
