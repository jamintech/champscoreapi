#Build Phase
FROM mcr.microsoft.com/dotnet/sdk:6.0 as build

WORKDIR /app

COPY *.csproj .
RUN dotnet restore

COPY . .
RUN dotnet publish -c Release -o publish

#Run Phase
FROM mcr.microsoft.com/dotnet/aspnet:6.0

WORKDIR /app
EXPOSE 80
EXPOSE 443
COPY --from=build /app/publish .
ENTRYPOINT [ "dotnet","jamintech.champs.coreAPI.dll" ]
