using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class Extensions {
    #region Rotation
    public static void LookAtXIgnored2D(this Transform me, Vector3 target) {
        me.LookAt(target);
        me.rotation = Quaternion.Euler(0,
                                       me.rotation.eulerAngles.y, 
                                       me.rotation.eulerAngles.z);
    }

    
    #endregion

}

