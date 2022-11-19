using Services;
using UnityEngine;

public class LeaderboardController : MonoBehaviour {
    public LeaderboardElement ElementPrefab;
    
    private async void OnEnable() {
        var leaderboardInfo = await LeaderboardService.Instance.GetAllScores();

        foreach (var info in leaderboardInfo) {
            var infoView = Instantiate(ElementPrefab, transform);
            infoView.Initialize(info.Name, info.Score);
        }
    }
}
