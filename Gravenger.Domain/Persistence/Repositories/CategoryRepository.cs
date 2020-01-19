using Gravenger.Domain.Core.Models;
using Gravenger.Domain.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gravenger.Domain.Persistence.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(GravengerContext context)
            :base(context)
        {

        }

        private GravengerContext Context
        {
            get { return base.Context as GravengerContext; }
        }
    }
}
