using System.Data;

namespace API.Repositories.Artist
{
    public interface IArtistRepository
    {
        string SearchArtistsFromDatabase(string name);

    }
}
