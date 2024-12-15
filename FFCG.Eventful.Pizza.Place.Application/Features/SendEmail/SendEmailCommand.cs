using FFCG.Eventful.Pizza.Place.Application.Interfaces;
using FFCG.Eventful.Pizza.Place.Domain.Models;
using MediatR;

namespace FFCG.Eventful.Pizza.Place.Application.Features.SendEmail;

public class SendEmailCommand : IRequest<Email> { }

public class SendEmailHandler(ICustomerProvider _customerProvider)
    : IRequestHandler<SendEmailCommand, Email>
{
    public async Task<Email> Handle(SendEmailCommand request, CancellationToken cancellationToken)
    {
        var result = await _customerProvider.SendEmail(new Email());

        return result;
    }
}
