using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RabbitMQSample
{
    public class Publisher
    {
        private readonly RabbitMQService _rabbitMqService;

        public Publisher(string queueName,IList<Person> persons)
        {
            _rabbitMqService = new RabbitMQService();
            using (var connection = _rabbitMqService.GetRabbitMQConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queueName, false, false, false, null);
                    String jsonified = JsonConvert.SerializeObject(persons);
                    byte[] personsBuffer = Encoding.UTF8.GetBytes(jsonified);
                    channel.BasicPublish("",queueName,null,personsBuffer);
                    Console.WriteLine("{0} queue'su üzerine {1}  mesajı yazıldı.", queueName, "Yazıldı");
                 }
                }
            }
                
        
    }
}
