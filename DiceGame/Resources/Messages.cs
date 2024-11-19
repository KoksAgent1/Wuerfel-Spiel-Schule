namespace DiceGame.Resources
{
    public static class Messages
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
        public const string InvalidInputPositiveInteger = "Invalid input. Please enter a positive integer.";
        public const string InvalidInputMinimumValue = "Invalid input. Please enter an integer greater than or equal to {0}.";
        public const string InvalidTieBreakerOption = "Invalid input. Please enter a valid tie-breaker option.";
        public const string InvalidYesOrNo = "Please enter 'y' or 'n': ";
        public const string InvalidSessionName = "Invalid session name.";
        public const string ExceptionOccurred = "An unexpected error occurred: {0}";
        public const string AddMorePlayersPrompt = "Please add more players in the 'Manage Players' menu.";

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
        public const string EnterNumberOfSides = "Enter the number of sides on the dice (minimum 2): ";
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
        public const string AvailableSessions = "Available Sessions:";
        public const string EnterSessionNumberToLoad = "Enter the number of the session to load: ";

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
        public const string Round = "round";

        // Leaderboard entry format
        public const string LeaderboardEntry = "{0}: {1} points, Rounds Won: {2}";

        // Tie-breaker rule strings
        public const string TieBreakerAcceptTie = "accept-tie";
        public const string TieBreakerSuddenDeath = "sudden-death";
        public const string TieBreakerHighestSingleDie = "highest-single-die";
        public const string TieBreakerReRoll = "re-roll";

        // Yes and No strings
        public const string Yes = "y";
        public const string No = "n";
    }
}
