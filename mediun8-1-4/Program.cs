using mediun8_1_4.Interfaces;
using mediun8_1_4.Models.Transport;
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
            player.OnMove += Player_OnMove;
            player.OnAttack += Player_OnAttack;

            player.Move(MovementDirection.Left);
            player.Move(MovementDirection.Back);

            player.Transport = new Car("Hummer", 10f);

            player.Move(MovementDirection.Forward);
            player.Move(MovementDirection.Right);

            player.Attack();

            player.Weapont = new Gun("Revolver", 20);
            player.ReloadWeapont();
            player.Attack();

            Thread.Sleep(100);
            player.Attack();
            player.Attack();
        }

        private static void Player_OnAttack(object sender, EventArgs e)
        {
            var weapontObj = (IWeapont)sender;

            Console.WriteLine();
            Console.WriteLine("My weapont: {0}", weapontObj.Name);
            
            if(!weapontObj.IsReloading())
            {
                Console.WriteLine("My target gets {0} damage", weapontObj.WeaponDamage);
            }
            else
            {
                Console.WriteLine("My weapont is reloading");
            }            
        }

        private static void Player_OnMove(object sender, EventArgs e)
        {
            var moveObj = (ITransport)sender;

            Console.WriteLine();
            Console.WriteLine("My transport: {0}", moveObj.Name);
            Console.WriteLine("I moving X: {0}, Y: {1}", moveObj.MovementDiractionX, moveObj.MovementDiractionY);
            Console.WriteLine("My speed: {0} m\\s", moveObj.MovementSpeed);
        }
    }
}
