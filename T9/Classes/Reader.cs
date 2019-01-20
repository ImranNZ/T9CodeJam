using System.IO;

namespace T9.Classes
{
    public class Reader : IReader
    {
        private readonly StreamReader _reader;

        public Reader(StreamReader reader)
        {
            _reader = reader;
        }

        public void Close()
        {
            _reader.Close();
        }

        public string ReadLine()
        {
            return _reader.ReadLine();
        }
    }
}