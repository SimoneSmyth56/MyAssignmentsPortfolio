namespace ZooManagementSystem.Animals
{
    // Define an internal interface for animal capabilities
    internal interface AnimalCapabilities
    {
        // Interface for animals capable of climbing
        public interface IClimable
        {
            // Method signature for climbing behavior
            string Climb();
        }

        // Interface for animals capable of swimming
        public interface ISwimmable
        {
            // Method signature for swimming behavior
            string Swim();
        }

        // Interface for animals capable of hibernating
        public interface IHibernate
        {
            // Method signature for hibernation behavior
            string Hibernate();
        }
    }
}

