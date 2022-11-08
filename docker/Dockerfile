FROM alpine:3.14

RUN apk add --no-cache bash icu-libs krb5-libs libgcc libintl libssl1.1 libstdc++ zlib wget
RUN wget https://dotnet.microsoft.com/download/dotnet/scripts/v1/dotnet-install.sh
RUN chmod +x dotnet-install.sh
RUN ./dotnet-install.sh -c Current

WORKDIR /app

COPY *.csproj ./
RUN /root/.dotnet/dotnet restore
COPY . ./
RUN /root/.dotnet/dotnet publish  -c Release -o out

RUN ls /app

#ENV ASPNETCORE_URLS="http://0.0.0.0:8080"

EXPOSE 8080
ENTRYPOINT ["/root/.dotnet/dotnet", "/app/out/docker.dll"]
