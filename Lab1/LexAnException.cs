using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    /// <summary>
    /// Класс исключительных ситуаций лексического анализа.
    /// </summary>
    class LexAnException : Exception
    {
        /// <summary>
        /// Позиция возникновения исключительной ситуации в анализируемом тексте.
        /// Индекс строки
        /// </summary>
        private int lineIndex;
        /// <summary>
        /// Индекс символа.
        /// </summary>
        private int symIndex;

        /// <summary>
        /// Индекс строки, где возникла исключительная ситуация - свойство только для чтения.
        /// </summary>
        public int LineIndex
        {
            get { return lineIndex; }
        }

        /// <summary>
        /// Индекс символа, на котором возникла исключительная ситуация - свойство только для чтения.
        /// </summary>
        public int SymIndex
        {
            get { return symIndex; }
        }

        /// <summary>
        /// Конструктор исключительной ситуации.
        /// </summary>
        /// <param name="message">Описание исключительной ситуации.</param>
        /// <param name="lineIndex">Позиция возникновения исключительной ситуации в анализируемом тексте.</param>
        /// <param name="symIndex">Позиция возникновения исключительной ситуации в анализируемом тексте.</param>
        public LexAnException(string message, int lineIndex, int symIndex) : base(message)
        {
            this.lineIndex = lineIndex;
            this.symIndex = symIndex;
        }
    }
}
