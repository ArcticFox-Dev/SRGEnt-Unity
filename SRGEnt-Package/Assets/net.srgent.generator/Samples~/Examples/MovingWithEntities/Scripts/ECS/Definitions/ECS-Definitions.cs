using SRGEnt.Attributes;
using UnityEngine;

namespace Samples.MovingWithEntities
{
    [EntityDefinition]
    public interface IMovingEntity
    {
        Vector3 Position { get; }
        GameObject View { get; }
        bool MoveLeft { get; }
        bool MoveRight { get; }
        bool MoveUp { get; }
        bool MoveDown { get; }
    }

    [DomainDefinition(typeof(IMovingEntity))]
    public interface IMovingDomain
    {
        RectOffset MovementBounds { get; }
        float MovementSpeed { get; }
        GameObject MoverViewPrefab { get; }
    }
}
