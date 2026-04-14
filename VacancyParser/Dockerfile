FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

COPY ["VacancyParser.csproj", "."]
RUN dotnet restore

COPY . .

RUN dotnet build

RUN dotnet tool install --global Microsoft.Playwright.CLI

ENV PATH="$PATH:/root/.dotnet/tools"

RUN playwright install chromium

RUN dotnet publish -c Release -o /app/publish


FROM mcr.microsoft.com/dotnet/runtime:8.0

WORKDIR /app

RUN apt-get update && apt-get install -y \
    wget \
    gnupg \
    ca-certificates \
    fonts-liberation \
    libnss3 \
    libatk-bridge2.0-0 \
    libx11-xcb1 \
    libxcomposite1 \
    libxdamage1 \
    libxrandr2 \
    libgbm1 \
    libasound2 \
    libgtk-3-0 \
    libxshmfence1 \
    libxext6 \
    libxfixes3 \
    libxcb1 \
    libdrm2 \
    && rm -rf /var/lib/apt/lists/*

COPY --from=build /root/.cache/ms-playwright /root/.cache/ms-playwright

COPY --from=build /app/publish .

ENV PLAYWRIGHT_BROWSERS_PATH=/root/.cache/ms-playwright

ENTRYPOINT ["dotnet", "VacancyParser.dll"]