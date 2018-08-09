using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutCameraDestroy : MonoBehaviour {

    private const string MAIN_CAMERA_TAG_NAME = "MainCamera";
    private bool _isRendered = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (!_isRendered)
        {
            Destroy(this);
        }

        _isRendered = false;
	}

    private void OnWillRenderObject()
    {
        //メインカメラに映った時だけ_isRenderedを有効に
        if (Camera.current.tag == MAIN_CAMERA_TAG_NAME)
        {
            _isRendered = true;
        }
    }
}
