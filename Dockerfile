# Use the official .NET runtime image
FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base

# Use the official .NET SDK image for building the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy the project files and restore dependencies
COPY ["./DPD_App/DPD_App.csproj", "./"]
RUN dotnet restore

# Copy the rest of the application files and publish the app
COPY . .
RUN dotnet publish -c Release -r linux-x64 --self-contained true -p:PublishSingleFile=true -p:IncludeNativeLibrariesForSelfExtract=true -o /publish

# Create the final image with the published app
FROM base AS final
WORKDIR /app
COPY --from=build /publish .
ENV INSTANCE_NAME = "Start"
ENTRYPOINT ./DPD_App --InstanceName $INSTANCE_NAME
