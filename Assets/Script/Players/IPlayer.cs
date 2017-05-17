using Script.Damages;
using Script.Maps;
using Script.Postions;
using UnityEngine;

namespace Script.Players
{
    public interface IPlayer : IRegistable, IDamagable
    {
        Transform Transform { get; }
    }
}
