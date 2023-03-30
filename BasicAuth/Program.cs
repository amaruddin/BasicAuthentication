namespace BasicAuth;

class Program
{
    public static List<User> users = new List<User>();
    public static void Main(string[] args)
    {
        menu:
        Console.WriteLine(DateTime.Now);
        Console.WriteLine("=== BASIC AUTHENTICATION ===");
        Console.WriteLine("1. Create User ");
        Console.WriteLine("2. Show User ");
        Console.WriteLine("3. Search User ");
        Console.WriteLine("4. Login User ");
        Console.WriteLine("5. Exit ");

        Console.Write("Input : ");
        inputMenu:
        int input = Convert.ToInt32(Console.ReadLine());
        switch (input)
        {
            case 1:
                Program.AddUser();
                Console.WriteLine("-----------------------------");
                Console.Write("0. Kembali ");
                int back = Convert.ToInt32(Console.ReadLine());
                if (back == 0) { Console.Clear();  goto menu; } else { Console.ReadKey(); }
                break;
            case 2:
                Program.ShowUser();
                Console.WriteLine("-----------------------------");
                Console.WriteLine("1. Edit User ");
                Console.WriteLine("2. Delete User ");
                Console.Write("0. Kembali ");
                int input2 = Convert.ToInt32(Console.ReadLine());
                switch (input2)
                {
                    case 1:
                        break;
                    case 2:
                        Console.WriteLine("Tulis user yang dihapus : ");
                        string del = Console.ReadLine();
                        //users.Remove(del);
                        break;
                    default:
                        break;
                }

                if (input2 == 0) { Console.Clear();  goto menu; } else { Console.ReadKey(); }
                break;
            case 3:
                Program.SearchUser();
                Console.WriteLine("-----------------------------");
                Console.Write("0. Kembali ");
                back = Convert.ToInt32(Console.ReadLine());
                if (back == 0) { Console.Clear(); goto menu; } else { Console.ReadKey(); }
                break;
            case 4:
                Program.LoginUser();
                Console.WriteLine("-----------------------------");
                Console.Write("0. Kembali ");
                back = Convert.ToInt32(Console.ReadLine());
                if (back == 0) { Console.Clear(); goto menu; } else { Console.ReadKey(); }
                break;
            case 5:
                Console.Clear();
                Console.WriteLine("-----------------------------");
                Console.WriteLine("---- Sekian Terima Kasih ----");
                Console.WriteLine("-----------------------------");
                Console.ReadKey();
                break;
            default:
                Console.WriteLine("Menu tidak tersedia !");
                Console.Write("Input : ");
                goto inputMenu;
        }
    }

    public static void AddUser()
    {
        Console.Clear();
        Console.WriteLine("-----------------------------");
        Console.WriteLine("---- Menu 1. Create User ----");
        Console.WriteLine("-----------------------------");
        Console.Write("  First Name : ");
        string fName = Console.ReadLine();
        Console.Write("  Last Name  : ");
        string lName = Console.ReadLine();
        Console.Write("  Password   : ");
        string password = Console.ReadLine();

        var user = new User(fName, lName, password);
        if (users.Any(u => u.Username.Contains(user.Username)))
        {
            user.Username = user.FirstName.Substring(0, 2) + user.LastName.Substring(0, 2) + users.Count(u => u.Username.ToLower().Contains(user.Username.ToLower()));
        }
        users.Add(user);
        Console.WriteLine("-----------------------------");
        Console.WriteLine("User berhasil dibuat");
        Console.WriteLine("-----------------------------");
    }
    public static void ShowUser()
    {
        Console.Clear();
        Console.WriteLine("-----------------------------");
        Console.WriteLine("----- Menu 2. Show User -----");
        Console.WriteLine("-----------------------------");
        int i = 0;
        foreach (var user in users)
        {
            Console.WriteLine("Id - " + i++);
            Console.WriteLine("Nama User : " + user.FirstName + " " + user.LastName);
            Console.WriteLine("Username  : " + user.Username);
            Console.WriteLine("Password  : " + user.Password);
        }

    }
    
    public static void SearchUser()
    {
        Console.Clear();
        Console.WriteLine("-----------------------------");
        Console.WriteLine("---- Menu 3. Search User ----");
        Console.WriteLine("-----------------------------");
        Console.WriteLine("Tuliskan nama yang dicari :  ");
        string cari = Console.ReadLine();

        var search = users.Where(u =>
                            u.FirstName.ToLower().Contains(cari) || u.LastName.ToLower().Contains(cari)
                     );
        int i = 0;
        foreach (var u in search)
        {
            Console.WriteLine("Id - " + i++);
            Console.WriteLine("Nama User : " + u.FirstName + " " + u.LastName);
            Console.WriteLine("Username  : " + u.Username);
            Console.WriteLine("Password  : " + u.Password);
        }
    }
    public static void LoginUser()
    {
        Console.Clear();
        Console.WriteLine("----------------------------");
        Console.WriteLine("---- Menu 4. Login User ----");
        Console.WriteLine("----------------------------");
        login:
        Console.WriteLine("\n     === Form Login ===     ");
        Console.Write("Username  : ");
        string username = Console.ReadLine();
        Console.Write("Password  : ");
        string password = Console.ReadLine();
        var login = users.Where(u => u.Username.Equals(username) && u.Password.Equals(password)).SingleOrDefault();

        if (login != null)
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine("Login berhasil. \n Selamat Datang " + login.FirstName);

        }
        else
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine("Login gagal ");
            goto login;
        }
    }

}

class User
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Password { get; set; }
    public string Username { get; set; }

    public User(string fname, string lname, string password)
    {
        FirstName = fname;
        LastName = lname;
        Password = password;
        Username = fname.Substring(0, 2) + lname.Substring(0, 2);
    }
}