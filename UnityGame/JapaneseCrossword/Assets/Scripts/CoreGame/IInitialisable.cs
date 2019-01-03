﻿namespace Assets.Scripts.CoreGame
{
    /// <summary>
    /// Intended to use for object, which should have a configuration on creation/ before creatrion
    /// </summary>
    internal interface IInitialisable
    {
        object Initialise();
        void SetProperties(object param, bool isLoad = false);
    }
}