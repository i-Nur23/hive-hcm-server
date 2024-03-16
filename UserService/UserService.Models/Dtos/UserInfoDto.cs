namespace UserService.Models.Dtos
{
    public class UserInfoDto
    {
        public int Id { get; set; }

        public string Name { get; set; } 
        
        public string Surname { get; set; }

        public string Email { get; set; }

        public string CompanyName {  get; set; }
        
        public string Token { get; set; }
    }
}
