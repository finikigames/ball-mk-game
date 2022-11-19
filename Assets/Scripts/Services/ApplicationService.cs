using DefaultNamespace.Settings;
using Scriptable;
using Services.Base;
using UnityEngine;

public class ApplicationService : SceneSingleton<ApplicationService> {
    public int ApplicationFrameRate;

    public InputSettings InputSettings;

    public MechanicsSettings MechanicsSettings;

    protected override void Initialize() {
        Application.targetFrameRate = ApplicationFrameRate;
        MechanicsSettings = new MechanicsSettings();
        MechanicsSettings.Initialize();
    }
}