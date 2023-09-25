using System.IO;
using UnityEngine;

namespace Assets.Scripts.Saving_System
{
    internal class SaveDataRepository
    {
        private readonly IData<SavedData> _data;

        private const string FOLDER_NAME = "dataSave";
        private const string FILE_NAME = "data.dat";
        private readonly string _path;

        public SaveDataRepository()
        {
            _data = new JsonData<SavedData>();
            _path = Path.Combine(Application.persistentDataPath, FOLDER_NAME);

            switch (Application.platform)
            {
                case RuntimePlatform.Android:
                    _data = new JsonData<SavedData>();
                    break;
                case RuntimePlatform.IPhonePlayer:
                    _data = new JsonData<SavedData>();
                    break;
                default:
                    _data = new BinarySerialization<SavedData>();
                    break;
            }

        }

        public void Save(UserProfile userProfile)
        {
            if (!Directory.Exists(Path.Combine(_path)))
            {
                Directory.CreateDirectory(_path);
            }

            var dictionaryContainer = new DictionaryContainer(userProfile.LevelBoxCount);

            var saveGameData = new SavedData()
            {
                CurrentLevel = userProfile.CurrentLevel,
                Money = userProfile.Money,
                BoxBank = userProfile.BoxBank,
                LevelBoxCount = dictionaryContainer,
                ActiveBoxCount = userProfile.ActiveBoxCount
            };

            _data.Save(saveGameData, Path.Combine(_path, FILE_NAME));
        }

        public void Load(UserProfile profilePlayer)
        {
            var file = Path.Combine(_path, FILE_NAME);
            if (!File.Exists(file))
            {
                Debug.Log("There is no saved data");
                return;
            }

            var newGame = _data.Load(file);
            profilePlayer.CurrentLevel = newGame.CurrentLevel;
            profilePlayer.BoxBank = newGame.BoxBank;
            profilePlayer.Money = newGame.Money;
            profilePlayer.LevelBoxCount = newGame.LevelBoxCount.ToDictionary();
            profilePlayer.ActiveBoxCount = newGame.ActiveBoxCount;
        }
    }
}
