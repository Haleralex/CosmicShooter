using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Project.Scripts.Controls
{
    public class PlaneController : MonoBehaviour
    {
        [SerializeField] private InputAction press, screenPos;

        private Vector3 curScreenPos;

        Camera camera;
        private bool isDragging;

        private Vector3 WorldPos
        {
            get
            {
                float z = camera.WorldToScreenPoint(transform.position).z;
                return camera.ScreenToWorldPoint(curScreenPos + new Vector3(0, 0, z));
            }
        }
        private bool isClickedOn
        {
            get
            {
                return true;
                Ray ray = camera.ScreenPointToRay(curScreenPos);
                Debug.Log("HERE");
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    Debug.Log(hit.transform.gameObject.name);
                    return true;//hit.transform == transform;
                }
                return false;
            }
        }
        private void Awake()
        {
            camera = Camera.main;
            screenPos.Enable();
            press.Enable();
            screenPos.performed += context => { curScreenPos = context.ReadValue<Vector2>(); };
            press.performed += _ => { if (isClickedOn) StartCoroutine(Drag()); };
            press.canceled += _ => { isDragging = false; };

        }

        private IEnumerator Drag()
        {
            isDragging = true;
            Vector3 offset = transform.position - WorldPos;
            // grab
            /* GetComponent<Rigidbody>().useGravity = false; */
            while (isDragging)
            {
                // dragging
                var newPos = WorldPos + offset;
                transform.position = new Vector3(Mathf.Clamp(newPos.x, -2.3f, 2.3f), Mathf.Clamp(newPos.y, -3.5f, 3.5f), newPos.z);
                yield return null;
            }
            // drop
            /* GetComponent<Rigidbody>().useGravity = true; */
        }
    }
}
