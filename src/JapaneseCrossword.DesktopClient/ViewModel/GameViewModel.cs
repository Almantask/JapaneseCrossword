using JapaneseCrossword.Core;
using JapaneseCrossword.Core.Rules;
using JapaneseCrossword.Core.State;
using JapaneseCrossword.DesktopClient.DisplayableGrid;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;

namespace JapaneseCrossword.DesktopClient.ViewModel
{
    internal class GameViewModel
    {
        public GameModel GameModel { set; get; }

        private readonly MonochromeGridView _pixelGridView;
        private List<IHintsGridBuider> _numberGridBuilders;

        public GameViewModel(Grid mainGrid, Grid leftGrid, Grid rightGrid, Grid topGrid, Grid botGrid)
        {
            GameModel = new GameModel();
            _pixelGridView = new MonochromeGridView(mainGrid);
            BuilHintGrids(leftGrid, rightGrid, topGrid, botGrid);

            BuildGameFromImageCommand = new BuildGameFromImageCommand(GameModel, this);
            BuildGameRandomCommand = new BuildGameRandomCommand(GameModel, this);
            CrosswordRevealCommand = new CrosswordRevealedCommand(GameModel);
            InteractWithCellCommand = new InteractWithCellCommand(GameModel, mainGrid);
            LoadGameCommand = new LoadGameCommand(GameModel);
            SaveGameCommand = new SaveGameCommand(GameModel);
            SaveScetchCommand = new SaveGameCommand(GameModel);
        }

        private void BuilHintGrids(Grid left, Grid right, Grid top, Grid bot)
        {
            _numberGridBuilders = new List<IHintsGridBuider>();
            Grid[] hintGridsSides = { left, right };
            Grid[] hintGridsGroundRoof = { top, bot };

            foreach (var hintGrid in hintGridsSides)
            {
                var numberGridBuilder = new NumberGridView(hintGrid, true);
                _numberGridBuilders.Add(numberGridBuilder);
            }
            foreach (var hintGrid in hintGridsGroundRoof)
            {
                var numberGridBuilder = new NumberGridView(hintGrid, false);
                _numberGridBuilders.Add(numberGridBuilder);
            }
        }

        public void BuildGame(MonochromeCell[,] gridData)
        {
            GameModel.Crossword = new Crossword(gridData, new StrictRules(), new LocalStateLoader(),
                _pixelGridView, _numberGridBuilders);
            GameModel.Crossword.Initialise(gridData);
        }

        public ICommand BuildGameFromImageCommand { get; }
        public ICommand BuildGameRandomCommand { get; }
        public ICommand CrosswordRevealCommand { get; }
        public ICommand InteractWithCellCommand { get; }
        public ICommand LoadGameCommand { get; }
        public ICommand SaveGameCommand { get; }
        public ICommand SaveScetchCommand { get; }
    }
}
