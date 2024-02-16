using System.Text;
using System.Text.Json;
using RabbitMQ.Client;

namespace Loan_Management_System_API_Task.Services;

public class MessageProducer : IMessageProducer
{
    public void SendMessage<T>(T message)
    {
        var factory = new ConnectionFactory()
        {
            HostName = "localhost",
            UserName = "user",
            Password = "password",
            VirtualHost = "/",
        };
        using var connection = factory.CreateConnection();
        using var channel = connection.CreateChannel();
        channel.QueueDeclare(queue: "loan-management-system", durable: true, exclusive: true);
        var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));
        channel.BasicPublish(exchange: "", routingKey: "loan-management-system", body: body);
    }
}