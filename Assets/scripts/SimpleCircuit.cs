using UnityEngine;

public class SimpleCircuit : MonoBehaviour
{
    public static bool wireA_Battery;
    public static bool wireA_Bulb;
    public static bool wireB_Battery;
    public static bool wireB_Bulb;

    public bool isWireA; // tick for WireA, untick for WireB

    public MeshRenderer bulbRenderer;
    public Material offMaterial;
    public Material onMaterial;

    void OnTriggerEnter(Collider other)
    {
        if (isWireA)
        {
            if (other.CompareTag("Battery")) wireA_Battery = true;
            if (other.CompareTag("Bulb")) wireA_Bulb = true;
        }
        else
        {
            if (other.CompareTag("Battery")) wireB_Battery = true;
            if (other.CompareTag("Bulb")) wireB_Bulb = true;
        }

        CheckCircuit();
    }

    void OnTriggerExit(Collider other)
    {
        if (isWireA)
        {
            if (other.CompareTag("Battery")) wireA_Battery = false;
            if (other.CompareTag("Bulb")) wireA_Bulb = false;
        }
        else
        {
            if (other.CompareTag("Battery")) wireB_Battery = false;
            if (other.CompareTag("Bulb")) wireB_Bulb = false;
        }

        CheckCircuit();
    }

    void CheckCircuit()
    {
        bool complete =
            wireA_Battery && wireA_Bulb &&
            wireB_Battery && wireB_Bulb;

        if (complete)
            bulbRenderer.material = onMaterial;
        else
            bulbRenderer.material = offMaterial;
    }
}
