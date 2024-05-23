package controllers

import (
	"fmt"
	"log"

	"github.com/gofiber/fiber/v3"
)

func UploadImage(c fiber.Ctx) error {
	id := c.FormValue("id")
	file, err := c.FormFile("image")
	if err != nil {
		log.Println("Error in uploading Image : ", err)
		return c.JSON(fiber.Map{"status": 500, "message": "Server error", "data": nil})
	}

	image := fmt.Sprintf("%s.jpg", id)

	err = c.SaveFile(file, fmt.Sprintf("./media/worker/%s", image))

	if err != nil {
		log.Println("Error in saving Image :", err)
		return c.JSON(fiber.Map{"status": 500, "message": "Server error", "data": nil})
	}

	return c.JSON(fiber.Map{"status": 201, "message": "Image uploaded successfully"})
}
