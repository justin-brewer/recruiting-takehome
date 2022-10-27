FROM mcr.microsoft.com/dotnet/sdk:6.0
WORKDIR /app
COPY . .
RUN dotnet dev-certs https
RUN dotnet dev-certs https --trust
EXPOSE 5000
EXPOSE 5001
ENTRYPOINT ["dotnet", "run"]