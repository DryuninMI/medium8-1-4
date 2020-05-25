using mediun8_1_4.Models.Weapont;
using System;
using System.Collections.Generic;
using System.Text;

namespace mediun8_1_4
{
    public class Player
    {
        public event Action<Transport> PlayerMoved;
        public event Action<Weapont> PlayerAttacked;

        public string Name { get; private set; }
        public int Age { get; private set; }

        public Transport Transport { get; set; }
        public Weapont Weapont { get; set; }

        public Player(string name, int age)
        {
            if (string.IsNullOrWhiteSpace(name))
                new ArgumentNullException(nameof(name));

            if (age < 16 || age > 100)
                new ArgumentOutOfRangeException(nameof(age));

            Name = name;
            Age = age;

            Transport = new Transport("Foots", 2f);
            Weapont = new Weapont("Fists", 1, 2);
        }

        public void Move(MovementDirection movementDirection)
        {
            float MovementDirectionX = 0f;
            float MovementDirectionY = 0f;

            switch (movementDirection)
            {
                case MovementDirection.Forward: { MovementDirectionY =  1.0f; } break; 
                case MovementDirection.Back:    { MovementDirectionY = -1.0f; } break;
                case MovementDirection.Left:    { MovementDirectionX = -1.0f; } break;
                case MovementDirection.Right:   { MovementDirectionX =  1.0f; } break;
            }

            Transport.Move(MovementDirectionX, MovementDirectionY);
            PlayerMoved?.Invoke(Transport);
        }

        public void Attack()
        {
            if (!Weapont.IsReloading())
                Weapont.Attack();

            PlayerAttacked?.Invoke(Weapont);
        }

        public void ReloadWeapont()
        {
            Weapont.TryReload();
        }
    }
}
