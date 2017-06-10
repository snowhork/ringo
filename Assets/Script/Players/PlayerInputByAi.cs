using System.Collections;
using System.Collections.Generic;
using ModestTree;
using UnityEngine;
using Script.Characters;
using Script.Maps;
using Script.Postions;

namespace Script.Players
{
    public class PlayerInputByAi : IPlayerInput
    {
        private IMapTipsCore _mapTipsCore;
        private readonly BaseCharacterParameter _parameter;
        private IPlayer _player;
        private int _distanceToRival;
        private Stack<Point> _decidedStack = new Stack<Point>();

        public PlayerInputByAi(IMapTipsCore mapTipsCore, BaseCharacterParameter parameter)
        {
            _mapTipsCore = mapTipsCore;
            _parameter = parameter;
            for (var i = 0; i < MapTipsCollection.MapSizeX; i++)
            {
                for (var j = 0; j < MapTipsCollection.MapSizeY; j++)
                {
                    var player = mapTipsCore.GetPlayer(new Point(i, j));
                    if (player == null || player.Attribute == parameter.Attribute) continue;
                    _player = player;
                    break;
                }
            }            
        }

        public Point LookInput()
        {
            return Point.Zero();
        }

        public Point MoveInput()
        {
            CalcDistance();

            if (!_decidedStack.IsEmpty())
            {
                var next = _parameter.Point + _decidedStack.Peek();
                return _decidedStack.Pop();
                if (_mapTipsCore.EnterableMapTip(next))
                {
                    return _decidedStack.Pop();
                }
                return Point.Zero();
            }
            return SearchPointable();
        }

        public Point AttackInput()
        {
            return SearchAttackable();
        }

        public Point SpecialAttackInput()
        {
            return Point.Zero();
        }

        private void CalcDistance()
        {
            _distanceToRival = Mathf.Abs(_player.Point.X - _parameter.Point.X) +
                           Mathf.Abs(_player.Point.Y - _parameter.Point.Y);
            
        }

        private Point MoveForward(Point point)
        {
            if (Random.Range(0, 2) == 0)
            {
                if (point.X < _parameter.Point.X)
                {
                    return new Point(-1, 0);
                }
                if (point.X > _parameter.Point.X)
                {
                    return new Point(1, 0);
                }

                if (point.Y < _parameter.Point.Y)
                {
                    return new Point(0, -1);
                }
                if (point.Y > _parameter.Point.Y)
                {
                    return new Point(0, 1);
                }
            }
            else
            {
                if (point.Y < _parameter.Point.Y)
                {
                    return new Point(0, -1);
                }
                if (point.Y > _parameter.Point.Y)
                {
                    return new Point(0, 1);
                }
                
                if (point.X < _parameter.Point.X)
                {
                    return new Point(-1, 0);
                }
                if (point.X > _parameter.Point.X)
                {
                    return  new Point(1, 0);
                }
            }
            return Point.Zero();
        }
        
        static readonly Point[] _forwards = new[]
        {
            new Point(1, 0), new Point(-1, 0), 
            new Point(0, 1), new Point(0, -1),  
        };

        private Point SearchPointable()
        {
            var current = _parameter.Point;
            var queue = new Queue<WfsInfo>();
                      

            foreach (var forward in _forwards)
            {
                queue.Enqueue(new WfsInfo(null, current + forward, forward));
            }

            WfsInfo decided = null;
            
            var flag = new bool[MapTipsCollection.MapSizeX,MapTipsCollection.MapSizeY];
            
            while (!queue.IsEmpty())
            {
                Wfs(queue.Dequeue(), queue, out decided, flag);
                if (decided != null) break;
                if(queue.Count >= 20) return MoveForward(_player.Point);
            }            
            while (decided != null)
            {
                _decidedStack.Push(decided.Forward);
                decided = decided.Back;
            }
            return Point.Zero();
            return _forwards[Random.Range(0, 4)];
        }

        class WfsInfo
        {
            public readonly WfsInfo Back;
            public readonly Point Current;
            public readonly Point Forward;

            public WfsInfo(WfsInfo back, Point current, Point forward)
            {
                Back = back;
                Current = current;
                Forward = forward;
            }
        }

        private void Wfs(WfsInfo info, Queue<WfsInfo> queue, out WfsInfo decided, bool[,] flag)
        {
            var current = info.Current;
            decided = null;
            if(current.X < 0 || current.Y < 0 || current.X >= MapTipsCollection.MapSizeX || current.Y >= MapTipsCollection.MapSizeY) return;
            if(flag[current.X, current.Y]) return;
            var _effect = _mapTipsCore.GetEffect(current);
            if (_effect != null && _effect.Attribute != _parameter.Attribute)
            {
                return;
            }
            var _block = _mapTipsCore.GetBlock(current);
            if (_block != null)
            {
                if (!_block.Destroyable)
                {
                    return;
                }
            }
            
            flag[current.X, current.Y] = true;

            foreach (var forward in _forwards)
            {
                var point = current + forward;
                if(point.X < 0 || point.Y < 0 || point.X >= MapTipsCollection.MapSizeX || point.Y >= MapTipsCollection.MapSizeY) continue;
                if(flag[point.X, point.Y]) continue;
                var effect = _mapTipsCore.GetEffect(point);
                if (effect != null && effect.Attribute != _parameter.Attribute)
                {
                    continue;
                }
                var block = _mapTipsCore.GetBlock(point);
                if (block != null)
                {
                    if (!block.Destroyable)
                    {
                        continue;
                    }
                }

                var nextInfo = new WfsInfo(info, point, forward);
                queue.Enqueue(nextInfo);
                var player = _mapTipsCore.GetPlayer(point);
                if (player != null && player.Attribute != _parameter.Attribute)
                {
                    decided = nextInfo;
                    Debug.Log("catch player");
                    return;
                }
                
                var item = _mapTipsCore.GetItem(point);
                if (item != null)
                {
                    decided = nextInfo;
                     Debug.Log("catch item");
                    return;
                }
                
                if (block != null)
                {
                    if (!block.Destroyable)
                    {
                        continue;
                    }
                    decided = nextInfo;
                    Debug.Log("catch block");
                    return;
                }
                

                Debug.Log("no catch");
            }
        }
        
        private Point SearchAttackable()
        {
            var forwards = new[]
            {
                new Point(1, 0), new Point(-1, 0), 
                new Point(0, 1), new Point(0, -1),  
            };
            for (var distance = 1; distance < 4; distance++)
            {
                for (var i = 0; i < 4; i++)
                {
                    var forward = forwards[i];
                    var point = new Point(forward.X*distance, forward.Y*distance) + _parameter.Point;
                    if(point.X < 0 || point.Y < 0 || point.X >= MapTipsCollection.MapSizeX || point.Y >= MapTipsCollection.MapSizeY) continue;                
                    
                    var block = _mapTipsCore.GetBlock(point);
                    if (block != null)
                    {
                        if (block.Destroyable)
                        {
                            return forward;
                        }
                    }
                    var player = _mapTipsCore.GetPlayer(point);
                    if (player != null)
                    {
                        return forward;
                    }                    
                }
            }
            return forwards[Random.Range(0, 4)];
        }
        
    }
}
