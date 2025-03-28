﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace Lab1
{
    /// <summary>
    /// Тип символа.
    /// </summary>
    public enum SymbolKind
    {
        Letter,    // Буква.
        Digit,     // Цифра.
        Space,     // Пробел.
        Reserved,  // Зарезервированный.
        Other,     // Другой.
        EndOfLine, // Конец строки.
        EndOfText  // Конец текста.
    };
    /// <summary>
    ///  Класс "Лексический анализатор".
    /// При обнаружении ошибки в исходном тексте он генерирует исключительную ситуацию LexAnException.
    /// </summary>
    class LexicalAnalyzer
    {
        private Transliterator _tr;

        private const char commentSymbol1 = '('; // Первый символ комментария.
        private const char commentSymbol2 = '*'; // Второй символ комментария.
        private const char commentSymbol3 = ')'; // Третий символ комментария.


        private Token token;
        /// <summary>
        /// Токен, распознанный при последнем вызове метода RecognizeNextToken() - свойство только для чтения.
        /// </summary>
        public Token Token
        {
            get { return token; }
        }
        public LexicalAnalyzer(string[] lines)
        {
            _tr = new(lines);

            token = null!;
        }

        /// Обработать лексическую ошибку.
        /// <param name="msg">Описание ошибки</param>
        /// <exception cref="LexAnException">Лексическое исключение</exception>
        private void LexicalError(string msg)
        {
            // Генерируем исключительную ситуацию, тем самым полностью прерывая процесс анализа текста.
            throw new LexAnException(msg,
                _tr.CurLineIndex,
                _tr.CurSymIndex);
        }

        /// <summary>
        /// Считать следующий символ.
        /// </summary>
        private void ReadNextSymbol()
        {
            _tr.ReadNextSymbol();
        }
        /// <summary>
        /// Состояния для идентификатора
        /// </summary>
        enum IdentifierStates { A, B, Fin }
        /// <summary>
        /// Текущее состояние идентификатора
        /// </summary>
        private IdentifierStates _identifierState;

        /// <summary>
        /// Распознать идентификатор.
        /// </summary>
        private void RecognizeIdentifier()
        {
            _identifierState = IdentifierStates.A;
            var stateHandlers = new Dictionary<IdentifierStates, Action>
            {
                [IdentifierStates.A] = () => HandleStateA(),
                [IdentifierStates.B] = () => HandleStateB()
            };

            while (_identifierState != IdentifierStates.Fin)
            {
                stateHandlers[_identifierState]?.Invoke();
                token.Type = TokenKind.Identifier;
            }
        }
        private void HandleStateA()
        {
            var transitions = new Dictionary<Func<bool>, Action>
            {
                [() => _tr.CurSym >= 'b' && _tr.CurSym <= 'd'] = () => _identifierState = IdentifierStates.A,
                [() => _tr.CurSym == 'a'] = () => _identifierState = IdentifierStates.B
            };

            if (!TryHandleTransition(transitions))
            {
                _identifierState = IdentifierStates.Fin;
                return;
            }

            HandleSymbol();
        }
        private void HandleStateB()
        {
            var transitions = new Dictionary<Func<bool>, Action>
            {
                [() => _tr.CurSym == 'a'] = () => _identifierState = IdentifierStates.B,
                [() => _tr.CurSym == 'c' || _tr.CurSym == 'd'] = () => _identifierState = IdentifierStates.A,
                [() => _tr.CurSym == 'b'] = () => LexicalError("Ожидались 'a', 'c', 'd' или конец")
            };

            if (!TryHandleTransition(transitions))
            {
                _identifierState = IdentifierStates.Fin;
                return;
            }

            HandleSymbol();
        }
        private bool TryHandleTransition(Dictionary<Func<bool>, Action> transitions)
        {
            foreach (var transition in transitions)
            {
                if (transition.Key()) // Проверяем условие (Func<bool>)
                {
                    transition.Value(); // Выполняем действие (Action)
                    return true;
                }
            }
            return false;
        }
        private void HandleSymbol()
        {
            token.Value += _tr.CurSym;
            ReadNextSymbol();
        }


        /// <summary>
        /// Состояния для числа
        /// </summary>
        enum DigitStates { A, B, C, D, E, F, G, H, Fin }
        /// <summary>
        /// Распознать число (целое или вещественное).
        /// </summary>
        private void RecognizeNumber()
        {
            var state = DigitStates.A;
            while (state != DigitStates.Fin)
            {
                switch (state)
                {
                    case DigitStates.A:
                        {
                            if (_tr.CurSym == '0')
                                state = DigitStates.B;
                            else if (_tr.CurSym == '1')
                                state = DigitStates.D;
                            else
                                LexicalError("Ожидались '0' или '1'"); // Обнаружена ошибка в тексте.
                            token.Value += _tr.CurSym; // Наращиваем значение текущего токена.
                            ReadNextSymbol(); // Читаем следующий символ в тексте.
                            break;
                        }
                    case DigitStates.B:
                        {
                            if (_tr.CurSym == '1')
                            {
                                token.Value += _tr.CurSym; // Наращиваем значение текущего токена.
                                ReadNextSymbol(); // Читаем следующий символ в тексте.
                                state = DigitStates.C;
                            }
                            else
                                LexicalError("Ожидалось '1'"); // Обнаружена ошибка в тексте.
                            break;
                        }
                    case DigitStates.D:
                        {
                            if (_tr.CurSym == '1')
                            {
                                token.Value += _tr.CurSym; // Наращиваем значение текущего токена.
                                ReadNextSymbol(); // Читаем следующий символ в тексте.
                                state = DigitStates.E;
                            }
                            else
                                LexicalError("Ожидалось '1'"); // Обнаружена ошибка в тексте.
                            break;
                        }
                    case DigitStates.C:
                        {
                            if (_tr.CurSym == '1')
                            {
                                token.Value += _tr.CurSym; // Наращиваем значение текущего токена.
                                ReadNextSymbol(); // Читаем следующий символ в тексте.
                                state = DigitStates.H;
                            }
                            else
                                LexicalError("Ожидалось '1'"); // Обнаружена ошибка в тексте.
                            break;
                        }
                    case DigitStates.E:
                        {
                            if (_tr.CurSym == '1')
                            {
                                token.Value += _tr.CurSym; // Наращиваем значение текущего токена.
                                ReadNextSymbol(); // Читаем следующий символ в тексте.
                                state = DigitStates.A;
                            }
                            else
                                LexicalError("Ожидалось '1'"); // Обнаружена ошибка в тексте.
                            break;
                        }
                    case DigitStates.H:
                        {
                            if (_tr.CurSym == '1')
                            {
                                token.Value += _tr.CurSym; // Наращиваем значение текущего токена.
                                ReadNextSymbol(); // Читаем следующий символ в тексте.
                                state = DigitStates.F;
                            }
                            else
                                state = DigitStates.Fin;
                            break;
                        }
                    case DigitStates.F:
                        {
                            if (_tr.CurSym == '0')
                            {
                                token.Value += _tr.CurSym; // Наращиваем значение текущего токена.
                                ReadNextSymbol(); // Читаем следующий символ в тексте.
                                state = DigitStates.G;
                            }
                            else
                                LexicalError("Ожидалось '0'"); // Обнаружена ошибка в тексте.
                            break;
                        }
                    case DigitStates.G:
                        {
                            if (_tr.CurSym == '0')
                            {
                                token.Value += _tr.CurSym; // Наращиваем значение текущего токена.
                                ReadNextSymbol(); // Читаем следующий символ в тексте.
                                state = DigitStates.H;
                            }
                            else
                                LexicalError("Ожидалось '0'"); // Обнаружена ошибка в тексте.
                            break;
                        }
                }
            }
            token.Type = TokenKind.Number;
        }
        /// <summary>
        /// Состояния для комментария
        /// </summary>
        enum CommentStates { S, A, B, C, Fin }
        /// <summary>
        /// Пропустить комментарий.
        /// </summary>
        private void SkipComment()
        {
            var state = CommentStates.S;
            while (state != CommentStates.Fin)
            {
                switch (state)
                {
                    case CommentStates.S:
                        {
                            if (_tr.CurSym == commentSymbol1)
                            {
                                ReadNextSymbol();
                                state = CommentStates.A;
                            }
                            else
                                LexicalError("Ожидалось " + commentSymbol1); // Обнаружена ошибка в тексте.
                            break;
                        }
                    case CommentStates.A:
                        {
                            if (_tr.CurSym == commentSymbol2)
                            {
                                ReadNextSymbol();
                                state = CommentStates.B;
                            }
                            else if (_tr.CurSymKind == SymbolKind.EndOfText)
                                LexicalError("Незаконченный комментарий"); // Обнаружена ошибка в тексте.
                            else
                                LexicalError("Ожидалось " + commentSymbol2); // Обнаружена ошибка в тексте.
                            break;
                        }
                    case CommentStates.B:
                        {
                            if(_tr.CurSym == commentSymbol2)
                            {
                                ReadNextSymbol();
                                state = CommentStates.C;
                            }
                            else if (_tr.CurSymKind == SymbolKind.EndOfText)
                                LexicalError("Незаконченный комментарий"); // Обнаружена ошибка в тексте.
                            else
                            {
                                ReadNextSymbol();
                                state = CommentStates.B;
                            }
                            break;
                        }
                    case CommentStates.C:
                        {
                            if(_tr.CurSym == commentSymbol3)
                            {
                                ReadNextSymbol();
                                state = CommentStates.Fin;
                            }
                            else if (_tr.CurSymKind == SymbolKind.EndOfText)
                                LexicalError("Незаконченный комментарий"); // Обнаружена ошибка в тексте.
                            else
                            {
                                ReadNextSymbol();
                                state = CommentStates.B;
                            }
                            break;
                        }
                }
            }
        }

        /// <summary>
        /// Распознать следующий токен в тексте.
        /// </summary>
        public void RecognizeNextToken()
        {
            // На данный момент уже прочитан символ, следующий за токеном, распознанным в прошлом вызове этого метода.
            // Если же это первый вызов, то на данный момент уже прочитан первый символ текста (в конструкторе).

            // Цикл пропуска пробелов, переходов на новую строку, комментариев.
            while (_tr.CurSymIsSpaceOrEndOfLine ||
                    (_tr.CurSym == commentSymbol1))
            {
                if (_tr.CurSym == commentSymbol1) // Если текущий символ - первый символ комментария.
                    SkipComment(); // Пропускаем комментарий.
                else
                    ReadNextSymbol(); // Пропускаем пробел или переход на новую строку.
            }

            // Создаем новый экземпляр токена.
            token = new Token();

            // Запоминаем позицию начала токена в исходном тексте. 
            token.LineIndex = _tr.CurLineIndex;
            token.SymStartIndex = _tr.CurSymIndex;

            switch (_tr.CurSymKind) // Анализируем текущий символ.
            {
                case SymbolKind.Letter: // Если текущий символ - буква.
                    RecognizeIdentifier(); // Вызываем процедуру распознавания идентификатора.            
                    break;

                case SymbolKind.Digit: // Если текущий символ - цифра.
                    RecognizeNumber(); // Вызываем процедуру распознавания числа (целого или вещественного).
                    break;

                case SymbolKind.EndOfText: // Если текущий символ - конец текста.
                    token.Type = TokenKind.EndOfText; // Тип распознанного токена - конец текста.
                    break;

                default: // Если текущий символ - какой-то другой.
                    LexicalError("Недопустимый символ"); // Обнаружена ошибка в тексте.
                    break;
            }
        }
    }
}
