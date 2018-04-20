using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace rabbitmMQ
{
    class Program
    {
        public static void Main()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "Notify2",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                string message = "Hello open api!";
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: "Notify2",
                                     basicProperties: null,
                                     body: body);
                Console.WriteLine(" [x] Sent {0}", message);
            }

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
        //static void Main(string[] args)
        //{
        //    var factory = new ConnectionFactory() { HostName = "localhost",
        //        RequestedHeartbeat = 30
        //    };

        //    using (var connection = factory.CreateConnection())
        //    {
        //        using (var channel = connection.CreateModel())
        //        {
        //            channel.QueueDeclare("testqueue", true, false, false, null);

        //            var consumer = new EventingBasicConsumer(channel);
        //            consumer.Received += Consumer_Received;
        //            channel.BasicConsume("testqueue", true, consumer);

        //            Console.ReadLine();
        //        }
        //    }
        //}

        //private static void Consumer_Received(object sender, BasicDeliverEventArgs e)
        //{
        //    var body = e.Body;
        //    var content = Encoding.UTF8.GetString(body);
        //    Console.WriteLine(content);
        //}
    }
}
