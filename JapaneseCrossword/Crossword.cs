using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using General;
using JapaneseCrossword.Rules;
using JapaneseCrossword.State;

namespace JapaneseCrossword
{
    public class Crossword
    {
        private GameProgress _progress;
        public IMonochrome[,] Goal => _progress.Goal;
        private readonly IRules _rules;
        private readonly IStateLoader _stateLoader;
        private readonly IMainGridBuilder _mainGridBuilder;
        private readonly List<IHintsGridBuider> _hintsGridBuilders;
        private readonly IHintsCalculator _verticalHintsCalculator;
        private readonly IHintsCalculator _horizontalHintsCalculator;

        public Crossword(MonochromeCell[,] gridData, IRules rules, IStateLoader loader, 
            IMainGridBuilder mainGridBuilder, List<IHintsGridBuider> hintsBuilders,
            IHintsCalculator verticalHintsCalculator, IHintsCalculator horizontalHintsCalculator)
        {
            _rules = rules;
            _stateLoader = loader;
            _mainGridBuilder = mainGridBuilder;
            _verticalHintsCalculator = verticalHintsCalculator;
            _horizontalHintsCalculator = horizontalHintsCalculator;
            _hintsGridBuilders = hintsBuilders;
            BuildGame(gridData);
        }

        private void BuildGame(IMonochrome[,] gridData)
        {
            _progress = new GameProgress(gridData);
            _mainGridBuilder.Build(gridData);
            var horizontalHintsGridData = _verticalHintsCalculator.Calculate().InvertOrientation();
            var verticalHintsGridData = _horizontalHintsCalculator.Calculate().InvertOrientation();
            foreach (var hintsGridBuilder in _hintsGridBuilders)
            {
                var hintsData = hintsGridBuilder.IsVertical ? verticalHintsGridData : horizontalHintsGridData;
                hintsGridBuilder.Build(hintsData);
            }
        }

        public bool IsGameOver()
        {
            return _rules.IsComplate(_progress);
        }

        public void Load(string path)
        {
            _progress = _stateLoader.Load(path);
            BuildGame(_progress.Current);
        }

        public void Save(string path)
        {
            _stateLoader.Save(_progress, path);
        }

        public void SaveCustom(string path)
        {
            var progressCustom = new GameProgress(_progress.Current);
            _stateLoader.Save(progressCustom, path);
        }
    }
}
