using ToDoListAPI.Entities;

namespace ToDoListAPI.Identity
{
    public interface IJwtProvider
    {
         string GenerateJwtToken(User user);
    }
}