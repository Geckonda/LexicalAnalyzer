using Lab1.Nodes;
using Lab1.Nodes.@abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class PrintTreeVisitor : IVisitor
    {
        public TreeNode Visit(SNode node)
        {
            var treeNode = new TreeNode("S");
            treeNode.Nodes.Add(SafeVisit(node.B, "B → ε"));
            treeNode.Nodes.Add(SafeVisit(node.SPrime, "S' → ε"));
            return treeNode;
        }

        public TreeNode Visit(SPrimePlusNode node)
        {
            var treeNode = new TreeNode("S' → + B S'");
            treeNode.Nodes.Add(new TreeNode("+"));
            treeNode.Nodes.Add(SafeVisit(node.B, "B → ε"));
            treeNode.Nodes.Add(SafeVisit(node.SPrimeNext, "S' → ε"));
            return treeNode;
        }

        public TreeNode Visit(SPrimeEmptyNode node)
        {
            return new TreeNode("S' → ε");
        }

        public TreeNode Visit(BNode node)
        {
            var treeNode = new TreeNode("B");
            treeNode.Nodes.Add(SafeVisit(node.C, "C → ε"));
            treeNode.Nodes.Add(SafeVisit(node.BPrime, "B' → ε"));
            return treeNode;
        }

        public TreeNode Visit(BPrimeMultNode node)
        {
            var treeNode = new TreeNode("B' → * C B'");
            treeNode.Nodes.Add(new TreeNode("*"));
            treeNode.Nodes.Add(SafeVisit(node.C, "C → ε"));
            treeNode.Nodes.Add(SafeVisit(node.BPrimeNext, "B' → ε"));
            return treeNode;
        }

        public TreeNode Visit(BPrimeEmptyNode node)
        {
            return new TreeNode("B' → ε");
        }

        public TreeNode Visit(CNumberNode node)
        {
            var treeNode = new TreeNode($"C.num → ({node.Number!.Value}) C' ");
            treeNode.Nodes.Add(SafeVisit(node.CPrime, "C' → ε"));
            return treeNode;
        }

        public TreeNode Visit(CIdentifierNode node)
        {
            var treeNode = new TreeNode($"C.id → ({node.Id!.Value}) C' ");
            treeNode.Nodes.Add(SafeVisit(node.CPrime, "C' → ε"));
            return treeNode;
        }

        public TreeNode Visit(CPrimeMinusNode node)
        {
            var treeNode = new TreeNode("C' → - C");
            treeNode.Nodes.Add(new TreeNode("-"));
            treeNode.Nodes.Add(SafeVisit(node.CPrimeNext, "C → ε"));
            return treeNode;
        }

        public TreeNode Visit(CPrimeEmptyNode node)
        {
            return new TreeNode("C' → ε");
        }

        private TreeNode SafeVisit(Node? node, string emptyLabel)
        {
            return node != null ? node.Accept(this) : new TreeNode(emptyLabel);
        }
    }
}
