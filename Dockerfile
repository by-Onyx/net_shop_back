FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /net_shop_back

# Копируем только файлы проекта, а не все содержимое
COPY net_shop_back.csproj ./
RUN dotnet restore

# Копируем остальные файлы проекта и выполняем сборку
COPY . .
RUN dotnet publish -c Release -o out

# Строим runtime образ
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /net_shop_back

# Копируем только результаты сборки из предыдущего образа
COPY --from=build-env /net_shop_back/out .
ENTRYPOINT ["dotnet", "net_shop_back.dll"]

