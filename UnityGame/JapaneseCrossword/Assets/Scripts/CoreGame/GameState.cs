using System.Collections.Generic;
using Assets.Scripts.SceneManagement;
using Assets.Scripts.Utility;
using JapaneseCrossword.Core;
using JapaneseCrossword.Core.Rules;
using JapaneseCrossword.Core.State;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.CoreGame
{
    public class GameState : MonoBehaviour
    {
        [SerializeField]
        private MainGridBuilder _mainGridBuilder;
        [SerializeField]
        private Text _gridSizeInput;
        [SerializeField]
        private HintsViewBuilder _hintsViewBuidlerTop;
        [SerializeField]
        private HintsViewBuilder _hintsViewBuidlerBot;
        [SerializeField]
        private HintsViewBuilder _hintsBuidlerLeft;
        [SerializeField]
        private HintsViewBuilder _hintsBuidlerRight;

        private Crossword _game;
        private GridDataGenerator _dataGenerator;

        private void Awake()
        {


            // Call this on button press
            InitialiseCrossword();
        }

        private void InitialiseCrossword()
        {
            _dataGenerator = new GridDataGenerator();
            var gridSize = ParseGridSize();
            int cols = gridSize[0];
            int rows = gridSize[1];
            var cells = _dataGenerator.Generate(cols, rows);

            var hintsBuilders = new List<IHintsGridBuider>
            {
                _hintsViewBuidlerTop,
                _hintsViewBuidlerBot,
                _hintsBuidlerLeft,
                _hintsBuidlerRight
            };



            _game = new Crossword(cells, new StrictRules(), new LocalStateLoader(),
                _mainGridBuilder, hintsBuilders);
        }

        /// <summary>
        /// Parses grid size from input field. Possible formats: x,y or x
        /// </summary>
        /// <returns>array of 2 elements: 0- cols, 1- rows</returns>
        private int[] ParseGridSize()
        {
            int[] gridSize = null;
            //var input = _gridSizeInput.text;
            var input = "10,10";
            var inputParts = input.Split(',');

            if (inputParts.Length == 1)
            {
                int sizeX;
                var isNumber = int.TryParse(inputParts[0], out sizeX);
                if (!isNumber)
                {
                    MessageBoxUtil.Show($"{input} is not a number!", MessageType.Error);
                }
                else
                {
                    gridSize = new int[] { sizeX, sizeX};
                }
            }
            else if (inputParts.Length == 2)
            {
                int sizeX;
                int sizeY;
                var isNumber1 = int.TryParse(inputParts[0], out sizeX);
                var isNumber2 = int.TryParse(inputParts[0], out sizeY);
                if (!isNumber1 || !isNumber2)
                {
                    MessageBoxUtil.Show($"{input} is not a number!", MessageType.Error);
                }
                gridSize = new[] { sizeX, sizeY };
            }

            return gridSize;
        }
    }
}
