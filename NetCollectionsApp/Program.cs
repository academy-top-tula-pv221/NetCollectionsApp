using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;

namespace NetCollectionsApp
{
    class UserAgeComparer : IComparer<User>
    {
        public int Compare(User? x, User? y)
        {
            return x!.Age.CompareTo(y!.Age);
        }
    }
    class User
    {
        public string Name { set; get; }
        public int Age { set; get; }
        public User() { }
        public User(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}";
        }
    }

    class Employe
    {
        public int Id { set; get; }
        public string Title { set; get; }
        public override string ToString()
        {
            return $"Title: {Title}, Id: {Id}";
        }


    }
    internal class Program
    {
        static void Main(string[] args)
        {
            ArrayList arr = new ArrayList();
            arr.Add(1);
            arr.Add("Hello");
            arr.Add(true);
            arr.Add(new { Title = "Bob", Code = 23 });
            foreach (var item in arr)
                Console.WriteLine(item.ToString());
            Console.WriteLine();

            List<int> list = new List<int>() { 1, 2, 3, 4 };
            List<float> flist = list.ConvertAll<float>(new Converter<int, float>(i => (float)i));


            List<User> users = new List<User>()
            {
                new User("Bob", 23),
                new User(){ Name = "Joe", Age = 43 },
                new User()
            };

            foreach(var user in users)
                Console.WriteLine(user);
            Console.WriteLine();


            User sam = new User("Sam", 33);
            users.Add(sam);

            foreach (var user in users)
                Console.WriteLine(user);
            Console.WriteLine();

            users.AddRange(new List<User>
            {
                new User("Tom", 23),
                new User("Leo", 53),
            });

            foreach (var user in users)
                Console.WriteLine(user);
            Console.WriteLine();

            Console.WriteLine(users.Contains(new User("Sam", 33)));

            List<Employe> employes = users.ConvertAll(
                new Converter<User, Employe>(
                    u => new Employe { Title = u.Name, Id = u.Age }
                    )
                );

            Console.WriteLine();
            foreach (var user in employes)
                Console.WriteLine(user);
            Console.WriteLine();
        }
    }
}