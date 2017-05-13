using UnityEngine;

namespace Script.Characters
{
    public class BaseCharacterParameter : MonoBehaviour
    {
        [SerializeField] private int _hp;
        [SerializeField] private int _maxHp;
        [SerializeField] private int _attack;
        [SerializeField] private float _speed;

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
