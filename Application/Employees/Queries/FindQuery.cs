using AutoMapper;
using Domain.Repositories;
using MediatR;

namespace Application.Employees.Queries;

public class FindQuery : IRequest<PagedListResult<FindResult>>
{
    public string DocumentNumber { get; set; }

    public class Handler : IRequestHandler<FindQuery, PagedListResult<FindResult>>
    {
        readonly IEmployeeRepository _repository;
        readonly IMapper _mapper;

        public Handler(IEmployeeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PagedListResult<FindResult>> Handle(FindQuery request, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetByDocument(request.DocumentNumber);
            return _mapper.Map<PagedListResult<FindResult>>(entities);
        }
    }
}