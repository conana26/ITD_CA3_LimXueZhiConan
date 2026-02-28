using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class CircuitController : MonoBehaviour
{
    [Header("Sockets")]
    public XRSocketInteractor wireASocket;
    public XRSocketInteractor wireBSocket;

    [Header("Bulb")]
    public MeshRenderer bulbRenderer;
    public Material offMaterial;
    public Material onMaterial;

    [Header("Feedback")]
    public AudioSource snapSound;
    public AudioSource successSound;
    public ParticleSystem glowEffect;

    private bool circuitCompleted = false;

    private void Start()
    {
        if (bulbRenderer && offMaterial)
            bulbRenderer.material = offMaterial;

        // Listen for snapping on BOTH sockets
        if (wireASocket != null)
            wireASocket.selectEntered.AddListener(OnWireSnapped);

        if (wireBSocket != null)
            wireBSocket.selectEntered.AddListener(OnWireSnapped);
    }

    private void OnDestroy()
    {
        if (wireASocket != null)
            wireASocket.selectEntered.RemoveListener(OnWireSnapped);

        if (wireBSocket != null)
            wireBSocket.selectEntered.RemoveListener(OnWireSnapped);
    }

    private void Update()
    {
        bool circuitComplete =
            wireASocket != null && wireASocket.hasSelection &&
            wireBSocket != null && wireBSocket.hasSelection;

        if (circuitComplete && !circuitCompleted)
        {
            CircuitComplete();
        }
        else if (!circuitComplete && circuitCompleted)
        {
            CircuitBroken();
        }
    }

    private void OnWireSnapped(SelectEnterEventArgs args)
    {
        if (snapSound != null)
            snapSound.Play();
    }

    private void CircuitComplete()
    {
        circuitCompleted = true;

        if (bulbRenderer && onMaterial)
            bulbRenderer.material = onMaterial;

        if (glowEffect != null)
            glowEffect.Play();

        if (successSound != null)
            successSound.Play();
        
        // Update the objectives
        ObjectiveManager.Instance.QuestProgressIncrement();

        Debug.Log("Series circuit complete!");
    }

    private void CircuitBroken()
    {
        circuitCompleted = false;

        if (bulbRenderer && offMaterial)
            bulbRenderer.material = offMaterial;

        if (glowEffect != null && glowEffect.isPlaying)
            glowEffect.Stop();

        Debug.Log("Series circuit incomplete");
    }
}
