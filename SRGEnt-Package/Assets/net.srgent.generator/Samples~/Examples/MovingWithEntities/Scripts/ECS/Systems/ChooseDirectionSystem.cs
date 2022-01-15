using System;
using SRGEnt.Generated;

namespace Samples.MovingWithEntities
{
    public class ChooseDirectionSystem : MovingExecuteSystem
    {
        public ChooseDirectionSystem(MovingDomain domain) : base(domain)
        {
        }

        protected override void SetMatcher(ref MovingMatcher matcher)
        {
            matcher.Requires
                .Position()
                .CannotHave
                .MoveDown()
                .MoveUp()
                .MoveLeft()
                .MoveRight();
        }

        protected override void Execute(ReadOnlySpan<MovingEntity> entities)
        {
            foreach (var entity in entities)
            {
                ChooseHorizontalDirection(entity);
            }
        }

        private void ChooseHorizontalDirection(MovingEntity entity)
        {
            var xPos = entity.Position.x;
            var yPos = entity.Position.y;

            if (xPos <= _domain.MovementBounds.left && yPos >= _domain.MovementBounds.top)
            {
                entity.MoveDown = true;
            }
            else if (xPos <= _domain.MovementBounds.left && yPos <= _domain.MovementBounds.bottom)
            {
                entity.MoveRight = true;
            }
            else if(xPos >= _domain.MovementBounds.right && yPos <= _domain.MovementBounds.bottom)
            {
                entity.MoveUp = true;
            }
            else if (xPos >= _domain.MovementBounds.right && yPos >= _domain.MovementBounds.top)
            {
                entity.MoveLeft = true;
            }
            else if (xPos >= _domain.MovementBounds.right && (yPos >= _domain.MovementBounds.top) ||
                (yPos <= _domain.MovementBounds.bottom))
            {
                entity.MoveLeft = true;
            }
            //Only initial Choice should go through the logic below
            else if (xPos <= _domain.MovementBounds.left || xPos >= _domain.MovementBounds.right)
            {
                ChooseVerticalDirection(entity);
            }
            else
            {
                if (xPos < 0)
                {
                    entity.MoveLeft = true;
                }
                else
                {
                    entity.MoveRight = true;
                }
            }
        }

        private void ChooseVerticalDirection(MovingEntity entity)
        {
            var yPos = entity.Position.y;
            if (yPos < 0)
            {
                entity.MoveDown = true;
            }
            else
            {
                entity.MoveUp = true;
            }
        }
    }
}