using mediun8_1_4.Models.Weapont;
using System;
using System.Threading;

namespace mediun8_1_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player("Solder", 30);
            player.PlayerMoved += OnPlayerMoved;
            player.PlayerAttacked += OnPlayerAttacked;

            player.Move(MovementDirection.Left);
            player.Move(MovementDirection.Back);

            player.Transport = new Transport("Hummer", 10f);

            player.Move(MovementDirection.Forward);
            player.Move(MovementDirection.Right);

            player.Attack();

            player.Weapont = new Weapont("Revolver", 20, 10);
            player.ReloadWeapont();
            player.Attack();

            Thread.Sleep(100);
            player.Attack();
            player.Attack();
        }

        private static void OnPlayerAttacked(Weapont weapon)
        {
            Console.WriteLine();
            Console.WriteLine("My weapont: {0}", weapon.Name);

            if (!weapon.IsReloading())
            {
                Console.WriteLine("My target gets {0} damage", weapon.Damage);
            }
            else
            {
                Console.WriteLine("My weapont is reloading");
            }
        }

        private static void OnPlayerMoved(Transport transport)
        {
            Console.WriteLine();
            Console.WriteLine("My transport: {0}", transport.Name);
            Console.WriteLine("I moving X: {0}, Y: {1}", transport.DirectionX, transport.DirectionY);
            Console.WriteLine("My speed: {0} m\\s", transport.Speed);
        }
    }
}
