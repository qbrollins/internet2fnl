﻿namespace vize.Models
{
    public class Surway
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
