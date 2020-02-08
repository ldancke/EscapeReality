using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EscapeReality.Shrink
{
    /**
     * Enum that indicates wheter the morph is shrinking or rising.
     */
    public enum MorphType
    {
        Shrink,
        Rise
    }

    /**
     * Struct that stores all information needed for a morph
     */
    public struct Morph
    {
        /** Indicates what direction the morph is in */
        public MorphType type;
        /** Final size target after the morph */
        public Vector3 target;
        /** Shrinkables that were in the players hands when the morph was initialized */
        public HashSet<Shrinkable> shrinkablesInHand;

        public Morph(MorphType type, Vector3 target)
        {
            this.type = type;
            this.target = target;
            this.shrinkablesInHand = new HashSet<Shrinkable>();
        }

        /** State the object will be in after the morph is done */
        public State ResultingState => this.type == MorphType.Shrink ? State.Shrunk : State.Normal;
    }
}
