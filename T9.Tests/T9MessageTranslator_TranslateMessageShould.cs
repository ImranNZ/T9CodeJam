using System;
using T9.Classes;
using Xunit;

namespace T9.Tests
{
    public class T9MessageTranslator_TranslateMessageShould
    {
        private readonly T9MessageTranslator _translator;
        private readonly IKeypad _keypad;

        public T9MessageTranslator_TranslateMessageShould()
        {
            _keypad = new T9Keypad();
            _translator = new T9MessageTranslator(_keypad);
        }

        [Theory]
        [InlineData("hi", "44 444")]
        [InlineData("  ", "0 0")]
        [InlineData("yes", "999337777")]
        [InlineData("foo  bar", "333666 6660 022 2777")]
        [InlineData("hello world", "4433555 555666096667775553")]
        public void ReturnsCorrectTranslatedMessages(string input, string expected)
        {
            var actual = _translator.TranslateMessage(input);

            Assert.True(expected == actual, $"'{input}' should translate to '{expected}'");
        }

        [Theory]
        [InlineData("*")]
        [InlineData("333)")]
        [InlineData(" % ")]
        [InlineData("@   ")]
        [InlineData("$ 662")]
        [InlineData("")]
        public void ReturnsExceptionForInvalidInput(string input)
        {
            Assert.Throws<ArgumentException>(() => _translator.TranslateMessage(input));
        }
    }
}