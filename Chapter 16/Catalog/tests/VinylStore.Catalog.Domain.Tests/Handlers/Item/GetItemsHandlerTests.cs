using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Shouldly;
using VinylStore.Catalog.Domain.Commands.Item;
using VinylStore.Catalog.Domain.Handlers.Item;
using VinylStore.Catalog.Domain.Infrastructure.Mapper;
using VinylStore.Catalog.Fixtures;
using VinylStore.Catalog.Infrastructure.Repositories;
using Xunit;

namespace VinylStore.Catalog.Domain.Tests.Handlers.Item
{
    public class GetItemsHandlerTests : IClassFixture<CatalogDataContextFactory>
    {
        public GetItemsHandlerTests(CatalogDataContextFactory catalogDataContextFactory)
        {
            _catalogDataContextFactory = catalogDataContextFactory;
        }

        private readonly CatalogDataContextFactory _catalogDataContextFactory;

        [Fact]
        public async Task getitems_should_return_right_data()
        {
            var sut = new GetItemsHandler(new ItemRepository(_catalogDataContextFactory.ContextInstance),
                new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<CatalogProfile>())));

            var result =
                await sut.Handle(new GetItemsCommand(), CancellationToken.None);

            result.Count.ShouldBe(3);
        }
    }
}
