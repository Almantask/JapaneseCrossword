using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Startup : MonoBehaviour
{
	void Start ()
	{
	    DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene("Menu");
    }
}
