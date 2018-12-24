using System.Collections.Generic;
using JapaneseCrossword.Core;
using JapaneseCrossword.Core.Rules;
using JapaneseCrossword.Core.State;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public MainGridBuilder MainGridBuilder;

    private Crossword _game;
    private GridDataGenerator _dataGenerator;

    private void Awake()
    {
        InitialiseCrossword();
    }

    private void InitialiseCrossword()
    {
        _dataGenerator = new GridDataGenerator();
        const int cols = 10;
        const int rows = 10;
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

}
