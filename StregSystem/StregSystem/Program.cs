
namespace StregSystem;

public class Program 
{
    public static void Main(String[] args)
    {
        Console.WriteLine("ula");
        User user = new User("mike", "Jensen", "Mike_222", "mejn2@student.aau.dk", 60.0m);
        User user1 = new User("mike1", "Jensen1", "Mike_2221", "mejn21@student.aau.dk", 60.0m);
        Console.WriteLine(user.Balance);
        user.Balance = -10.0m;
        Console.WriteLine(user.Balance);
        user.Balance = -10.0m;
        Console.WriteLine(user.Balance);

        Console.WriteLine($"user: {user.Id}\nuser1: {user1.Id}");

        //Console.WriteLine(user.ToString());
    }
}