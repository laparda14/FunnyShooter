namespace FunnyShooter.Core {
    public class GameManager : MonoSingleton<GameManager> {
        private void Update() {
            EventManager.Instance.Update();
        }
    }
}