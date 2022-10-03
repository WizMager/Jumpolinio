using System.Collections.Generic;
using ComponentsMonoScripts;
using MonoController.Interfaces;
using UnityEngine;
using Views;

namespace MonoController.ControllerScripts
{
    public class PlayerShoot : IUpdate, IDestroy
    {
        private List<CrystalView> _crystalViews;
        private readonly Transform _shootPosition;
        private bool _shoot;
        private Vector3 _targetPosition;
        private readonly LineRenderer _lineRenderer;
        private readonly PortalView _portalView;

        public PlayerShoot(List<CrystalView> crystalViews, PlayerComponents playerComponents, AllPlatformsComponents allPlatformsComponents)
        {
            CrystalSubscription(crystalViews, true);
            _shootPosition = playerComponents.GetShootPosition;
            _lineRenderer = playerComponents.GetLineRenderer;
            _portalView = allPlatformsComponents.GetPortalView;
        }

        private void CrystalSubscription(List<CrystalView> crystalViews, bool sub)
        {
            _crystalViews = crystalViews;
            foreach (var crystalView in _crystalViews)
            {
                if (sub)
                {
                    crystalView.OnPlayerEnterShootRange += OnShootRangeEnterHandler;
                    crystalView.OnPlayerDestroyCrystal += OnCrystalDestroyHandler; 
                }
                else
                {
                    crystalView.OnPlayerEnterShootRange -= OnShootRangeEnterHandler;
                    crystalView.OnPlayerDestroyCrystal -= OnCrystalDestroyHandler;  
                }
            }
        }

        private void OnCrystalDestroyHandler(CrystalView currentCrystal)
        {
            _lineRenderer.enabled = false;
            currentCrystal.OnPlayerEnterShootRange -= OnShootRangeEnterHandler;
            currentCrystal.OnPlayerDestroyCrystal -= OnCrystalDestroyHandler;
            _crystalViews.Remove(currentCrystal);
            if (_crystalViews.Count == 0)
            {
               _portalView.PortalOpen();
            }
        }

        private void OnShootRangeEnterHandler(bool inside, Vector3 position)
        {
            _shoot = inside;
            _lineRenderer.enabled = false;
            if (!inside) return;
            _targetPosition = position;
            _lineRenderer.enabled = true;
        }


        public void Update(float deltaTime)
        {
            if (!_shoot) return;
            Vector3[] linePositions = {_shootPosition.position, _targetPosition};
            _lineRenderer.SetPositions(linePositions);
        }

        public void OnDestroy()
        {
            CrystalSubscription(_crystalViews, false);
        }
    }
}