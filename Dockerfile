# STAGE01 - Build application and its dependencies  
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env  
WORKDIR /app
COPY . .
RUN dotnet restore
WORKDIR /app/Covid_19_RealTime_Info
ENTRYPOINT ["dotnet", "watch", "run", "--no-restore", "--urls", "https://0.0.0.0:5001", "http://0.0.0.0:5000"]