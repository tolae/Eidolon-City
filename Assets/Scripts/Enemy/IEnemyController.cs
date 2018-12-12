using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyController {

    IEnumerator Move(Vector3 target, float speed, bool control);
}
