using System;
using Script.Characters;
using Script.Postions;
using UniRx;
using UnityEngine;

namespace Script.Players
{
    public class PlayerInputByJoyCon2 : IPlayerInput
    {
        private int _id;
        private readonly BaseCharacterParameter _parameter;
        private float _inputTime;
        private float _threshold = 0.08f;

        public PlayerInputByJoyCon2(int id, BaseCharacterParameter parameter)
        {
            _id = id;
            _parameter = parameter;
        }

        public Point LookInput()
        {                                                
            if (Input.GetAxis("Horizontal" + _id) != 0 || Input.GetAxis("Vertical" + _id) != 0)
            {
                _inputTime += Time.deltaTime;
            }
            else
            {
                _inputTime = 0;
            }
            
            if (Input.GetAxis("Horizontal" + _id) > 0) return new Point(1,  0);
            if (Input.GetAxis("Horizontal" + _id) < 0)  return new Point(-1, 0);
            if (Input.GetAxis("Vertical" + _id) > 0)   return new Point(0, 1);
            if (Input.GetAxis("Vertical" + _id) < 0)    return new Point(0, -1);
            return new Point(0, 0);
        }

        public Point MoveInput()
        {
            if (_inputTime > _threshold)
            {
                if (Input.GetAxis("Horizontal" + _id) > 0) return new Point(1, 0);
                if (Input.GetAxis("Horizontal" + _id) < 0) return new Point(-1, 0);
                if (Input.GetAxis("Vertical" + _id) > 0) return new Point(0, 1);
                if (Input.GetAxis("Vertical" + _id) < 0) return new Point(0, -1);
            }
            return new Point(0, 0);
        }

        public Point AttackInput()
        {
            if (Input.GetButtonDown("RightButton" + _id)) return _parameter.Forward;
            return new Point(0, 0);
        }

        public Point SpecialAttackInput()
        {
            if (Input.GetButtonDown("UpButton" + _id)) return _parameter.Forward;
            return new Point(0, 0);
        }
    }
}
