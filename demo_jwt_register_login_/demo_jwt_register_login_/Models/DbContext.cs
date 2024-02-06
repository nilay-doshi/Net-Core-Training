namespace demo_jwt_register_login_.Models
{
    public class DbContext :IDbContext
    {
        public List<Register> _registerUsers = new List<Register>()
        {
            new Register()
            {
                UserName = "Nilay",
                Password = "nilay@12345",
                Address = "Ahmedabad",
                Age = 25
            }
        };

        public List<Register> getUsers()
        {
            return _registerUsers;
        }

        public void registerUser(Register user)
        {
            _registerUsers.Add(user);
        }

        public Register updateUser(Register user)
        {
            var existingUser = _registerUsers.Find(x  => x.UserName == user.UserName);
            existingUser.Password = user.Password;
            existingUser.Address = user.Address;
            existingUser.Age = user.Age;
            return existingUser;
        }
    }
}
