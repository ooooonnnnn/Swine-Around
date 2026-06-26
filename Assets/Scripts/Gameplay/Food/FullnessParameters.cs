namespace Gameplay.Food
{
    public struct FullnessParameters: IFillProvider
    {
        public int currentFullness;
        public int maxFullness;
        public int fullnessGained;
        public int ScoreValue => ScoreManager.Instance.GetScoreFromFood(this);
        
        public static explicit operator float(FullnessParameters p) => p.currentFullness / (float) p.maxFullness;
        public float Fill => (float)this;
    }
}
