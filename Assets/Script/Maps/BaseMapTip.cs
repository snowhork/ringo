using Script.Blocks;
using Script.Bullets;
using Script.Effect;
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
		protected IBlock _block;
		protected IPlayer _player;
		protected IBullet _bullet;
		protected IEffect _effect;

		private void OnDestroy()
		{
			if(_item != null) Destroy(_item.GameObject);
			if(_player != null) Destroy(_player.GameObject);
			Destroy(gameObject);
		}

		public IItem Item
		{
			get { return _item; }
		}

		public IBlock Block
		{
			get { return _block; }
		}

		public IPlayer Player
		{
			get { return _player; }
		}

		public IEffect Effect
		{
			get { return _effect; }
		}

		public IBullet Bullet
		{
			get { return _bullet; }
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

		public void Register(IBlock block)
		{
			_block = block;
		}

		public void Register(IPlayer player)
		{
			_player = player;
		}

		public void Register(IBullet bullet)
		{
			_bullet = bullet;
		}

		public void Register(IEffect effect)
		{
			_effect = effect;
		}

		public void Remove(IItem item)
		{
			if(item != _item) return;
			_item = null;
		}

		public void Remove(IBlock block)
		{
			if(block != _block) return;
			_block = null;
		}

		public void Remove(IPlayer player)
		{
			if(player != _player) return;
			_player = null;
		}

		public void Remove(IBullet bullet)
		{
			if(bullet != _bullet) return;
			_bullet = null;
		}

		public void Remove(IEffect effect)
		{
			if(effect != _effect) return;
			_effect = null;
		}

		public void SetTransform()
		{
			transform.position = new Vector3(TipSize*Point.X, 0, TipSize*Point.Y);
		}

		public abstract bool Enterable();
	}
}
