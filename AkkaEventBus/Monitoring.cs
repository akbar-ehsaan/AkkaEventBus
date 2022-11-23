using Akka.Actor;
using Akka.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkkaEventBus
{
    public class DeadLetterMonitor : ReceiveActor

    {

        public DeadLetterMonitor()

        {

            Receive<DeadLetter>(x => Handle(x));

        }

        private void Handle(DeadLetter deadLetter)

        {

            var msg = $"message: {deadLetter.Message}, \n" +

                        $"sender:  {deadLetter.Sender},  \n" +

                        $"recipient: {deadLetter.Recipient}\n";

            Console.WriteLine(msg);

        }

    }
    public class EchoActor : ReceiveActor { }


}
