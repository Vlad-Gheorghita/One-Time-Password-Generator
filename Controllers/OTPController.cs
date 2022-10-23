using Microsoft.AspNetCore.Mvc;
using One_Time_Password_Generator.Enums;
using One_Time_Password_Generator.Services;

namespace One_Time_Password_Generator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OTPController : ControllerBase
    {
        private readonly OTPService otpService;

        public OTPController(OTPService otpService)
        {
            this.otpService = otpService;
        }

        /// <summary>
        /// Generates an One-Time Password for specified user
        /// </summary>
        /// <param name="id"></param>
        /// <param name="timeStamp"></param>
        /// <returns>
        /// The password generated
        /// </returns>
        [HttpGet("Generate One Time password")]
        public IActionResult GenerateOTPForUser(string id, DateTime? timeStamp = null)
        {
            timeStamp ??= DateTime.Now;

            var res = otpService.Generate(id, timeStamp.GetValueOrDefault());

            return Ok("Your One-Time Password is: " + res);
        }


        /// <summary>
        /// Checks if OTP is valid
        /// </summary>
        /// <param name="id"></param>
        /// <param name="otp"></param>
        /// <returns></returns>
        [HttpPost("Check OTP")]
        public IActionResult CheckOTP(string id, string otp)
        {
            var res = otpService.Check(id, otp);

            return res switch
            {
                CheckOTPResponseCode.InvalidUserID => NotFound("User not found"),
                CheckOTPResponseCode.InvalidOTP => BadRequest("Invalid OTP"),
                CheckOTPResponseCode.ExpiredOTP => BadRequest("OTP is expired"),
                CheckOTPResponseCode.NotActivatedOTP => BadRequest("OTP is not activated yet"),
                CheckOTPResponseCode.Valid => Ok("Valid"),
                _ => BadRequest("Something went wrond"),
            };
        }

    }
}
