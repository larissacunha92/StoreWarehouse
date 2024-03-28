using System.Text.Json;
using RabbitMQ.Client;
using System.Text;

namespace StorewWarehouse.API.Services;

public class MessageProducer : IMessageProducer
{
    public void SendMessage<T>(T message)
    {
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

        var jsonString = JsonSerializer.Serialize(message);
        var body = Encoding.UTF8.GetBytes(jsonString);

        channel.BasicPublish("", "products", body: body);
    }
}