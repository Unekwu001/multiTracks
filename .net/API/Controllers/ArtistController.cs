using Microsoft.AspNetCore.Mvc;
using API.Repositories.Artist;

namespace API.Controllers
{
    [Route("api.multitracks.com/artist")]
	[ApiController]
	public class ArtistController : ControllerBase
	{

		private readonly IArtistRepository _artistRepository;
		public ArtistController(IArtistRepository artistRepository)
		{
			_artistRepository = artistRepository;
		}





		[HttpGet("search")]
		public string SearchArtistByName(string artistName) 
		{

			// variable matchingArtist collects and saves the JSon coming from SearchArtistFromDatabase method.
			var matchingArtists = _artistRepository.SearchArtistsFromDatabase(artistName);


			if (matchingArtists == "")
			{
				return $"Oops, {artistName} Not found"; // Return 404 Not Found if no matching artists are found
			}
			else
			{
				return $"Great!, {artistName} was found"; // Return 200 OK with the matching artists
			}
		}




	}
}
