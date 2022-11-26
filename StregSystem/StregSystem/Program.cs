
namespace StregSystem;

public class Program 
{
    public static void Main(String[] args)
    {
        Console.WriteLine("ula");
        User user = new User();
        user.Firstname = "mike";
        user.Lastname = "Jensen";
        user.Username = "Mike_222";
        user.Email = "mejn2@student.aau.dk";
        Console.WriteLine(user.Balance);
        user.Balance = 60.0m;


        Console.WriteLine(user.Balance);
        user.Balance = -24.0m;
        Console.WriteLine(user.Balance);

        Console.WriteLine(user.ToString());
    }
}