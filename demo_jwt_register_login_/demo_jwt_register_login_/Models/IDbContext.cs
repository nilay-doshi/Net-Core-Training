namespace demo_jwt_register_login_.Models
{
    public interface IDbContext
    {
        Guid Id { get; set; }
        string UserName { get; set; }
        string Password { get; set; }

        string Address { get; set; } 
        int age { get; set; }

        //  Register { get; set; }
    }
}