using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Catalog.Domain.Commands.Item;
using Catalog.Domain.Repositories;
using Catalog.Domain.Responses.Item;
using MediatR;

namespace Catalog.Domain.Handlers.Item
{
    public class GetItemsHandler : IRequestHandler<GetItemsCommand, IList<ItemResponse>>
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public GetItemsHandler(IItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public async Task<IList<ItemResponse>> Handle(GetItemsCommand command, CancellationToken cancellationToken)
        {
            var result = await _itemRepository.GetAsync();
            return _mapper.Map<IList<ItemResponse>>(result);
        }
    }
}