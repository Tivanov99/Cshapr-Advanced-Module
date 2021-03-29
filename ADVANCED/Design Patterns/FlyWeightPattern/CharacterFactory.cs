using System;
using System.Collections.Generic;
using System.Text;

namespace Flyweight
{
    public class CharacterFactory
    {
        private Dictionary<char, Character> characters = new Dictionary<char, Character>();
        private Character character;

        public Character GetCharacter(char symbol)
        {
            if (characters.ContainsKey(symbol))
            {
                character = characters[symbol];
            }
            else
            {
                switch (symbol)
                {
                    case 'M':
                        character = new CharacterM();
                        break;
                    case 'P':
                        character = new CharacterP();
                        break;
                    case 'W':
                        character = new CharacterW();
                        break;
                }
                characters.Add(symbol, character);
            }
            return character;
        }
    }
}
