

using UnityEngine;

public class Orienter : MonoBehaviour{

    [SerializeField]
    private float numberOfPoints;

    [SerializeField]
    private float distance = 1f;

    [SerializeField]
    private float raycastDistance;

    [SerializeField]
    private LayerMask raycastMask;
    
    [SerializeField]
    private float downRaycastDistance;


    private float GOLDEN_RATIO = (1f + Mathf.Sqrt(5)) / 2f;
    private float ANGLE_INCREMENT = 2f * Mathf.PI * (1f + Mathf.Sqrt(5)) / 2f;



    public bool Orient(Transform glider){
        
        if(Physics.Raycast(glider.position + glider.up, -glider.up, out var downHitInfo, downRaycastDistance, raycastMask.value, QueryTriggerInteraction.Ignore)){
            glider.position = downHitInfo.point + glider.up * distance;
        }

        var combinedDir = Vector3.zero;

        for(int i = 0; i < numberOfPoints; i++){
            float t = (float) i / numberOfPoints;
            float angle1 = Mathf.Acos(1f - 2f * t);
            float angle2 = ANGLE_INCREMENT * i;

            float x = Mathf.Sin(angle1) * Mathf.Cos(angle2);
            float y = Mathf.Sin(angle1) * Mathf.Sin(angle2);
            float z = Mathf.Cos(angle1);

            if(y > 0)
                continue;

            Vector3 localPointOnSphere = new Vector3(x, y, z);
            Vector3 pointOnSphere = glider.TransformDirection(localPointOnSphere);

            if(Physics.Raycast(glider.position, pointOnSphere, out var hitInfo, raycastDistance, raycastMask.value, QueryTriggerInteraction.Ignore)){
                Debug.DrawLine(glider.position, glider.position + pointOnSphere * raycastDistance, Color.green);   
                combinedDir += pointOnSphere;
            }else{
                Debug.DrawLine(glider.position, glider.position + pointOnSphere * raycastDistance, Color.red);
            }
        }
        
        var appliedRot = Quaternion.Lerp(Quaternion.identity, Quaternion.FromToRotation(glider.up, -combinedDir), 0.1f);
        glider.rotation = appliedRot * glider.rotation;
    
    
        if(Physics.Raycast(glider.position, -glider.up, out var afterDownHitInfo, downRaycastDistance, raycastMask.value, QueryTriggerInteraction.Ignore)){
            glider.position = afterDownHitInfo.point + glider.up * distance;
        }else{
            return false;
        }
    
        return true;
    }
}