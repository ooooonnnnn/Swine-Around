using Gameplay.Food;

namespace Audio
{
    public class AudioManagerProxy : Singleton<AudioManagerProxy>, IAudioManager
    {
        public void ChangeFullnessVariable(FullnessParameters fullnessParameters)
        {
            if (!AudioManager.Instance) return;
            AudioManager.Instance.ChangeFullnessVariable(fullnessParameters);
        }

        public void SetMasterVolume(float volume)
        {
            if (!AudioManager.Instance) return;
            AudioManager.Instance.SetMasterVolume(volume);
        }

        public float GetMasterVolume()
        {
            if (!AudioManager.Instance) return 0;
            return AudioManager.Instance.GetMasterVolume();
        }

        public void SetMusicVolume(float volume)
        {
            if (!AudioManager.Instance) return;
            AudioManager.Instance.SetMusicVolume(volume);
        }

        public float GetMusicVolume()
        {
            if (!AudioManager.Instance) return 0;
            return AudioManager.Instance.GetMusicVolume();
        }
    }
}