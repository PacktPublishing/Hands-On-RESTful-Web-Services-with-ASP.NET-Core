using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VinylStore.Catalog.Domain.Entities;
using VinylStore.Catalog.Domain.Infrastructure.Repositories;

namespace VinylStore.Catalog.Infrastructure.Repositories
{
    public class ItemRepository
        : IItemRepository
    {
        private readonly CatalogContext _context;

        public ItemRepository(CatalogContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<IList<Item>> GetAsync()
        {
            return await _context.Items
                .AsNoTracking()
                .Where(_ => !_.IsInactive)
                .ToListAsync();
        }

        public async Task<Item> GetAsync(Guid id)
        {
            var item = await _context.Items
                .AsNoTracking()
                .Where(_ => !_.IsInactive)
                .Where(x => x.Id == id)
                .Include(x => x.Genre)
                .Include(x => x.Artist).FirstOrDefaultAsync();

            if (item == null) return null;

            _context.Entry(item).State = EntityState.Detached;
            return item;
        }

        public async Task<IList<Item>> GetItemByArtistIdAsync(Guid id)
        {
            var items = await _context.Items
                .Where(_ => !_.IsInactive)
                .Where(item => item.ArtistId == id).ToListAsync();

            return items;
        }

        public async Task<IList<Item>> GetItemByGenreIdAsync(Guid id)
        {
            var items = await _context.Items
                .Where(_ => !_.IsInactive)
                .Where(item => item.GenreId == id).ToListAsync();

            return items;
        }

        public Item Add(Item item)
        {
            return _context.Items.Add(item).Entity;
        }

        public Item Update(Item item)
        {
            _context.Entry(item).State = EntityState.Modified;
            return item;
        }

        public Item Delete(Item item)
        {
            throw new NotImplementedException();
        }
    }
}
