using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

namespace FunnyShooter.Core {
    public class SceneManager : Singleton<SceneManager> {
        public void LoadScene(int buildIndex) {
            UnitySceneManager.LoadScene(buildIndex);
        }

        public void LoadScene(string sceneName) {
            UnitySceneManager.LoadScene(sceneName);
        }
    }
}