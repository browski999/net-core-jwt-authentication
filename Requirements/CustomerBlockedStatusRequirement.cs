using Microsoft.AspNetCore.Authorization;

namespace SecureWebApiJWT.Requirements
{
    public class CustomerBlockedStatusRequirement : IAuthorizationRequirement
    {
        public bool IsBlocked { get; }

        public CustomerBlockedStatusRequirement(bool isblocked)
        {
            IsBlocked = isblocked;
        }
    }
}
