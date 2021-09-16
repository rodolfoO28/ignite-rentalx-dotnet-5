FROM mcr.microsoft.com/dotnet/sdk:5.0

WORKDIR /App

COPY . .

RUN dotnet restore && dotnet build

EXPOSE 3333

# CMD ["dotnet", "run", "-p", "src"]
CMD ["dotnet", "watch", "run", "-p", "src", "--no-launch-profile"]