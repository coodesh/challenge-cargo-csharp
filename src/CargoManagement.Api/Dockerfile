# BUG INTENCIONAL: Dockerfile sem multi-stage build.
# Usa a imagem do SDK (pesada, ~900MB) ao invés de usar multi-stage
# com a imagem de runtime aspnet:8.0-jammy-chiseled (~110MB).
#
# O candidato deve corrigir para multi-stage build:
#   Stage 1 (build): sdk:8.0 para compilar
#   Stage 2 (runtime): aspnet:8.0-jammy-chiseled para rodar

FROM mcr.microsoft.com/dotnet/sdk:8.0
WORKDIR /app
COPY . .
RUN dotnet publish -c Release -o out
ENTRYPOINT ["dotnet", "out/CargoManagement.Api.dll"]
