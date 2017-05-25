using System.Collections;
using Script.Attributes;
using Script.Hits;
using Script.Maps;
using UnityEngine;

namespace Script.Players
{
    public interface IPlayer : IRegistable, IHittable, IAttribute
    {
        Transform Transform { get; }
    }
}
