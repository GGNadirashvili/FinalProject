namespace ATM
{
    public record User
    {
        public int CardNumber { get; set; }
        public int PinCode { get; set; }
        public double Balance { get; set; }
    }
}
