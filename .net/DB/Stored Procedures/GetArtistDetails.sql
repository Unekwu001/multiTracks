CREATE PROCEDURE dbo.GetArtistDetails
    @artistID INT = NULL
AS
BEGIN
    IF NOT EXISTS (SELECT * FROM dbo.Artist WHERE artistID = @artistID)
        SET @artistID = 1;

    SELECT *
    FROM dbo.Artist
    WHERE artistID = @artistID;
END

