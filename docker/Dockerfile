FROM alpine:3.14

RUN apk add --no-cache bash icu-libs krb5-libs libgcc libintl libssl1.1 libstdc++ zlib wget
RUN wget https://dotnet.microsoft.com/download/dotnet/scripts/v1/dotnet-install.sh
RUN chmod +x dotnet-install.sh
RUN ./dotnet-install.sh -c Current
RUN alias dotnet=/root/.dotnet/dotnet
ENV PATH=/root/.dotnet/:$PATH

WORKDIR /app

COPY *.csproj ./
RUN dotnet restore
COPY . ./
RUN dotnet publish -c Release -o out

EXPOSE 8080
ENTRYPOINT ["dotnet", "/app/out/docker.dll"]
