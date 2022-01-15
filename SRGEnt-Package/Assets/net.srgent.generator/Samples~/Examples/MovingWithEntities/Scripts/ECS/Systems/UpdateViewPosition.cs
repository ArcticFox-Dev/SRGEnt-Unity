using System;
using SRGEnt.Generated;

namespace Samples.MovingWithEntities
{
    public class UpdateViewPosition : MovingExecuteSystem
    {
        public UpdateViewPosition(MovingDomain domain) : base(domain)
        {
        }

        protected override void SetMatcher(ref MovingMatcher matcher)
        {
            matcher.Requires
                .Position()
                .View();
        }

        protected override void Execute(ReadOnlySpan<MovingEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.View.transform.position = entity.Position;
            }
        }
    }
}