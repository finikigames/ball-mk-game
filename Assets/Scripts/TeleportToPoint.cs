using Extensions;
using UnityEngine;

public class TeleportToPoint : MonoBehaviour {
    public Vector3 EndPoint;
    private const string _playerlayerName = "Player";

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.layer != LayerMask.NameToLayer(_playerlayerName)) return;

        var rigidBody = other.gameObject.AddComponentLazy<Rigidbody>();
        other.transform.position = EndPoint;
        rigidBody.velocity = Vector3.zero;
    }
}