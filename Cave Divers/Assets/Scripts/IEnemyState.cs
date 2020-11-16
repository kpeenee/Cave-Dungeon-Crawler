﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyState 
{
    IEnemyState DoStateAction(Enemy enemy);
}
