using One_Time_Password_Generator.Entities;
using One_Time_Password_Generator.Enums;
using One_Time_Password_Generator.Repositories;

namespace One_Time_Password_Generator.Services
{
    public class OTPService
    {
        private readonly UserRepository userRepository;

        public OTPService(UserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        /// <summary>
        /// Generates an One-Time Password for the specified user id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="timeStamp"></param>
        /// <returns>
        /// The generated OTP
        /// </returns>
        public string Generate(string id, DateTime timeStamp)
        {
            var loweredId = id.ToLowerInvariant();
            var user = userRepository.GetUserById(loweredId);

            if (user == null)
            {
                user = new User
                {
                    UserId = loweredId,
                    OTP = Generate(),
                    Activated_DateTime = timeStamp
                };
                userRepository.AddUser(user);
            }
            else
            {
                user.OTP = Generate();
                user.Activated_DateTime = timeStamp;
                user = userRepository.UpdateUser(user);
            }

            return user.OTP;
        }

        /// <summary>
        /// Checks if user exists AND OTP is valid
        /// </summary>
        /// <param name="id"></param>
        /// <param name="otp"></param>
        /// <returns>
        /// True if user exists and OTP is valid, False otherwise
        /// </returns>
        public CheckOTPResponseCode Check(string id, string otp)
        {
            var user = userRepository.GetUserById(id.ToLowerInvariant());

            if (user == null)
                return CheckOTPResponseCode.InvalidUserID;

            //return otp.Equals(user.OTP) && IsValid(user);

            if (!otp.Equals(user.OTP))
                return CheckOTPResponseCode.InvalidOTP;

            if (!IsActivated(user))
                return CheckOTPResponseCode.NotActivatedOTP;

            if (IsExpired(user))
                return CheckOTPResponseCode.ExpiredOTP;

            return CheckOTPResponseCode.Valid;
        }

        /// <summary>
        /// </summary>
        /// <param name="user"></param>
        /// <returns>
        /// True if OTP is not expired <br />
        /// False if OTP is expired or not activated yet
        /// </returns>
        private static bool IsExpired(User user)
        {
            return user.Activated_DateTime.AddSeconds(30) < DateTime.Now;
        }

        /// <summary>
        /// </summary>
        /// <param name="user"></param>
        /// <returns>
        /// True if OTP is activated <br/>
        /// False if OTP is not activated
        /// </returns>
        private static bool IsActivated(User user)
        {
            return user.Activated_DateTime <= DateTime.Now;
        }

        /// <summary>
        /// Generates a random password that contains only numbers
        /// </summary>
        /// <returns>
        /// The random generated password
        /// </returns>
        private static string Generate()
        {
            const int otpLength = 9;
            string otp = "";
            Random rand = new();

            for (int i = 1; i <= otpLength; i++)
            {
                otp += rand.Next(0, 9);
            }

            return otp;
        }
    }
}
