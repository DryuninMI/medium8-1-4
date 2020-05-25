using mediun8_1_4;
using System;

namespace mediun8_1_4
{
    public class Transport
    {
        public string Name { get; }
        public float Speed { get; }
        public float DirectionX { get; private set; }
        public float DirectionY { get; private set; }

        public Transport(string name, float movementSpeed = 2f)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            if (movementSpeed < 1f)
                throw new ArgumentOutOfRangeException(nameof(movementSpeed));

            Name = name;
            Speed = movementSpeed;
        }

        public void Move(float directionX, float directionY)
        {
            DirectionX = directionX;
            DirectionY = directionY;

            // Do move
        }
    }
}
