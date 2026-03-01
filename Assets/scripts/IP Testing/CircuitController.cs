using UnityEngine;

public class CircuitController : MonoBehaviour
{
    public static CircuitController Instance;

    public MeshRenderer bulbRenderer;
    public Material offMaterial;
    public Material onMaterial;
    public ParticleSystem glowEffect;
    public AudioSource successSound;

    // Wire A connection states
    private bool wireA_End1 = false;
    private bool wireA_End2 = false;

    // Wire B connection states
    private bool wireB_End1 = false;
    private bool wireB_End2 = false;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        if (bulbRenderer != null && offMaterial != null)
        {
            bulbRenderer.material = offMaterial;
        }
    }

    // ---- Wire A ----
    public void SetWireAEnd1(bool touching)
    {
        wireA_End1 = touching;
        UpdateCircuit();
    }

    public void SetWireAEnd2(bool touching)
    {
        wireA_End2 = touching;
        UpdateCircuit();
    }

    // ---- Wire B ----
    public void SetWireBEnd1(bool touching)
    {
        wireB_End1 = touching;
        UpdateCircuit();
    }

    public void SetWireBEnd2(bool touching)
    {
        wireB_End2 = touching;
        UpdateCircuit();
    }

    private void UpdateCircuit()
    {
        bool circuitComplete =
            wireA_End1 &&
            wireA_End2 &&
            wireB_End1 &&
            wireB_End2;

        if (bulbRenderer == null) return;

        if (circuitComplete && onMaterial != null)
        {
            bulbRenderer.material = onMaterial;
            Debug.Log("Circuit Complete! Bulb is ON!");
            if (glowEffect != null)
                glowEffect.Play();

            if (successSound != null)
                successSound.Play();
        }
        else if (offMaterial != null)
        {
            bulbRenderer.material = offMaterial;
            Debug.Log("Circuit incomplete - Bulb is OFF");
        }
    }

    public void RegisterWireSnapped(SnapWire wire)
{
    snappedWires++;

    if (snappedWires >= 2)
    {
        UpdateCircuit();
    }
}

    private int snappedWires = 0;


    public bool IsWireAComplete()
    {
        return wireA_End1 && wireA_End2;
    }

    public bool IsWireBComplete()
    {
        return wireB_End1 && wireB_End2;
    }

}
