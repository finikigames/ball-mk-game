using UnityEngine;

namespace Services.Platform.Base {
    public abstract class BaseInput {
        public virtual void Initialize() {}
        public abstract bool GetJumpState();
        public abstract bool GetJumpEndState();
        public abstract Vector2 GetInputState();
    }
}