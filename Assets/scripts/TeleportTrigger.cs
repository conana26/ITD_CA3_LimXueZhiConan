using UnityEngine;

public class TeleportTrigger : MonoBehaviour
{
    public int teleportIndex;
    public TutorialManager manager;

    private bool completed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (completed) return;
        if (!other.CompareTag("Player")) return;

        int expected = manager.GetNextTeleportIndex();

        if (teleportIndex == expected)
        {
            completed = true;
            manager.CompleteTeleport(teleportIndex);
        }
    }
}