using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Nodes.@abstract
{
    public abstract class Node
    {
        public string Name { get; protected set; }
        public abstract TreeNode Accept(IVisitor v);

    }
}
