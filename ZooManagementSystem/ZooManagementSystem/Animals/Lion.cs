namespace ZooManagementSystem.Animals
{
    // Class representing a Lion, inheriting from ZooAnimals and implementing IClimable
    class Lion : ZooAnimals, AnimalCapabilities.IClimable
    {
        // Instance of AnimalDietInfo for managing lion's diet
        AnimalDietInfo lionDiet = new AnimalDietInfo();

        // Constructor for Lion class, initializing properties including specific mane color
        public Lion(string animalSpecies, string name, int age, string gender, double weight, string manecolour, AnimalType animalTypeEnum)
            : base(animalSpecies, name, age, gender, weight, animalTypeEnum)
        {
            ManeColour = manecolour;

            // Initialize and set lion's diet information
            LionDietInfo();
        }

        // Property for storing mane color of the lion
        public string ManeColour { get; set; }

        // Method overriding Eat() to describe lion's eating behavior
        public override string Eat()
        {
            return "You fed the Lion meat";
        }

        // Method overriding Eat(int feedTimes) to describe lion's feeding frequency
        public override string Eat(int feedTimes)
        {
            return $"The lion is fed {feedTimes} times per day.";
        }

        // Method to specify the location of the lion
        public string Location(int enclosureNumber)
        {
            return $"The lion is in enclosure number: {enclosureNumber}";
        }

        // Method for viewing lion information
        public void ViewLionInformation(out string lionInfo)
        {
            lionInfo = $"Name: {Name}\r\n" +
                            $"Age: {Age}\r\n" +
                            $"Gender: {Gender}\r\n" +
                            $"Weight (kg): {Weight}\r\n" +
                            $"Mane Colour: {ManeColour}\r\n";
        }

        // Method to display diet information of the lion
        public string LionDietInfo()
        {
            lionDiet.getDietInfo("Meat", "Twice a day", 1);
            return lionDiet.displayDietInfo(out string dietInfo);
        }

        // Method to specify the habitat of the lion
        public string LionHabitat()
        {
            HabitatType lionHabitat = HabitatType.Savannah;
            return "Lions live in the" + " " + lionHabitat;
        }

        // Method to specify the type of the lion
        public string LionType()
        {
            AnimalType lionType = AnimalType.Mammal;
            return "A lion is a" + " " + lionType;
        }

        // Method to describe climbing behavior of the lion (implementation of IClimable interface)
        public string Climb()
        {
            return "The lion climbs trees";
        }

        public override string animalSound
        {
            get { return "The lion Roars!"; } // Specific sound for lions
        }

        public override string animalMove()
        {
            return "The lion is running"; // Specific movement for lion
        }

        public override string animalSleep()
        {
            return "The lion sleeps in the shade during the day"; // Specific sleeping behaviour of lion
        }
    }
}
