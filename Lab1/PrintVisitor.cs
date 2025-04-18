using Lab1.Nodes;
using Lab1.Nodes.@abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class PrintVisitor : IVisitor
    {
        public void Visit(SNode node)
        {
            throw new NotImplementedException();
        }

        public void Visit(SPrimePlusNode node)
        {
            throw new NotImplementedException();
        }

        public void Visit(SPrimeEmptyNode node)
        {
            throw new NotImplementedException();
        }

        public void Visit(BNode node)
        {
            throw new NotImplementedException();
        }

        public void Visit(BPrimeMultNode node)
        {
            throw new NotImplementedException();
        }

        public void Visit(BPrimeEmptyNode node)
        {
            throw new NotImplementedException();
        }

        public void Visit(CNumberNode node)
        {
            throw new NotImplementedException();
        }

        public void Visit(CIdentifierNode node)
        {
            throw new NotImplementedException();
        }

        public void Visit(CPrimeMinusNode node)
        {
            throw new NotImplementedException();
        }

        public void Visit(CPrimeEmptyNode node)
        {
            throw new NotImplementedException();
        }
    }
}
