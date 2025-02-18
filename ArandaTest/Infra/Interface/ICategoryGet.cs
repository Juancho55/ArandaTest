namespace Infra.Interface
{
    public interface ICategoryGet
    {
        public Task<List<Models.Category.Category>> GetAll();
    }
}
