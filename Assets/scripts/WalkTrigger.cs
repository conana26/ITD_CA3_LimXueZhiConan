using UnityEngine;
using System.Collections;

public class WalkTrigger : MonoBehaviour
{
    public int triggerIndex;
    public TutorialManager manager;


    private bool completed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (completed) return;
        if (!other.CompareTag("Player")) return;

        int expectedIndex = manager.GetNextWalkIndex();

        manager.CompleteWalkTrigger(triggerIndex);
    }

}