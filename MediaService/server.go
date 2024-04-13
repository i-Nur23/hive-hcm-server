package main

import (
	"media_server/controllers"

	"github.com/gofiber/fiber/v3"
	"github.com/gofiber/fiber/v3/middleware/cors"
)

func main() {
	app := fiber.New()

	app.Use(cors.New(cors.Config{
		AllowOrigins: "http://localhost:3000",
		AllowHeaders: "*",
	}))

	app.Static("/", "./public")

	app.Post("/upload", controllers.UploadImage)

	app.Listen(":5000")
}
