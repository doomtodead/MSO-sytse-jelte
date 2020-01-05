using System;
using System.Collections.Generic;
using System.Text;

namespace MSO_Retake
{
        public abstract class Mail
        {
            private string _email;

            public string email
            {
                get { return _email; }
                set { _email = value; }
            }

            public abstract void Display();
        }

        public class EMail : Mail
        {
            private string _name;
            public EMail(string name, string email)
            {
                this._name = name;
                this.email = email;
            }


            public override void Display()
            {
                Console.WriteLine("Hello " + _name);
                Console.WriteLine("We are sending a mail to " + email + "\n");
            }
        }

        public abstract class Decorator : Mail

        {
            protected Mail Item;

            public Decorator(Mail Item)
            {
                this.Item = Item;
            }

            public override void Display()
            {
                Item.Display();
            }
        }

        public class DigitalMail : Decorator
        {
            private List<string> Keys = new List<string>();

            public DigitalMail(Mail Item) : base(Item)
            {

            }

            public void SetKeys(List<Product> products)
            {
                foreach (DigitalProduct product in products)
                {
                    Keys.Add(product.link);
                }
            }

            public override void Display()
            {
                base.Display();

                foreach (string key in Keys)
                {
                    Console.WriteLine(key);
                }

            }
        }

        public class PhysicalMail : Decorator
        {

            public PhysicalMail(Mail Item) : base(Item)
            {

            }

            public override void Display()
            {
                base.Display();

                Console.WriteLine("Here we would dusplay Shipping Details\n");
            }
        }
}
