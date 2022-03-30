# #See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

# FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
# WORKDIR /app
# EXPOSE 80
# EXPOSE 443

# FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
# WORKDIR /src
# COPY ["SCHOOL-PROJECT-INTERFACE.csproj", "./"]
# RUN dotnet restore "SCHOOL-PROJECT-INTERFACE.csproj"
# COPY . .
# WORKDIR "/src/"
# RUN dotnet build "SCHOOL-PROJECT-INTERFACE.csproj" -c Release -o /app/build

# FROM build AS publish
# RUN dotnet publish "SCHOOL-PROJECT-INTERFACE.csproj" -c Release -o /app/publish

# FROM base AS final
# WORKDIR /app
# COPY --from=publish /app/publish .
# ENTRYPOINT ["dotnet", "./SCHOOL-PROJECT-INTERFACE.dll"]



FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY ./SCHOOL-PROJECT-INTERFACE/SCHOOL-PROJECT-INTERFACE.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . .
WORKDIR /app/SCHOOL-PROJECT-INTERFACE
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 
WORKDIR /app
COPY --from=build-env /app/SCHOOL-PROJECT-INTERFACE/out ./

# Run the app on container startup
# Use your project name for the second parameter
# e.g. MyProject.dll
ENTRYPOINT [ "dotnet", "SCHOOL-PROJECT-INTERFACE.dll" ]