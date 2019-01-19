using System;
using System.Text;

namespace T9.Classes
{
    public class T9MessageTranslator : IMessageTranslator
    {
        private readonly IKeypad _keypad;

        public T9MessageTranslator(IKeypad keypad)
        {
            _keypad = keypad;
        }

        public string TranslateMessage(string input)
        {
            if (string.IsNullOrEmpty(input)) throw new ArgumentException();

            var sb = new StringBuilder("");

            for (int i = 0; i < input.Length; i++)
            {
                var digit = _keypad.GetDigitOf(input[i]);
                var position = _keypad.GetPositionOf(input[i]);

                for (int j = 0; j < position; j++) sb.Append($"{digit}");

                var nextIndex = i + 1;

                if (nextIndex < input.Length && _keypad.GetDigitOf(input[nextIndex]) == digit) sb.Append(" ");
            }

            return sb.ToString();
        }
    }
}