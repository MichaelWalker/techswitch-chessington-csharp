using System;

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

            var winningPlayer = whiteScore > blackScore ? Player.White : Player.Black;
            var marginOfLead = Math.Abs(whiteScore - blackScore);

            if (marginOfLead >= 6)
            {
                return $"{winningPlayer} is winning";
            }
            if (marginOfLead >= 3)
            {
                return $"{winningPlayer} has taken a slight lead";
            }
            return "Its very close";
        }
    }
}