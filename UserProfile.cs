using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Playables;

namespace Assets.Scripts.Saving_System
{
    [System.Serializable]
    internal class UserProfile : IController
    {
        private SaveDataRepository _saveData;

        private int _boxBank;
        private int _money;
        private int _currentLevel;
        private int _activeBoxCount;

        private Dictionary<int, int> _levelBoxCount;
        public int BoxBank { get => _boxBank; set => _boxBank = value; }
        public int Money { get => _money; set => _money = value; }
        public int CurrentLevel { get => _currentLevel; set => _currentLevel = value; }
        public int ActiveBoxCount { get => _activeBoxCount; set => _activeBoxCount = value; }

        public Dictionary<int, string> LevelBoxCount;


        public UserProfile(SaveDataRepository saveDataRepository)
        {
            _saveData = saveDataRepository;

            LevelBoxCount = new();
            _saveData.Load(this);

        }
    }
}
