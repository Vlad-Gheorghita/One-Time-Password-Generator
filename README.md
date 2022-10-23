# :closed_lock_with_key: One-Time Password Generator
  I created a web API project and a database using SQLite. In the database, there is one table, Users, that stores the user id (UserId), One-Time Password (OTP) generated, and the date and time it will be active (Activated_DateTime). In the project, I used EntityFramework to access the data from the database easily.<br>
  The project is structured as follows: User entity, User repository which defines the CRUD, OTPService which generates and checks the One-Time Password, and controllers where you can request an OTP or check its validation. For the OTP generation, I created a random number generator with a length of 9 characters.<br>
	By running the application, you can either request an OTP by specifying only the user id and it will return the OTP with the current DateTime as activating time, or you can specify the user id and a specific date and time as the activating time for the OTP. You can also check the OTP validation by inserting the user id and the generated password and it will return if it's valid, invalid, expired, not activated yet or the user does not exist.<br>

## :memo: Table design in DB

|UserId|OTP|Activated_DateTime|
|------|---|------------------|
|user ids|generated password|yyyy-mm-dd hh:mm:ss|

## :rocket: Get Started
Just clone this repository and run it.
