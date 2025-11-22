using LibraryApi.Entities;

namespace LibraryApi.Services.AuthenticationService
{
    public interface IAuthenticationServices
    {
        
            public Task<User> Login(string username, string password);
            public Task<User> SignUp(User user);
        
    }
}
