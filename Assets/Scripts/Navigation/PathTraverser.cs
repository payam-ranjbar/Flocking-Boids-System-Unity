using System;
using UnityEngine;

namespace Navigation
{
    public class PathTraverser : MonoBehaviour
    {
        [SerializeField] private Path path;
        [SerializeField] private float speed = 1f;
        [SerializeField] private AnimationCurve ease = AnimationCurve.Linear(0, 0, 1, 1);
        [SerializeField] private bool startAtFirstNode;
        [SerializeField] private bool traverseLoop;
        [SerializeField] private float distanceThreshold = 0.5f;
        
        private int _traverseIndex;
        
        public bool IsMoving { get; private set; }

        private int PathLength => (path != null) ? path.NodeCount : 0;
        private bool PathIsValid => path != null && path.NodeCount > 0;

        private Vector3 CurrentDest
        {
            get
            {
                if (_traverseIndex < 0 || _traverseIndex >= PathLength)
                    return transform.position;
                return path[_traverseIndex];
            }
        }

        private bool ReachedEnd => _traverseIndex >= PathLength;

        private void Start()
        {
            if (startAtFirstNode)
            {
                SetStartingPosition();
            }
        }

        private void Update()
        {
            if (!PathIsValid) return;
            if (ReachedEnd && !traverseLoop) return;
            if (ReachedEnd && traverseLoop)
            {
                _traverseIndex = 0;
            }
            if (ReachedCurrentNode())
            {
                GetNextWaypoint();
            }
            Traverse();
        }

        private float DistanceToNext()
        {
            if (!PathIsValid || ReachedEnd)
            {
                return float.MaxValue;
            }
            return Vector3.Distance(transform.position, CurrentDest);
        }

        private bool ReachedCurrentNode()
        {
            return DistanceToNext() <= distanceThreshold;
        }

        private void GetNextWaypoint()
        {
            if (!PathIsValid)
            {
                Debug.LogError($"{gameObject.name}: Path is null or empty");
                return;
            }
            if (ReachedEnd)
            {
                if (!traverseLoop)
                {
                    Debug.Log($"{gameObject.name}: Path is fully traversed");
                    return;
                }
                else
                {
                    _traverseIndex = 0;
                    return;
                }
            }
            _traverseIndex++;
        }

        private void SetStartingPosition()
        {
            if (!PathIsValid) return;
            _traverseIndex = 0;
            transform.position = path[_traverseIndex];
        }

        private void Traverse()
        {
            if (transform.position == CurrentDest)
            {
                IsMoving = false;
                return;
            }
            IsMoving = true;
            transform.position = Vector3.MoveTowards(
                transform.position,
                CurrentDest,
                speed * Time.deltaTime
            );
        }
    }
}
