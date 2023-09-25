using System;

namespace Assets.Scripts.Saving_System
{
    [Serializable]
    internal class SavedData
    {
        public DictionaryContainer LevelBoxCount;

        public int CurrentLevel;

        public int BoxBank;

        public int Money;

        public int ActiveBoxCount;
    }
}
