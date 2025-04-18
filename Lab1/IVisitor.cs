using Lab1.Nodes;
using Lab1.Nodes.@abstract;
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
        void Visit(SPrimePlusNode node);
        void Visit(SPrimeEmptyNode node);
        void Visit(BNode node);
        void Visit(BPrimeMultNode node);
        void Visit(BPrimeEmptyNode node);
        void Visit(CNumberNode node);
        void Visit(CIdentifierNode node);
        void Visit(CPrimeMinusNode node);
        void Visit(CPrimeEmptyNode node);
    }
}
