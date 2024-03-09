using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserService.Models.Dtos
{
    public class UserInfoDto
    {
        public int Id { get; set; }

        public string Name { get; set; } 
        
        private string Surname { get; set; }

        public string Email { get; set; }

        public string CompanyName {  get; set; }
        
        public string Token { get; set; }
    }
}
