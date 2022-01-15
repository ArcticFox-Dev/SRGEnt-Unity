using System;
using SRGEnt.Generated;
using UnityEngine;

namespace Samples.MovingWithEntities
{
    public class MoveLeftSystem : MovingExecuteSystem
    {
        public MoveLeftSystem(MovingDomain domain) : base(domain)
        {
        }

        protected override void SetMatcher(ref MovingMatcher matcher)
        {
            matcher.Requires
                .Position()
                .MoveLeft();
        }

        protected override void Execute(ReadOnlySpan<MovingEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.Position += Vector3.left * _domain.MovementSpeed * Time.deltaTime;
                if (entity.Position.x <= _domain.MovementBounds.left)
                {
                    entity.Position = new Vector3(_domain.MovementBounds.left, entity.Position.y, 0);
                    entity.MoveLeft = false;
                }
            }
        }
    }
}