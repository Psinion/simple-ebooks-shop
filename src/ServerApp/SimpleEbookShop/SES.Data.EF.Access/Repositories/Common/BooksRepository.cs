using SES.Data.Access.EF.Contexts;
using SES.Data.Access.EF.Repositories;
using SES.Data.Repositories.Common;
using SES.Domain.Entities;

namespace Solar.Data.Access.EF.Repositories.Common;

public class BooksRepository : GenericRepository<Book>, IBooksRepository
{
    public BooksRepository(MainDbContext dbLocalContext) : base(dbLocalContext)
    {
    }
}