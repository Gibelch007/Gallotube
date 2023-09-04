using Gallotube.Models;

namespace Gallotube.Interfaces;

public interface IVideoTagRepository
{
    void Create(int VideoId, byte TagId);

    void Delete(int VideoId, byte TagId);

    void Delete(int VideoId);

    List<VideoTag> ReadVideosTag();

    List<Video> ReadVideoByTag(byte TagId);

    List<Tag> ReadTagsByVideo(int VideoId);
}