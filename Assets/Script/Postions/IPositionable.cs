using UnityEngine;

namespace Script.Postions
{
    public interface IPositionable
    {
        Point Point { get; set; }
        GameObject GameObject { get; }
    }
}
