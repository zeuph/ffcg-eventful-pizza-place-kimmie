using FFCG.Eventful.Pizza.Place.Application.Interfaces;
using MediatR;

namespace FFCG.Eventful.Pizza.Place.Application.Features.GetAllPizzas;

public class GetAllPizzasQuery : IRequest<IEnumerable<Domain.Models.Pizza>> { }

public class GetAllPizzasHandler(IPizzaProvider _provider) : IRequestHandler<GetAllPizzasQuery, IEnumerable<Domain.Models.Pizza>>
{
    public async Task<IEnumerable<Domain.Models.Pizza>> Handle(GetAllPizzasQuery request, CancellationToken cancellationToken)
        => await _provider.GetAllPizzas();
}