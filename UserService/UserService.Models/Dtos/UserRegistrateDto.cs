﻿namespace UserService.Models.Dtos
{
    public class UserRegistrateDto
    {
        public string Name { get; set; }

        public string Surname {  get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string CompanyName { get; set; }

        public Guid CompanyId { get; set; }
    }
}
