using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

Console.WriteLine("Welcome to the StoreWarehouse.Job!");

var factory = new ConnectionFactory()
{
  HostName = "localhost",
  UserName = "user",
  Password = "mypass",
  VirtualHost = "/"
};
var connection = factory.CreateConnection();

using var channel = connection.CreateModel();
channel.QueueDeclare("products", durable: true, exclusive: false);

var consumer = new EventingBasicConsumer(channel);
consumer.Received += (model, eventArgs) =>
{
  var body = eventArgs.Body.ToArray();
  var message = Encoding.UTF8.GetString(body);

  Console.WriteLine($"New products initiated for - {message}");
};

channel.BasicConsume("products", true, consumer);

Console.ReadKey();