using mediun8_1_4.Interfaces;

namespace mediun8_1_4.Models.Transport
{
    class Foot : ITransport
    {
        public string Name { get; }

        public float MovementSpeed { get; }
        public float MovementDiractionX { get; private set; }
        public float MovementDiractionY { get; private set; }

        public Foot()
        {
            Name = "Foot";
            MovementSpeed = 1f;
        }

        public void Move(float directionX, float directionY)
        {
            MovementDiractionX = directionX;
            MovementDiractionY = directionY;

            // Do move
        }
    }
}
