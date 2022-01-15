using System;
using SRGEnt.Generated;
using UnityEngine;

namespace Samples.MovingWithEntities
{
    public class MoveUpSystem : MovingExecuteSystem
    {
        public MoveUpSystem(MovingDomain domain) : base(domain)
        {
        }

        protected override void SetMatcher(ref MovingMatcher matcher)
        {
            matcher.Requires
                .Position()
                .MoveUp();
        }

        protected override void Execute(ReadOnlySpan<MovingEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.Position += Vector3.up * _domain.MovementSpeed * Time.deltaTime;
                if (entity.Position.y >= _domain.MovementBounds.top)
                {
                    entity.Position = new Vector3(entity.Position.x, _domain.MovementBounds.top, 0);
                    entity.MoveUp = false;
                }
            }
        }
    }
}