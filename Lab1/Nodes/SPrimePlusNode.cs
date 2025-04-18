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
            this.Name = "S' +";
        }

        public Token? Plus { get; set; }
        public BNode? B { get; set; }
        public SPrimeNode? SPrimeNext { get; set; }
        public override TreeNode Accept(IVisitor v)
        {
            return v.Visit(this);
        }
    }
}
