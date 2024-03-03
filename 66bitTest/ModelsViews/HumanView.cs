namespace _66bitTest.ModelsViews
{
    public class HumanView
    {
        public long Id { get; set; }

        public required string FirstName { get; set; }

        public required string SecondName { get; set; }

        public required string Gender { get; set; }

        public required DateOnly BirthDate { get; set; }

        public required string Country { get; set; }

        public required string TeamName { get; set; }
    }
}
