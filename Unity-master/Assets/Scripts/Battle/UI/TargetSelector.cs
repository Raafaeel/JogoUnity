using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
using System.Linq;

namespace Battle
{
    public class TargetSelector : MonoBehaviour
    {
        private TargetSystem targetSystem;
        private Transform selectorTransform;
        private Transform currentSelection;
        private List<Actor> targets = new List<Actor>();

        [SerializeField] private Vector2 selectorOffset = new Vector2(0, -1.75f);
        [SerializeField] private float moveSpeed = 40f;
        [SerializeField] private float positionTolerance = 0.01f;

        private void Awake()
        {
            targetSystem = FindFirstObjectByType<TargetSystem>();
            selectorTransform = transform;
            currentSelection = GetComponentInParent<Actor>().transform;
        }

        private void Start()
        {
            UpdateTargetList();
        }

        private void Update()
        {
            // Smooth movement to target offset
            selectorTransform.localPosition = Vector2.MoveTowards(
                selectorTransform.localPosition,
                selectorOffset,
                moveSpeed * Time.deltaTime
            );

            HandleInput();
        }

        private void HandleInput()
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                FindSelectionInDirection(Dir.Up);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                FindSelectionInDirection(Dir.Down);
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                FindSelectionInDirection(Dir.Left);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                FindSelectionInDirection(Dir.Right);
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                // Only accept selection when animation completes
                if (Vector2.Distance(selectorTransform.localPosition, selectorOffset) < positionTolerance)
                {
                    targetSystem.Accept(this);
                }
            }
        }

        private void FindSelectionInDirection(Dir dir)
        {
            Actor actorFound = FindActorInDirection(dir);
            if (actorFound == null) return;

            currentSelection = actorFound.transform;
            selectorTransform.SetParent(currentSelection);
            selectorTransform.localPosition = Vector3.zero;
        }

        private Actor FindActorInDirection(Dir direction)
        {
            UpdateTargetList();
            if (targets.Count == 0) return null;

            switch (direction)
            {
                case Dir.Up:
                    return FindVerticalTarget(true);
                case Dir.Down:
                    return FindVerticalTarget(false);
                case Dir.Left:
                    return FindHorizontalTarget(false);
                case Dir.Right:
                    return FindHorizontalTarget(true);
                default:
                    return null;
            }
        }

        private Actor FindVerticalTarget(bool findAbove)
        {
            float currentY = currentSelection.position.y;
            float currentX = currentSelection.position.x;

            IEnumerable<Actor> candidates = targets
                .Where(actor => Mathf.Abs(actor.transform.position.x - currentX) < positionTolerance)
                .Where(actor => findAbove 
                    ? actor.transform.position.y > currentY
                    : actor.transform.position.y < currentY);

            return findAbove
                ? candidates.OrderBy(actor => actor.transform.position.y).FirstOrDefault()
                : candidates.OrderByDescending(actor => actor.transform.position.y).FirstOrDefault();
        }

        private Actor FindHorizontalTarget(bool findRight)
        {
            float currentX = currentSelection.position.x;
            float currentY = currentSelection.position.y;

            IEnumerable<Actor> candidates = targets
                .Where(actor => findRight
                    ? actor.transform.position.x > currentX
                    : actor.transform.position.x < currentX);

            if (!candidates.Any()) return null;

            float referenceX = findRight
                ? candidates.Min(actor => actor.transform.position.x)
                : candidates.Max(actor => actor.transform.position.x);

            return candidates
                .Where(actor => Mathf.Abs(actor.transform.position.x - referenceX) < positionTolerance)
                .OrderBy(actor => Mathf.Abs(actor.transform.position.y - currentY))
                .FirstOrDefault();
        }

        private void UpdateTargetList()
        {
            if (targetSystem != null)
            {
                targets = new List<Actor>(targetSystem.ValidTargets);
            }
        }
    }
}