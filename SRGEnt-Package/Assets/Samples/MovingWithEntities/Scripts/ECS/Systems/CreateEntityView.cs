using System;
using SRGEnt.Generated;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Samples.MovingWithEntities
{
    public class CreateEntityView : MovingExecuteSystem
    {
        public CreateEntityView(MovingDomain domain) : base(domain)
        {
        }

        protected override void SetMatcher(ref MovingMatcher matcher)
        {
            matcher.CannotHave
                .View();
        }

        protected override void Execute(ReadOnlySpan<MovingEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.View = Object.Instantiate(_domain.MoverViewPrefab, entity.Position, Quaternion.identity);;
            }
        }
    }
}