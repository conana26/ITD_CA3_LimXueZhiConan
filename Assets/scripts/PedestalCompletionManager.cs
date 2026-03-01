using UnityEngine;


public class PedestalCompletionManager : MonoBehaviour
{
    public UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor socket1;
    public UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor socket2;
    public UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor socket3;

    public GameObject congratsCanvas;

    private bool isCompleted = false;

    void Update()
    {
        if (!isCompleted &&
            socket1.hasSelection &&
            socket2.hasSelection &&
            socket3.hasSelection)
        {
            CompletePuzzle();
        }
    }

    void CompletePuzzle()
    {
        isCompleted = true;
        congratsCanvas.SetActive(true);
        Debug.Log("All objects placed! Congrats!");
    }
}
