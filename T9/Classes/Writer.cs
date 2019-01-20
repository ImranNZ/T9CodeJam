using System.IO;

namespace T9.Classes
{
    public class Writer : IWriter
    {
        private readonly StreamWriter _writer;

        public Writer(StreamWriter writer)
        {
            _writer = writer;
        }

        public void Close()
        {
            _writer.Close();
        }

        public void WriteLine(string output)
        {
            _writer.WriteLine(output);
        }
    }
}