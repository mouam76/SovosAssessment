using System;

namespace DataAccessLayer.Models
{
    public class CaseModel
    {
        public Guid Id { get; set; }
        public int Type { get; set; }
        public int Status { get; set; }
        public string UserName { get; set; }
        public string Title { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
