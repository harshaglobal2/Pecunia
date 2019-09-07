namespace Banking.PersonalBanking
{
    public partial class Customer : IPerson
    {
        //auto-implemented property
        public string LandMark { get; set; } //read & write
        //public string LandMark { get; } //read-only

        //field for indexer
        private string[] _contactNumbers;

        //property
        public string[] ContactNumbers
        {
            set
            {
                _contactNumbers = value;
            }
            get
            {
                return _contactNumbers;
            }
        }

        //indexer
        public string this[int index]
        {
            set
            {
                _contactNumbers[index] = value;
            }
            get
            {
                return _contactNumbers[index];
            }
        }
    }
}
