using System;
using System.Threading;
using Akka.Actor;

namespace PhoenixMessage.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var sys = Akka.Actor.ActorSystem.Create("phoenix");
            var server = new DbServerEmulator();

            var dangerActor = sys.ActorOf(DangerActor.Props(server));

            dangerActor.Tell(new DangerActor.DbConnect());

            Thread.Sleep(1000);

            

            Console.ReadLine();
            
        }
    }
}
