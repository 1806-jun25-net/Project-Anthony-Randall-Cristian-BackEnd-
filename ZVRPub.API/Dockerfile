FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.sln .
COPY ZVRPub.API/*.csproj ./ZVRPub.API/
COPY ZVRPub.Library/*.csproj ./ZVRPub.Library/
COPY ZVRPub.Repository/*.csproj ./ZVRPub.Repository/
COPY ZVRPub.Scaffold/*.csproj ./ZVRPub.Scaffold/
RUN dotnet restore

# copy everything else and build app
COPY . ./
WORKDIR /app/ZVRPub.API
RUN dotnet publish -c Release -o out


FROM microsoft/dotnet:2.1-aspnetcore-runtime AS runtime
WORKDIR /app
COPY --from=build /app/ZVRPub.API/out ./
ENTRYPOINT ["dotnet", "ZVRPub.API.dll"]