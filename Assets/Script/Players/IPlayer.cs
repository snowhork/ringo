using Script.Damages;
using Script.Maps;
using UnityEngine;

namespace Script.Players
{
    public interface IPlayer : IRegistable, IDamagable
    {
        Transform Transform { get; }
    }
}
