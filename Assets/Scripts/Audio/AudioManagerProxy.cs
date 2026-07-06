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
    }
}