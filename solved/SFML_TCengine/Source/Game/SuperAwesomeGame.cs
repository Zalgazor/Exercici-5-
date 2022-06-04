using SFML.Graphics;
using SFML.System;
using System.Collections.Generic;
using TCEngine;

namespace TCGame
{
    class SuperAwesomeGame : Game
    {
        public void Init()
        {
            CreateBackground();
        }

        public void DeInit()
        {
        }

        public void Update(float _dt)
        {
        }

        private void CreateBackground()
        { 
            Actor backgroundActor = new Actor("Background");

            SpriteComponent spriteComponent = backgroundActor.AddComponent<SpriteComponent>("Textures/Background");
            spriteComponent.m_RenderLayer = RenderComponent.ERenderLayer.Background;

            TecnoCampusEngine.Get.Scene.CreateActor(backgroundActor);

        }

        private void CreateSaludBar()
        {
            Actor actor = new Actor("Horizontal Bar HUD");

            TransformComponent transformComponent = actor.AddComponent<TransformComponent>();
            transformComponent.Transform.Position = new Vector2f(600.0f, 50.0f);

            BarHUDComponent barHUDComponent = actor.AddComponent<BarHUDComponent>(new Vector2f(300.0f, 40.0f));

            float barDirection = 1.0f;

            TimerComponent timerComponent = actor.AddComponent<TimerComponent>(0.05f);
            timerComponent.Loop = true;
            timerComponent.OnTime = () =>
            {
                barHUDComponent.FillRatio += 0.05f * barDirection;
                if (barHUDComponent.FillRatio >= 1.0f || barHUDComponent.FillRatio <= 0.0f)
                {
                    barDirection = barDirection * -1.0f;
                }
            };

            TecnoCampusEngine.Get.Scene.CreateActor(actor);
        }

        private void CreateFelicidadBar()
        {
            Actor actor = new Actor("Barra Felicidad");

            TransformComponent transformComponent = actor.AddComponent<TransformComponent>();
            transformComponent.Transform.Position = new Vector2f(TecnoCampusEngine.Get.Scene., 50.0f);

            BarHUDComponent barHUDComponent = actor.AddComponent<BarHUDComponent>(new Vector2f(300.0f, 40.0f));

            float barDirection = 1.0f;

            TimerComponent timerComponent = actor.AddComponent<TimerComponent>(0.05f);
            timerComponent.Loop = true;
            timerComponent.OnTime = () =>
            {
                barHUDComponent.FillRatio += 0.05f * barDirection;
                if (barHUDComponent.FillRatio >= 1.0f || barHUDComponent.FillRatio <= 0.0f)
                {
                    barDirection = barDirection * -1.0f;
                }
            };

            TecnoCampusEngine.Get.Scene.CreateActor(actor);
        }

        private void CreateSociabilidadBar()
        {
            Actor actor = new Actor("Horizontal Bar HUD");

            TransformComponent transformComponent = actor.AddComponent<TransformComponent>();
            transformComponent.Transform.Position = new Vector2f(600.0f, 50.0f);

            BarHUDComponent barHUDComponent = actor.AddComponent<BarHUDComponent>(new Vector2f(300.0f, 40.0f));

            float barDirection = 1.0f;

            TimerComponent timerComponent = actor.AddComponent<TimerComponent>(0.05f);
            timerComponent.Loop = true;
            timerComponent.OnTime = () =>
            {
                barHUDComponent.FillRatio += 0.05f * barDirection;
                if (barHUDComponent.FillRatio >= 1.0f || barHUDComponent.FillRatio <= 0.0f)
                {
                    barDirection = barDirection * -1.0f;
                }
            };

            private void CreateAdiccionBar()
            {
                Actor actor = new Actor("Horizontal Bar HUD");

                TransformComponent transformComponent = actor.AddComponent<TransformComponent>();
                transformComponent.Transform.Position = new Vector2f(600.0f, 50.0f);

                BarHUDComponent barHUDComponent = actor.AddComponent<BarHUDComponent>(new Vector2f(300.0f, 40.0f));

                float barDirection = 1.0f;

                TimerComponent timerComponent = actor.AddComponent<TimerComponent>(0.05f);
                timerComponent.Loop = true;
                timerComponent.OnTime = () =>
                {
                    barHUDComponent.FillRatio += 0.05f * barDirection;
                    if (barHUDComponent.FillRatio >= 1.0f || barHUDComponent.FillRatio <= 0.0f)
                    {
                        barDirection = barDirection * -1.0f;
                    }
                };

                TecnoCampusEngine.Get.Scene.CreateActor(actor);
            }

            TecnoCampusEngine.Get.Scene.CreateActor(actor);
        }

    }
}
