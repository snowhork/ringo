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
        private readonly IMapCreator _mapCreator;

        public MainLoop(IMapCreator mapCreator)
        {
            _mapCreator = mapCreator;
            _mapCreator.Initialize();
        }

        public void Tick()
        {
            //_camera.transform.position = Vector3.Lerp(_camera.transform.position, nextCameraPos, 0.01f);
        }
    }
}
