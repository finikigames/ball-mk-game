using System;
using Services.Base;
using UnityEngine;

public class ApplicationService : SceneSingleton<ApplicationService> {
    public int ApplicationFrameRate;
    
    private void Start() {
        Application.targetFrameRate = ApplicationFrameRate;
    }
}