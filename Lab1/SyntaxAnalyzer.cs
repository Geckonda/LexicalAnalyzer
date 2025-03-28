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
        public void ParseText()
        {
            _la.RecognizeNextToken(); // Распознаем первый токен в тексте.

            S(); // Вызываем процедуру разбора для стартового нетерминала S.

            if (_la.Token.Type != TokenKind.EndOfText) // Если текущий токен не является концом текста.
            {
                SyntaxError("После арифметического выражения идет еще какой-то текст"); // Обнаружена синтаксическая ошибка.
            }
        }
        /// <summary>
        /// S → B S'
        /// </summary>
        private void S()
        {
            B();
            SPrime();
        }
        /// <summary>
        /// S' → + B S' | ε
        /// </summary>
        private void SPrime()
        {
            if (_la.Token.Type == TokenKind.Plus) // First(+ B S') = { '+' }
            {
                Match(TokenKind.Plus);
                B();
                SPrime();
            }
            else if (_la.Token.Type != TokenKind.EndOfText) // Follow(S') = { $ }
            {
                SyntaxError("Ожидалось '+' или конец строки");
            }
        }
        /// <summary>
        ///  B → C B'
        /// </summary>
        private void B()
        {
            C();
            BPrime();
        }
        /// <summary>
        /// B' → * C B' | ε
        /// </summary>
        private void BPrime()
        {
            if (_la.Token.Type == TokenKind.Multiply) // First(* C B') = { '*' }
            {
                Match(TokenKind.Multiply);
                C();
                BPrime();
            }
            else if (_la.Token.Type != TokenKind.Plus &&
                 _la.Token.Type != TokenKind.EndOfText) // Follow(B') = { +, $ }
            {
                SyntaxError("Ожидалось '*', '+' или конец строки");
            }
        }
        /// <summary>
        /// C → <1> | <2> | <1> C' | <2> C'
        /// </summary>
        private void C()
        {
            if (_la.Token.Type == TokenKind.Number)
            {
                Match(TokenKind.Number);
                CPrime();
            }
            else if (_la.Token.Type == TokenKind.Identifier)
            {
                Match(TokenKind.Identifier);
                CPrime();
            }
            else
            {
                SyntaxError("Ожидалось слово 'первого типа' или 'второго типа'");
            }
        }
        /// <summary>
        /// C' → - C' | ε
        /// </summary>
        private void CPrime()
        {
            if (_la.Token.Type == TokenKind.Minus) // First(- C') = { '-' }
            {
                Match(TokenKind.Minus);
                CPrime();
            }
            else if (_la.Token.Type != TokenKind.Multiply &&
                     _la.Token.Type != TokenKind.Plus &&
                     _la.Token.Type != TokenKind.EndOfText) // Follow(C') = { *, +, $ }
            {
                SyntaxError("Ожидалось '-', '*', '+' или конец строки");
            }
        }

    }
}
