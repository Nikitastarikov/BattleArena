﻿using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using BattleArena.Infrastructure.Services.SaveLoad;
using BattleArena.Infrastructure.Services.GameFactory;
using BattleArena.Infrastructure.Services.PersistentData;

namespace BattleArena.Enemy
{
    //[RequireComponent(typeof(UniqueId))]
    public class LootPiece : MonoBehaviour, ISavedProgress
    {
        //private const float TIME_DELAY = 1.5f;

        //[SerializeField]
        //private GameObject _skull;
        //[SerializeField]
        //private GameObject _pickupFxPrefab;
        //[SerializeField]
        //private GameObject _pickupPopup;

        //[SerializeField]
        //private TextMeshPro _lootText;

        //private Loot _loot;

        //private string _id = string.Empty;
        //private bool _isGet = false;
        //private WorldData _worldData;
        //private IGameFactory _factory;

        //public void Constructor(WorldData worldData, IGameFactory factory)
        //{
        //    _worldData = worldData;
        //    _factory = factory;
        //}

        //public void Initialize(Loot loot) => 
        //    _loot = loot;

        //public void UpdateProgress(PlayerProgress progress) => 
        //    progress.KnokedOutLoot.NotCollectedLoot.Add(new LootOnLevel(_id, CreatePositionOnLevel(CurrentLevel(), transform.position.AsVectorData()), _loot));

        //public void LoadProgress(PlayerProgress progress)
        //{
        //    LootOnLevel lootOnLevel = progress.KnokedOutLoot.NotCollectedLoot.Find(loot => loot.Id == _id);
        //    if (lootOnLevel != null)
        //    {
        //        _loot = lootOnLevel.Loot;
        //        transform.position = lootOnLevel.PositionOnLevel.Position.AsUnityVector();
        //    }
        //}

        //private PositionOnLevel CreatePositionOnLevel(string id, Vector3Data vector3Data) =>
        //    new PositionOnLevel(id, vector3Data);

        //private string CurrentLevel() => 
        //    SceneManager.GetActiveScene().name;

        //private void Awake() => 
        //    _id = GetComponent<UniqueId>().Id;

        //private void OnDestroy() => 
        //    _factory.Unregister(this);

        //private void OnTriggerEnter(Collider other) => Pickup();

        //private void Pickup()
        //{
        //    if (_isGet)
        //        return;

        //    _isGet = true;

        //    UpdateWorldData();
        //    HideSkull();
        //    PickupFX();
        //    ShowText();
        //    StartCoroutine(StartDestroyTimer());
        //}

        //private void UpdateWorldData() => 
        //    _worldData.LootData.Collect(_loot);

        //private void HideSkull() => 
        //    _skull.SetActive(false);

        //private void PickupFX() => 
        //    InstantiateAsync(_pickupFxPrefab, transform.position, Quaternion.identity);

        //private IEnumerator StartDestroyTimer()
        //{
        //    yield return new WaitForSeconds(TIME_DELAY);
        //    Destroy(gameObject);
        //}

        //private void ShowText()
        //{
        //    _lootText.text = $"{_loot.Value}";
        //    _pickupPopup.SetActive(true);
        //}

        public void UpdateProgress(IPersistentProgressService progressData)
        {
            throw new System.NotImplementedException();
        }

        public void LoadProgress(IPersistentProgressService progressData)
        {
            throw new System.NotImplementedException();
        }
    }
}
