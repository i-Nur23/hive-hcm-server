package main

import (
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

    app.Get("/", func(c fiber.Ctx) error {
        return c.SendString("Hello, golanf")
    })

    app.Listen(":5000")
}