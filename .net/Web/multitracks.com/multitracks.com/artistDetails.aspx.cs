using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class artistDetails : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		var sql = new SQL();

		if (!IsPostBack)
		{
			if (int.TryParse(Request.QueryString["artistID"], out int artistID))
			{
				// Create the SQL parameter for artistID
				var artistIDParam = new SqlParameter("@artistID", SqlDbType.Int);
				artistIDParam.Value = artistID;

				// Add the parameter to the SQL parameters collection
				sql.Parameters.Add(artistIDParam);

				var artistData = sql.ExecuteStoredProcedureDT("GetArtistDetails");

				if (artistData.Rows.Count > 0)
				{
					var heroUrl = artistData.Rows[0]["heroURL"].ToString();
					heroArtist.ImageUrl = heroUrl;

					var imgUrl = artistData.Rows[0]["imageURL"].ToString();
					imgArtist.ImageUrl = imgUrl;

					var name = artistData.Rows[0]["title"].ToString();
					titleArtist.Text = name;

					var biography = artistData.Rows[0]["biography"].ToString();
					bioArtist.Text = biography;
				}
				else
				{
					// Handle the case when artistID is not found or is null
					// Set a default image or display an error message
				}
			}
		}
	}








	//protected void Page_Load(object sender, EventArgs e)
	//{
	//	var sql = new SQL();

	//	if (!IsPostBack)
	//	{
	//		if (int.TryParse(Request.QueryString["artistID"], out int artistID))
	//		{
	//			var query = "IF NOT EXISTS (SELECT * FROM dbo.Artist WHERE artistID = @artistID)" +
	//						" SET @artistID = 1;" +
	//						" SELECT * FROM dbo.Artist WHERE artistID = @artistID";

	//			// Create the SQL parameter for artistID
	//			var artistIDParam = new SqlParameter("@artistID", SqlDbType.Int);
	//			artistIDParam.Value = artistID;

	//			// Add the parameter to the SQL parameters collection
	//			sql.Parameters.Add(artistIDParam);

	//			var artistData = sql.ExecuteDT(query);

	//			if (artistData.Rows.Count > 0)
	//			{
	//				var heroUrl = artistData.Rows[0]["heroURL"].ToString();
	//				heroArtist.ImageUrl = heroUrl;

	//				var imgUrl = artistData.Rows[0]["imageURL"].ToString();
	//				imgArtist.ImageUrl = imgUrl;

	//				var name = artistData.Rows[0]["title"].ToString();
	//				titleArtist.Text = name;

	//				var biography = artistData.Rows[0]["biography"].ToString();
	//				bioArtist.Text = biography;

	//			}
	//			else
	//			{
	//				// Handle the case when artistID is not found or is null
	//				// Set a default image or display an error message
	//			}
	//		}
	//	}
	//}



	//protected void Page_Load(object sender, EventArgs e)
	//{
	//	var sql = new SQL();

	//	if (!IsPostBack)
	//	{
	//		if (int.TryParse(Request.QueryString["artistID"], out int artistID))
	//		{
	//			// Call the ExecuteStoredProcedureDS method passing the GetArtistDetails stored procedure as a parameter
	//			DataSet artistData = sql.ExecuteStoredProcedureDS($"GetArtistDetails {artistID}");

	//			// Check if the dataset contains any tables
	//			if (artistData.Tables.Count > 0)
	//			{
	//				// Assuming you want to display the first table from the dataset
	//				DataTable artistTable = artistData.Tables[0];
	//				var imageUrl = artistTable.Rows[0]["imageURL"].ToString();

	//				// Bind the artistTable to your UI controls or use the data as needed

	//			}
	//		}
	//	}
	//}




}
