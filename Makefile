start-backend:
	dotnet run --project Backend/Backend.csproj

start-frontend:
	dotnet run --project Frontend/Frontend.csproj

test-backend:
	dotnet test Backend.Tests/Backend.Tests.csproj

test-frontend:
	dotnet test Frontend.Tests/Frontend.Tests.csproj

run-all: 
	make start-backend &
	make start-frontend

test-all: test-backend test-frontend

test-and-run-all: test-all
	make start-backend &
	make start-frontend