using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleTargetCamera : MonoBehaviour
{
public List<Transform> targets;
public List<GameObject> players = new List<GameObject>();

public Vector3 offset;
public float smoothTime = 0.5f;

public float minZoom = 40f;
public float maxZoom = 20f;
public float zoomLimiter = 50f;

private Vector3 velocity;
private Camera cam;

void Start (){
    cam = GetComponent<Camera>();
}
void LateUpdate(){
    int playnm = GameObject.FindGameObjectsWithTag("Player").Length;
    if (players.Count ==0 || playnm != players.Count){
            players = new List<GameObject>();
            foreach(GameObject fooObj in GameObject.FindGameObjectsWithTag("Player")) {
 
                players.Add(fooObj);
         
         }

    }
    if (targets.Count == 0 || playnm != targets.Count){
        targets = new List<Transform>();
        for(int i = 0; i < playnm; ++i){
            targets.Add(players[i].transform);
        }
        return;
    }
    Move();
    Zoom();
   
}
void Zoom(){
    float newZoom = Mathf.Lerp(maxZoom, minZoom, GetGreatestDistance()/zoomLimiter);
    cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, newZoom, Time.deltaTime);
}
void Move (){
     Vector3 centerPoint = GetCenterpoint();
    Vector3 newPosition = centerPoint + offset;

    transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);

}
float GetGreatestDistance()
{
    var bounds = new Bounds(targets[0].position, Vector3.zero);
    for (int i = 0; i < targets.Count; i++)
    {
        bounds.Encapsulate(targets[i].position);
    }
    return bounds.size.x;
}
Vector3 GetCenterpoint(){
    if (targets.Count ==1)
    {
        return targets[0].position;
    }
    var bounds = new Bounds(targets[0].position, Vector3.zero);
    for (int i = 0; i < targets.Count; i++)
    {
        bounds.Encapsulate(targets[i].position);
    }
    return bounds.center;

}


}
