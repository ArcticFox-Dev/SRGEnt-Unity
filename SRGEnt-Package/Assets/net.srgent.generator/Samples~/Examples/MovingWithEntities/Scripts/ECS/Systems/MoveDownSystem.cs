using System;
using SRGEnt.Generated;
using UnityEngine;

namespace Samples.MovingWithEntities
{
    public class MoveDownSystem : MovingExecuteSystem
    {
        public MoveDownSystem(MovingDomain domain) : base(domain)
        {
        }

        protected override void SetMatcher(ref MovingMatcher matcher)
        {
            matcher.Requires
                .Position()
                .MoveDown();
        }

        protected override void Execute(ReadOnlySpan<MovingEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.Position += Vector3.down * _domain.MovementSpeed * Time.deltaTime;
                if (entity.Position.y <= _domain.MovementBounds.bottom)
                {
                    entity.Position = new Vector3(entity.Position.x, _domain.MovementBounds.bottom, 0);
                    entity.MoveDown = false;
                }
            }
        }
    }
}