public class UserInterface
{
    private string _userName;
    private string _password;

    private void GetData()
    {
        Console.WriteLine("Enter your username:");
        _userName = Console.ReadLine();

        Console.WriteLine("Enter your password");
        _password = Console.ReadLine();
    }

    // sign up 

    public void Signup()
    {
        GetData();

        var biz = new Business();
        biz.SignUp(_userName, _password);
    }
}

public class Business
{
    public void SignUp(string username, string password)
    {

    }
}

public class DataAcess
{

}