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

        public MainLoop(IItemSpawner itemSpawner, IMapCreator mapCreator)
        {
            _itemSpawner = itemSpawner;
            _mapCreator = mapCreator;

            _itemSpawner.Spawn();

            Observable.Interval(TimeSpan.FromSeconds(2f))
                .Subscribe(_ =>
                {
                    _mapCreator.CreateCol();
                });

            Observable.Interval(TimeSpan.FromSeconds(3f))
                .Subscribe(_ =>
                {
                    _mapCreator.RemoveCol();
                });
        }

        public void Tick()
        {
            //do nothing.
        }
    }
}
