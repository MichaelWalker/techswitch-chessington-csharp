namespace Chessington.GameEngine
{
    public class WinPredictor
    {
        private readonly IScoreCalculator _scoreCalculator;

        public WinPredictor(IScoreCalculator scoreCalculator)
        {
            _scoreCalculator = scoreCalculator;
        }

        public string GetWinPrediction()
        {
            return "Its very close";
        }
    }
}