namespace Core_ViewBasedAuthorization.Models
{
    /// <summary>
    /// Identity Information
    /// </summary>
    public class Users
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// USers Database
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Users> GetUsers()
        {
            return new List<Users>() { new Users { Username = "mahesh", Password = "123", Role = "Admin", DateOfBirth= DateTime.Parse("02/02/1990") },
                                   new Users { Username = "sabnis", Password = "456", Role = "Guest", DateOfBirth= DateTime.Parse("04/06/2005") }};
        }
    }
}
