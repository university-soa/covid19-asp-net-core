# STAGE01 - Build application and its dependencies  
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env  
WORKDIR /app  
COPY . .
RUN dotnet publish -c Release 

FROM mcr.microsoft.com/dotnet/core/sdk:3.1

WORKDIR /app
COPY --from=build-env /app/Covid_19_RealTime_Info/bin/Release/netcoreapp3.1/Covid_19_RealTime_Info.dll /app/Covid_19_RealTime_Info.dll

ENTRYPOINT ["dotnet", "/app/Covid_19_RealTime_Info.dll"]