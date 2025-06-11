using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq; // <- Nauja eilutė XML skaitymui
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JsonUserAppFramework
{
    public class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
    }

    public class UserBase
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class Admin : UserBase
    {
        public string Permissions { get; set; }
    }

    public class RegularUser : UserBase
    {
        public string MembershipLevel { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // === 1. Nuskaitom JSON user.json ===
            string filePath = "user.json";
            string json = File.ReadAllText(filePath);
            List<User> users = JsonConvert.DeserializeObject<List<User>>(json);

            Console.WriteLine("=== Vartotojai iš user.json ===");
            foreach (var user in users)
            {
                Console.WriteLine($"Vardas: {user.Name}, Amžius: {user.Age}, Miestas: {user.City}");
            }

            // === 2. Pridedam naują vartotoją ===
            users.Add(new User { Name = "Alex Green", Age = 28, City = "Chicago" });
            string updatedJson = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText(filePath, updatedJson);

            // === 3. Skaitom user_types.json ===
            string roleJsonPath = "user_types.json";
            if (File.Exists(roleJsonPath))
            {
                string roleJson = File.ReadAllText(roleJsonPath);
                JArray array = JArray.Parse(roleJson);

                Console.WriteLine("\n=== Vartotojai su rolėmis ===");
                foreach (var item in array)
                {
                    string role = item["Role"]?.ToString();
                    if (role == "Admin")
                    {
                        var admin = item.ToObject<Admin>();
                        Console.WriteLine($"[Admin] {admin.Name}, Amžius: {admin.Age}, Leidimai: {admin.Permissions}");
                    }
                    else if (role == "User")
                    {
                        var regular = item.ToObject<RegularUser>();
                        Console.WriteLine($"[User] {regular.Name}, Amžius: {regular.Age}, Lygis: {regular.MembershipLevel}");
                    }
                }
            }
            else
            {
                Console.WriteLine("\nFailas user_types.json nerastas.");
            }

            // === 4. Skaitom XML failą user.xml pagal teoriją ===
            try
            {
                string xmlPath = "user.xml";
                if (File.Exists(xmlPath))
                {
                    XDocument doc = XDocument.Load(xmlPath);
                    var xmlUsers = doc.Descendants("User");

                    Console.WriteLine("\n=== Vartotojai iš user.xml ===");
                    foreach (var user in xmlUsers)
                    {
                        string name = user.Element("Name")?.Value;
                        string age = user.Element("Age")?.Value;
                        string city = user.Element("City")?.Value;
                        Console.WriteLine($"Vardas: {name}, Amžius: {age}, Miestas: {city}");
                    }
                }
                else
                {
                    Console.WriteLine("\nFailas user.xml nerastas.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nKlaida skaitant XML: {ex.Message}");
            }

            Console.ReadKey();
        }
    }
}
