namespace ZooManagementSystem.Animals
{
    // Define a class for Baboons, inheriting from ZooAnimals and implementing IClimable
    class Baboon : ZooAnimals, AnimalCapabilities.IClimable
    {
        // Instance of AnimalDietInfo for managing baboon's diet
        AnimalDietInfo baboonDiet = new AnimalDietInfo();

        // Constructor for initializing Baboon object
        public Baboon(string animalSpecies, string name, int age, string gender, double weight, string taillength, AnimalType animalTypeEnum)
            : base(animalSpecies, name, age, gender, weight, animalTypeEnum)
        {
            Taillength = taillength;

            // Initialize and set baboon's diet information
            BaboonDietInfo();
        }

        // Property for storing tail length of the baboon
        public string Taillength { get; set; }

        // Method overriding Eat() to describe baboon's eating behavior
        public override string Eat()
        {
            return "You fed the baboon fruits and roots";
        }

        // Method overriding Eat(int feedTimes) to describe baboon's feeding frequency
        public override string Eat(int feedTimes)
        {
            return $"The baboon is fed {feedTimes} times per day.";
        }

        // Method to specify the location of the baboon
        public string Location(int enclosureNumber)
        {
            return $"The baboon is in enclosure number: {enclosureNumber}";
        }

        // Method to view information about the baboon
        public void ViewBaboonInformation(out string baboonInfo)
        {
            baboonInfo = $"Name: {Name}\r\n" +
                            $"Age: {Age}\r\n" +
                            $"Gender: {Gender}\r\n" +
                            $"Weight (kg): {Weight}\r\n" +
                            $"Tail Length: {Taillength}\r\n";
        }

        // Method to display diet information of the baboon
        public string BaboonDietInfo()
        {
            baboonDiet.getDietInfo("Fruits and Roots", "Once a day", 2);
            return baboonDiet.displayDietInfo(out string dietInfo);
        }

        // Method to specify the habitat of the baboon
        public string BaboonHabitat()
        {
            HabitatType baboonHabitat = HabitatType.Mountains;
            return "Baboons live in the" + " " + baboonHabitat;
        }

        // Method to specify the type of the baboon
        public string BaboonType()
        {
            AnimalType baboonType = AnimalType.Primate;
            return "A baboon is a" + " " + baboonType;
        }

        // Method to describe climbing behavior of the baboon (implementation of IClimable interface)
        public string Climb()
        {
            return "The baboon climbs trees";
        }

        // Property to specify the specific sound of the baboon
        public override string animalSound
        {
            get { return "The baboon barks!"; } // Specific sound for baboons
        }

        // Method to specify the movement behavior of the baboon
        public override string animalMove()
        {
            return "The baboon swings from branches"; // Specific movement for baboons
        }

        // Method to specify the sleeping behavior of the baboon
        public override string animalSleep()
        {
            return "The baboon sleeps in the tree"; // Specific sleeping behaviour of baboons
        }
    }
}
