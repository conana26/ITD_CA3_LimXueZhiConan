using UnityEngine;
public class CircuitManager : MonoBehaviour
{
    public static CircuitManager Instance;

    public MeshRenderer bulbRenderer; // Drag your bulb GameObject here
    public Material offMaterial; // Drag your normal bulb material here
    public Material onMaterial; // Drag your emissive/lit material here

    private bool wireA_Battery = false;
    private bool wireA_Bulb = false;
    private bool wireB_Battery = false;
    private bool wireB_Bulb = false;

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

    public void SetWireABattery(bool touching) 
    { 
        wireA_Battery = touching;
        UpdateCircuit();
    }

    public void SetWireABulb(bool touching) 
    { 
        wireA_Bulb = touching;
        UpdateCircuit();
    }

    public void SetWireBBattery(bool touching) 
    { 
        wireB_Battery = touching;
        UpdateCircuit();
    }

    public void SetWireBBulb(bool touching) 
    { 
        wireB_Bulb = touching;
        UpdateCircuit();
    }

    private void UpdateCircuit()
    {
        // Circuit is complete when both wires touch both battery and bulb
        bool circuitComplete = (wireA_Battery && wireA_Bulb && wireB_Battery && wireB_Bulb) ||
                               (wireA_Battery && wireB_Bulb && wireB_Battery && wireA_Bulb);

        if (bulbRenderer != null)
        {
            if (circuitComplete && onMaterial != null)
            {
                bulbRenderer.material = onMaterial;
                Debug.Log("Circuit Complete! Bulb is ON!");
            }
            else if (offMaterial != null)
            {
                bulbRenderer.material = offMaterial;
                Debug.Log("Circuit incomplete - Bulb is OFF");
            }
        }
    }
}