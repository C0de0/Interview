using System;
using System.Collections.Generic;
using System.Text;

namespace Interview.Persistance
{
    public interface IRecipesDbContextProvider
    {
        RecipesDbContext New();
    }
}
