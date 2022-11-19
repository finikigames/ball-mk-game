using TMPro;
using UnityEngine;

public class LeaderboardElement : MonoBehaviour {
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Score;

    public void Initialize(string name, int score) {
        Name.text = name;
        Score.text = score.ToString();
    }
}
