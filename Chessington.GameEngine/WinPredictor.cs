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
            var whiteScore = _scoreCalculator.GetWhiteScore();
            var blackScore = _scoreCalculator.GetBlackScore();

            if (blackScore - whiteScore >= 3)
            {
                return "Black has taken a slight lead";
            }
            return "Its very close";
        }
    }
}