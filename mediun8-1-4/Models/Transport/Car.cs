using mediun8_1_4.Interfaces;
using System;

namespace mediun8_1_4.Models.Transport
{
    class Car : ITransport
    {
        public string Name { get; }

        public float MovementSpeed { get; }
        public float MovementDiractionX { get; private set; }
        public float MovementDiractionY { get; private set; }

        public Car(string name, float movementSpeed = 2f)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new NullReferenceException();

            if (movementSpeed < 2f)
                throw new InvalidOperationException();

            Name = name;
            MovementSpeed = movementSpeed;
        }

        public void Move(float directionX, float directionY)
        {
            MovementDiractionX = directionX;
            MovementDiractionY = directionY;

            // Do move
        }
    }
}
