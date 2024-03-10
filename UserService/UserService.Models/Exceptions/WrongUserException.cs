namespace UserService.Models.Exceptions
{
    public class WrongUserException : BadRequestException
    {
        public WrongUserException() : base("Неверный логин или пароль.") { }
    }
}
