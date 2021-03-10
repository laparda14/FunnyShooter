using UnityEngine;
using FunnyShooter.Runtime;

namespace FunnyShooter.Core {
    public class SoundManager : MonoSingleton<SoundManager> {
        [SerializeField]
        private AudioSource musicPlayer;
        [SerializeField]
        private AudioSource sourcePlayer;

        public void PlayeMusic(string musicName) {
            AudioClip clip = ResourcesManager.Instance.Load<AudioClip>(musicName, ResourcesType.Audio);
            if (!clip) {
                Utility.Log.Error("this audio clip '{0}' is not exist", musicName);
            }
            musicPlayer.clip = clip;
            if (!musicPlayer.isPlaying) {
                musicPlayer.Play();
            }
        }

        public void PlayerSource(string sourceName) {
            AudioClip clip = ResourcesManager.Instance.Load<AudioClip>(sourceName, ResourcesType.Audio);
            if (!clip) {
                Utility.Log.Error("this audio clip '{0}' is not exist", sourceName);
            }
            sourcePlayer.PlayOneShot(clip);
        }

        public void PlayerSource(string sourceName, Vector3 position) {
            AudioClip clip = ResourcesManager.Instance.Load<AudioClip>(sourceName, ResourcesType.Audio);
            if (!clip) {
                Utility.Log.Error("this audio clip '{0}' is not exist", sourceName);
            }
            AudioSource sourcePlayer = GameObjectPoolManager.Instance.SpawnObj<AudioSource>("SourcePlayer");
            sourcePlayer.transform.position = position;
            sourcePlayer.PlayOneShot(clip);
        }
    }
}