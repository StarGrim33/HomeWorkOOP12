namespace HomeWorkOOP12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User user = new();
            Zoo zoo = new();
            zoo.Run(user);
        }
    }

    class Zoo
    {
        private EnclosureBuilder _enclosureBuilder = new();
        private List<Enclosure> _enclosures = new();

        public Zoo()
        {
            _enclosures.Add(_enclosureBuilder.Build(5, "вольер Валента"));
            _enclosures.Add(_enclosureBuilder.Build(5, "вольер Александра"));
            _enclosures.Add(_enclosureBuilder.Build(5, "вольер Софи"));
            _enclosures.Add(_enclosureBuilder.Build(5, "вольер Елена"));
        }

        public string Name { get; private set; } = "Лимпопо";

        public void Run(User user)
        {
            bool isProgramOn = true;

            Console.WriteLine($"Приветствуем Вас, {user.Name}, в зоопарке: {Name}");

            while (isProgramOn)
            {
                Console.Clear();
                ShowEnclosures();
                Console.WriteLine("\nК какому вольеру Вы хотите подойти?");

                bool isNumber = int.TryParse(Console.ReadLine(), out int userInput);

                if (isNumber)
                {
                    if(userInput > 0 && userInput <= _enclosures.Count)
                        _enclosures[userInput - 1].ShowAnimals();
                }
                else
                {
                    Console.WriteLine("Ошибка");
                    Console.ReadKey();
                }
            }
        }

        private void ShowEnclosures()
        {
            int index = 1;

            foreach (Enclosure enclosure in _enclosures)
            {
                Console.WriteLine($"{index}.Вольер: {enclosure.Name}");
                index++;
            }
        }
    }

    class Enclosure
    {
        private List<Animals> _animals = new();

        public Enclosure(string name, List<Animals> animals)
        {
            Name = name;
            _animals = animals;
        }

        public string Name { get; private set; }

        public void ShowAnimals()
        {
            Console.Clear();
            Console.WriteLine($"Вольер: {Name}");
            Console.WriteLine($"{new string('#', 25)}");

            foreach (Animals animal in _animals)
            {
                Console.WriteLine($"Вид: {animal.Type}, пол: {animal.Sex}, возраст: {animal.Age}");
            }

            Console.ReadKey();
            return;
        }
    }

    class EnclosureBuilder
    {
        public Enclosure Build(int animalsCount, string name)
        {
            List<Animals> animals = new();

            for (int i = 0; i < animalsCount; i++)
            {
                animals.Add(CreateRandomAnimal());
            }

            return new Enclosure(name, animals);
        }

        private Animals CreateRandomAnimal()
        {
            Random random = new();
            var animal = CreateAnimals();
            int randomIndex = random.Next(animal.Count);
            return animal[randomIndex];
        }

        private List<Animals> CreateAnimals()
        {
            Random random = new();
            string[] sex = { "самец", "самка" };
            var randomSex = random.Next(sex.Length);
            var randomAge = random.Next(100);

            return new List<Animals>
            {
                new Tiger("Тигр", sex[randomSex], randomAge),
                new PolarBeer("Белый медведь", sex[randomSex], randomAge),
                new Lion("Лев", sex[randomSex], randomAge),
                new Bear("Медведь", sex[randomSex], randomAge),
                new Giraffe("Жираф", sex[randomSex], randomAge),
                new Gazelle("Газель", sex[randomSex], randomAge),
                new Raccoon("Енот", sex[randomSex], randomAge),
                new Gorilla("Горилла", sex[randomSex], randomAge),
                new Elephant("Слон", sex[randomSex], randomAge),
            };
        }
    }

    abstract class Animals
    {
        public Animals(string type, string sex, int age)
        {
            Type = type;
            Sex = sex;
            Age = age;
        }

        public string Type { get; protected set; }
        public string Sex { get; protected set; }
        public int Age { get; protected set; }

        public abstract void Sound();
    }

    class Tiger : Animals
    {
        public Tiger(string type, string sex, int age) : base(type, sex, age)
        {
        }

        public override void Sound()
        {
            Console.WriteLine($"Издает протяжный рык: арррррр");
        }
    }

    class Giraffe : Animals
    {
        public Giraffe(string type, string sex, int age) : base(type, sex, age)
        {
        }

        public override void Sound()
        {
            Console.WriteLine("Мычит, свистит или ревет");
        }
    }

    class PolarBeer : Animals
    {
        public PolarBeer(string type, string sex, int age) : base(type, sex, age)
        {
        }

        public override void Sound()
        {
            Console.WriteLine("Издает рев!");
        }
    }

    class Raccoon : Animals
    {
        public Raccoon(string type, string sex, int age) : base(type, sex, age)
        {
        }

        public override void Sound()
        {
            Console.WriteLine("Резко стрекочит или угрожающе рычит");
        }
    }

    class Gazelle : Animals
    {
        public Gazelle(string type, string sex, int age) : base(type, sex, age)
        {
        }

        public override void Sound()
        {
            Console.WriteLine("Короткий лай или длинный рычащий звук");
        }
    }

    class Lion : Animals
    {
        public Lion(string type, string sex, int age) : base(type, sex, age)
        {
        }

        public override void Sound()
        {
            Console.WriteLine("Громко рычит или ревет");
        }
    }

    class Gorilla : Animals
    {
        public Gorilla(string type, string sex, int age) : base(type, sex, age)
        {
        }

        public override void Sound()
        {
            Console.WriteLine("Хрюкает или издают звук, похожий на глухой лай");
        }
    }

    class Elephant : Animals
    {
        public Elephant(string type, string sex, int age) : base(type, sex, age)
        {
        }

        public override void Sound()
        {
            Console.WriteLine("Трубит или ревет");
        }
    }

    class Bear : Animals
    {
        public Bear(string type, string sex, int age) : base(type, sex, age)
        {
        }

        public override void Sound()
        {
            Console.WriteLine("Издает медвежий рык");
        }
    }

    class User
    {
        public User()
        {
            Name = ToWelcome();
        }

        public string Name { get; private set; }

        public string ToWelcome()
        {
            Console.WriteLine("Здравствуйте, как Вас зовут ?");
            string? userName = Console.ReadLine();

            if (userName == null)
            {
                return userName = "Аноним";
            }

            return userName;
        }
    }
}