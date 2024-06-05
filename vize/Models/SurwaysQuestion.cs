using Microsoft.AspNetCore.Http.HttpResults;

namespace vize.Models

{
    public class SurwaysQuestion
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public List<Surway> Surways { get; set; }
        public string Response { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
