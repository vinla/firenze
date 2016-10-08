using System;
using System.Collections.Generic;
using System.Linq;

namespace Firenze.Core
{
    public class Mission
    {
        public Mission(IEnumerable<Character> characters)
        {
            if(characters == null)
                throw new ArgumentNullException(nameof(characters));            

            Characters = characters.ToList();
            if (Characters.Any() == false)
                throw new InvalidOperationException("At least one character is required to undertake a mission");
        }

        public List<Character> Characters { get; }
    }
}