using MineSweeper.Core;
using MineSweeper.Lang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MineSweeper
{
    public class Settings
    {
        public Config Config { get; set; }
        public HighScores HighScores { get; set; }
    }

    public class Config
    {
        public GameConfig GameConfig { get; set; }
        public Cheat Cheat { get; set; }
        public CustomizedConfig CustomizedConfig { get; set; }
        public int WindowTop { get; set; }
        public int WindowLeft { get; set; }
        public string Lang { get; set; }
    }

    public enum Difficulty
    {
        Beginner = 0,
        Intermediate = 1,
        Expert = 2,
        Customized = 3,
    }

    public class HighScores
    {
        public ScoreInfo Beginner { get; set; }
        public ScoreInfo Intermediate { get; set; }
        public ScoreInfo Expert { get; set; }
    }

    public class ScoreInfo
    {
        public int Score { get; set; }
        public string Name { get; set; }
    }

    public class GameConfig
    {
        public Difficulty Difficulty { get; set; }
        public bool AllowMark { get; set; }
        public bool AllowFlag { get; set; }
        public MineFields.FirstClickType FirstClickType { get; set; }
        public bool Show4DigitsNumber { get; set; }
        public bool TimeStartFromZero { get; set; }
        public bool AllowHighScoreInRestartGame { get; set; }
    }

    public class Cheat
    {
        public bool ShowMines { get; set; }
        public bool ShowPossibility { get; set; }
    }

    public class CustomizedConfig
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public int MineCount { get; set; }
    }

    public static class SettingProvider
    {
        public static Settings Settings { get; set; }
        private static XmlSerializer XmlSerializer = new XmlSerializer(typeof(Settings));

        static SettingProvider()
        {
            LoadSettings();
            DifficultyLookup = new Dictionary<int, ScoreInfo>()
            {
                { 0, Settings.HighScores.Beginner },
                { 1, Settings.HighScores.Intermediate },
                { 2, Settings.HighScores.Expert }
            };
        }


        public static Dictionary<int, ScoreInfo> DifficultyLookup = null;

        public static bool SaveSettings()
        {
            var settingFile = "Settings.xml";
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Settings));
            try
            {
                if (!File.Exists(settingFile))
                {
                    File.Create(settingFile);
                }
                using (Stream writer = new FileStream(settingFile, FileMode.Truncate))
                {
                    XmlSerializer.Serialize(writer, Settings);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static void LoadSettings()
        {
            var settingFile = "Settings.xml";
            bool readSuccess = false;
            if (File.Exists(settingFile))
            {
                try
                {
                    using (Stream reader = new FileStream(settingFile, FileMode.Open))
                    {
                        Settings = (Settings)XmlSerializer.Deserialize(reader);
                    }
                    readSuccess = true;
                }
                catch
                {

                }

            }

            if (!readSuccess)
            {
                Settings = new Settings();
                Settings.Config = new Config();
                Settings.Config.GameConfig = new GameConfig()
                {
                    AllowFlag = true,
                    AllowHighScoreInRestartGame = false,
                    AllowMark = true,
                    Difficulty = Difficulty.Beginner,
                    FirstClickType = MineFields.FirstClickType.Protection,
                    Show4DigitsNumber = false,
                    TimeStartFromZero = false
                };
                Settings.Config.CustomizedConfig = new CustomizedConfig()
                {
                    Height = 9,
                    Width = 9,
                    MineCount = 10
                };
                Settings.Config.Cheat = new Cheat()
                {
                    ShowMines = false,
                    ShowPossibility = false,
                };
                var anonymousText = L10N.GetText("Anonymous");
                Settings.HighScores = new HighScores();
                Settings.HighScores.Beginner = new ScoreInfo()
                {
                    Score = 9999990,
                    Name = anonymousText
                };
                Settings.HighScores.Intermediate = new ScoreInfo()
                {
                    Score = 9999990,
                    Name = anonymousText
                };
                Settings.HighScores.Expert = new ScoreInfo()
                {
                    Score = 9999990,
                    Name = anonymousText
                };
                SaveSettings();
            }
        }
    }
}
