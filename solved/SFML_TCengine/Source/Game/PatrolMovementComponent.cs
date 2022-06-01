using SFML.System;
using System.Diagnostics;
using TCEngine;

namespace TCGame
{
    public class PatrolMovementComponent : BaseComponent
    {
        private const float DEFAULT_SPEED = 100.0f;

        private Vector2f m_Forward;
        private float m_Speed;
        private Actor m_Target;
        private float m_TimeToElevate = 2.0f;

        private enum State
        {
            Patrolling,
            ReachingTarget,
            ElevatingTarget
        }
        private State m_State = State.Patrolling;


        public Vector2f Forward
        {
            get => m_Forward;
            set => m_Forward = value;
        }

        public PatrolMovementComponent(Vector2f _forward)
        {
            m_Forward = _forward;
            m_Speed = DEFAULT_SPEED;
        }

        public PatrolMovementComponent()
        {
            m_Forward = new Vector2f(-1.0f, 0.0f);
            m_Speed = DEFAULT_SPEED;
        }


        public override EComponentUpdateCategory GetUpdateCategory()
        {
            return EComponentUpdateCategory.Update;
        }

        public override void OnActorDestroyed()
        {
            base.OnActorDestroyed();

            if ( m_Target != null)
            {
                TargetableComponent targetableComponent = m_Target.GetComponent<TargetableComponent>();
                Debug.Assert(targetableComponent != null);
                if(targetableComponent.ActorTargetting == Owner)
                {
                    targetableComponent.ActorTargetting = null;
                }

                TransformComponent transformComponent = m_Target.GetComponent<TransformComponent>();
                Debug.Assert(transformComponent != null);
                transformComponent.Transform.Scale = new Vector2f(1.0f, 1.0f);
            }
        }

        public override void Update(float _dt)
        {
            base.Update(_dt);


            switch (m_State)
            {
                case State.Patrolling:
                    {
                        Patrol(_dt);
                        SelectTarget();
                        break;
                    }

                case State.ReachingTarget:
                    {
                        ReachPerson(_dt);
                        break;
                    }

                case State.ElevatingTarget:
                    {
                        ElevatingPerson(_dt);
                        break;
                    }
            }
        }

        private void ChangeState(State _newState)
        {
            if (_newState == State.Patrolling)
            {
                m_Target = null;
            }
            else if (_newState == State.ElevatingTarget)
            {
                m_TimeToElevate = 2.0f;
            }

            m_State = _newState;
        }


        private void Patrol(float _dt)
        {
            Move(_dt);
        }

        private void SelectTarget()
        {
            TargetableComponent targetableComponent = TecnoCampusEngine.Get.Scene.GetRandomComponent<TargetableComponent>();
            m_Target = targetableComponent != null ? targetableComponent.Owner : null;

            if (m_Target != null)
            {
                m_Target.OnDestroy += LeaveTarget;
                ChangeState(State.ReachingTarget);
            }
        }

        private void ReachPerson(float _dt)
        {
            Debug.Assert(m_Target != null);

            Vector2f targetPosition =  m_Target.GetPosition();
            Vector2f toTarget = targetPosition - Owner.GetPosition();
            m_Forward = toTarget.Normal();

            Move(_dt);

            if (toTarget.Size() < 10.0f)
            {
                ChangeState(State.ElevatingTarget);
            }
        }

        private void LeaveTarget(Actor _target)
        {
            if( m_Target == _target)
            {
                ChangeState(State.Patrolling);
            }
        }

        private void ElevatingPerson(float _dt)
        {

            TargetableComponent targetableComponent = m_Target.GetComponent< TargetableComponent>();
            if (targetableComponent != null && (targetableComponent.ActorTargetting == null || targetableComponent.ActorTargetting == Owner))
            {
                if(targetableComponent.ActorTargetting == null)
                {
                    targetableComponent.ActorTargetting = Owner;
                }

                TransformComponent transformComponent = Owner.GetComponent<TransformComponent>();
                Debug.Assert(transformComponent != null);

                m_TimeToElevate -= _dt;

                TransformComponent targetTransformComponent = m_Target.GetComponent<TransformComponent>();
                if (targetTransformComponent != null)
                {
                    targetTransformComponent.Transform.Position += new Vector2f(0.0f, _dt * -30.0f);
                    targetTransformComponent.Transform.Scale += new Vector2f(1.0f, 1.0f) * (-0.5f * _dt);
                }

                if (m_TimeToElevate < 0.0f)
                {
                    m_Target.Destroy();
                }
            }
            else
            {
                m_Target = null;
            }


            if( m_Target == null)
            {
                ChangeState(State.Patrolling);
            }

        }

        private void Move(float _dt)
        {
            TransformComponent transformComponent = Owner.GetComponent<TransformComponent>();
            Debug.Assert(transformComponent != null);

            Vector2f velocity = m_Forward * m_Speed;
            transformComponent.Transform.Position += velocity * _dt;
        }


        public override object Clone()
        {
            PatrolMovementComponent clonedComponent = new PatrolMovementComponent(m_Forward);
            return clonedComponent;
        }
    }
}
