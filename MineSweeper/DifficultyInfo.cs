using System.Collections.Generic;
using MineSweeper.Lang;
using MineSweeper.Properties;

namespace MineSweeper
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

        public static DifficultyInfo Beginner = new DifficultyInfo()
        {
            Id = 0,
            Name = L10N.GetText("Beginner"),
            Height = 9,
            Width = 9,
            Mines = 10,
            IsCustomized = false
        };

        public static DifficultyInfo Intermediate = new DifficultyInfo()
        {
            Id = 1,
            Name = L10N.GetText("Intermediate"),
            Height = 16,
            Width = 16,
            Mines = 40,
            IsCustomized = false
        };

        public static DifficultyInfo Expert = new DifficultyInfo()
        {
            Id = 2,
            Name = L10N.GetText("Expert"),
            Height = 16,
            Width = 30,
            Mines = 99,
            IsCustomized = false
        };

        public static DifficultyInfo Customized = new DifficultyInfo()
        {
            Id = 3,
            Name = L10N.GetText("Customize"),
            Height = SettingProvider.Settings.Config.CustomizedConfig.Height,
            Width = SettingProvider.Settings.Config.CustomizedConfig.Width,
            Mines = SettingProvider.Settings.Config.CustomizedConfig.MineCount,
            IsCustomized = true
        };

        public static List<DifficultyInfo> Difficulties = new List<DifficultyInfo>();

        public static void SetDifficultyName()
        {
            Beginner.Name = L10N.GetText("Beginner");
            Intermediate.Name = L10N.GetText("Intermediate");
            Expert.Name = L10N.GetText("Expert");
            Customized.Name = L10N.GetText("Customize");
        }

        static DifficultyInfo()
        {
            Difficulties.Add(Beginner);
            Difficulties.Add(Intermediate);
            Difficulties.Add(Expert);
            Difficulties.Add(Customized);
        }
    }
}
