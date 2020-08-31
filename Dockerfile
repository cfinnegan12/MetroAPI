FROM mcr.microsoft.com/dotnet/core/sdk AS build-env
WORKDIR /app

COPY  *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet
WORKDIR /app
EXPOSE 80
COPY --from=build-env /app/out .
COPY mtt_MET20200629v1.cif .
ENTRYPOINT [ "dotnet", "MetroAPI.dll" ]