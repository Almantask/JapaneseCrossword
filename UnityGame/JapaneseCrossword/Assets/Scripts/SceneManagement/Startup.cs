using System.Collections.Generic;
using JapaneseCrossword;
using JapaneseCrossword.Hints;
using JapaneseCrossword.Rules;
using JapaneseCrossword.State;
using UnityEngine;

public class Startup : MonoBehaviour
{
	void Start ()
	{
	    DontDestroyOnLoad(gameObject);
        // TODO: register dependencies
	    //var game = new Crossword();
	}
}
