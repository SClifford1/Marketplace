dotnet build Marketplace.sln -c "Release"
docker build -t marketplace -f Marketplace\Dockerfile .