using Lab1.Nodes;
using Lab1.Nodes.@abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class SyntaxAnalyzer
    {
        private LexicalAnalyzer _la;

        /// <summary>
        /// Конструктор синтаксического анализатора. 
        /// </summary>
        /// <param name="inputLines">Исходный текст</param>
        public SyntaxAnalyzer(string[] inputLines)
        {
            // Создаем лексический анализатор.
            // Передаем ему текст.
            _la = new LexicalAnalyzer(inputLines);
        }

        /// <summary>
        /// Обработать синтаксическую ошибку.
        /// </summary>
        /// <param name="msg">описание ошибки.</param>
        private void SyntaxError(string msg)
        {
            // Генерируем исключительную ситуацию, тем самым полностью прерывая процесс анализа текста.
            throw new SynAnException(msg, _la.CurLineIndex, _la.CurSymIndex);
        }

        /// <summary>
        /// Проверить, что тип текущего распознанного токена совпадает с заданным.
        /// Если совпадает, то распознать следующий токен, иначе синтаксическая ошибка.
        /// </summary>
        private void Match(TokenKind tkn)
        {
            if (_la.Token.Type == tkn) // Сравниваем.
            {
                _la.RecognizeNextToken(); // Распознаем следующий токен.
            }
            else
            {
                SyntaxError("Ожидалось " + tkn.ToString()); // Обнаружена синтаксическая ошибка.
            }
        }

        /// <summary>
        /// Проверить, что текущий распознанный токен совпадает с заданным (сравнение производится в нижнем регистре).
        /// Если совпадает, то распознать следующий токен, иначе синтаксическая ошибка.
        /// </summary>
        private void Match(string tkn)
        {
            if (_la.Token.Value.ToLower() == tkn.ToLower()) // Сравниваем.
            {
                _la.RecognizeNextToken(); // Распознаем следующий токен.
            }
            else
            {
                SyntaxError("Ожидалось " + tkn); // Обнаружена синтаксическая ошибка.
            }
        }

        /// <summary>
        /// Провести синтаксический анализ текста.
        /// </summary>
        public SNode? ParseText()
        {
            _la.RecognizeNextToken(); // Распознаем первый токен в тексте.
            if (_la.Token.Type == TokenKind.EndOfText) return null;

            SNode node = S(); // Вызываем процедуру разбора для стартового нетерминала S.
            
            if (_la.Token.Type != TokenKind.EndOfText) // Если текущий токен не является концом текста.
            {
                SyntaxError("После арифметического выражения идет еще какой-то текст"); // Обнаружена синтаксическая ошибка.
                return null;
            }
            return node;
        }
        /// <summary>
        /// S → B S'
        /// </summary>
        private SNode S()
        {
            SNode node = new SNode();
            node.B = B();
            node.SPrime = SPrime();
            return node;
        }
        /// <summary>
        /// S' → + B S' | ε
        /// </summary>
        private SPrimeNode SPrime()
        {
            if (_la.Token.Type == TokenKind.Plus) // First(+ B S') = { '+' }
            {
                SPrimePlusNode node = new SPrimePlusNode();
                node.Plus = _la.Token;
                Match(TokenKind.Plus);
                node.B = B();
                node.SPrimeNext = SPrime();
                return node;
            }
            else if (_la.Token.Type != TokenKind.EndOfText) // Follow(S') = { $ }
            {
                SyntaxError("Ожидалось '+' или конец строки");
                return null!;
            }
            return new SPrimeEmptyNode();
        }
        /// <summary>
        ///  B → C B'
        /// </summary>
        private BNode B()
        {
            BNode node = new BNode();
            node.C = C();
            node.BPrime = BPrime();
            return node;
        }
        /// <summary>
        /// B' → * C B' | ε
        /// </summary>
        private BPrimeNode BPrime()
        {
            if (_la.Token.Type == TokenKind.Multiply) // First(* C B') = { '*' }
            {
                BPrimeMultNode node = new BPrimeMultNode();
                node.Mult = _la.Token;
                Match(TokenKind.Multiply);
                node.C = C();
                node.BPrimeNext = BPrime();
                return node;
            }
            else if (_la.Token.Type != TokenKind.Plus &&
                 _la.Token.Type != TokenKind.EndOfText) // Follow(B') = { +, $ }
            {
                SyntaxError("Ожидалось '*', '+' или конец строки");
                return null!;
            }
            return new BPrimeEmptyNode();
        }
        /// <summary>
        /// C → <1> C' | <2> C'
        /// </summary>
        private CNode C()
        {
            if (_la.Token.Type == TokenKind.Number)
            {
                CNumberNode node = new CNumberNode();
                node.Number = _la.Token;
                Match(TokenKind.Number);
                node.CPrime = CPrime();
                return node;
            }
            else if (_la.Token.Type == TokenKind.Identifier)
            {
                CIdentifierNode node = new CIdentifierNode();
                node.Id = _la.Token;
                Match(TokenKind.Identifier);
                node.CPrime = CPrime();
                return node;
            }
            else
            {
                SyntaxError("Ожидалось слово 'первого типа' или 'второго типа'");
                return null!;
            }
        }
        /// <summary>
        /// C' → - C' | ε
        /// </summary>
        private CPrimeNode CPrime()
        {
            if (_la.Token.Type == TokenKind.Minus) // First(- C') = { '-' }
            {
                CPrimeMinusNode node = new CPrimeMinusNode();
                node.Minus = _la.Token;
                Match(TokenKind.Minus);
                node.CPrimeNext = CPrime();
                return node;
            }
            else if (_la.Token.Type != TokenKind.Multiply &&
                     _la.Token.Type != TokenKind.Plus &&
                     _la.Token.Type != TokenKind.EndOfText) // Follow(C') = { *, +, $ }
            {
                SyntaxError("Ожидалось '-', '*', '+' или конец строки");
                return null!;
            }
            return new CPrimeEmptyNode();
        }

    }
}
