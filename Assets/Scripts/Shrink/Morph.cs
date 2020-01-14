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

    public struct Morph
    {
        MorphType type;
        public Vector3 target;
        public HashSet<Shrinkable> shrinkablesInHand;

        public Morph(MorphType type, Vector3 target)
        {
            this.type = type;
            this.target = target;
            this.shrinkablesInHand = new HashSet<Shrinkable>();
        }

        public State ResultingState => this.type == MorphType.Shrink ? State.Shrunk : State.Normal;
    }
}
