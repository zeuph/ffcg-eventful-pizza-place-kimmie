namespace FFCG.Eventful.Pizza.Place.Application.Interfaces;

public interface IMessagingClient
{
    public Task<bool> SendMessage<T>(string subject, T data);
}