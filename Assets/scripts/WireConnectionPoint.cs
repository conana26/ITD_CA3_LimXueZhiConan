using UnityEngine;

public class WireConnectionPoint : MonoBehaviour
{
    public enum WireType { WireA, WireB }
    public enum WireEnd { End1, End2 }

    public WireType expectedWire;
    public WireEnd wireEnd;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(expectedWire.ToString())) return;

        NotifyManager(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag(expectedWire.ToString())) return;

        NotifyManager(false);
    }

    void NotifyManager(bool connected)
    {
        if (expectedWire == WireType.WireA)
        {
            if (wireEnd == WireEnd.End1)
                CircuitController.Instance.SetWireAEnd1(connected);
            else
                CircuitController.Instance.SetWireAEnd2(connected);
        }
        else
        {
            if (wireEnd == WireEnd.End1)
                CircuitController.Instance.SetWireBEnd1(connected);
            else
                CircuitController.Instance.SetWireBEnd2(connected);
        }
    }
}
