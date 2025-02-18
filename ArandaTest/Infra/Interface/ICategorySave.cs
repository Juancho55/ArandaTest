namespace Infra.Interface
{
    public interface ICategorySave
    {
        public Task<bool> Save(Models.Category.Category model);
    }
}
