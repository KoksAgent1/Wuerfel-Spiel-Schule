using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.IO;

namespace DiceGame
{
    // Enums for tie-breaker rules
    enum TieBreakerRule
    {
        AcceptTie,
        SuddenDeath,
        HighestSingleDie,
        ReRoll
    }

    // Class to hold all messages and constants for easy editing
    static class Messages
    {
        // Menu options
        public const string MainMenu = "=== Dice Game Menu ===\n1. {0}\n2. Save Session\n3. Manage Sessions\n4. Settings\n5. Manage Players\n6. View Stats\n7. Exit\nSelect an option: ";
        public const string StartNewGame = "Start New Game";
        public const string PlayNextRound = "Play Next Round";

        // Errors and validations
        public const string InvalidSelection = "Invalid selection. Please try again.";
        public const string PressAnyKey = "Press any key to continue...";
        public const string NameCannotBeEmpty = "Name cannot be empty. Please enter a valid name: ";
        public const string PlayerAlreadyExists = "A player with this name already exists.";
        public const string AtLeastTwoPlayersRequired = "At least two players are required to start a game.";
        public const string ConfigureSettingsFirst = "Game settings are not configured. Please configure settings before starting a game.";
        public const string InvalidInputPositiveInteger = "Invalid input. Please enter a positive integer.\n";
        public const string InvalidTieBreakerOption = "Invalid input. Please enter a valid tie-breaker option.\n";
        public const string InvalidYesOrNo = "Please enter 'y' or 'n': ";
        public const string InvalidSessionName = "Invalid session name.";

        // Game messages
        public const string StartingRound = "Starting round {0}...\n";
        public const string PlayerTurn = "It's {0}'s turn.";
        public const string RollResult = "Roll {0}: You rolled {1}.";
        public const string KeepRollPrompt = "Do you want to keep this roll? (y/n): ";
        public const string MaxRollsReached = "You have reached the maximum number of rolls.";
        public const string FinalRoll = "{0}'s final roll: {1} (Total this round: {2}, Cumulative score: {3})\n";
        public const string RoundWinner = "The winner of round {0} is {1} with a score of {2}!\n";
        public const string RoundTie = "Round {0} ends in a tie between: {1} with a score of {2}!";
        public const string OverallWinner = "\nThe overall winner is {0} with a total score of {1}!";
        public const string GameTie = "\nThe game ends in a tie between: {0} with a total score of {1}!";
        public const string TieBreakerRuleAcceptTie = "Tie-breaker rule is to accept the tie.\n";
        public const string TieBreakerInitiate = "Initiating {0} tie-breaker...";
        public const string SuddenDeathRoll = "{0} rolls a {1} in sudden death.";
        public const string HighestSingleDie = "{0}'s highest die: {1}";
        public const string ReRollResult = "{0} re-rolls and gets {1} (Total: {2})";
        public const string TieContinues = "Tie continues even after {0}.";

        // Settings messages
        public const string SettingsMenu = "=== Current Game Settings ===\n1. Number of Rounds: {0}\n2. Number of Dice: {1}\n3. Number of Sides on Dice: {2}\n4. Max Rolls per Player per Round: {3}\n5. Tie-Breaker Rule: {4}\n6. Back to Main Menu\n\nSelect a setting to edit (1-5) or 6 to return: ";
        public const string EnterNumberOfRounds = "Enter the number of rounds to play: ";
        public const string EnterNumberOfDice = "Enter the number of dice to use: ";
        public const string EnterNumberOfSides = "Enter the number of sides on the dice: ";
        public const string EnterMaxRollsPerPlayer = "Enter the maximum number of rolls per player per round: ";
        public const string ChooseTieBreakerRule = "Choose tie-breaker rule ('accept-tie', 'sudden-death', 'highest-single-die', 're-roll'): ";
        public const string SettingsUpdated = "\nSettings updated successfully!";
        public const string SettingsWizardWelcome = "Welcome to the Dice Game Settings Wizard!";
        public const string SettingsWizardComplete = "Settings configured successfully!";

        // Player management messages
        public const string ManagePlayersMenu = "=== Manage Players ===\nCurrent Players:\n{0}\nOptions:\n1. Add New Player\n2. Delete Player\n3. Back to Main Menu\n\nSelect an option: ";
        public const string NoPlayersAdded = "(No players added yet)";
        public const string EnterNewPlayerName = "Enter name for the new player: ";
        public const string PlayerAdded = "Player '{0}' added successfully!";
        public const string EnterPlayerNumberToDelete = "Enter the number of the player to delete: ";
        public const string ConfirmDeletePlayer = "Are you sure you want to delete '{0}'? (y/n): ";
        public const string PlayerDeleted = "Player deleted successfully.";
        public const string InvalidPlayerSelection = "Invalid selection.";

        // Session management messages
        public const string SessionContinuationPrompt = "Saved game sessions found. Would you like to load an existing session? (y/n): ";
        public const string NoSavedSession = "No saved game sessions found.";
        public const string SessionContinued = "Continuing game session '{0}'.";
        public const string SessionStartedNew = "Starting a new game session.";
        public const string EnterSessionName = "Enter a name for this session: ";
        public const string SessionSaved = "Game session saved as '{0}'.";
        public const string ManageSessionsMenu = "=== Manage Sessions ===\nSaved Sessions:\n{0}\nOptions:\n1. Delete Session\n2. Back to Main Menu\n\nSelect an option: ";
        public const string NoSessionsAvailable = "(No saved sessions)";
        public const string EnterSessionNumberToDelete = "Enter the number of the session to delete: ";
        public const string ConfirmDeleteSession = "Are you sure you want to delete session '{0}'? (y/n): ";
        public const string SessionDeleted = "Session deleted successfully.";

        // Miscellaneous
        public const string ExitingGame = "Exiting the game. Goodbye!";
        public const string AutomaticallySelectingPlayers = "Automatically selecting players: {0} and {1}";
        public const string SelectPlayersPrompt = "Select players for this game:";
        public const string EnterPlayerNumbers = "Enter the numbers of the players to include, separated by commas (e.g., 1,3,4):";
        public const string SelectedPlayers = "Selected players: ";
        public const string InvalidPlayerNumbers = "Invalid selection. Please select at least two valid player numbers.";
        public const string LeaderboardHeader = "=== Leaderboard ===";
        public const string NoPlayersAvailable = "(No players available)";
        public const string TieBreakerUsageHeader = "Tie-Breaker Usage:";
        public const string GameStatisticsHeader = "=== Game Statistics ===\n";
        public const string PlayerStats = "{0}:\n - Total Score: {1}\n - Rounds Won: {2}\n";
        public const string SessionLoadPrompt = "Enter the number of the session to load: ";
        public const string InvalidSessionSelection = "Invalid selection.";
        public const string SessionAlreadyExists = "A session with this name already exists. Overwrite? (y/n): ";

        // Tie-breaker rule strings
        public const string TieBreakerAcceptTie = "accept-tie";
        public const string TieBreakerSuddenDeath = "sudden-death";
        public const string TieBreakerHighestSingleDie = "highest-single-die";
        public const string TieBreakerReRoll = "re-roll";

        // Yes and No strings
        public const string Yes = "y";
        public const string No = "n";
    }

    // Enums for main menu options
    enum MainMenuOption
    {
        StartOrContinueGame = 1,
        SaveSession,
        ManageSessions,
        Settings,
        ManagePlayers,
        ViewStats,
        Exit
    }

    // Enums for settings menu options
    enum SettingsMenuOption
    {
        NumberOfRounds = 1,
        NumberOfDice,
        NumberOfSides,
        MaxRollsPerPlayer,
        TieBreakerRule,
        BackToMainMenu
    }

    class Dice
    {
        public int NumberOfSides { get; private set; }

        private Random random;

        public Dice(int numberOfSides)
        {
            NumberOfSides = numberOfSides;
            random = new Random();
        }

        public int Roll()
        {
            return random.Next(1, NumberOfSides + 1);
        }
    }

    class Player
    {
        public string Name { get; set; }
        public List<int> CurrentRoll { get; set; }
        public int TotalScore { get; set; }
        public int RoundsWon { get; set; }

        public Player(string name)
        {
            Name = name;
            CurrentRoll = new List<int>();
            TotalScore = 0;
            RoundsWon = 0;
        }

        public Player()
        {
            // Parameterless constructor for deserialization
            CurrentRoll = new List<int>();
        }

        public List<int> RollDice(Dice dice, int numberOfDice)
        {
            CurrentRoll.Clear();
            for (int i = 0; i < numberOfDice; i++)
            {
                int roll = dice.Roll();
                CurrentRoll.Add(roll);
            }
            return new List<int>(CurrentRoll);
        }
    }

    class GameSettings
    {
        public int NumberOfRounds { get; set; }
        public int NumberOfDice { get; set; }
        public int NumberOfSides { get; set; }
        public int MaxRollsPerPlayer { get; set; }
        public TieBreakerRule TieBreakerRule { get; set; }
        public bool IsConfigured { get; set; }
    }

    class GameData
    {
        public List<Player> Players { get; set; }
        public GameSettings Settings { get; set; }
        public Dictionary<TieBreakerRule, int> TieBreakerUsage { get; set; }
        public int CurrentRound { get; set; }
        public bool GameInProgress { get; set; }
        public List<Player> GamePlayers { get; set; }

        public GameData()
        {
            Players = new List<Player>();
            Settings = new GameSettings();
            TieBreakerUsage = new Dictionary<TieBreakerRule, int>
            {
                { TieBreakerRule.AcceptTie, 0 },
                { TieBreakerRule.SuddenDeath, 0 },
                { TieBreakerRule.HighestSingleDie, 0 },
                { TieBreakerRule.ReRoll, 0 }
            };
            GameInProgress = false;
            CurrentRound = 1;
            GamePlayers = new List<Player>();
        }
    }

    class Game
    {
        private Dice dice;
        private const string SessionsDirectory = "Sessions";

        public GameData Data { get; private set; }
        private string currentSessionFile;

        public Game()
        {
            if (!Directory.Exists(SessionsDirectory))
            {
                Directory.CreateDirectory(SessionsDirectory);
            }

            LoadOrCreateSession();
        }

        private void LoadOrCreateSession()
        {
            var sessionFiles = Directory.GetFiles(SessionsDirectory, "*.json");

            if (sessionFiles.Length > 0)
            {
                Console.Write(Messages.SessionContinuationPrompt);
                string continueSession = GetYesOrNo();
                if (continueSession == Messages.Yes)
                {
                    LoadSession();
                }
                else
                {
                    Data = new GameData();
                    currentSessionFile = null;
                    RunSettingsWizardIfNeeded();
                }
            }
            else
            {
                Console.WriteLine(Messages.NoSavedSession);
                Data = new GameData();
                currentSessionFile = null;
                RunSettingsWizardIfNeeded();
            }
        }

        public void DisplayMenu()
        {
            while (true)
            {
                Console.Clear();
                DisplayLeaderboard();

                string gameOption = Data.GameInProgress && Data.CurrentRound <= Data.Settings.NumberOfRounds
                    ? Messages.PlayNextRound
                    : Messages.StartNewGame;

                Console.Write(string.Format(Messages.MainMenu, gameOption));
                string choice = Console.ReadLine();

                if (int.TryParse(choice, out int menuChoice) &&
                    Enum.IsDefined(typeof(MainMenuOption), menuChoice))
                {
                    switch ((MainMenuOption)menuChoice)
                    {
                        case MainMenuOption.StartOrContinueGame:
                            StartOrContinueGame();
                            break;
                        case MainMenuOption.SaveSession:
                            SaveCurrentSession();
                            break;
                        case MainMenuOption.ManageSessions:
                            ManageSessions();
                            break;
                        case MainMenuOption.Settings:
                            ViewAndEditSettings();
                            break;
                        case MainMenuOption.ManagePlayers:
                            ManagePlayers();
                            break;
                        case MainMenuOption.ViewStats:
                            DisplayGameStatistics();
                            break;
                        case MainMenuOption.Exit:
                            Console.WriteLine(Messages.ExitingGame);
                            return;
                    }
                }
                else
                {
                    Console.WriteLine(Messages.InvalidSelection);
                    Console.WriteLine(Messages.PressAnyKey);
                    Console.ReadKey();
                }
            }
        }

        private void StartOrContinueGame()
        {
            if (!Data.Settings.IsConfigured)
            {
                Console.WriteLine(Messages.ConfigureSettingsFirst);
                Console.WriteLine(Messages.PressAnyKey);
                Console.ReadKey();
                RunSettingsWizard();
                return;
            }
            if (Data.Players.Count < 2)
            {
                Console.WriteLine(Messages.AtLeastTwoPlayersRequired);
                Console.WriteLine("Please add more players in the 'Manage Players' menu.");
                Console.WriteLine(Messages.PressAnyKey);
                Console.ReadKey();
                return;
            }

            // Ensure dice is instantiated
            dice = new Dice(Data.Settings.NumberOfSides);

            if (Data.GameInProgress && Data.CurrentRound <= Data.Settings.NumberOfRounds)
            {
                StartGame();
            }
            else
            {
                StartNewGame();
            }
        }

        private void StartNewGame()
        {
            Data.CurrentRound = 1;
            Data.GameInProgress = true;

            // Prompt the user to select players for the game
            SelectPlayersForGame();

            // Reset players' scores and rounds won
            foreach (var player in Data.GamePlayers)
            {
                player.TotalScore = 0;
                player.RoundsWon = 0;
            }

            // Reset tie-breaker usage
            Data.TieBreakerUsage = new Dictionary<TieBreakerRule, int>
            {
                { TieBreakerRule.AcceptTie, 0 },
                { TieBreakerRule.SuddenDeath, 0 },
                { TieBreakerRule.HighestSingleDie, 0 },
                { TieBreakerRule.ReRoll, 0 }
            };

            StartGame();
        }

        private void StartGame()
        {
            Console.Clear();
            Console.WriteLine(string.Format(Messages.StartingRound, Data.CurrentRound));

            List<Player> roundWinners = new List<Player>();
            int highestScore = -1;

            foreach (var player in Data.GamePlayers)
            {
                Console.WriteLine(string.Format(Messages.PlayerTurn, player.Name));

                int rolls = 0;
                bool stop = false;
                List<int> finalRoll = new List<int>();

                while (rolls < Data.Settings.MaxRollsPerPlayer && !stop)
                {
                    rolls++;
                    List<int> result = player.RollDice(dice, Data.Settings.NumberOfDice);
                    Console.WriteLine(string.Format(Messages.RollResult, rolls, string.Join(", ", result)));

                    if (rolls < Data.Settings.MaxRollsPerPlayer)
                    {
                        Console.Write(Messages.KeepRollPrompt);
                        string input = GetYesOrNo();
                        if (input == Messages.Yes)
                        {
                            finalRoll = new List<int>(result);
                            stop = true;
                        }
                    }
                    else
                    {
                        finalRoll = new List<int>(result);
                        Console.WriteLine(Messages.MaxRollsReached);
                    }
                }

                int total = finalRoll.Sum();

                player.TotalScore += total; // Update cumulative score

                Console.WriteLine(string.Format(Messages.FinalRoll, player.Name, string.Join(", ", finalRoll), total, player.TotalScore));

                if (total > highestScore)
                {
                    highestScore = total;
                    roundWinners.Clear();
                    roundWinners.Add(player);
                }
                else if (total == highestScore)
                {
                    roundWinners.Add(player);
                }
            }

            Player roundWinner = null;

            if (roundWinners.Count == 1)
            {
                roundWinner = roundWinners[0];
                roundWinner.RoundsWon++;
                Console.WriteLine(string.Format(Messages.RoundWinner, Data.CurrentRound, roundWinner.Name, highestScore));
            }
            else
            {
                string tiedPlayers = string.Join(", ", roundWinners.Select(p => p.Name));
                Console.WriteLine(string.Format(Messages.RoundTie, Data.CurrentRound, tiedPlayers, highestScore));

                roundWinner = HandleTie(roundWinners, "round");
                if (roundWinner != null)
                {
                    roundWinner.RoundsWon++;
                    Console.WriteLine(string.Format(Messages.RoundWinner, Data.CurrentRound, roundWinner.Name, highestScore));
                }
                else
                {
                    Console.WriteLine(Messages.TieBreakerRuleAcceptTie);
                }
            }

            Data.CurrentRound++;

            if (Data.CurrentRound > Data.Settings.NumberOfRounds)
            {
                DetermineOverallWinner();
                Data.GameInProgress = false;
            }

            SaveCurrentSession();

            Console.WriteLine(Messages.PressAnyKey);
            Console.ReadKey();
        }

        private void SelectPlayersForGame()
        {
            Data.GamePlayers = new List<Player>();

            if (Data.Players.Count == 2)
            {
                // Automatically select both players
                Data.GamePlayers.AddRange(Data.Players);
                Console.WriteLine(string.Format(Messages.AutomaticallySelectingPlayers, Data.Players[0].Name, Data.Players[1].Name));
                Console.WriteLine(Messages.PressAnyKey);
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine(Messages.SelectPlayersPrompt);
                for (int i = 0; i < Data.Players.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {Data.Players[i].Name}");
                }

                Console.WriteLine(Messages.EnterPlayerNumbers);

                while (true)
                {
                    Console.Write(Messages.SelectedPlayers);
                    string input = Console.ReadLine();
                    var indices = input.Split(',')
                                       .Select(s => s.Trim())
                                       .Where(s => int.TryParse(s, out _))
                                       .Select(int.Parse)
                                       .Distinct()
                                       .ToList();

                    if (indices.Count >= 2 && indices.All(i => i >= 1 && i <= Data.Players.Count))
                    {
                        foreach (var index in indices)
                        {
                            Data.GamePlayers.Add(Data.Players[index - 1]);
                        }
                        break;
                    }
                    else
                    {
                        Console.WriteLine(Messages.InvalidPlayerNumbers);
                    }
                }
            }
        }

        private void ViewAndEditSettings()
        {
            while (true)
            {
                Console.Clear();
                Console.Write(string.Format(Messages.SettingsMenu,
                    Data.Settings.NumberOfRounds,
                    Data.Settings.NumberOfDice,
                    Data.Settings.NumberOfSides,
                    Data.Settings.MaxRollsPerPlayer,
                    Data.Settings.TieBreakerRule));

                string choice = Console.ReadLine();

                if (int.TryParse(choice, out int menuChoice) &&
                    Enum.IsDefined(typeof(SettingsMenuOption), menuChoice))
                {
                    if (menuChoice == (int)SettingsMenuOption.BackToMainMenu)
                    {
                        break;
                    }

                    switch ((SettingsMenuOption)menuChoice)
                    {
                        case SettingsMenuOption.NumberOfRounds:
                            Data.Settings.NumberOfRounds = GetPositiveInteger(Messages.EnterNumberOfRounds);
                            Data.Settings.IsConfigured = true;
                            break;
                        case SettingsMenuOption.NumberOfDice:
                            Data.Settings.NumberOfDice = GetPositiveInteger(Messages.EnterNumberOfDice);
                            Data.Settings.IsConfigured = true;
                            break;
                        case SettingsMenuOption.NumberOfSides:
                            Data.Settings.NumberOfSides = GetPositiveInteger(Messages.EnterNumberOfSides);
                            Data.Settings.IsConfigured = true;
                            break;
                        case SettingsMenuOption.MaxRollsPerPlayer:
                            Data.Settings.MaxRollsPerPlayer = GetPositiveInteger(Messages.EnterMaxRollsPerPlayer);
                            Data.Settings.IsConfigured = true;
                            break;
                        case SettingsMenuOption.TieBreakerRule:
                            Data.Settings.TieBreakerRule = GetTieBreakerRule();
                            Data.Settings.IsConfigured = true;
                            break;
                    }

                    SaveCurrentSession();

                    Console.WriteLine(Messages.SettingsUpdated);
                    Console.WriteLine(Messages.PressAnyKey);
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine(Messages.InvalidSelection);
                    Console.WriteLine(Messages.PressAnyKey);
                    Console.ReadKey();
                }
            }
        }

        private void RunSettingsWizardIfNeeded()
        {
            if (!Data.Settings.IsConfigured)
            {
                RunSettingsWizard();
            }
        }

        private void RunSettingsWizard()
        {
            Console.Clear();
            Console.WriteLine(Messages.SettingsWizardWelcome);

            Data.Settings.NumberOfRounds = GetPositiveInteger(Messages.EnterNumberOfRounds);
            Data.Settings.NumberOfDice = GetPositiveInteger(Messages.EnterNumberOfDice);
            Data.Settings.NumberOfSides = GetPositiveInteger(Messages.EnterNumberOfSides);
            Data.Settings.MaxRollsPerPlayer = GetPositiveInteger(Messages.EnterMaxRollsPerPlayer);
            Data.Settings.TieBreakerRule = GetTieBreakerRule();
            Data.Settings.IsConfigured = true;

            SaveCurrentSession();

            Console.WriteLine(Messages.SettingsWizardComplete);
            Console.WriteLine(Messages.PressAnyKey);
            Console.ReadKey();
        }

        private void ManagePlayers()
        {
            while (true)
            {
                Console.Clear();

                string playersList = Data.Players.Count == 0
                    ? Messages.NoPlayersAdded
                    : string.Join("\n", Data.Players.Select((p, index) => $"{index + 1}. {p.Name}"));

                Console.Write(string.Format(Messages.ManagePlayersMenu, playersList));

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    AddPlayer();
                }
                else if (choice == "2")
                {
                    DeletePlayer();
                }
                else if (choice == "3")
                {
                    break;
                }
                else
                {
                    Console.WriteLine(Messages.InvalidSelection);
                    Console.WriteLine(Messages.PressAnyKey);
                    Console.ReadKey();
                }
            }
        }

        private void AddPlayer()
        {
            Console.Write(Messages.EnterNewPlayerName);
            string name = Console.ReadLine().Trim();
            while (string.IsNullOrEmpty(name))
            {
                Console.Write(Messages.NameCannotBeEmpty);
                name = Console.ReadLine().Trim();
            }

            if (Data.Players.Any(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine(Messages.PlayerAlreadyExists);
            }
            else
            {
                Player player = new Player(name);
                Data.Players.Add(player);
                SaveCurrentSession();

                Console.WriteLine(string.Format(Messages.PlayerAdded, name));
            }

            Console.WriteLine(Messages.PressAnyKey);
            Console.ReadKey();
        }

        private void DeletePlayer()
        {
            if (Data.Players.Count == 0)
            {
                Console.WriteLine(Messages.NoPlayersAdded);
                Console.WriteLine(Messages.PressAnyKey);
                Console.ReadKey();
                return;
            }

            Console.Write(Messages.EnterPlayerNumberToDelete);
            if (int.TryParse(Console.ReadLine(), out int index) && index >= 1 && index <= Data.Players.Count)
            {
                Console.Write(string.Format(Messages.ConfirmDeletePlayer, Data.Players[index - 1].Name));
                string confirm = GetYesOrNo();
                if (confirm == Messages.Yes)
                {
                    Data.Players.RemoveAt(index - 1);
                    SaveCurrentSession();
                    Console.WriteLine(Messages.PlayerDeleted);
                }
            }
            else
            {
                Console.WriteLine(Messages.InvalidPlayerSelection);
            }

            Console.WriteLine(Messages.PressAnyKey);
            Console.ReadKey();
        }

        private void ManageSessions()
        {
            while (true)
            {
                var sessionFiles = Directory.GetFiles(SessionsDirectory, "*.json");

                string sessionsList = sessionFiles.Length == 0
                    ? Messages.NoSessionsAvailable
                    : string.Join("\n", sessionFiles.Select((s, index) => $"{index + 1}. {Path.GetFileNameWithoutExtension(s)}"));

                Console.Clear();
                Console.Write(string.Format(Messages.ManageSessionsMenu, sessionsList));

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    DeleteSession(sessionFiles);
                }
                else if (choice == "2")
                {
                    break;
                }
                else
                {
                    Console.WriteLine(Messages.InvalidSelection);
                    Console.WriteLine(Messages.PressAnyKey);
                    Console.ReadKey();
                }
            }
        }

        private void DeleteSession(string[] sessionFiles)
        {
            if (sessionFiles.Length == 0)
            {
                Console.WriteLine(Messages.NoSessionsAvailable);
                Console.WriteLine(Messages.PressAnyKey);
                Console.ReadKey();
                return;
            }

            Console.Write(Messages.EnterSessionNumberToDelete);
            if (int.TryParse(Console.ReadLine(), out int index) && index >= 1 && index <= sessionFiles.Length)
            {
                string sessionFile = sessionFiles[index - 1];
                string sessionName = Path.GetFileNameWithoutExtension(sessionFile);
                Console.Write(string.Format(Messages.ConfirmDeleteSession, sessionName));
                string confirm = GetYesOrNo();
                if (confirm == Messages.Yes)
                {
                    File.Delete(sessionFile);
                    Console.WriteLine(Messages.SessionDeleted);
                }
            }
            else
            {
                Console.WriteLine(Messages.InvalidSessionSelection);
            }

            Console.WriteLine(Messages.PressAnyKey);
            Console.ReadKey();
        }

        private void LoadSession()
        {
            var sessionFiles = Directory.GetFiles(SessionsDirectory, "*.json");

            Console.WriteLine("Available Sessions:");
            for (int i = 0; i < sessionFiles.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {Path.GetFileNameWithoutExtension(sessionFiles[i])}");
            }

            Console.Write(Messages.SessionLoadPrompt);
            if (int.TryParse(Console.ReadLine(), out int index) && index >= 1 && index <= sessionFiles.Length)
            {
                currentSessionFile = sessionFiles[index - 1];
                string jsonData = File.ReadAllText(currentSessionFile);
                Data = JsonConvert.DeserializeObject<GameData>(jsonData);
                Console.WriteLine(string.Format(Messages.SessionContinued, Path.GetFileNameWithoutExtension(currentSessionFile)));
            }
            else
            {
                Console.WriteLine(Messages.InvalidSessionSelection);
                Data = new GameData();
                currentSessionFile = null;
                RunSettingsWizardIfNeeded();
            }

            Console.WriteLine(Messages.PressAnyKey);
            Console.ReadKey();
        }

        private void SaveCurrentSession()
        {
            if (currentSessionFile == null)
            {
                Console.Write(Messages.EnterSessionName);
                string sessionName = Console.ReadLine().Trim();
                while (string.IsNullOrEmpty(sessionName))
                {
                    Console.WriteLine(Messages.InvalidSessionName);
                    Console.Write(Messages.EnterSessionName);
                    sessionName = Console.ReadLine().Trim();
                }

                string sessionFilePath = Path.Combine(SessionsDirectory, sessionName + ".json");

                if (File.Exists(sessionFilePath))
                {
                    Console.Write(Messages.SessionAlreadyExists);
                    string overwrite = GetYesOrNo();
                    if (overwrite == Messages.Yes)
                    {
                        currentSessionFile = sessionFilePath;
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    currentSessionFile = sessionFilePath;
                }
            }

            string jsonData = JsonConvert.SerializeObject(Data, Formatting.Indented);
            File.WriteAllText(currentSessionFile, jsonData);
            Console.WriteLine(string.Format(Messages.SessionSaved, Path.GetFileNameWithoutExtension(currentSessionFile)));
        }

        private Player HandleTie(List<Player> tiedPlayers, string tieContext)
        {
            TieBreakerRule rule = Data.Settings.TieBreakerRule;
            Data.TieBreakerUsage[rule]++;
            string tieBreakerName = rule.ToString().Replace('_', '-').ToLower();

            if (rule == TieBreakerRule.AcceptTie)
            {
                return null;
            }
            else if (rule == TieBreakerRule.SuddenDeath)
            {
                Console.WriteLine(string.Format(Messages.TieBreakerInitiate, tieBreakerName));
                return SuddenDeathTieBreaker(tiedPlayers);
            }
            else if (rule == TieBreakerRule.HighestSingleDie)
            {
                Console.WriteLine(string.Format(Messages.TieBreakerInitiate, tieBreakerName));
                return HighestSingleDieTieBreaker(tiedPlayers);
            }
            else if (rule == TieBreakerRule.ReRoll)
            {
                Console.WriteLine(string.Format(Messages.TieBreakerInitiate, tieBreakerName));
                return ReRollTieBreaker(tiedPlayers);
            }
            return null;
        }

        private Player SuddenDeathTieBreaker(List<Player> tiedPlayers)
        {
            while (tiedPlayers.Count > 1)
            {
                int highestRoll = -1;
                List<Player> suddenDeathWinners = new List<Player>();

                foreach (var player in tiedPlayers)
                {
                    int roll = dice.Roll();
                    Console.WriteLine(string.Format(Messages.SuddenDeathRoll, player.Name, roll));

                    if (roll > highestRoll)
                    {
                        highestRoll = roll;
                        suddenDeathWinners.Clear();
                        suddenDeathWinners.Add(player);
                    }
                    else if (roll == highestRoll)
                    {
                        suddenDeathWinners.Add(player);
                    }
                }

                if (suddenDeathWinners.Count == 1)
                {
                    return suddenDeathWinners[0];
                }
                else
                {
                    Console.WriteLine(string.Format(Messages.TieContinues, "sudden death"));
                    tiedPlayers = suddenDeathWinners;
                }
            }

            return tiedPlayers[0];
        }

        private Player HighestSingleDieTieBreaker(List<Player> tiedPlayers)
        {
            int highestSingleDie = -1;
            List<Player> winners = new List<Player>();

            foreach (var player in tiedPlayers)
            {
                int maxDie = player.CurrentRoll.Max();
                Console.WriteLine(string.Format(Messages.HighestSingleDie, player.Name, maxDie));

                if (maxDie > highestSingleDie)
                {
                    highestSingleDie = maxDie;
                    winners.Clear();
                    winners.Add(player);
                }
                else if (maxDie == highestSingleDie)
                {
                    winners.Add(player);
                }
            }

            if (winners.Count == 1)
            {
                return winners[0];
            }
            else
            {
                Console.WriteLine(string.Format(Messages.TieContinues, "highest single die comparison"));
                return null; // Tie remains unresolved
            }
        }

        private Player ReRollTieBreaker(List<Player> tiedPlayers)
        {
            int highestScore = -1;
            List<Player> winners = new List<Player>();

            foreach (var player in tiedPlayers)
            {
                List<int> newRoll = player.RollDice(dice, Data.Settings.NumberOfDice);
                int total = newRoll.Sum();
                Console.WriteLine(string.Format(Messages.ReRollResult, player.Name, string.Join(", ", newRoll), total));

                if (total > highestScore)
                {
                    highestScore = total;
                    winners.Clear();
                    winners.Add(player);
                }
                else if (total == highestScore)
                {
                    winners.Add(player);
                }
            }

            if (winners.Count == 1)
            {
                return winners[0];
            }
            else
            {
                Console.WriteLine(string.Format(Messages.TieContinues, "re-rolling"));
                return null; // Tie remains unresolved
            }
        }

        private void DetermineOverallWinner()
        {
            List<Player> overallWinners = new List<Player>();
            int highestTotalScore = -1;

            foreach (var player in Data.GamePlayers)
            {
                if (player.TotalScore > highestTotalScore)
                {
                    highestTotalScore = player.TotalScore;
                    overallWinners.Clear();
                    overallWinners.Add(player);
                }
                else if (player.TotalScore == highestTotalScore)
                {
                    overallWinners.Add(player);
                }
            }

            Console.WriteLine();
            DisplayLeaderboard();

            Player overallWinner = null;

            if (overallWinners.Count == 1)
            {
                overallWinner = overallWinners[0];
                Console.WriteLine(string.Format(Messages.OverallWinner, overallWinner.Name, highestTotalScore));
            }
            else
            {
                string tiedPlayers = string.Join(", ", overallWinners.Select(p => p.Name));
                Console.WriteLine(string.Format(Messages.GameTie, tiedPlayers, highestTotalScore));

                overallWinner = HandleTie(overallWinners, "overall");
                if (overallWinner != null)
                {
                    Console.WriteLine(string.Format(Messages.OverallWinner, overallWinner.Name, highestTotalScore));
                }
                else
                {
                    Console.WriteLine(Messages.TieBreakerRuleAcceptTie);
                }
            }

            Console.WriteLine(Messages.PressAnyKey);
            Console.ReadKey();
        }

        private void DisplayLeaderboard()
        {
            Console.WriteLine(Messages.LeaderboardHeader);
            if (Data.Players.Count == 0)
            {
                Console.WriteLine(Messages.NoPlayersAvailable);
            }
            else
            {
                Data.Players.Sort((p1, p2) => p2.TotalScore.CompareTo(p1.TotalScore));

                foreach (var player in Data.Players)
                {
                    Console.WriteLine($"{player.Name}: {player.TotalScore} points, Rounds Won: {player.RoundsWon}");
                }
            }

            Console.WriteLine();
        }

        private void DisplayGameStatistics()
        {
            Console.Clear();
            Console.WriteLine(Messages.GameStatisticsHeader);

            foreach (var player in Data.Players)
            {
                Console.WriteLine(string.Format(Messages.PlayerStats, player.Name, player.TotalScore, player.RoundsWon));
            }

            Console.WriteLine(Messages.TieBreakerUsageHeader);
            foreach (var tieBreaker in Data.TieBreakerUsage)
            {
                Console.WriteLine($" - {tieBreaker.Key}: {tieBreaker.Value} times");
            }

            Console.WriteLine(Messages.PressAnyKey);
            Console.ReadKey();
        }

        // Input validation methods
        public static int GetPositiveInteger(string prompt)
        {
            int value;
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (int.TryParse(input, out value) && value > 0)
                {
                    return value;
                }
                Console.WriteLine(Messages.InvalidInputPositiveInteger);
            }
        }

        public static string GetYesOrNo()
        {
            while (true)
            {
                string input = Console.ReadLine().Trim().ToLower();
                if (input == Messages.Yes || input == Messages.No)
                {
                    return input;
                }
                Console.Write(Messages.InvalidYesOrNo);
            }
        }

        public static TieBreakerRule GetTieBreakerRule()
        {
            while (true)
            {
                Console.Write(Messages.ChooseTieBreakerRule);
                string input = Console.ReadLine().Trim().ToLower();
                if (input == Messages.TieBreakerAcceptTie)
                {
                    return TieBreakerRule.AcceptTie;
                }
                else if (input == Messages.TieBreakerSuddenDeath)
                {
                    return TieBreakerRule.SuddenDeath;
                }
                else if (input == Messages.TieBreakerHighestSingleDie)
                {
                    return TieBreakerRule.HighestSingleDie;
                }
                else if (input == Messages.TieBreakerReRoll)
                {
                    return TieBreakerRule.ReRoll;
                }
                else
                {
                    Console.WriteLine(Messages.InvalidTieBreakerOption);
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.DisplayMenu();
        }
    }
}
