using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class InfoRetriever : MonoBehaviour {
    public Button Button;
    public TextMeshProUGUI Text;
    
    private void Start() {
        Button.onClick.AddListener(() => StartCoroutine(GetScore()));
    }
    
    private IEnumerator GetScore()
    {
        using (UnityWebRequest www = UnityWebRequest.Get("https://ball-game-example.herokuapp.com/leaderboard"))
        {
            yield return www.SendWebRequest();

            Text.text = www.downloadHandler.text;
            
            if (www.isNetworkError || www.isHttpError)
                Debug.Log(www.error);
            else
                Debug.Log("HighScore sent to Data Base");
	
        }
    }
}
