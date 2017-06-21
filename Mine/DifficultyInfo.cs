using System.Collections.Generic;
using Mine.Properties;

namespace Mine
{
    public class DifficultyInfo
    {
        private DifficultyInfo()
        {

        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int Mines { get; set; }
        public bool IsCustomized { get; private set; }
        public int HighScore { get; set; }
        public string HighScoreName { get; set; }

        public static DifficultyInfo Beginner = new DifficultyInfo()
        {
            Id = 0,
            Name = "beginner",
            Height = 9,
            Width = 9,
            Mines = 10,
            HighScore = Settings.Default.HighScoreBegginer,
            HighScoreName = Settings.Default.HighScoreBegginerName,
            IsCustomized = false
        };

        public static DifficultyInfo Intermediate = new DifficultyInfo()
        {
            Id = 1,
            Name = "intermediate",
            Height = 16,
            Width = 16,
            Mines = 40,
            HighScore = Settings.Default.HighScoreIntermediate,
            HighScoreName = Settings.Default.HighScoreIntermediateName,
            IsCustomized = false
        };

        public static DifficultyInfo Expert = new DifficultyInfo()
        {
            Id = 2,
            Name = "expert",
            Height = 16,
            Width = 30,
            Mines = 99,
            HighScore = Settings.Default.HighScoreExpert,
            HighScoreName = Settings.Default.HighScoreExpertName,
            IsCustomized = false
        };

        public static DifficultyInfo Customized = new DifficultyInfo()
        {
            Id = 3,
            Name = "customized",
            Height = Settings.Default.CustomHeight,
            Width = Settings.Default.CustomWidth,
            Mines = Settings.Default.CustomMines,
            HighScore = 999,
            HighScoreName = null,
            IsCustomized = true
        };

        public static List<DifficultyInfo> Difficulties = new List<DifficultyInfo>();

        static DifficultyInfo()
        {
            Difficulties.Add(Beginner);
            Difficulties.Add(Intermediate);
            Difficulties.Add(Expert);
            Difficulties.Add(Customized);
        }
    }
}
