namespace PinnacleSample
{
    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        // A customer is valid if their ID is greater than 0
        public bool Exists => ID > 0;
    }
}
