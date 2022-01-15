using System;
using SRGEnt.Generated;
using UnityEngine;

namespace Samples.MovingWithEntities
{
    public class MoveRightSystem : MovingExecuteSystem
    {
        public MoveRightSystem(MovingDomain domain) : base(domain)
        {
        }

        protected override void SetMatcher(ref MovingMatcher matcher)
        {
            matcher.Requires
                .Position()
                .MoveRight();
        }

        protected override void Execute(ReadOnlySpan<MovingEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.Position += Vector3.right * _domain.MovementSpeed * Time.deltaTime;
                if (entity.Position.x >= _domain.MovementBounds.right)
                {
                    entity.Position = new Vector3(_domain.MovementBounds.right, entity.Position.y, 0);
                    entity.MoveRight = false;
                }
            }
        }
    }
}