FROM mcr.microsoft.com/dotnet/sdk:9.0.303 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /app

# Copy the .csproj file and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy the remaining source code
COPY . .

# Publish the application
RUN dotnet publish -c ${BUILD_CONFIGURATION} -o out

# Use the official .NET ASP.NET runtime 9.0 image to run the application
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=build /app/out .

# Expose the port your application listens on
EXPOSE 80

# Define the entry point for the application
ENTRYPOINT ["dotnet", "Demo.dll"] 