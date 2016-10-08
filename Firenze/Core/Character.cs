using System;

namespace Firenze.Core
{
    public class GameObject
    {
        public GameObject()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }        
    }

    public class Character : GameObject
    {
        public String Name { get; set; }
        public Int32 Level { get; set; }
        public Int32 XP { get; set; }
    }    
}
