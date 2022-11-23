using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkkaEventBus
{
    public class BookPublisher : ReceiveActor

    {

        public BookPublisher()

        {

            Receive<NewBookMessage>(x => Handle(x));

        }

        private void Handle(NewBookMessage x)

        {

            Context.System.EventStream.Publish(x);

        }
        public class BookSubscriber : ReceiveActor

        {

            public BookSubscriber()

            {

                Receive<NewBookMessage>(x => HandleNewBookMessage(x));

            }



            private void HandleNewBookMessage(NewBookMessage book)

            {

                Console.WriteLine(

              $"Book: {book.BookName} got published - message received by {Self.Path.Name}!");

            }

        }
        public class NewBookMessage

        {

            public NewBookMessage(string name)

            {

                BookName = name;

            }

            public string BookName { get; }

        }

    }
}
