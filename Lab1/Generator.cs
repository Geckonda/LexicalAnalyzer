using Lab1.Nodes;
using Lab1.Nodes.@abstract;
using System;
using System.Text;

namespace Lab1
{
    public class Generator : IGenerator
    {
        private string Indent(int offset) => new string(' ', offset * 5);

        public string Visit(SNode node, int offset)
        {
            var sb = new StringBuilder();
            sb.Append(node.B!.Accept(this, offset));
            sb.Append(node.SPrime!.Accept(this, offset));
            return sb.ToString();
        }

        public string Visit(SPrimePlusNode node, int offset)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{Indent(offset)}+");
            sb.Append(node.B!.Accept(this, offset + 1));
            sb.Append(node.SPrimeNext!.Accept(this, offset + 1));
            return sb.ToString();
        }

        public string Visit(SPrimeEmptyNode node, int offset)
        {
            return string.Empty;
        }

        public string Visit(BNode node, int offset)
        {
            var sb = new StringBuilder();
            sb.Append(node.C!.Accept(this, offset));
            sb.Append(node.BPrime!.Accept(this, offset));
            return sb.ToString();
        }

        public string Visit(BPrimeMultNode node, int offset)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{Indent(offset)}*");
            sb.Append(node.C!.Accept(this, offset + 1));
            sb.Append(node.BPrimeNext!.Accept(this, offset + 1));
            return sb.ToString();
        }

        public string Visit(BPrimeEmptyNode node, int offset)
        {
            return string.Empty;
        }

        public string Visit(CNumberNode node, int offset)
        {
            var sb = new StringBuilder();
            int value = Convert.ToInt32(node.Number!.Value, 2);
            sb.AppendLine($"{Indent(offset)}{value}");
            sb.Append(node.CPrime!.Accept(this, offset + 1));
            return sb.ToString();
        }

        public string Visit(CIdentifierNode node, int offset)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{Indent(offset)}{node.Id!.Value}");
            sb.Append(node.CPrime!.Accept(this, offset + 1));
            return sb.ToString();
        }

        public string Visit(CPrimeMinusNode node, int offset)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{Indent(offset)}-");
            sb.Append(node.CPrimeNext!.Accept(this, offset + 1));
            return sb.ToString();
        }

        public string Visit(CPrimeEmptyNode node, int offset)
        {
            return string.Empty;
        }
    }

}
