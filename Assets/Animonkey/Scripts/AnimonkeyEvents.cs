namespace Animonkey.Animonkey
{
    public static class AnimonkeyEvents
    {
        public delegate void AnimonkeyEvent();
        
        /// <summary>
        /// This method runs on every frame of the animation for every loop.
        /// </summary>
        /// <param name="animonkey"></param>
        /// <param name="onUpdateCallback"></param>
        /// <returns></returns>
        public static AnimonkeyEvent OnUpdate(this Animonkey animonkey, AnimonkeyEvent onUpdateCallback)
        {
            animonkey.onUpdate = onUpdateCallback;
            return animonkey.onUpdate;
        }
        
        /// <summary>
        /// This method runs once for each animation. It doesn't work in every loop.
        /// </summary>
        /// <param name="animonkey"></param>
        /// <param name="onCompleteCallback"></param>
        /// <returns></returns>
        public static AnimonkeyEvent OnComplete(this Animonkey animonkey, AnimonkeyEvent onCompleteCallback)
        {
            animonkey.onComplete = onCompleteCallback;
            return animonkey.onComplete;
        }

        public static void ClearAllEvents(this Animonkey animonkey)
        {
            animonkey.onComplete = null;
            animonkey.onUpdate = null;
        }
    }
}