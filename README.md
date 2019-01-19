# T9CodeJam

# Instructions

Run from Visual Studio 2017 or using the console run the following:

> cd T9.App/

> dotnet run

Output can be found in the directory where the executable is run under the 'Output' folder.

Tests cover the logic for translating the message (T9MessageTranslator.cs).  Other classes are not tested as they are considered trivial code.

# Improvements

If I were to spend more time on this exercise, I would potentially refactor the stream reader and stream writer into their own custom interfaces/classes. This would be instead of using the standard StreamReader/Writer classes directly.

The keypad could also use a map instead of a list.
