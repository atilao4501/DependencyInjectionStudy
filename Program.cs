using System.Data.Common;
using Microsoft.Extensions.DependencyInjection;

IServiceCollection collection = new ServiceCollection();
collection.AddScoped<IDataAcess, DataAcessMySql>();
collection.AddScoped<IBusiness, BusinessV2>();
collection.AddScoped<UserInterface>();

IServiceProvider serviceProvider = collection.BuildServiceProvider();

UserInterface ui = serviceProvider.GetService<UserInterface>();
ui.Signup();

public class UserInterface
{
    private string _userName;
    private string _password;

    private IBusiness _business;

    public UserInterface(IBusiness business)
    {
        _business = business;
    }

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

        //var biz = new Business();
        _business.SignUp(_userName, _password);
    }
}

public interface IBusiness
{
    public void SignUp(string userName, string password);
}

public class Business : IBusiness
{
    private IDataAcess _dataAcess;
    public Business(IDataAcess dataAcess)
    {
        _dataAcess = dataAcess;
    }
    public void SignUp(string username, string password)
    {
        _dataAcess.SignUp(username, password);

    }
}

public class BusinessV2 : IBusiness
{
    private IDataAcess _dataAcess;

    public BusinessV2(IDataAcess dataAcess)
    {
        _dataAcess = dataAcess;
    }

    public void SignUp(string username, string password)
    {
        _dataAcess.SignUp(username, password);
    }
}

public interface IDataAcess
{
    void SignUp(string userName, string password);
}

public class DataAcessSqlServer : IDataAcess
{
    public void SignUp(string username, string password)
    {
        //Entity Framework
    }
}
public class DataAcessMySql : IDataAcess
{
    public void SignUp(string username, string password)
    {
        //Entity Framework
    }
}