using Lab1.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public interface IGenerator
    {
        string Visit(SNode node, int offset);
        string Visit(SPrimePlusNode node, int offset);
        string Visit(SPrimeEmptyNode node, int offset);
        string Visit(BNode node, int offset);
        string Visit(BPrimeMultNode node, int offset);
        string Visit(BPrimeEmptyNode node, int offset);
        string Visit(CNumberNode node, int offset);
        string Visit(CIdentifierNode node, int offset);
        string Visit(CPrimeMinusNode node, int offset);
        string Visit(CPrimeEmptyNode node, int offset);
    }
}
