using System;
using System.ComponentModel.DataAnnotations;

namespace Dobby_Jeopardy.models
{
    public class GameBoards
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string[][] DefaultBoard { get; set; }
        public string fakedBoard { get; set; }
        public Tuple<int, int> DailyDouble { get; set; }
        public string Description { get; set; }

    }
}