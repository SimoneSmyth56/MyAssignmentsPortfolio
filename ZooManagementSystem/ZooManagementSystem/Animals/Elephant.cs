namespace ZooManagementSystem.Animals
{
    // Define a class for Elephants, inheriting from ZooAnimals and implementing ISwimmable
    class Elephant : ZooAnimals, AnimalCapabilities.ISwimmable
    {
        // Instance of AnimalDietInfo for managing elephant's diet
        AnimalDietInfo elephantDiet = new AnimalDietInfo();

        // Constructor for initializing Elephant object
        public Elephant(string animalSpecies, string name, int age, string gender, double weight, string trunklength, AnimalType animalTypeEnum)
            : base(animalSpecies, name, age, gender, weight, animalTypeEnum)
        {
            TrunkLength = trunklength;

            // Initialize and set elephant's diet information
            ElephantDietInfo();
        }

        // Property for storing trunk length of the elephant
        public string TrunkLength { get; set; }

        // Method overriding Eat() to describe elephant's eating behavior
        public override string Eat()
        {
            return "You fed the elephant grasses, leaves, shrubs, fruits and roots ";
        }

        // Method overriding Eat(int feedTimes) to describe elephant's feeding frequency
        public override string Eat(int feedTimes)
        {
            return $"The elephant is fed {feedTimes} times per day.";
        }

        // Method to specify the location of the elephant
        public string Location(int enclosureNumber)
        {
            return $"The elephant is in enclosure number: {enclosureNumber}";
        }

        // Method to view information about the elephant
        public void ViewElephantInformation(out string elephantInfo)
        {
            elephantInfo = $"Name: {Name}\r\n" +
                            $"Age: {Age}\r\n" +
                            $"Gender: {Gender}\r\n" +
                            $"Weight (kg): {Weight}\r\n" +
                            $"Trunk Length: {TrunkLength}\r\n";
        }

        // Method to display diet information of the elephant
        public string ElephantDietInfo()
        {
            elephantDiet.getDietInfo("Leaves, fruits and roots", "Three times a day", 1);
            return elephantDiet.displayDietInfo(out string dietInfo);
        }

        // Method to specify the habitat of the elephant
        public string ElephantHabitat()
        {
            HabitatType elephantHabitat = HabitatType.Grasslands;
            return "Elephants live in the" + " " + elephantHabitat;
        }

        // Method to specify the type of the elephant
        public string ElephantType()
        {
            AnimalType elephantType = AnimalType.Mammal;
            return "An elephant is a" + " " + elephantType;
        }

        // Method to describe swimming behavior of the elephant (implementation of ISwimmable interface)
        public string Swim()
        {
            return "The elephant swims in the pool";
        }


        public override string animalSound
        {
            get { return "The elephant Trumpets!"; } // Specific sound for elephants
        }

        
        public override string animalMove()
        {
            return "The elephant is walking"; // Specific movement for elephants
        }

        
        public override string animalSleep()
        {
            return "The elephant can sleep lying down on sleep while standing"; // Specific sleeping behaviour of elephants
        }
    }
}