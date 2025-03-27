using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    /// <summary>
    /// Класс исключительных ситуаций синтаксического анализа.
    /// </summary>
    class SynAnException : Exception
    {
        // Позиция возникновения исключительной ситуации в анализируемом тексте.
        private int lineIndex; // Индекс строки.
        private int symIndex;  // Индекс символа.

        /// <summary>
        /// Индекс строки, где возникла исключительная ситуация - свойство только для чтения.
        /// </summary>
        public int LineIndex => lineIndex;

        /// <summary>
        /// Индекс символа, на котором возникла исключительная ситуация - свойство только для чтения.
        /// </summary>
        public int SymIndex => symIndex;

        /// <summary>
        /// Конструктор исключительной ситуации.
        /// </summary>
        /// <param name="message">Описание исключительной ситуации.</param>
        /// <param name="lineIndex">Позиция строки возникновения исключительной ситуации в анализируемом тексте.</param>
        /// <param name="symIndex">Позиция символа возникновения исключительной ситуации в анализируемом тексте.</param>
        public SynAnException(string message, int lineIndex, int symIndex)
            : base(message)
        {
            this.lineIndex = lineIndex;
            this.symIndex = symIndex;
        }
    }
}
