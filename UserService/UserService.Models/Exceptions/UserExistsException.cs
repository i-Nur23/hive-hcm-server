namespace UserService.Models.Exceptions
{
    public class UserExistsException : BadRequestException
    {
        public UserExistsException(string email) : 
            base($"Пользоваетль с {email} уже существует") { }
    }
}
