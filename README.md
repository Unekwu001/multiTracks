STEPS TO VIEW ARTIST DETAILS PAGE
-----------------------------------------------
The project targets passing data to the details page  through the url and dynamically generating the page's content ( images and pictures). It makes use of the MTData Access Library to handle data request. The "**GetArtistDetails**" stored procedure was the sole QueryHouse.
Below are the steps to follow in other to successfully load and run the project.

0.  Open the solution in Visual Studio. Right-click on the "multitracks.com" project and select "**Set as Startup project**".
1.  Load the project. When loaded, head over to change the database connection string found within the Web.config file.
2.  Test the Details page using the url. For example if you are using your local machine and you want to view the Artist with ID of 2, you will need to  visit:  **localhost/artistDetails.aspx?artistID=2.** This will automatically generate a details page for the artist with ID of 2.
3.  You may continue to test the page by changing the value of the ID to see how it dynamically generates the details of the Artist.
4.  The code was further refactored such that if a non-existing ID is entered, it redirects you to the Artist with ID of 1. (This is for development and test purposes).


STEPS FOR THE API PROJECT
-------------------------
ASP.NET CORE WEB API  was used for this project.

0.  Open the solution in Visual Studio. Right-click on the "multitracks.com" project and select "**Set as Startup project**".
1.  Load the project. When loaded, head over to change the database connection string found within the Program.cs file to your desired database(local or remote). Also, ensure you  publish the MultiTracksDB before attempting to connect.
2.  Run the Project with Debugging.
3.  The Project will automatically take you to a Swagger GUI. Use the Gui to test if API works well and makes the right calls.(POST And GET).
4.  All APIs (methods) are found within the Controllers Folder.
5.  The Repositories Folder is where the Data Logic Happens. It contains Artist and Song Repositories along with their Contracts(Interfaces).
6.  Dependency injection was used within the project to ensure the project is in compliance with both OOP and SOLID Principles.
