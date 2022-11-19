using System.Collections;
using Newtonsoft.Json;
using Services.Base;
using UnityEngine;
using UnityEngine.Networking;

namespace Services {
    public class OneScoreInfo {
        public string Name;
        public int Score;
    }
    
    public class LeaderboardService : BaseSingleton<LeaderboardService> {
        private const string _baseLink = "https://ball-game-example.herokuapp.com";
        private const string _leaderboardLink = _baseLink + "/leaderboard";
        
        private OneScoreInfo[] _leaderboard;
        
        public IEnumerator GetAllScores() {
            using UnityWebRequest www = UnityWebRequest.Get(_leaderboardLink);
            yield return www.SendWebRequest();

            var model = www.downloadHandler.text;
            _leaderboard = JsonConvert.DeserializeObject<OneScoreInfo[]>(model);

            if (www.result == UnityWebRequest.Result.ConnectionError) {
                Debug.Log(www.error);
            }
        }

        public IEnumerator PushScore(string name, int score) {  
            WWWForm form = new WWWForm();
            form.AddField("name", name);
            form.AddField("score", score);
            
            using UnityWebRequest www = UnityWebRequest.Post(_leaderboardLink, form);
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError) {
                Debug.Log(www.error);
            }
        }
    }
}