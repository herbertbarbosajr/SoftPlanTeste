FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["CalcSoft.Api/CalcSoft.Api.csproj", "CalcSoft.Api/"]
RUN dotnet restore "CalcSoft.Api/CalcSoft.Api.csproj"
COPY . .
WORKDIR "/src/CalcSoft.Api"
RUN dotnet build "CalcSoft.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "CalcSoft.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CalcSoft.Api.dll"]