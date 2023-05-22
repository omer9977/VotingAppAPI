#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Presentation/VotingAPI.WebAPI/VotingAPI.WebAPI.csproj", "Presentation/VotingAPI.WebAPI/"]
COPY ["Core/VotingAPI.Application/VotingAPI.Application.csproj", "Core/VotingAPI.Application/"]
COPY ["Core/VotingAPI.Domain/VotingAPI.Domain.csproj", "Core/VotingAPI.Domain/"]
COPY ["Infrastructure/VotingAPI.Infrastructure/VotingAPI.Infrastructure.csproj", "Infrastructure/VotingAPI.Infrastructure/"]
COPY ["Infrastructure/VotingAPI.ObsService/VotingAPI.ObsService.csproj", "Infrastructure/VotingAPI.ObsService/"]
COPY ["Infrastructure/VotingAPI.Persistence/VotingAPI.Persistence.csproj", "Infrastructure/VotingAPI.Persistence/"]
RUN dotnet restore "Presentation/VotingAPI.WebAPI/VotingAPI.WebAPI.csproj"
COPY . .
WORKDIR "/src/Presentation/VotingAPI.WebAPI"
RUN dotnet build "VotingAPI.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VotingAPI.WebAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VotingAPI.WebAPI.dll"]