namespace ZooManagementSystem.Animals
{
    // ZooAnimals class inherits from Animal class
    class ZooAnimals : Animal
    {
        // Fields to store animal's basic information
        public string AnimalSpecies;
        public string Name;
        public int Age;
        public string Gender;
        public double Weight;

        // Property to store the type of animal
        public AnimalType animalTypeEnum { get; private set; }

        // Constructor to initialize a ZooAnimals instance
        public ZooAnimals(string animalSpecies, string name, int age, string gender, double weight, AnimalType animalTypeEnum)
        {
            AnimalSpecies = animalSpecies;
            this.animalTypeEnum = animalTypeEnum;
            Name = name;
            Age = age;
            Gender = gender;
            Weight = weight;
        }

        // Virtual method to describe the feeding action
        public virtual string Eat()
        {
            return "The animal is fed";
        }

        // Overloaded method to describe feeding action with specific feed times
        public virtual string Eat(int feedTimes)
        {
            return $"The animal is fed {feedTimes} times per day.";
        }

        // Overridden property to return the animal's sound
        public override string animalSound => "The animal makes a generic sound";
    }

    // Struct to store dietary information of an animal
    public struct AnimalDietInfo
    {
        public string dietaryRequirements;
        public string feedingSchedule;
        public float waterRequirements;

        // Method to set diet information
        public void getDietInfo(string dR, string fS, float wR)
        {
            dietaryRequirements = dR;
            feedingSchedule = fS;
            waterRequirements = wR;
        }

        // Method to display diet information
        public string displayDietInfo(out string dietInfo)
        {
            dietInfo = "Dietary Requirements:" + " " + dietaryRequirements + "\r\n" +
                       "Feeding Schedule:" + " " + feedingSchedule + "\r\n" +
                       "Water Requirements:" + " " + waterRequirements + "L of water" + "\r\n";
            return dietInfo;
        }
    }

    // Enum to represent different animal types
    public enum AnimalType
    {
        Mammal,
        Primate,
        Reptile,
    }

    // Enum to represent different types of food
    public enum FoodType
    {
        Meat,
        Leaves,
        Roots,
        Fruit,
        Mice,
    }

    // Enum to represent different types of habitats
    public enum HabitatType
    {
        Savannah,
        Jungle,
        Grasslands,
        Mountains,
    }
}
