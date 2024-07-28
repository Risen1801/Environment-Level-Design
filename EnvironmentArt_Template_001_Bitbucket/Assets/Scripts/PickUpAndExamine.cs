using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using StarterAssets;

public class PickUpAndExamine : MonoBehaviour
{

    private GameObject hitObject;
    private bool objectIsPickedUp = false;
    private bool examiningObject = false;

    private PickUpObject myPickUpObjectScript;

    public CharacterController myCharacterController;

    public GameObject handPosition;
    public GameObject examinePosition;

    public float thrust = 300f;

    public float zoomFOV = 30.0f;
    public float zoomSpeed = 9f;

    private float targetFOV;
    private float baseFOV;

    private GameObject _player;
    private StarterAssetsInputs _starterAssetsInputs;

    // Use this for initialization
    /*
    void Start()
    {
        SetBaseFOV(GetComponent<Camera>().fieldOfView);

        // get the CharacterController of the parent object (player)
        //myCharacterController = transform.parent.gameObject.GetComponent<CharacterController>();
        _player = GameObject.FindWithTag("Player");
        _starterAssetsInputs = _player.GetComponent<StarterAssetsInputs>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {

            if (!objectIsPickedUp)
            {

                // check if objects in front of the camera
                // important! player must be on layer "IgnoreRaycast"!
                Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {

                    // debug
                    //print("Loking at " + hit.transform.name);

                    // check if object has rigidbody
                    if (hit.transform.gameObject.GetComponent<Rigidbody>() != null)
                    {

                        // check if object has pickup-script
                        if (hit.transform.gameObject.GetComponent("PickUpObject"))
                        {

                            // get object
                            hitObject = hit.transform.gameObject;

                            // get script
                            myPickUpObjectScript = hitObject.GetComponent<PickUpObject>();

                            // pick up object
                            hitObject.transform.parent = handPosition.transform;
                            hitObject.transform.position = handPosition.transform.position;
                            hitObject.GetComponent<Rigidbody>().isKinematic = true;

                            objectIsPickedUp = true;
                        }
                    }
                }
            }
            else
            {
                hitObject.transform.parent = null;
                hitObject.GetComponent<Rigidbody>().isKinematic = false;
                hitObject.GetComponent<Rigidbody>().AddForce(transform.forward * thrust);
                hitObject = null;

                objectIsPickedUp = false;
            }
        }

        // ===========================

        if (objectIsPickedUp && !examiningObject)
        {
            //hitObject.transform.eulerAngles = new Vector3(handPosition.transform.eulerAngles.x, handPosition.transform.eulerAngles.y, handPosition.transform.eulerAngles.z);
        }

        // ===========================

        if (examiningObject)
        {
            if (myPickUpObjectScript.rotateHorizontal)
            {
                hitObject.transform.Rotate(new Vector3(Input.GetAxis("Mouse Y"), 0, 0));

            }
            if (myPickUpObjectScript.rotateVertical)
            {
                hitObject.transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0));

            }
        }

        // ===========================
        // start examining

        if (Input.GetButtonDown("Fire2") && objectIsPickedUp)
        {
            if (!examiningObject)
            {
                hitObject.transform.position = examinePosition.transform.position;
                if (myPickUpObjectScript.adjustObject)
                {
                    hitObject.transform.eulerAngles = gameObject.transform.eulerAngles;
                }
                examiningObject = true;
                myCharacterController.enabled = false;
                //GetComponent<ScriptMachine>().enabled = false;
                _starterAssetsInputs.cursorInputForLook = false;
                _starterAssetsInputs.LookInput(Vector2.zero);
            }
        }

        // ===========================
        // end examining

        if (Input.GetButtonUp("Fire2") && objectIsPickedUp)
        {
            if (examiningObject)
            {
                hitObject.transform.position = handPosition.transform.position;
                examiningObject = false;
                myCharacterController.enabled = true;
                //GetComponent<ScriptMachine>().enabled = true;
                _starterAssetsInputs.cursorInputForLook = true;
            }
        }

        // ===========================
        // zoom

        if (Input.GetButton("Fire2") && !objectIsPickedUp)
        {
            targetFOV = zoomFOV;
        }
        else
        {
            targetFOV = baseFOV;
        }

        UpdateZoom();

    }

    private void UpdateZoom()
    {
        GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, targetFOV, zoomSpeed * Time.deltaTime);
    }

    public void SetBaseFOV(float fov)
    {
        baseFOV = fov;
    }

    */
    void Start()
    {
        SetBaseFOV(GetComponent<Camera>().fieldOfView);
        _player = GameObject.FindWithTag("Player");
        _starterAssetsInputs = _player.GetComponent<StarterAssetsInputs>();
    }

    void Update()
    {
        // Pick up or drop object
        if (Input.GetButtonDown("Fire1") && !examiningObject)
        {
            if (!objectIsPickedUp)
            {
                Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.gameObject.GetComponent<Rigidbody>() != null)
                    {
                        if (hit.transform.gameObject.GetComponent<PickUpObject>())
                        {
                            hitObject = hit.transform.gameObject;
                            myPickUpObjectScript = hitObject.GetComponent<PickUpObject>();
                            hitObject.transform.parent = handPosition.transform;
                            hitObject.transform.position = handPosition.transform.position;
                            hitObject.GetComponent<Rigidbody>().isKinematic = true;
                            objectIsPickedUp = true;
                        }
                    }
                }
            }
            else
            {
                DropObject();
            }
        }

        // Rotate object while examining
        if (examiningObject)
        {
            if (myPickUpObjectScript.rotateHorizontal)
            {
                hitObject.transform.Rotate(new Vector3(Input.GetAxis("Mouse Y"), 0, 0));
            }
            if (myPickUpObjectScript.rotateVertical)
            {
                hitObject.transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0));
            }
        }

        // Start examining
        if (Input.GetButtonDown("Fire2") && objectIsPickedUp && !examiningObject)
        {
            StartExamining();
        }

        // End examining
        if (Input.GetButtonUp("Fire2") && examiningObject)
        {
            StopExamining();
        }

        // Zoom
        targetFOV = (Input.GetButton("Fire2") && !objectIsPickedUp) ? zoomFOV : baseFOV;
        UpdateZoom();
    }

    private void DropObject()
    {
        hitObject.transform.parent = null;
        hitObject.GetComponent<Rigidbody>().isKinematic = false;
        hitObject.GetComponent<Rigidbody>().AddForce(transform.forward * thrust);
        hitObject = null;
        objectIsPickedUp = false;
    }

    private void StartExamining()
    {
        hitObject.transform.position = examinePosition.transform.position;
        if (myPickUpObjectScript.adjustObject)
        {
            hitObject.transform.eulerAngles = gameObject.transform.eulerAngles;
        }
        examiningObject = true;
        myCharacterController.enabled = false;
        _starterAssetsInputs.cursorInputForLook = false;
        _starterAssetsInputs.LookInput(Vector2.zero);
    }

    private void StopExamining()
    {
        hitObject.transform.position = handPosition.transform.position;
        examiningObject = false;
        myCharacterController.enabled = true;
        _starterAssetsInputs.cursorInputForLook = true;
    }

    private void UpdateZoom()
    {
        GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, targetFOV, zoomSpeed * Time.deltaTime);
    }

    public void SetBaseFOV(float fov)
    {
        baseFOV = fov;
    }
}
