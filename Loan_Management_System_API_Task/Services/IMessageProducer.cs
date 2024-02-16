namespace Loan_Management_System_API_Task.Services;

public interface IMessageProducer
{
    public void SendMessage<T>(T message);

}