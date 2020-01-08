using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EscapeReality.Shrink
{
    public enum MorphType
    {
        Shrink,
        Rise
    }

    public class Morph
    {
        private Vector3 target;
        private MorphType morphType;
    }
}