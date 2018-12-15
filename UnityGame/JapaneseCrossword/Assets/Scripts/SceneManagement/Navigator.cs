using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(DesktopInput))]
public class Navigator : MonoBehaviour
{
    private Scenes _currentScene = Scenes.Startup;
    private Scenes _previousScene = Scenes.Startup;
    private GenericInputCheker _inputChecker;
    private Dictionary<string, Scenes> _scenesMap;

    public void OpenScene(string scene)
    {
        var actualScene = _scenesMap[scene];
        OpenScene(actualScene);
    }

    public void OpenScene(Scenes scene)
    {
        _previousScene = _currentScene;
        _currentScene = scene;
        SceneManager.LoadScene((int)scene);
        Debug.Log($"Previous: {_previousScene}, Current: {_currentScene}");
    }

	void Start ()
	{
	    MapScenes();
	    _inputChecker = GetComponent<DesktopInput>();
        OpenScene(Scenes.Menu);

	}

    private void MapScenes()
    {
        _scenesMap = new Dictionary<string, Scenes>();
        var scenes = Enum.GetValues(typeof(Scenes));
        foreach (Scenes scene in scenes)
        {
            _scenesMap.Add(scene.ToString(), scene);
        }
    }
	
	void Update ()
	{
	    if (!_inputChecker.IsBackKeyPressed) return;
	    if (_currentScene == Scenes.Menu) return;
	    OpenScene(_previousScene);
	}
}
