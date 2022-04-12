using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Core_ViewBasedAuthorization.CustomHandler
{
    public class AgeRequirement : IAuthorizationRequirement
    {
        public int Age { get; }
        public AgeRequirement(int age)
        {
            Age = age;
        }
    }

    /// <summary>
    ///  The Custom Handle for Authozation
    /// </summary>
    public class AgeRequirementHandler : AuthorizationHandler<AgeRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AgeRequirement requirement)
        {
            DateTime userDateOfBirth = DateTime.Parse(context.User.FindFirst(c => c.Type == ClaimTypes.DateOfBirth).Value);

            // Get Age
            int age = DateTime.Today.Year - userDateOfBirth.Year;
            if (age >= requirement.Age)
            {
                // Provide Access or USe this Success on View
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
