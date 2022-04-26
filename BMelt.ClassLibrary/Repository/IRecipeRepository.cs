﻿using BMelt.ClassLibrary.Models;

namespace BMelt.ClassLibrary.Repository
{
    public interface IRecipeRepository : IRepository<Recipe>
    {
        public Task<IEnumerable<Recipe>> GetAsync(Cuisine cuisine);
    }
}