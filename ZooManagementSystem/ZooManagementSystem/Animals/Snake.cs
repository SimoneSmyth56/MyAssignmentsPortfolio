namespace ZooManagementSystem.Animals
{
    // Snake class, inheriting from ZooAnimals and implementing IHibernate interface
    class Snake : ZooAnimals, AnimalCapabilities.IHibernate
    {
        // Instance of AnimalDietInfo for managing snake's diet information
        AnimalDietInfo snakeDiet = new AnimalDietInfo();

        // Constructor for creating a new snake object
        public Snake(string animalSpecies, string name, int age, string gender, double weight, string bodylength, AnimalType animalTypeEnum)
            : base(animalSpecies, name, age, gender, weight, animalTypeEnum)
        {
            Bodylength = bodylength;

            // Initialize snake's diet information
            SnakeDietInfo();
        }

        // Property for storing snake's body length
        public string Bodylength { get; set; }

        // Method to handle snake's eating behavior
        public override string Eat()
        {
            return "You fed the snake a mouse ";
        }

        // Method to handle snake's eating behavior with multiple feedings per day
        public override string Eat(int feedTimes)
        {
            return $"The snake is fed {feedTimes} times per day.";
        }

        // Method to get the location of the snake's enclosure number
        public string Location(int enclosureNumber)
        {
            return $"The snake is in enclosure number: {enclosureNumber}";
        }

        // Method to view snake's information
        public void ViewSnakeInformation(out string snakeInfo)
        {
            snakeInfo = $"Name: {Name}\r\n" +
                        $"Age: {Age}\r\n" +
                        $"Gender: {Gender}\r\n" +
                        $"Weight (kg): {Weight}\r\n" +
                        $"Body Length: {Bodylength}\r\n";
        }

        // Method to retrieve and display snake's diet information
        public string SnakeDietInfo()
        {
            snakeDiet.getDietInfo("Rodents", "Twice a week", 0.25F);
            return snakeDiet.displayDietInfo(out string dietInfo);
        }

        // Method to determine snake's habitat
        public string SnakeHabitat()
        {
            HabitatType snakeHabitat = HabitatType.Jungle;
            return "Snakes live in the" + " " + snakeHabitat;
        }

        // Method to determine snake's animaltype
        public string SnakeType()
        {
            AnimalType snakeType = AnimalType.Reptile;
            return "A snake is a" + " " + snakeType;
        }

        // Method to handle snake's hibernation behavior
        public string Hibernate()
        {
            return "The snake hibernates during winter";
        }

 
        public override string animalSound
        {
            get { return "The snake Hisses!"; } // Specific sound for snakes
        }

   
        public override string animalMove()
        {
            return "The snake is slithering"; // Specific movement for snakes
        }


        public override string animalSleep()
        {
            return "Snakes sleep with their eyes open"; // Specific sleeping behavior of snakes
        }

    }
}