using System;
using System.Collections;
using System.Collections.Generic;
using Services;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class InfoRetriever : MonoBehaviour {
    public Button Button;
    public TextMeshProUGUI Text;
    
    private void Start() {
        Button.onClick.AddListener(() => StartCoroutine(LeaderboardService.Instance.PushScore("Витя", 123)));
    }
}
