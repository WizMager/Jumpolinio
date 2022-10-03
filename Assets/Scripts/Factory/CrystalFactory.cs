using System;
using System.Collections.Generic;
using ComponentsMonoScripts;
using Data;
using UnityEngine;
using Views;
using Zenject;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace Factory
{
    public class CrystalFactory : IFactory<List<CrystalView>>
    {
        private readonly Transform _root;
        private readonly GameObject _crystalPrefab;
        private readonly Dictionary<int, (bool isEmpty, Transform spawnPosition)> _spawnPositions;
        private readonly int _crystalCount;

        public CrystalFactory(CrystalData crystalData, AllPlatformsComponents allPlatformsComponents)
        {
            _crystalPrefab = crystalData.crystalPrefab;
            _spawnPositions = FillSpawnDictionary(allPlatformsComponents.GetCrystalSpawnPositions);
            _crystalCount = crystalData.crystalCount;
            
            var rootObject = new GameObject("Crystals");
            _root = rootObject.transform;
        }

        private Dictionary<int, (bool isEmpty, Transform spawnPosition)> FillSpawnDictionary(Transform[] spawnPositions)
        {
            var spawnDictionary = new Dictionary<int, (bool isEmpty, Transform spawnPosition)>(spawnPositions.Length);
            for (int i = 0; i < spawnPositions.Length; i++)
            {
                spawnDictionary.Add(i, (true, spawnPositions[i]));
            }
            return spawnDictionary;
        }

        private int GetEmptyRandomSpawnIndex(int spawnPositions)
        {
            var spawnIndex = -1;
            var tryCount = spawnPositions;
            do
            {
                var randomSpawnPosition = Random.Range(0, spawnPositions);
                if (_spawnPositions[randomSpawnPosition].isEmpty)
                {
                    spawnIndex = randomSpawnPosition;
                    ChangeDictionaryValue(spawnIndex);
                    break;
                }
                tryCount--;
            } while (tryCount > 0);

            if (tryCount != 0) return spawnIndex;
            
            for (int i = 0; i < spawnPositions; i++)
            {
                if (!_spawnPositions[i].isEmpty) continue;
                spawnIndex = i;
                break;
            }

            if (spawnIndex == -1)
            {
                throw new ArgumentException("You has no empty spawn positions!");
            }

            return spawnIndex;
        }

        private void ChangeDictionaryValue(int index)
        {
            var spawnPosition = _spawnPositions[index];
            spawnPosition.isEmpty = false;
            _spawnPositions[index] = spawnPosition; 
        }
        
        public List<CrystalView> Create()
        {
            var crystalsList = new List<CrystalView>(_crystalCount);
            for (int i = 0; i < _crystalCount; i++)
            {
                crystalsList.Add(Object
                    .Instantiate(_crystalPrefab, _spawnPositions[GetEmptyRandomSpawnIndex(_spawnPositions.Count)].spawnPosition.position, Quaternion.identity, _root)
                    .GetComponent<CrystalView>());
            }

            return crystalsList;
        }
        
    }
}