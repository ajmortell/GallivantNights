using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity {

    protected override void OnCantMove<T>(T component) {
        throw new System.NotImplementedException();
    }
    
}
