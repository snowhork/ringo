using Script.Creatures;
using Script.Items;
using Script.Players;
using Script.Postions;
using UnityEngine;

namespace Script.Maps
{
	public abstract class BaseMapTip : MonoBehaviour, IPositionable
	{
		public const float TipSize = 1f;
		protected Point _point;
		protected IItem _item;
		protected ICreature _creature;
		protected IPlayer _player;

		private void OnDestroy()
		{
			if(_item != null) Destroy(_item.GameObject);
			if(_creature != null) Destroy(_creature.GameObject);
			if(_player != null) Destroy(_player.GameObject);
			Destroy(gameObject);
		}

		public IItem Item
		{
			get { return _item; }
		}

		public ICreature Creature
		{
			get { return _creature; }
		}

		public IPlayer Player
		{
			get { return _player; }
		}

		public Point Point
		{
			get { return _point; }
			set { _point = value;  }
		}

		public GameObject GameObject
		{
			get { return gameObject; }
		}

		public void Register(IItem item)
		{
			_item = item;
		}

		public void Register(ICreature creature)
		{
			_creature = creature;
		}

		public void Register(IPlayer player)
		{
			_player = player;
		}

		public void Remove(IItem item)
		{
			if(item != _item) return;
			_item = null;
		}

		public void Remove(ICreature creature)
		{
			if(creature != _creature) return;
			_creature = null;
		}

		public void Remove(IPlayer player)
		{
			if(player != _player) return;
			_player = null;
		}

		public void SetTransform()
		{
			transform.position = new Vector3(TipSize*Point.X, 0, TipSize*Point.Y);
		}

		public abstract bool Enterable();
	}
}
