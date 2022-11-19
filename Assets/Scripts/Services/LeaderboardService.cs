using System.Collections;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using Services.Base;
using UnityEngine;
using UnityEngine.Networking;

namespace Services {
    public class OneScoreInfo {
        public string _Id;
        public string Name;
        public int Score;
    }

    public class RequestScoreInfo {
        public string name;
        public int score;
    }
    
    public class LeaderboardService : BaseSingleton<LeaderboardService> {
        private const string _baseLink = "https://ball-game-example.herokuapp.com";
        private const string _leaderboardLink = _baseLink + "/leaderboard";
        
        public OneScoreInfo[] Leaderboard;
        
        public async UniTask<OneScoreInfo[]> GetAllScores() {
            using UnityWebRequest www = UnityWebRequest.Get(_leaderboardLink);
            await www.SendWebRequest();

            var model = www.downloadHandler.text;
            Leaderboard = JsonConvert.DeserializeObject<OneScoreInfo[]>(model);

            if (www.result == UnityWebRequest.Result.ConnectionError) {
                Debug.Log(www.error);
            }

            return Leaderboard;
        }

        public async UniTask PushNewScore(string name, int score) {  
            WWWForm form = new WWWForm();
            form.AddField("name", name);
            form.AddField("score", score);
            
            using UnityWebRequest www = UnityWebRequest.Post(_leaderboardLink, form);
            await www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError) {
                Debug.Log(www.error);
            }
        }
        
        public async UniTask UpdateScore(OneScoreInfo info) {
            var requestScore = new RequestScoreInfo {name = info.Name, score = info.Score};
            var serialized = JsonConvert.SerializeObject(requestScore);
            var bytes = System.Text.Encoding.UTF8.GetBytes(serialized);
            
            using UnityWebRequest www = UnityWebRequest.Put(_leaderboardLink + $"/{info._Id}", bytes);
            www.SetRequestHeader("Content-Type", "application/json");
            await www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError) {
                Debug.Log(www.error);
            }
        }
    }
}