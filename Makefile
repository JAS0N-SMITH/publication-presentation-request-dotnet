start-backend:
	dotnet run --project Backend/Backend.csproj

start-frontend:
	dotnet run --project Frontend/Frontend.csproj

test-backend:
	dotnet restore
	dotnet test Backend.Tests/Backend.Tests.csproj

test-frontend:
	dotnet restore
	dotnet test Frontend.Tests/Frontend.Tests.csproj

run-all: 
	make start-backend &
	make start-frontend

test-all: test-backend test-frontend

test-and-run-all: test-all
	make start-backend &
	make start-frontend

update-packages:
	dotnet restore

clean:
	dotnet clean

build-backend:
	dotnet build Backend/Backend.csproj

build-frontend:
	dotnet build Frontend/Frontend.csproj

build-all: build-backend build-frontend

lint-backend:
	dotnet format Backend/Backend.csproj

lint-frontend:
	dotnet format Frontend/Frontend.csproj

lint-all: lint-backend lint-frontend

deploy:
	echo "Deploying application..."
	# Add deployment commands here