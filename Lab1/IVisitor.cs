using Lab1.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public interface IVisitor
    {
        void Visit(SNode node);
        void Visit(SPrimeNode node);
        void Visit(BNode node);
        void Visit(BPrimeNode node);
        void Visit(CNode node);
        void Visit(CPrimeNode node);
    }
}
