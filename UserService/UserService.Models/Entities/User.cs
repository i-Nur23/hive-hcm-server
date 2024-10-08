﻿using Core.Enums;

namespace UserService.Models.Entities
{
    public class User
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public Guid CompanyId { get; set; }

        public Role RoleType { get; set; }

        public string Role => $"{RoleType}";
    }
}