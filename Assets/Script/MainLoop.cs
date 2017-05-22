using System;
using Script.Items;
using Script.Maps;
using UniRx;
using UnityEngine;
using Zenject;

namespace Script
{
    public class MainLoop : ITickable
    {
        private readonly IItemSpawner _itemSpawner;
        private readonly IMapCreator _mapCreator;
        private readonly Camera _camera;
        private Vector3 nextCameraPos;

        public MainLoop(IItemSpawner itemSpawner, IMapCreator mapCreator, Camera camera)
        {
            nextCameraPos = camera.transform.position;
            _itemSpawner = itemSpawner;
            _mapCreator = mapCreator;
            _camera = camera;

            Observable.Interval(TimeSpan.FromSeconds(2f))
                .Subscribe(_ =>
                {
                    _mapCreator.CreateCol();
                });

            Observable.Interval(TimeSpan.FromSeconds(3f))
                .Subscribe(_ =>
                {
                    _mapCreator.RemoveCol();
                    nextCameraPos += Vector3.right * 1f;
                });

            Observable.Interval(TimeSpan.FromSeconds(1.25f))
                .Subscribe(_ =>
                {
                    _itemSpawner.Spawn();
                });
        }

        public void Tick()
        {
            _camera.transform.position = Vector3.Lerp(_camera.transform.position, nextCameraPos, 0.01f);
        }
    }
}
