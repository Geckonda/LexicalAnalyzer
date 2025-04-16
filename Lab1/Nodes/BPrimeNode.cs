using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Nodes
{
    public class BPrimeNode : Node
    {
        public const char Star = '*';
        public CNode C {  get; set; }
        public BPrimeNode BPrimeNext { get; set; }
        public override void Accept(IVisitor v)
        {
            v.Visit(this);
        }
    }
}
