namespace Advance_Web_Programming_Project.Models.Topic
{
    public class TopicDescription
    {
        public int Id { get; set; }
        public int TopicId { get; set; }
        public int TopicAmount { get; set; }
        public string TopicTitle { get; set; }
        public string TopicPath { get; set; }
    }
}