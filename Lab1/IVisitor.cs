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
        TreeNode Visit(SNode node);
        TreeNode Visit(SPrimePlusNode node);
        TreeNode Visit(SPrimeEmptyNode node);
        TreeNode Visit(BNode node);
        TreeNode Visit(BPrimeMultNode node);
        TreeNode Visit(BPrimeEmptyNode node);
        TreeNode Visit(CNumberNode node);
        TreeNode Visit(CIdentifierNode node);
        TreeNode Visit(CPrimeMinusNode node);
        TreeNode Visit(CPrimeEmptyNode node);
    }
}
