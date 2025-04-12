using FastFoodAPI.Messages;

namespace FastFoodAPI.Services {
    public interface IAuthService {
        public Task<bool> LoginUser(EmployeeLoginRequest loginRequest);
        public Task<string> CreateToken();
        public Task<(bool Success, string[] Errors)> RegisterUser(EmployeeRegistrationRequest registrationRequest);
        public Task<bool> AssignRoleBasedOnJobTitle(int jobTitleId, string userId);
    }
}
