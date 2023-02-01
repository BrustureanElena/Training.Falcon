using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Companies.Core.ApplicationServices
{
    public class PagedResult<TEntity>
    {
        public IReadOnlyCollection<TEntity> Items { get; }

        public string NextPageToken { get; }

        public PagedResult(IList<TEntity> items, string nextPageToken = null)
        {
            NextPageToken = nextPageToken;

            Items = new ReadOnlyCollection<TEntity>(items);
        }
    }
}
