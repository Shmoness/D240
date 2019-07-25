using UnityEngine;
 using System.Collections;
  
 [AddComponentMenu("Camera-Control/Mouse Orbit with zoom")]
 public class newcamerarotate : MonoBehaviour {
  
     public Transform target;
     public float distance = 5.0f;
     public float xSpeed = 120.0f;
     public float ySpeed = 120.0f;
     public float zoom_speed = 1.0f;

    //can change the min and max values for the zoom of the object.
     public float yMinLimit = -20f;
     public float yMaxLimit = 80f;
  
     public float distanceMin = 1f;
     public float distanceMax = 10f;

     public float maxPanY;
     
     private Rigidbody rigidbody;
  
     float x = 0.0f;
     float y = 0.0f;

     float delY = 0.0f;
     float newY;
     float topY;
     float bottomY;
  
     // Use this for initialization
     void Start () 
     {
         Vector3 angles = transform.eulerAngles;
         x = angles.y;
         y = angles.x;
  
         rigidbody = GetComponent<Rigidbody>();
  
         // Make the rigid body not change rotation
         if (rigidbody != null)
         {
             rigidbody.freezeRotation = true;
         }

        topY = target.position.y + maxPanY;
        bottomY = target.position.y - maxPanY;
     }
  
     void LateUpdate () 
     {
        //float scrollwheel = Input.GetAxis("Mouse ScrollWheel");
 
        //zoom with scroll wheel; forward to zoom in, backward to scroll out.
        //transform.Translate(0, -scrollwheel * zoom_speed, scrollwheel * zoom_speed, Space.World);
        //distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel")*5, distanceMin, distanceMax);
        if (target) 
         {
  
             Quaternion rotation = Quaternion.Euler(y, x, 0);
  
             distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel")*5, distanceMin, distanceMax);
  
             RaycastHit hit;
             if (Physics.Linecast (target.position, transform.position, out hit)) 
             {
                 distance -=  hit.distance;
             }
             Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
             Vector3 position = rotation * negDistance + target.position;
  
             transform.rotation = rotation;
             transform.position = position;
         }
        if (Input.GetMouseButton(0)) 
        {
             x += Input.GetAxis("Mouse X") * xSpeed * distance * 0.02f;
             y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
  
             y = ClampAngle(y, yMinLimit, yMaxLimit);
  
             Quaternion rotation = Quaternion.Euler(y, x, 0);
  
             distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel")*5, distanceMin, distanceMax);
  
             RaycastHit hit;
             if (Physics.Linecast (target.position, transform.position, out hit)) 
             {
             
                 distance -=  hit.distance;
             }
             Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
             Vector3 position = rotation * negDistance + target.position;
  
             transform.rotation = rotation;
             transform.position = position;
        }
        if(Input.GetMouseButton(1))
        {
            delY = Input.GetAxis("Mouse Y") * ySpeed * 0.01f;

            //Vector3 position = new Vector3(transform.position.x, newY, transform.position.z);
            //transform.position = position;

            Vector3 move = new Vector3(0, delY, 0);
            target.Translate(move);

            newY = Mathf.Clamp(target.position.y, bottomY, topY);
            target.position = new Vector3(target.position.x, newY, target.position.z);
        }
     }
  
     public static float ClampAngle(float angle, float min, float max)
     {
         if (angle < -360F)
             angle += 360F;
         if (angle > 360F)
             angle -= 360F;
         return Mathf.Clamp(angle, min, max);
     }
 }