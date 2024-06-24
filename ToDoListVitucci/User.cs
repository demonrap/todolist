
//Definizione classe utenti

public class User
{

    //Definizione parametri di ingresso
    public string Username { get; }
    public string Password { get; }

    public User(string username, string password)
    {
        Username = username;
        Password = password;
    }
}