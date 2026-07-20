using Gameplay.Food;

namespace Audio
{
    public interface IAudioManager
    {
        public void ChangeFullnessVariable(FullnessParameters fullnessParameters);
        
        public void SetMasterVolume(float volume);

        public float GetMasterVolume();

        public void SetMusicVolume(float volume);
        
        public float GetMusicVolume();
    }
}