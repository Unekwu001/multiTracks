using System;
using System.Web;
using DataAccess;
using static DataAccess.SQL;
using System.Data;


namespace MultiTracks_API.Repositories
{
	public class ArtistRepository : IArtistRepository
	{
		private SQL Sql { get; }

		public ArtistRepository()
		{
			Sql = new SQL();
		}

		public DataTable SearchArtists(string name)
		{
			string query = "SELECT * FROM Artists WHERE Name LIKE @Name";
			Sql.Parameters.Clear();
			Sql.Parameters.Add("@Name", SqlDbType.VarChar, "%" + name + "%");

			//returning the Executed SQL query using the ExecuteDT method from the SQL class
			return Sql.ExecuteDT(query, clearParameters: true);
		}

	}
}