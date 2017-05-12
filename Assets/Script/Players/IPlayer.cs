using Script.Damages;
using Script.Postions;
using UnityEngine;

namespace Script.Players
{
    public interface IPlayer : IPositionable, IDamagable
    {
        Transform Transform { get; }
    }
}
