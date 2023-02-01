using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;
using Data;
using BattleArena.Infrastructure.Services.PersistentData;

namespace BattleArena.Infrastructure.Services.SaveLoad
{
    public class SaveLoadService : ISaveLoadService
    {
        private Dictionary<IProgress, List<ISavedProgress>> _progressWritersDictionary;
        private Dictionary<IProgress, List<ISavedProgressReader>> _progressReadersDictionary;

        private const string PROGRESS_KEY = "Progress";

        private readonly IPersistentProgressService _persistentProgressService;

        [Inject]
        public SaveLoadService(IPersistentProgressService persistentProgressService)
        {
            _persistentProgressService = persistentProgressService;

            _progressWritersDictionary = GetNewSavedProgressDictionary<ISavedProgress>();
            _progressReadersDictionary = GetNewSavedProgressDictionary<ISavedProgressReader>();
        }

        void ISaveLoadService.LoadProgress()
        {
            foreach (KeyValuePair<IProgress, List<ISavedProgressReader>> progressReadersList in _progressReadersDictionary)
            {
                PlayerPrefs.GetString(string.Concat(PROGRESS_KEY, progressReadersList.Key))?.ToDeserialized(progressReadersList.Key);
                GetPersistentDataType(progressReadersList.Key);
            }
        }

        void ISaveLoadService.SaveProgress()
        {
            foreach (KeyValuePair<IProgress, List<ISavedProgress>> progressWritersList in _progressWritersDictionary)
            {
                SaveProgressByType(progressWritersList.Key);
            }
        }

        public void SaveProgressByType<T>(T type = null) where T : class, IProgress
        {
            Debug.LogError("SaveProgressByType: " + typeof(T));

            KeyValuePair<IProgress, List<ISavedProgress>> progressWritersList = _progressWritersDictionary.
                First(pair => pair.Key.GetType().Equals(typeof(T)));

            UpdateProgress(progressWritersList);

            PlayerPrefs.SetString(string.Concat(PROGRESS_KEY, progressWritersList.Key), JsonUtility.ToJson(progressWritersList.Value));
        }

        private T GetPersistentDataType<T>(T typePersistentData = null) where T : class, IProgress => 
            _progressWritersDictionary.First(dictionary => dictionary.Key is T) as T;

        private Dictionary<IProgress, List<T>> GetNewSavedProgressDictionary<T>() where T : class, ISavedProgressReader
        {
            return new Dictionary<IProgress, List<T>>
            {
                [_persistentProgressService.HeroState = new HeroState()] = new List<T>(),
                [_persistentProgressService.PositionOnLevel = new PositionOnLevel()] = new List<T>()
            };
        }

        private void UpdateProgress(KeyValuePair<IProgress, List<ISavedProgress>> progressWritersList)
        {
            foreach (ISavedProgress progressWriter in progressWritersList.Value)
            {
                progressWriter?.UpdateProgress(_persistentProgressService);
            }
        }
    }
}

