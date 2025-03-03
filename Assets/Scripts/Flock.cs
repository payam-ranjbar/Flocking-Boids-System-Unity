using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour {
    private float speed;
    private bool turning;

    public Animator animator;
    
    void Start()
    {
        SetSpeed();
        if (animator != null)
        {
            animator.SetFloat("Flap Offset", Random.Range(0f, 2f));
        }

        transform.localScale += (Random.Range(-0.05f, 0.05f) * Vector3.one);
    }

    private void SetSpeed()
    {
        speed = Random.Range(FlockManager.Instance.minSpeed, FlockManager.Instance.maxSpeed);
    }


    void Update() {

        Bounds bound = new Bounds(FlockManager.Instance.transform.position, FlockManager.Instance.limits * 2.0f);

        turning = !bound.Contains(transform.position);

        if (turning)
        {
            TurnToFlockCenter();
        } else
        {
            
            bool speedChangeChance = ProbablityExtentions.Luck(0.14f);
            var applyRulesChance  = ProbablityExtentions.Luck(0.14f);
            
            if (speedChangeChance) SetSpeed();
            if(applyRulesChance) ApplyRules();

        }

        Move();
    }

    private void Move()
    {
        transform.Translate(0.0f, 0.0f, speed * Time.deltaTime);
    }

    private void TurnToFlockCenter()
    {
        Vector3 direction = FlockManager.Instance.transform.position - transform.position;
        RotateAt(direction);
    }

    private void ApplyRules() {

        var flock = FlockManager.Instance.allBoid;

        var vCentre = Vector3.zero;
        var avoidanceVector = Vector3.zero;

        var gSpeed = 0.01f;
        float distance;
        var groupSize = 0;
        
        foreach (GameObject flockEntity in flock)
        {
            if (flockEntity == gameObject) continue;
            
            distance = Vector3.Distance(flockEntity.transform.position, this.transform.position);
            
            if (!CheckInDistanceWith(flockEntity)) continue;
            
            vCentre += flockEntity.transform.position;
            groupSize++;

            if (distance < FlockManager.Instance.avoidanceThreshold) {

                avoidanceVector += (transform.position - flockEntity.transform.position);
            }

            Flock anotherFlock = flockEntity.GetComponent<Flock>();
            gSpeed += anotherFlock.speed;
        }

        if (groupSize <= 0) return;

        var directionToFlockCenter = FlockManager.Instance.goalPos - transform.position;
        var averageCentre = vCentre / groupSize;
        averageCentre += directionToFlockCenter;
        speed = gSpeed / groupSize;

        LimitSpeed();

        Vector3 direction = (averageCentre + avoidanceVector) - transform.position;
        
        RotateAt(direction);
        
    }

    private bool CheckInDistanceWith(GameObject other)
    {
        var distance = Vector3.Distance(other.transform.position, transform.position);
        return distance <= FlockManager.Instance.neighbourDistance ;
    }

    private void LimitSpeed()
    {
        if (speed > FlockManager.Instance.maxSpeed)
        {
            speed = FlockManager.Instance.maxSpeed;
        }
    }

    private void RotateAt(Vector3 direction)
    {
        if (direction == Vector3.zero) return;

        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            Quaternion.LookRotation(direction),
            FlockManager.Instance.rotationSpeed * Time.deltaTime);
    }
}