FROM mcr.microsoft.com/dotnet/sdk AS build-env
WORKDIR /app

COPY . .

RUN dotnet build King.Mapper.sln -c release