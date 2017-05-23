using System.Collections;
using Script.Damages;
using Script.Maps;
using UniRx;
using UnityEngine;

namespace Script.Players
{
    public interface IPlayer : IRegistable, IDamagable
    {
        Transform Transform { get; }
        void ExecuteCoroutine(IEnumerator coroutine);
    }
}
