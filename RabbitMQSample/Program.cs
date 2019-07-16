using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;


namespace RabbitMQSample
{
    class Program
    {
        private static readonly string _queue_name = "ISMAILERMIS";
        private  static Publisher _publisher;
        private static Consumer _consumer;
        static void Main(string[] args)
        {
            List<Person> per = new List<Person>
            {
                new Person
                {
                    Id=1,Name = "ismail",Surname = "ERMİŞ",CityName = "istanbul"

                },
                new Person
                {
                    Id=1,Name = "Batuhan",Surname = "ERMİŞ",CityName = "istanbul"

                },
                new Person
                {
                    Id=1,Name = "Kağan",Surname = "ERMİŞ",CityName = "istanbul"

                }
            };

            _publisher = new Publisher(_queue_name,per);
           
            System.Threading.Thread.Sleep(5000);
           
            _consumer = new Consumer(_queue_name);

            Console.ReadKey();
            
        }
    }
}
