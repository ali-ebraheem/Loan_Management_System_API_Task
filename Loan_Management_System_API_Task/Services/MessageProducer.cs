using System.Text;
using System.Text.Json;
using RabbitMQ.Client;

namespace Loan_Management_System_API_Task.Services;

public class MessageProducer(IConfiguration configuration) : IMessageProducer
{
    public void SendMessage<T>(T message)
    {
        var factory = new ConnectionFactory()
        {
            HostName = configuration["RabbitMq:HostName"],
            UserName = configuration["RabbitMq:UserName"],
            Password = configuration["RabbitMq:Password"],
            VirtualHost = configuration["RabbitMQ:VirtualHost"],
        };
        using var connection = factory.CreateConnection();
        using var channel = connection.CreateChannel();
        channel.QueueDeclare(queue: "loan-management-system", durable: true, exclusive: true);
        var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));
        channel.BasicPublish(exchange: "", routingKey: "loan-management-system", body: body);
    }
}