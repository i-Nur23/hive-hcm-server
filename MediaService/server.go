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

	app.Static("/", "./media")

	app.Post("/upload", controllers.UploadImage)

	app.Get("/", func(c fiber.Ctx) error {
		return c.JSON(fiber.Map{
			"message": "Hello World",
		})
	})

	app.Listen(":5000")
}
