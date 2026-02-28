using UnityEngine;


public class WireSnap : MonoBehaviour
{
    public Transform snapTarget;
    public float snapDistance = 0.2f;
    public AudioSource snapSound;

    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grab;
    private bool snapped = false;

    void Start()
    {
        grab = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
    }

    void Update()
    {
        if (snapped) return;

        if (CanSnap() && IsCloseEnough())
        {
            SnapIntoPlace();
        }
    }

    bool CanSnap()
    {
        // Wire A or B decides based on tag
        if (CompareTag("WireA"))
            return CircuitController.Instance.IsWireAComplete();

        if (CompareTag("WireB"))
            return CircuitController.Instance.IsWireBComplete();

        return false;
    }

    bool IsCloseEnough()
    {
        return Vector3.Distance(transform.position, snapTarget.position) <= snapDistance;
    }

    void SnapIntoPlace()
    {
        snapped = true;

        transform.position = snapTarget.position;
        transform.rotation = snapTarget.rotation;

        grab.enabled = false;

        if (snapSound != null)
            snapSound.Play();
    }
        

}
