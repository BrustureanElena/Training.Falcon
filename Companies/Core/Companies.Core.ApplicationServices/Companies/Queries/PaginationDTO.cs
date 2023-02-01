namespace Companies.Core.ApplicationServices.Companies.Queries
{
    public class PaginationDTO
    {
        private const int DefaultLimit = 100;

        private int? limit;

        public int Limit
        {
            get => limit ?? DefaultLimit;
            set => limit = value;
        }

        public string Next { get; set; }
    }
}
