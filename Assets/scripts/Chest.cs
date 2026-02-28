using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class Chest : MonoBehaviour
{
    public HingeJoint drawerHinge;
    public float unlockedMaxAngle = 120f;

    private XRSocketInteractor socket;

    void Awake()
    {
        socket = GetComponent<XRSocketInteractor>();
    }

    void OnEnable()
    {
        socket.selectEntered.AddListener(OnKeyInserted);
    }

    void OnDisable()
    {
        socket.selectEntered.RemoveListener(OnKeyInserted);
    }

    private void OnKeyInserted(SelectEnterEventArgs args)
    {
        UnlockDrawer();
    }

    private void UnlockDrawer()
    {
        JointLimits limits = drawerHinge.limits;
        limits.max = unlockedMaxAngle; 
        drawerHinge.limits = limits;

        drawerHinge.useLimits = true;

        Debug.Log("Drawer unlocked!");
    }
}