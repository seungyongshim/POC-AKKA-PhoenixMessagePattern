using System;
using Akka.Actor;
using Akka.Event;

namespace PhoenixMessage
{
    public class DangerActor : ReceiveActor, IWithUnboundedStash
    {
        public DangerActor(IDbServer dbServer)
        {
            Receive<DbConnect>(m =>
            {
                dbServer.Connect();
            });
        }

        public ILoggingAdapter Logger { get; } = Context.GetLogger();
        public IStash Stash { get; set; }

        public static Props Props(IDbServer dbServer) => Akka.Actor.Props.Create(() => new DangerActor(dbServer));

        protected override void PreRestart(Exception reason, object message)
        {
            Logger.Error(reason, message.ToString());

            Stash.Prepend(new[]
            {
                new Envelope(message, Context.Parent)
            });
        }

        public class DbConnect
        { 
        }
    }
}
