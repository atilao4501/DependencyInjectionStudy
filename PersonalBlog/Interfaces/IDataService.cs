using PersonalBlog.Models;

namespace PersonalBlog.Interface
{
    public interface IDataService
    {
        Task Create(Post model);
        Task<List<Post>> GetAll();

    }

}

