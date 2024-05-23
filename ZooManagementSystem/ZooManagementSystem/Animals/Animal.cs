namespace ZooManagementSystem.Animals
{
    // Abstract base class for all animals in the zoo
    public abstract class Animal
    {
        // Abstract property representing the sound the animal makes
        public abstract string animalSound { get; }

        // Virtual method representing the animal's sleep behavior
        // Returns a string indicating how the animal is sleeping
        public virtual string animalSleep()
        {
            return "Sleeping...";
        }

        // Virtual method representing the animal's movement behavior
        // Returns a string indicating that the animal is moving
        public virtual string animalMove()
        {
            return "Moving...";
        }

    }
}
