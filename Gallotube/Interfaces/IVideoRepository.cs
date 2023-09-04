using Gallotube.Models;

namespace Gallotube.Interfaces;

public interface IVideoRepository : IRepository<Video>
{
    List<Video> ReadAllDetailed();

    Video ReadByIdDetailed(int id);
}