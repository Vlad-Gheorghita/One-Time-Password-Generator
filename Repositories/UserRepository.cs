
using One_Time_Password_Generator.Data;
using One_Time_Password_Generator.Entities;

namespace One_Time_Password_Generator.Repositories
{
    public class UserRepository
    {
        private readonly DataContext dbContext;

        public UserRepository(DataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <summary>
        /// Search for the user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// The user if found otherwise null
        /// </returns>
        public User? GetUserById(string id)
        {
            var user = dbContext.Users.FirstOrDefault(u => u.UserId!.Equals(id));

            return user;
        }

        /// <summary>
        /// Adds a user in table Users
        /// </summary>
        /// <param name="user"></param>
        /// <returns>
        /// The user created
        /// </returns>
        public User AddUser(User user)
        {
            dbContext.Users.Add(user);
            dbContext.SaveChanges();

            return user;
        }

        /// <summary>
        /// Updates the user
        /// </summary>
        /// <param name="user"></param>
        /// <returns>
        /// The updated user
        /// </returns>
        public User UpdateUser(User user)
        {
            var dbUser = dbContext.Users.FirstOrDefault(u => u.UserId!.Equals(user.UserId));

            dbUser!.OTP = user.OTP;
            dbUser.Activated_DateTime = user.Activated_DateTime;

            dbContext.SaveChanges();

            return dbUser;
        }

    }
}
