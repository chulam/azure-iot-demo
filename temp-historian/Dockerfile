FROM microsoft/aspnetcore:1.1
WORKDIR /app
EXPOSE 5000
COPY ./bin/Debug/netcoreapp1.1/publish .
ENTRYPOINT ["dotnet", "TemperatureHistorian.dll"]