#docker build -t [name of image] .
#docker run -d -p 3450:80  [name of image]
# if you build it under the same tag example :0.0.1 as one that already exists 
# and push it to docker hub then Azure will grab the changes


FROM mcr.microsoft.com/dotnet/sdk:7.0 AS BUILD

WORKDIR /app

COPY API ./API
COPY DataAccess ./DataAccess

RUN dotnet publish API -o dist

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS RUN

WORKDIR /app

COPY --from=BUILD app/dist .

CMD [ "dotnet", "API.dll" ]