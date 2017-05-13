using UnityEngine;

namespace Script.Characters
{
    public class BaseCharacterParameter
    {
        private int _hp;
        private int _maxHp;
        private int _attack;
        private float _speed;

        public BaseCharacterParameter(int hp, int maxHp, int attack, float speed)
        {
            _hp = hp;
            _maxHp = maxHp;
            _attack = attack;
            _speed = speed;
        }

        public int Hp
        {
            get { return _hp; }
            set
            {
                _hp = value;
                Debug.Log(_hp);
            }
        }

        public int MaxHp
        {
            get { return _maxHp; }
            set { _maxHp = value; }
        }

        public int Attack
        {
            get { return _attack; }
            set { _attack = value; }
        }

        public float Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }
    }
}
