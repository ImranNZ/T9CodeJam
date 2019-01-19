using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using T9.Models;

namespace T9.Classes
{
    public class T9Keypad : IKeypad
    {
        private readonly IReadOnlyList<Key> _keys = new ReadOnlyCollection<Key>(new List<Key>
        {
            new Key() { Digit = 0, Character = ' ', Position = 1 },
            new Key() { Digit = 2, Character = 'a', Position = 1 },
            new Key() { Digit = 2, Character = 'b', Position = 2 },
            new Key() { Digit = 2, Character = 'c', Position = 3 },
            new Key() { Digit = 3, Character = 'd', Position = 1 },
            new Key() { Digit = 3, Character = 'e', Position = 2 },
            new Key() { Digit = 3, Character = 'f', Position = 3 },
            new Key() { Digit = 4, Character = 'g', Position = 1 },
            new Key() { Digit = 4, Character = 'h', Position = 2 },
            new Key() { Digit = 4, Character = 'i', Position = 3 },
            new Key() { Digit = 5, Character = 'j', Position = 1 },
            new Key() { Digit = 5, Character = 'k', Position = 2 },
            new Key() { Digit = 5, Character = 'l', Position = 3 },
            new Key() { Digit = 6, Character = 'm', Position = 1 },
            new Key() { Digit = 6, Character = 'n', Position = 2 },
            new Key() { Digit = 6, Character = 'o', Position = 3 },
            new Key() { Digit = 7, Character = 'p', Position = 1 },
            new Key() { Digit = 7, Character = 'q', Position = 2 },
            new Key() { Digit = 7, Character = 'r', Position = 3 },
            new Key() { Digit = 7, Character = 's', Position = 4 },
            new Key() { Digit = 8, Character = 't', Position = 1 },
            new Key() { Digit = 8, Character = 'u', Position = 2 },
            new Key() { Digit = 8, Character = 'v', Position = 3 },
            new Key() { Digit = 9, Character = 'w', Position = 1 },
            new Key() { Digit = 9, Character = 'x', Position = 2 },
            new Key() { Digit = 9, Character = 'y', Position = 3 },
            new Key() { Digit = 9, Character = 'z', Position = 4 },
        });

        public int GetPositionOf(char letter)
        {
            return GetKeyOf(letter).Position;
        }

        public int GetDigitOf(char letter)
        {
            return GetKeyOf(letter).Digit;
        }

        private Key GetKeyOf(char letter)
        {
            var key = _keys.SingleOrDefault(x => x.Character == letter);

            if (key == null) throw new ArgumentException($"'{letter}' does not exist on the keypad");

            return key;
        }

    }
}