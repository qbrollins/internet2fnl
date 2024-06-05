using vize.Models;

namespace vize.Dtos
{
    public class SurwayDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public bool IsActive { get; set; }

        public string Description { get; set; }
        public int SurwaysQuestionId { get; set; }

        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
