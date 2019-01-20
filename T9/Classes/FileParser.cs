using System;
using System.Collections.Generic;
using System.IO;

namespace T9.Classes
{
    public class FileParser : IInputParser
    {
        private readonly IMessageTranslator _translator;
        private readonly IReader _reader;
        private readonly IWriter _writer;
        private int _numberOfCases = 0;
        private List<string> _messages;

        public FileParser(IMessageTranslator translator, IReader reader, IWriter writer)
        {
            _translator = translator;
            _reader = reader;
            _writer = writer;
            _messages = new List<string>();
        }

        public void Start()
        {
            ParseNumberOfCases();
            ParseCases();
            DisplayCases();
            _reader.Close();
            _writer.Close();
        }

        public void ParseNumberOfCases()
        {
            try
            {
                var n = Convert.ToInt32(_reader.ReadLine());

                if (n < 1 || n > 100) throw new ArgumentException("Invalid number of cases; N must be between 1 and 100.");

                _numberOfCases = n;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occurred: {ex.Message}");
                throw;
            }
        }

        public void ParseCases()
        {
            try
            {
                int i = 1;
                while (_numberOfCases != 0)
                {
                    var input = _reader.ReadLine();
                    _messages.Add($"Case #{i}: {_translator.TranslateMessage(input)}");
                    i++;
                    _numberOfCases--;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                throw;
            }
        }

        public void DisplayCases()
        {
            _messages.ForEach(x => _writer.WriteLine(x));
        }
    }
}