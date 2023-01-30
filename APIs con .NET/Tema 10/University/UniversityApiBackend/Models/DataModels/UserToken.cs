namespace UniversityApiBackend.Models.DataModels
{
    public class UserToken
    {
        public int Id { get; set; }
        public string Token { get; set; } = String.Empty;
        public string Username { get; set; } = String.Empty;
        public TimeSpan Validity { get; set; }
        public string RefreshToken { get; set; } = String.Empty;
        public string EmailId { get; set; } = String.Empty;
        public Guid GuidId { get; set; }
        public DateTime ExpiredTime { get; set; }
        public string Role { get; set; } = String.Empty;
        public string WelcomeMessage { get; set; } = String.Empty;
    }
}
