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
        public MainGridBuilder MainGridBuilder;
        public Text GridSizeInput;

        private Crossword _game;
        private GridDataGenerator _dataGenerator;

        private void Awake()
        {
            InitialiseCrossword();
        }

        private void InitialiseCrossword()
        {
            _dataGenerator = new GridDataGenerator();
            var gridSize = ParseGridSize();
            int cols = 10;
            int rows = 10;
            var cells = _dataGenerator.Generate(cols, rows);

            var verticalHintsBuilder = new VerticalHintsBuilder();
            var horizontalhintsBuilder = new HorizontalHintsBuilder();
            var hintsBuilders = new List<IHintsGridBuider>
            {
                verticalHintsBuilder,
                horizontalhintsBuilder
            };

            _game = new Crossword(cells, new StrictRules(), new LocalStateLoader(),
                MainGridBuilder, hintsBuilders);
        }

        /// <summary>
        /// Parses grid size from input field. Possible formats: x,y or x
        /// </summary>
        /// <returns>array of 2 elements: 0- cols, 1- rows</returns>
        private int[] ParseGridSize()
        {
            var gridSize = new int[2];
            var input = GridSizeInput.text;
            var inputParts = input.Split(new[] {','});

            if (inputParts.Length == 1)
            {
                int sizeX;
                var isNumber = int.TryParse(inputParts[0], out sizeX);
                if (!isNumber)
                {
                    MessageBoxUtil.Show($"{input} is not a number!", MessageType.Error);
                }
            }
            return gridSize;
        }
    }
}
