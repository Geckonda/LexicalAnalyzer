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

            //E(); // Вызываем процедуру разбора для стартового нетерминала E.

            if (_la.Token.Type != TokenKind.EndOfText) // Если текущий токен не является концом текста.
            {
                SyntaxError("После арифметического выражения идет еще какой-то текст"); // Обнаружена синтаксическая ошибка.
            }
        }
    }
}
