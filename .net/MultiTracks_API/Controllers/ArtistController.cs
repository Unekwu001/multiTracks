using System.Web.Http;
using MultiTracks_API.Repositories;

namespace MultiTracks_API.Controllers
{
	public class ArtistController : ApiController
	{
		private readonly IArtistRepository _artistRepository;

		public ArtistController(IArtistRepository artistRepository)
		{
			_artistRepository = artistRepository;
		}


		[HttpGet]
		[Route("api.multitracks.com/artist/search")]
		public IHttpActionResult SearchArtistByName(string artistName)
		{
			var matchingArtists = _artistRepository.SearchArtists(artistName);

			if (matchingArtists == null || matchingArtists.Rows == null)
			{
				return NotFound(); // Return 404 Not Found if no matching artists are found
			}
			else
			{
				return Ok(matchingArtists); // Return 200 OK with the matching artists
			}
		}

	}
}
