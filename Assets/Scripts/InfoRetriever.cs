using Services;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InfoRetriever : MonoBehaviour {
    public Button Button;
    public TextMeshProUGUI Text;
    
    private void Start() {
        Button.onClick.AddListener(async () => 
            await LeaderboardService.Instance.UpdateScore(new OneScoreInfo{_Id = "6378b64a33c40e0016ae5878", Name = "Витя", Score = 125}));
        //Button.onClick.AddListener(() => StartCoroutine(LeaderboardService.Instance.GetAllScores()));
    }
}
