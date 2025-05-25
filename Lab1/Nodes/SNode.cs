using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Nodes.@abstract;

namespace Lab1.Nodes
{
    public class SNode : Node
    {
        public SNode()
        {
            this.Name = "S";
        }
        public BNode? B {  get; set; }
        public SPrimeNode? SPrime { get; set; }
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
