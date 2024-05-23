FROM golang:1.22

WORKDIR /src

COPY ["Server/MediaService/go.mod", "Server/MediaService/"]
COPY ["Server/MediaService/go.sum", "Server/MediaService/"]
COPY ["Server/MediaService/public", "Service/MediaService/media"] 
COPY ["Server/MediaService/server.go", "Server/MediaService/"]
COPY ["Server/MediaService/controllers/ImagesController.go", "Server/MediaService/controllers/"]

WORKDIR "/src/Server/MediaService"
RUN go mod download

RUN CGO_ENABLED=0 GOOS=linux go build -o /build

CMD [ "/build" ]

# FROM golang:1.22

# WORKDIR /src/MediaService

# COPY . .
# RUN go mod tidy