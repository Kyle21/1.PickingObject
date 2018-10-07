using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sample : MonoBehaviour {

    Camera AttachedCamera;
    public Shader Post_Outline;
    public Shader DrawSimple;
    Camera TempCam;
    Material Post_Mat;


    void Start()
    {
        AttachedCamera = GetComponent<Camera>();
        TempCam = new GameObject().AddComponent<Camera>();
        TempCam.enabled = false;
        Post_Mat = new Material(Post_Outline);
    }
    //Subtract the original image from the blurred image
    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        //set up a temporary camera
        TempCam.CopyFrom(AttachedCamera);
        TempCam.clearFlags = CameraClearFlags.Color;
        TempCam.backgroundColor = Color.black;

        //cull any layer that isn't the outline
        TempCam.cullingMask = 1 << LayerMask.NameToLayer("Outline");

        RenderTextureFormat rtFormat = RenderTextureFormat.ARGBHalf;
        if (!SystemInfo.SupportsRenderTextureFormat(RenderTextureFormat.ARGBHalf))
            rtFormat = RenderTextureFormat.ARGB32;

        //make the temporary rendertexture
        RenderTexture TempRT = new RenderTexture(source.width, source.height, 0, rtFormat);

        //put it to video memory
        TempRT.Create();

        //set the camera's target texture when rendering
        TempCam.targetTexture = TempRT;

        // Outline process:
        // 1. render selected objects into a mask buffer, with different colors for visible vs occluded ones (using existing Z buffer for testing)
        TempCam.RenderWithShader(DrawSimple, "");
        // 1. End

        // 2. blur the mask information in two separable passes, keeping the mask channels
        RenderTexture horizontalBlur = new RenderTexture(source.width, source.height, 0, rtFormat);
        horizontalBlur.Create();

        Post_Mat.SetVector("_BlurDirection", new Vector2(1, 0));
        Graphics.Blit(TempRT, horizontalBlur, Post_Mat, 0);

        RenderTexture verticalBlur = new RenderTexture(source.width, source.height, 0, rtFormat);
        verticalBlur.Create();

        Post_Mat.SetVector("_BlurDirection", new Vector2(0, 1));
        Graphics.Blit(horizontalBlur, verticalBlur, Post_Mat, 0);
        // 2. End


        // 3. blend outline over existing scene image. blurred information & mask channels allow computing distance to selected
        // object edges, from which we create the outline pixels
        Graphics.Blit(verticalBlur, destination, Post_Mat, 1);
        // 3. End



        //release the temporary RT
        TempRT.Release();
        horizontalBlur.Release();
        verticalBlur.Release();
    }
}
