# Set the base image to .NET 6 SDK
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /app

# Copy the project file(s) and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy the remaining source code
COPY . .

# Build the application
RUN dotnet publish -c Release -o out

# Create the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "HairSalon.dll"]

# Install the agent
RUN apt-get update && apt-get install -y wget ca-certificates gnupg \
&& echo 'deb http://apt.newrelic.com/debian/ newrelic non-free' | tee /etc/apt/sources.list.d/newrelic.list \
&& wget https://download.newrelic.com/548C16BF.gpg \
&& apt-key add 548C16BF.gpg \
&& apt-get update \
&& apt-get install -y 'newrelic-dotnet-agent' \
&& rm -rf /var/lib/apt/lists/*

# Enable the agent
ENV CORECLR_ENABLE_PROFILING=1 \
CORECLR_PROFILER={36032161-FFC0-4B61-B559-F6C5D41BAE5A} \
CORECLR_NEWRELIC_HOME=/usr/local/newrelic-dotnet-agent \
CORECLR_PROFILER_PATH=/usr/local/newrelic-dotnet-agent/libNewRelicProfiler.so \
NEW_RELIC_LICENSE_KEY=86d972a9658ac756c6dc70ae7bc018c1FFFFNRAL \
NEW_RELIC_APP_NAME="HairSalon.Solution"
