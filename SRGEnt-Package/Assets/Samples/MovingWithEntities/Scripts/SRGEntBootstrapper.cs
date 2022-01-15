using System.Collections.Generic;
using UnityEngine;
using SRGEnt.Generated;
using SRGEnt.Interfaces;

namespace Samples.MovingWithEntities
{
    public class SRGEntBootstrapper : MonoBehaviour
    {
        [SerializeField] [Range(1, 5)] private int _entityCount = 2;
        [SerializeField] [Range(0.5f, 2)] private float _movementSpeed = 1.25f;
        [SerializeField] private GameObject _moverViewPrefab;

        private List<ISystem> _systems = new List<ISystem>();
        public void Start()
        {
            var domain = new MovingDomain(_entityCount);
            domain.MovementBounds = new RectOffset(-8, 8, 4, -4);;
            domain.MovementSpeed = _movementSpeed;
            domain.MoverViewPrefab = _moverViewPrefab;

            var rng = new System.Random();
            for (var i = 0; i < _entityCount; i++)
            {
                var entity = domain.CreateEntity();
                var xPos = rng.Next(domain.MovementBounds.left, domain.MovementBounds.right);
                var yPos = rng.Next(domain.MovementBounds.bottom, domain.MovementBounds.top);
                entity.Position = new Vector3(xPos, yPos, 0);
            }
            
            _systems.Add(new CreateEntityView(domain));
            _systems.Add(new ChooseDirectionSystem(domain));
            _systems.Add(new MoveDownSystem(domain));
            _systems.Add(new MoveUpSystem(domain));
            _systems.Add(new MoveRightSystem(domain));
            _systems.Add(new MoveLeftSystem(domain));
            _systems.Add(new UpdateViewPosition(domain));
        }

        public void Update()
        {
            foreach (var system in _systems)
            {
                system.Execute();
            }
        }
    }
}