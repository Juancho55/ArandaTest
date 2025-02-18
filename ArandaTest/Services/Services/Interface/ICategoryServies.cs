namespace Services.Services.Interface
{
    public interface ICategoryServies
    {
        public Task<bool> SaveAsync(Models.Category.Category request);

        public Task<List<Models.Category.Category>> GetAsync();
    }
}
