using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Nodes.@abstract
{
    public abstract class Node
    {
        public string name;
        public abstract void Accept(IVisitor v);

    }
}
