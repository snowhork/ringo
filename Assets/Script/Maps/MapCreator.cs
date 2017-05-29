using System.Collections.Generic;
using Script.Factories;
using Script.Installers;
using Script.Postions;
using UnityEngine;
using Zenject;

namespace Script.Maps
{
    public class MapCreator : IMapCreator
    {
        private readonly DiContainer _container;
        private readonly IMapTipsCollection _collection;
        private readonly List<MapTipsFactory> _mapTipsFactories;
        private readonly List<BlocksFactory> _blocksFactories;
        private readonly List<PlayersFactory> _playersFactories;

        public MapCreator(DiContainer container, IMapTipsCollection collection,
            List<MapTipsFactory> mapTipsFactories,
            List<BlocksFactory> blocksFactories,
            List<PlayersFactory> playersFactories)
        {
            _container = container;
            _collection = collection;
            _mapTipsFactories = mapTipsFactories;
            _blocksFactories = blocksFactories;
            _playersFactories = playersFactories;
        }

        public void Initialize()
        {
            var tips = new BaseMapTip[MapTipsCollection.MapSizeX, MapTipsCollection.MapSizeY];
            for (var i = 0; i < tips.GetLength(0); i++)
            {
                for (var j = 0; j < tips.GetLength(1); j++)
                {
                    tips[i, j] = _mapTipsFactories[0].Create(new Point(i, j));
                }
            }
            _collection.Initialize(tips);

            _playersFactories[0].Create(new Point(0, 0));
            _playersFactories[1].Create(new Point(14, 14));

            for (var x = 1; x <= MapTipsCollection.MapSizeX - 2; x += 2)
            {
                for (var y = 1; y <= MapTipsCollection.MapSizeY - 2; y += 2)
                {
                    var tip = _collection.GetMapTip(x, y);
                    if (tip.Player != null) continue;
                    if (tip.Block != null) continue;
                    //if(Random.Range(0,2) == 1) continue;
                    
                    tip.Register(_blocksFactories[1].Create(tip.Point));
                }
            }

            for (var time = 0; time < 20; time++)
            {
                var x = Random.Range(0, MapTipsCollection.MapSizeX);
                var y = Random.Range(0, MapTipsCollection.MapSizeY);
                var tip = _collection.GetMapTip(x, y);
                if(tip.Player != null) continue;
                if(tip.Block != null) continue;
                tip.Register(_blocksFactories[0].Create(tip.Point));
            }
        }

        public void AddBlock()
        {
            throw new System.NotImplementedException();
        }


    }
}
