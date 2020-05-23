using mediun8_1_4.Interfaces;
using mediun8_1_4.Models.Transport;
using mediun8_1_4.Models.Weapont;
using System;
using System.Collections.Generic;
using System.Text;

namespace mediun8_1_4
{
    public class Player
    {
        public event EventHandler OnMove;
        public event EventHandler OnAttack;

        public string Name { get; private set; }
        public int Age { get; private set; }

        public ITransport Transport { get; set; }
        public IWeapont Weapont { get; set; }

        public Player(string name, int age)
        {
            Name = name;
            Age = age;

            Transport = new Foot();
            Weapont = new Fists();
        }

        public void Move(MovementDirection movementDirection)
        {
            float MovementDirectionX = 0f;
            float MovementDirectionY = 0f;

            switch (movementDirection)
            {
                case MovementDirection.Forward: { MovementDirectionY = 1.0f;  } break; 
                case MovementDirection.Back:    { MovementDirectionY = -1.0f; } break;
                case MovementDirection.Left:    { MovementDirectionX = -1.0f; } break;
                case MovementDirection.Right:   { MovementDirectionX = 1.0f;  } break;
            }

            Transport.Move(MovementDirectionX, MovementDirectionY);
            OnMove?.Invoke(Transport, EventArgs.Empty);
        }

        public void Attack()
        {
            if (!Weapont.IsReloading())
                Weapont.Attack();

            OnAttack?.Invoke(Weapont, EventArgs.Empty);
        }
        public void ReloadWeapont()
        {
            Weapont.TryReload();
        }
    }
}
