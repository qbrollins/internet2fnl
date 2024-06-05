namespace vize.Dtos
{
    public class SurwaysQuestionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public string Response { get; set; }
    }
}
