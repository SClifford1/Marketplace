# MarketplaceAPI

## Prerequisites
- SQLServer
- .NET core 3.1
- Docker for windows with windows containers selected

## Setup
  1) Update the connection string to point to a valid SQLServer instance. The connection string can be found in ~\Marketplace\appsettings.json. An example connection string is contained within the file:
	...
	"ConnectionStrings": {
		"MarketplaceDB": "Server=192.168.1.2;Database=MarketplaceDB;User Id=sa;Password=password;"
	}
	
  2) Run "BuildMarketplace.bat" to build the marketplace binaries.
  
  3) Run "RunMarketPlace.bat" to run the marketplace. To run in docker, use "RunMarketplaceDocker.bat".
  
  4) Navigate to the following URL in the browser to interact with the API:
	http://localhost:5000/swagger/index.html
