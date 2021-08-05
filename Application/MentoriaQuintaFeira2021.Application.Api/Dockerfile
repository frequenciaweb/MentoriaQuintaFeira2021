#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Application/MentoriaQuintaFeira2021.Application.Api/MentoriaQuintaFeira2021.Application.Api.csproj", "Application/MentoriaQuintaFeira2021.Application.Api/"]
COPY ["Infra/MentoriaQuintaFeira2021.Infra.Data/MentoriaQuintaFeira2021.Infra.Data.csproj", "Infra/MentoriaQuintaFeira2021.Infra.Data/"]
COPY ["Domain/MentoriaQuintaFeira2021.Domain/MentoriaQuintaFeira2021.Domain.csproj", "Domain/MentoriaQuintaFeira2021.Domain/"]
COPY ["Domain/MentoriaQuintaFeira2021.Domain.Services/MentoriaQuintaFeira2021.Domain.Services.csproj", "Domain/MentoriaQuintaFeira2021.Domain.Services/"]
COPY ["Infra/MentoriaQuintaFeira2021.Infra.CrossCutting/MentoriaQuintaFeira2021.Infra.CrossCutting.csproj", "Infra/MentoriaQuintaFeira2021.Infra.CrossCutting/"]
RUN dotnet restore "Application/MentoriaQuintaFeira2021.Application.Api/MentoriaQuintaFeira2021.Application.Api.csproj"
COPY . .
WORKDIR "/src/Application/MentoriaQuintaFeira2021.Application.Api"
RUN dotnet build "MentoriaQuintaFeira2021.Application.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MentoriaQuintaFeira2021.Application.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MentoriaQuintaFeira2021.Application.Api.dll"]
