using UnityEngine;
using System.Collections;

public class CameraInversion : MonoBehaviour {

    public Transform target;
    
  

    // Flip the camera
    void OnPreCull()
    {
        camera.ResetWorldToCameraMatrix();
        camera.ResetProjectionMatrix();
        camera.projectionMatrix = camera.projectionMatrix * Matrix4x4.Scale(new Vector3(1, -1, 1));
        rotateCameraWithPlayer();        
    }

    // Invert the backface culling again
    void OnPostRender()
    {
        GL.SetRevertBackfacing(false);
    }

    // Rotate the camera as the player rotates ingame
    void rotateCameraWithPlayer()
    {
        Vector3 temp = camera.transform.eulerAngles;
        temp.y = -target.eulerAngles.y-90;
        camera.transform.eulerAngles = temp;
    }
}
