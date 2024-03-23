namespace UserService.Models.Dtos
{
    public class UserPasswordChangeDto
    {
        public string OldPassword { get; set; }

        public string NewPassword { get; set; }
    }
}
