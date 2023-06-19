using System.Collections.Generic;

namespace Advance_Web_Programming_Project.Models.Others
{
    public class LeaderboardUser
    {
        public int Id { get; set; }
        public List<string> Username { get; set; }
        public List<int> Level { get; set; }
    }
}