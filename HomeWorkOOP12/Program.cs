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

        public string Name { get; private set; } = "Лимпопо";

        public void Run(User user)
        {
            const string CommandFirstEnclosure = "1";
            const string CommandSecondEnclosure = "2";
            const string CommandThirdEnclosure = "3";
            const string CommandFourthEnclosure = "4";

            bool isProgramOn = true;

            Console.WriteLine($"Приветствуем Вас, {user.Name}, в зоопарке: {Name}");

            Enclosure firstEnclosure = _enclosureBuilder.Build(5, "вольер Валента");
            Enclosure secondEnclosure = _enclosureBuilder.Build(5, "вольер Александра");
            Enclosure thirdEnclosure = _enclosureBuilder.Build(5, "вольер Софи");
            Enclosure fourthEnclosure = _enclosureBuilder.Build(5, "вольер Елена");

            while (isProgramOn)
            {
                Console.Clear();
                Console.WriteLine("К какому вольеру Вы хотите подойти?");
                Console.WriteLine($"{CommandFirstEnclosure}-{firstEnclosure.Name}, {CommandSecondEnclosure}-{secondEnclosure.Name}, " +
                    $"{CommandThirdEnclosure}-{thirdEnclosure.Name}, {CommandFourthEnclosure}-{fourthEnclosure.Name}");

                string? userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandFirstEnclosure:
                        firstEnclosure.ShowAnimals();
                        break;

                    case CommandSecondEnclosure:
                        secondEnclosure.ShowAnimals();
                        break;

                    case CommandThirdEnclosure:
                        thirdEnclosure.ShowAnimals();
                        break;

                    case CommandFourthEnclosure:
                        fourthEnclosure.ShowAnimals();
                        break;

                    default:
                        Console.WriteLine("Выберите цифрой пункт меню");
                        break;
                }
            }
        }
    }

    class Enclosure
    {
        private List<AnimalPredator> _predators = new();
        private List<AnimalHerbivore> _herbivores = new();

        public Enclosure(string name, List<AnimalPredator> animals)
        {
            Name = name;
            _predators = animals;
        }

        public Enclosure(string name, List<AnimalHerbivore> animalHerbivores)
        {
            Name = name;
            _herbivores = animalHerbivores;
        }

        public string Name { get; private set; }

        public void ShowAnimals()
        {
            Console.Clear();
            Console.WriteLine($"Вольер: {Name}");
            Console.WriteLine($"{new string('#', 25)}");

            foreach (AnimalPredator animal in _predators)
            {
                Console.WriteLine($"Вид: {animal.Type}, пол: {animal.Sex}, возраст: {animal.Age}");
            }

            foreach (AnimalHerbivore animal in _herbivores)
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
            Random random = new();
            List<AnimalPredator> predators = new();
            List<AnimalHerbivore> herbivores = new();

            if (Chance(random))
            {
                for (int i = 0; i < animalsCount; i++)
                {
                    predators.Add(CreateRandomPredator());
                }

                return new Enclosure(name, predators);
            }
            else
            {
                for (int i = 0; i < animalsCount; i++)
                {
                    herbivores.Add(CreateRandomHerbivore());
                }

                return new Enclosure(name, herbivores);
            }
        }

        private AnimalPredator CreateRandomPredator()
        {
            Random random = new();
            var animal = CreatePredatorAnimals();
            int randomIndex = random.Next(animal.Count);
            return animal[randomIndex];
        }

        private AnimalHerbivore CreateRandomHerbivore()
        {
            Random random = new();
            var animal = CreateHerbivoreAnimals();
            int randomIndex = random.Next(animal.Count);
            return animal[randomIndex];
        }

        private List<AnimalPredator> CreatePredatorAnimals()
        {
            Random random = new();
            string[] sex = { "самец", "самка" };
            var randomSex = random.Next(sex.Length);
            var randomAge = random.Next(100);

            return new List<AnimalPredator>
            {
                new Tiger("Тигр", sex[randomSex], randomAge),
                new PolarBeer("Белый медведь", sex[randomSex], randomAge),
                new Lion("Лев", sex[randomSex], randomAge),
                new Bear("Медведь", sex[randomSex], randomAge)
            };
        }

        private List<AnimalHerbivore> CreateHerbivoreAnimals()
        {
            Random random = new();
            string[] sex = { "самец", "самка" };
            var randomSex = random.Next(sex.Length);
            var randomAge = random.Next(100);

            return new List<AnimalHerbivore>
            {
                new Giraffe("Жираф", sex[randomSex], randomAge),
                new Gazelle("Газель", sex[randomSex], randomAge),
                new Raccoon("Енот", sex[randomSex], randomAge),
                new Gorilla("Горилла", sex[randomSex], randomAge),
                new Elephant("Слон", sex[randomSex], randomAge),

            };
        }

        private bool Chance(Random random)
        {
            int chance = 50;
            int number = random.Next(1, 100);

            return number < chance;
        }
    }

    abstract class AnimalPredator
    {
        public AnimalPredator(string type, string sex, int age)
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

    abstract class AnimalHerbivore
    {
        public AnimalHerbivore(string type, string sex, int age)
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

    class Tiger : AnimalPredator
    {
        public Tiger(string type, string sex, int age) : base(type, sex, age)
        {
        }

        public override void Sound()
        {
            Console.WriteLine($"Издает протяжный рык: арррррр");
        }
    }

    class Giraffe : AnimalHerbivore
    {
        public Giraffe(string type, string sex, int age) : base(type, sex, age)
        {
        }

        public override void Sound()
        {
            Console.WriteLine("Мычит, свистит или ревет");
        }
    }

    class PolarBeer : AnimalPredator
    {
        public PolarBeer(string type, string sex, int age) : base(type, sex, age)
        {
        }

        public override void Sound()
        {
            Console.WriteLine("Издает рев!");
        }
    }

    class Raccoon : AnimalHerbivore
    {
        public Raccoon(string type, string sex, int age) : base(type, sex, age)
        {
        }

        public override void Sound()
        {
            Console.WriteLine("Резко стрекочит или угрожающе рычит");
        }
    }

    class Gazelle : AnimalHerbivore
    {
        public Gazelle(string type, string sex, int age) : base(type, sex, age)
        {
        }

        public override void Sound()
        {
            Console.WriteLine("Короткий лай или длинный рычащий звук");
        }
    }

    class Lion : AnimalPredator
    {
        public Lion(string type, string sex, int age) : base(type, sex, age)
        {
        }

        public override void Sound()
        {
            Console.WriteLine("Громко рычит или ревет");
        }
    }

    class Gorilla : AnimalHerbivore
    {
        public Gorilla(string type, string sex, int age) : base(type, sex, age)
        {
        }

        public override void Sound()
        {
            Console.WriteLine("Хрюкает или издают звук, похожий на глухой лай");
        }
    }

    class Elephant : AnimalHerbivore
    {
        public Elephant(string type, string sex, int age) : base(type, sex, age)
        {
        }

        public override void Sound()
        {
            Console.WriteLine("Трубит или ревет");
        }
    }

    class Bear : AnimalPredator
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