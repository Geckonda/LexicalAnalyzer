using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    /// <summary>
    /// Тип токена.
    /// </summary>
    enum TokenKind
    {
        Number,     // Число.
        Identifier, // Идентификатор.
        EndOfText,  // Конец текста.
        Unknown     // Неизвестный.
    };

    class Token
    {
        private string? value;   // Значение токена (само слово).
        private TokenKind type; // Тип токена.

        // Позиция токена в исходном тексте.
        private int lineIndex;     // Индекс строки.
        private int symStartIndex; // Индекс символа в строке lineIndex, с которого начинается токен.

        /// <summary>
        /// Значение токена (само слово).
        /// </summary>
        public string? Value
        {
            get { return value; }
            set { this.value = value; }
        }

        /// <summary>
        /// Тип токена.
        /// </summary>
        public TokenKind Type
        {
            get { return type; }
            set { this.type = value; }
        }

        /// <summary>
        /// Индекс строки в исходном тексте, на которой расположен токен.
        /// </summary>
        public int LineIndex
        {
            get { return lineIndex; }
            set { this.lineIndex = value; }
        }

        /// <summary>
        /// Индекс символа в строке LineIndex в исходном тексте, с которого начинается токен.
        /// </summary>
        public int SymStartIndex
        {
            get { return symStartIndex; }
            set { this.symStartIndex = value; }
        }

        /// <summary>
        /// Сбросить значения полей токена.
        /// </summary>
        public void Reset()
        {
            this.value = "";
            this.type = TokenKind.Unknown;
            this.lineIndex = -1;
            this.symStartIndex = -1;
        }

        public Token()
        {
            Reset(); // Сбрасываем значения полей токена.
        }
    }

}
