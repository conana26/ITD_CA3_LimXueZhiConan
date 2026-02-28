using UnityEngine;


public class WireB : MonoBehaviour
{
    public Transform batterySnapPoint;
    public Transform bulbSnapPoint;
    public float snapDistance = 0.5f;

    private bool snappedToBattery = false;
    private bool snappedToBulb = false;

    void Update()
    {
        if (!snappedToBattery && Vector3.Distance(transform.position, batterySnapPoint.position) < snapDistance)
        {
            SnapTo(batterySnapPoint);
            snappedToBattery = true;
            CircuitManager.Instance.SetWireBBattery(true);
        }

        if (!snappedToBulb && Vector3.Distance(transform.position, bulbSnapPoint.position) < snapDistance)
        {
            SnapTo(bulbSnapPoint);
            snappedToBulb = true;
            CircuitManager.Instance.SetWireBBulb(true);
        }
    }

    void SnapTo(Transform snapPoint)
    {
        transform.position = snapPoint.position;

        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null) rb.isKinematic = true;

        UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grab = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        if (grab != null) grab.enabled = false;
    }
}
