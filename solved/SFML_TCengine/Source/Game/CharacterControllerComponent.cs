using SFML.System;
using SFML.Window;
using TCEngine;

namespace TCGame
{
    public class CharacterControllerComponent : BaseComponent
    {

        private const float MOVEMENT_SPEED = 200f;

        public CharacterControllerComponent()
        {
        }

        public override EComponentUpdateCategory GetUpdateCategory()
        {
            return BaseComponent.EComponentUpdateCategory.PreUpdate;
        }

        public override void Update(float _dt)
        {
            base.Update(_dt);

            if (Keyboard.IsKeyPressed(Keyboard.Key.A))
            {
                Move(new Vector2f(-1.0f, 0.0f), _dt);
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.D))
            {
                Move(new Vector2f(1.0f, 0.0f), _dt);
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.W))
            {
                Move(new Vector2f(0.0f, -1.0f), _dt);
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.S))
            {
                Move(new Vector2f(0.0f, 1.0f), _dt);
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.Space))
            {
                CannonComponent cannonComponent = Owner.GetComponent<CannonComponent>();
                if(cannonComponent != null)
                {
                    cannonComponent.Shoot();
                }
            }
        }

        private void Move(Vector2f _direction, float _dt)
        {
            TransformComponent transformComponent = Owner.GetComponent<TransformComponent>();
            Vector2f velocity = _direction * MOVEMENT_SPEED;
            transformComponent.Transform.Position += velocity * _dt;
        }
    }
}
