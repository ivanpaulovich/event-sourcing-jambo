FROM microsoft/dotnet:2-sdk-jessie
ARG source
WORKDIR /app
EXPOSE 80
COPY ${source:-obj/Docker/publish} .
ENTRYPOINT ["dotnet", "Jambo.Consumer.UI.dll"]
