using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformController : MonoBehaviour {
    Rigidbody rb;
    public float speed;
    public float rotSpeed;
    public LayerMask groundMask;
    public bool ground;
    RaycastHit hit;
    float xRotationLimit = 90;
    float yRotationLimit = 90;
    float zRotationLimit = 90;
    public GameObject pos;

    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    private void Update() {
        pos.transform.localPosition = transform.forward;
        ground = Physics.Raycast(transform.position, Vector3.down, out hit, 1, groundMask);
        if (ground && /**(transform.rotation.x > xRotationLimit || transform.rotation.x < (xRotationLimit*-1)) || */CheckAngles()) {
            Debug.Log(transform.rotation.eulerAngles.x);
            transform.rotation = Quaternion.identity;
        }


        //if (transform.rotation.eulerAngles.y > yRotationLimit) {
        //    transform.rotation = Quaternion.identity;
        //}

        //if (transform.rotation.eulerAngles.z > zRotationLimit) {
        //    transform.rotation = Quaternion.identity;
        //}
    }
    public bool CheckAngles() {
        return Physics.Raycast(transform.position, transform.up, 1, groundMask) || Physics.Raycast(transform.position, transform.right, 1, groundMask) || Physics.Raycast(transform.position, transform.right * -1, 1, groundMask);
    }
    // Update is called once per frame
    void FixedUpdate() {
        //if (ground)
        // Vector3 movement = transform.rotation * Vector3.forward;
        if (Input.GetAxisRaw("Vertical") != 0)
            transform.position += transform.forward * Time.deltaTime * Input.GetAxis("Vertical") * speed *( Input.GetKey(KeyCode.Space) ? 5 : 1);
        //  rb.velocity = movement * Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.Rotate(Vector3.up * rotSpeed * Input.GetAxis("Horizontal"));
        // rb.AddTorque(transform.up * Input.GetAxis("Horizontal") * rotSpeed);
        if (Input.GetKeyDown(KeyCode.Space)) {
            rb.AddForce(transform.up * 200, ForceMode.Impulse);
        }
        //  transform.LookAt(transform.forward);

    }
    private void OnDrawGizmos() {
        Gizmos.DrawLine(transform.position, transform.position + (Vector3.down * 10));
    }
}
