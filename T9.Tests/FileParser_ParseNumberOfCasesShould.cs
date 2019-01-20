using System;
using System.IO;
using Moq;
using T9.Classes;
using Xunit;

namespace T9.Tests
{
    public class FileParser_ParseNumberOfCasesShould
    {
        private readonly FileParser _parser;
        private readonly Mock<IWriter> _writer;
        private readonly Mock<IReader> _reader;
        private readonly Mock<IMessageTranslator> _translator;

        public FileParser_ParseNumberOfCasesShould()
        {
            _translator = new Mock<IMessageTranslator>();

            _writer = new Mock<IWriter>();
            _reader = new Mock<IReader>();

            _parser = new FileParser(_translator.Object, _reader.Object, _writer.Object);
        }

        [Theory]
        [InlineData("1")]
        [InlineData("100")]
        public void NotThrowExceptionGivenValidInput(string input)
        {
            _reader
                .Setup(x => x.ReadLine())
                .Returns(input);

            _parser.ParseNumberOfCases();
        }

        [Theory]
        [InlineData("101")]
        [InlineData("0")]
        public void ThrowExceptionGivenInvalidInput(string input)
        {
            _reader
                .Setup(x => x.ReadLine())
                .Returns(input);
            Assert.Throws<ArgumentException>(() => _parser.ParseNumberOfCases());
        }
    }
}