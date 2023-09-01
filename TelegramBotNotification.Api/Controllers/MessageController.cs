using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Reflection;

namespace TelegramBotNotification.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessageController : Controller
    {
        [HttpGet("{id}")]
        public ActionResult<User> GetUser(Guid id)
        {
            // Здесь должна быть логика получения данных пользователя из БД или другого источника

            // Пример заполнения модели User данными
            User user = new User
            {
                Id = Guid.NewGuid(),
                RoleId = Guid.NewGuid(),
                Name = "John Doe",
                Phone = "+1234567890",
                Avatar = "avatar.jpg",
                Miniature = "thumbnail.jpg",
                DOB = new DateOnly(1990, 1, 1),
                Gender = Gender.Male,
                Language = Language.English,
                Theme = Theme.Light,
                Role = new Role.Role(),
                UserPasswords = new List<UserPassword.UserPassword>(),
                Rooms = new List<Room>()
            };

            // Возвращаем пользователю модель User
            return Ok(user);
        }
    }
}
