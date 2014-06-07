using UnityEngine;
using System.Collections;

public class CameraInversion : MonoBehaviour {

    // Invert the backface culling
    /**void OnPreRender()
    {
        GL.SetRevertBackfacing(true);
    }**/

    // Flip the camera
    void OnPreCull()
    {
        camera.ResetWorldToCameraMatrix();
        camera.ResetProjectionMatrix();
        camera.projectionMatrix = camera.projectionMatrix * Matrix4x4.Scale(new Vector3(1, -1, 1));
    }

    // Invert the backface culling again
    void OnPostRender()
    {
        GL.SetRevertBackfacing(false);
    }
}
