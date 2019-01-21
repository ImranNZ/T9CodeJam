using System;
using System.IO;
using Moq;
using T9.Classes;
using Xunit;

namespace T9.Tests
{
    public class FileParser_ParseCasesShould
    {
        private readonly FileParser _parser;
        private readonly Mock<IWriter> _writer;
        private readonly Mock<IReader> _reader;
        private readonly Mock<IMessageTranslator> _translator;

        public FileParser_ParseCasesShould()
        {
            _translator = new Mock<IMessageTranslator>();

            _writer = new Mock<IWriter>();
            _reader = new Mock<IReader>();

            _parser = new FileParser(_translator.Object, _reader.Object, _writer.Object);
        }

        [Theory]
        [InlineData(@"vTvjqvjzeKMDKZX0MuY1QnBVWkh9Yo2f28sczFvUrue9fYn4ieDnpVYVbaYsOva3bbZHHwQf8PZO7ds0IHDSOzydoFn1ToiOR0RKPFeiWp0nRPWzHsZc1YYG
        OWIGKsl4MwqKMCGgiXvzs6RxfjrdL7sRxxPKCZ3eqsTWSs3Qpj03suaQj6o4LMmuhH6XXNViCceRoa3w6I5jhXkT1BLEYmbn6n0fFstMPhSeX5g2BAVyWIqMwBXwOvF23MTtZ3
        RKny6tEpPB6bcg1YRdETLeNnQ7sPlfDTnsbRGkTPwULXMjrVWiVk6UyxMIQw4Tpme7H6HmYmgmaJuHqKtjd1vg8LNTRMB0z4GssuCAeSQMGn4Dp5bEzSrd9Ax9igdlqjpfpxUG
        aQXOs6fx67IlxODEPu5d22JJ1uYLdDy3u3MQcYi21pvV6lkd5UWNvuWP8ePXZouzlMTF82i2kOkHVQbD2jz6ZvlDurpSLnbf97y7Mj1sUEQaKBpPG9Q2hkIwLn4qBhcOOlyDvl
        aE4RRtJdeJDtBvI7QMx0F1TXd0bfsoSrZJL8oFgm8kt4eYMyHBEHybd640n63bHUasfGXK3vcVJy8nOKZifWKpbHtBRMOu6zPjBdYB7iOhrE5xRkHqdlLQCYsVUMYJtBqyVUCk
        uV7DJAhyaztvijtKONFIbsnEn5QUlEy25zda0N2objtIHUWsDFzOtYc703b05s92Dz9UlnwRSvhPYEaUamrOehq4Q18FiyEnU9Y54nzOxwXZ1psOx3kPNij7BnJQur2zyyrVEg
        XDkOnwxmBMYf8OuSGEP1aUGwDBKHL235rjBDZAaobub0xEpSqJCfN4bSM7XtOnaYkAUMrrf1RgbKDHFAlijny6ACuO1nE4elETqvLwBLxg3xZwLAvqnzObXAWIOaOfAFniX4ix
        hpIHc7")]
        public void NotThrowExceptionGivenValidInput(string input)
        {
            _reader
                .Setup(x => x.ReadLine())
                .Returns(input);

            _parser.ParseCases();
        }

        [Theory]
        [InlineData("")]
        [InlineData(@"vTvjqvjzeKMDKZX0MuY1QnBVWkh9Yo2f28sczFvUrue9fYn4ieDnpVYVbaYsOva3bbZHHwQf8PZO7ds0IHDSOzydoFn1ToiOR0RKPFeiWp0nRPWzHsZc1YYG
        OWIGKsl4MwqKMCGgiXvzs6RxfjrdL7sRxxPKCZ3eqsTWSs3Qpj03suaQj6o4LMmuhH6XXNViCceRoa3w6I5jhXkT1BLEYmbn6n0fFstMPhSeX5g2BAVyWIqMwBXwOvF23MTtZ3
        RKny6tEpPB6bcg1YRdETLeNnQ7sPlfDTnsbRGkTPwULXMjrVWiVk6UyxMIQw4Tpme7H6HmYmgmaJuHqKtjd1vg8LNTRMB0z4GssuCAeSQMGn4Dp5bEzSrd9Ax9igdlqjpfpxUG
        aQXOs6fx67IlxODEPu5d22JJ1uYLdDy3u3MQcYi21pvV6lkd5UWNvuWP8ePXZouzlMTF82i2kOkHVQbD2jz6ZvlDurpSLnbf97y7Mj1sUEQaKBpPG9Q2hkIwLn4qBhcOOlyDvl
        aE4RRtJdeJDtBvI7QMx0F1TXd0bfsoSrZJL8oFgm8kt4eYMyHBEHybd640n63bHUasfGXK3vcVJy8nOKZifWKpbHtBRMOu6zPjBdYB7iOhrE5xRkHqdlLQCYsVUMYJtBqyVUCk
        uV7DJAhyaztvijtKONFIbsnEn5QUlEy25zda0N2objtIHUWsDFzOtYc703b05s92Dz9UlnwRSvhPYEaUamrOehq4Q18FiyEnU9Y54nzOxwXZ1psOx3kPNij7BnJQur2zyyrVEg
        XDkOnwxmBMYf8OuSGEP1aUGwDBKHL235rjBDZAaobub0xEpSqJCfN4bSM7XtOnaYkAUMrrf1RgbKDHFAlijny6ACuO1nE4elETqvLwBLxg3xZwLAvqnzObXAWIOaOfAFniX4ix
        hpIHc7o")]
        public void ThrowExceptionGivenInvalidInput(string input)
        {
            _reader
                .Setup(x => x.ReadLine())
                .Returns(input);
            Assert.Throws<ArgumentException>(() => _parser.ParseCases());
        }
    }
}