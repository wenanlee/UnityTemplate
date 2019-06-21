using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/** 
 *Copyright(C) 2015 by UGMAX
 *All rights reserved. 
 *FileName:     GlobalManager.cs 
 *Author:       WenanLee 
 *Version:      3.0 
 *UnityVersion：2018.1.4f1 
 *Date:         2018-07-11 
 *Description:    
 *History: 
*/

public class GlobalManager : MonoBehaviour
{
    public static GlobalManager instance;
    void Awake()
    {
        instance = this;
    }
}
