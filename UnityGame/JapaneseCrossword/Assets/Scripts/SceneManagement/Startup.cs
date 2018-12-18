using JapaneseCrossword;
using JapaneseCrossword.Hints;
using JapaneseCrossword.Rules;
using JapaneseCrossword.State;
using System.Collections.Generic;
using UnityEngine;

public class Startup : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        var dataGenerator = new GridDataGenerator();
        var cells = dataGenerator.Generate(10, 10);
        var verticalHintsBuilder = new VerticalHintsBuilder();
        var horizontalhintsBuilder = new HorizontalHintsBuilder();
        var hintsBuilders = new List<IHintsGridBuider>
        {
            verticalHintsBuilder,
            horizontalhintsBuilder
        };
        var game = new Crossword(cells, new StrictRules(), new LocalStateLoader(),
            new MainGridBuilder(), ,
            new VerticalHintsCalculator(cells, new ConsequitiveElementsFinder()),
            new HorizontalHintsCalculator(cells, new ConsequitiveElementsFinder()));
    }
}