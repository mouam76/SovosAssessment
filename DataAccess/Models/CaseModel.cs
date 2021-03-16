using System;

namespace DataAccess.Models
{
    public class CaseModel
    {
        public Guid Id { get; set; }
        public int? Type { get; set; }
        public int? Status { get; set; }
        public string UserName { get; set; }
        public string Title { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public DateTime? DateCreated { get; set; }

        public bool ValidSearch()
        {
            if (DateStart != null ||
                    DateEnd != null ||
                    Status != null ||
                    Type != null ||
                    !string.IsNullOrWhiteSpace(Title) ||
                    !string.IsNullOrWhiteSpace(UserName))
            {
                return true;
            }

            return false;
        }
    }
}
