using System.Collections.Generic;

namespace Advance_Web_Programming_Project.Models.Topic
{
    public class Topic
    {
        public int Id { get; set; }
        public List<string> TopicId { get; set; }
        public List<string> TopicTitle { get; set; }
        public List<string> TopicDescription { get; set; }
    }
}