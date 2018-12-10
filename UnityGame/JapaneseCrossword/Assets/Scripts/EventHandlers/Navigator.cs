using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Scenes { Startup, Menu, Main, Options, Credits}

[RequireComponent(typeof(DesktopInput))]
public class Navigator : MonoBehaviour
{
    private Scenes _currentScene = Scenes.Startup;
    private Scenes _previousScene = Scenes.Startup;
    private GenericInputCheker _inputChecker;
    private Dictionary<string, Scenes> _scenesMap;

    public void OpenNextScene(string scene)
    {
        var actualScene = _scenesMap[scene];
        OpennextScene(actualScene);
    }

    public void OpennextScene(Scenes scene)
    {
        _previousScene = _currentScene;
        _currentScene = scene;
        SceneManager.LoadScene((int)scene);
        Debug.Log($"Previous: {_previousScene}, Current: {_currentScene}");
    }

	void Start ()
	{
	    _inputChecker = GetComponent<DesktopInput>();
	    _currentScene = (Scenes)SceneManager.GetActiveScene().buildIndex;
	    MapScenes();
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
	    if (_currentScene == _previousScene) return;
	    OpennextScene(_previousScene);
	}
}
