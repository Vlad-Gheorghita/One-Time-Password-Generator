namespace One_Time_Password_Generator.Entities
{
    public class User
    {
        public string ?UserId { get; set; }
        public string OTP { get; set; } = string.Empty;
        public DateTime Activated_DateTime { get; set; } = DateTime.Now;
    }
}
