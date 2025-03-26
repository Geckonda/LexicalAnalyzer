using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class Transliterator
    {
        private const char commentSymbol1 = '{'; // Первый символ комментария.
        private const char commentSymbol2 = '}'; // Второй символ комментария.

        public char CommentSymbol1 { get => commentSymbol1; }
        public char CommentSymbol2 { get => commentSymbol2; }

        /// <summary>
        /// Входной текст - массив строк.
        /// </summary>
        private string[] inputLines;
        /// <summary>
        /// Индекс текущей строки.
        /// </summary>
        private int curLineIndex;
        /// <summary>
        /// Индекс текущего символа в текущей строке.
        /// </summary>
        private int curSymIndex;
        /// <summary>
        /// Текущий символ
        /// </summary>
        private char curSym;
        /// <summary>
        /// Тип текущего символа.
        /// </summary>
        private SymbolKind curSymKind;

        public int CurLineIndex => curLineIndex;
        public int CurSymIndex => curSymIndex;
        public char CurSym => curSym;
        public SymbolKind CurSymKind => curSymKind;

        public bool CurSymIsSpaceOrEndOfLine => (curSymKind == SymbolKind.Space)
                                                || (curSymKind == SymbolKind.EndOfLine);

        public Transliterator(string[] lines)
        {
            this.inputLines = lines;
            // Обнуляем поля.
            curLineIndex = 0;
            curSymIndex = -1;
            curSym = (char)0;

            // Считываем первый символ входного текста.
            ReadNextSymbol();
        }

        public void ReadNextSymbol()
        {
            if (curLineIndex >= inputLines.Length) // Если индекс текущей строки выходит за пределы текстового поля.
            {
                curSym = (char)0; // Обнуляем значение текущего символа.
                curSymKind = SymbolKind.EndOfText; // Тип текущего символа - конец текста.
                return;
            }

            curSymIndex++; // Увеличиваем индекс текущего символа.
            var x = inputLines[curLineIndex].Length;
            if (curSymIndex >= x) // Если индекс текущего символа выходит за пределы текущей строки.
            {
                curLineIndex++; // Увеличиваем индекс текущей строки.

                if (curLineIndex < inputLines.Length) // Если индекс текущей строки находится в пределах текстового поля.
                {
                    curSym = (char)0; // Обнуляем значение текущего символа.
                    curSymIndex = -1; // Переносим индекс текущего символа в начало строки.
                    curSymKind = SymbolKind.EndOfLine; // Тип текущего символа - конец строки.
                    return;
                }
                else
                {
                    curSym = (char)0; // Обнуляем значение текущего символа.
                    curSymKind = SymbolKind.EndOfText; // Тип текущего символа - конец текста.
                    return;
                }
            }

            curSym = inputLines[curLineIndex][curSymIndex]; // Считываем текущий символ.
            ClassifyCurrentSymbol();
        }
        public void ClassifyCurrentSymbol()
        {
            if (((int)curSym >= (int)'a') && ((int)curSym <= (int)'d')) // Если текущий символ лежит в диапазоне заглавных латинских букв.
            {
                curSymKind = SymbolKind.Letter; // Тип текущего символа - буква.
            }
            else if (((int)curSym >= (int)'0') && ((int)curSym <= (int)'1')) // Если текущий символ лежит в диапазоне цифр.
            {
                curSymKind = SymbolKind.Digit; // Тип текущего символа - цифра.
            }
            else
            {
                switch (curSym)
                {
                    case ' ': // Если текущий символ - пробел.
                        curSymKind = SymbolKind.Space; // Тип текущего символа - пробел.
                        break;

                    case commentSymbol1:
                    case commentSymbol2:
                        curSymKind = SymbolKind.Reserved; // Тип текущего символа - зарезервированный.
                        break;

                    default:
                        curSymKind = SymbolKind.Other; // Тип текущего символа - другой.
                        break;
                }
            }
        }
    }
}
