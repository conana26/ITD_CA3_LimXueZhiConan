using UnityEngine;


public class SnapWire : MonoBehaviour
{
    public Transform snapTarget;   // Where the wire should snap to
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

        float dist = Vector3.Distance(transform.position, snapTarget.position);

        if (dist <= snapDistance)
        {
            SnapIntoPlace();
        }
    }

    void SnapIntoPlace()
    {
        snapped = true;

        // Lock position & rotation
        transform.position = snapTarget.position;
        transform.rotation = snapTarget.rotation;

        // Disable grabbing
        grab.enabled = false;

        // Optional snap sound
        if (snapSound != null)
            snapSound.Play();

        // Tell Circuit Controller
        CircuitController.Instance.RegisterWireSnapped(this);

    }
}
