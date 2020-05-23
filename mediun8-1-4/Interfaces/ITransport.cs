using System;
using System.Collections.Generic;
using System.Text;

namespace mediun8_1_4.Interfaces
{
    public interface ITransport
    {
        string Name { get; }
        float MovementSpeed { get; }
        float MovementDiractionX { get; }
        float MovementDiractionY { get; }

        void Move(float directionX, float directionY);
    }
}
