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
        var game = new Crossword(cells, new StrictRules(), new LocalStateLoader(),
            new MainGridBuilder(), new List<IHintsGridBuider>(),
            new VerticalHintsCalculator(cells, new ConsequitiveElementsFinder()),
            new HorizontalHintsCalculator(cells, new ConsequitiveElementsFinder()));
    }
}