using System;
using Scriptable;
using Services.Base;
using UnityEngine;

public class ApplicationService : SceneSingleton<ApplicationService> {
    public int ApplicationFrameRate;

    public InputSettings InputSettings;
    
    private void Start() {
        Application.targetFrameRate = ApplicationFrameRate;
    }
}