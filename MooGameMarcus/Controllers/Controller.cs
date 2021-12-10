namespace MooGameMarcus
{
    public class Controller
    {
        private IUserInterface _ui;
        private readonly IFileRepository _repository;
        private IGameLogic _gameLogic;

        public Controller(IUserInterface ui, IFileRepository repository, IGameLogic gameLogic)
        {
            _ui = ui;
            _repository = repository;
            _gameLogic = gameLogic;
        }

        public void Run()
        {
            bool playOn = true;
            _ui.Output("Enter your user name:\n");
            string playerName = "";
            do
            {
                playerName = _ui.Input(true);

            } while (string.IsNullOrEmpty(playerName));


            string guess = "";
            do
            {
                string gameChoice = "";
                int difficulty = 0;

                _ui.Output("Choose game:\n\t[N]umber 00-99\n\t[M]oo Game");
                do
                {
                    gameChoice = _ui.Input(false);

                    if (gameChoice.ToLower() == "m")
                    {
                        _ui.Output("Choose difficulty: [N]ormal or [H]ard");
                        string normalOrHard = _ui.Input(false);
                        difficulty = normalOrHard.ToLower() == "h" || normalOrHard.ToLower() == "hard" ? difficulty = 6 : difficulty = 4;
                    }
                    else if (gameChoice.ToLower() == "n")
                    {
                        difficulty = 2;
                    }
                    else
                    {
                        _ui.Clear();
                        _ui.Output("Invalid input! Type 'N' for Number Game or 'M' for Moo Game to choose game.");
                    }
                } while (difficulty == 0);


                _ui.Clear();
                string goal = _gameLogic.CreateGoalNumber(difficulty);
                string game = difficulty == 2 ? "Numbers 00-99" : "Moo Game";

                _ui.Output($"{game}:\nPress 'q' at any time to exit game\n");
                //comment out or remove next line to play real games!
                //_ui.Output("For practice, number is: " + goal + "\n");
                guess = _ui.Input(false);

                int numberOfGuesses = 1;
                string stringResult = _gameLogic.CheckGuess(goal, guess, difficulty);
                _ui.Output(stringResult + "\n");
                while (guess != goal)
                {
                    numberOfGuesses++;
                    if (guess == "q")
                    {
                        _ui.Exit();
                    }
                    guess = _ui.Input(false);
                    stringResult = _gameLogic.CheckGuess(goal, guess, difficulty);
                    _ui.Output(stringResult + "\n");
                }
                _repository.WriteToFile(playerName, numberOfGuesses, game);

                _ui.Output(_repository.ShowTopList(game));
                _ui.Output("Correct, it took " + numberOfGuesses + " guesses\nPlay again? [Y]/[N]");
                string playAgainAnswer = _ui.Input(false);
                if (playAgainAnswer != null && playAgainAnswer != "" && playAgainAnswer.Substring(0, 1).ToLower() == "n")
                {
                    playOn = false;
                }
                _ui.Clear();
            } while (playOn);
        }
    }
}
