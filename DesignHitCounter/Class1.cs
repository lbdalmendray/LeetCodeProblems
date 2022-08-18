namespace DesignHitCounter
{
    public class HitCounter
    {
        private readonly LinkedList<(int, int)> hitList ;
        private int counter = 0;
        private Object lockObject = new object();
        private readonly int maxTime = 300;
        public HitCounter()
        {
            hitList = new LinkedList<(int, int)>();
        }

        public void Hit(int timestamp)
        {
            lock(lockObject)
            {
                if(hitList.First == null || hitList.First.Value.Item1 != timestamp)
                {
                    hitList.AddFirst((timestamp, 1));
                }
                else
                {
                    (_, int count) = hitList.First.Value;
                    hitList.RemoveFirst();
                    hitList.AddFirst((timestamp, count + 1));
                }
                counter++;

                Task.Factory.StartNew(()=> UpdateHitListBy300Seconds(timestamp));
            }
        }        

        public int GetHits(int timestamp)
        {
            lock (lockObject)
            {
                UpdateHitListBy300SecondsNoLock(timestamp);
                return counter;
            }
        }

        private void UpdateHitListBy300Seconds(int timeSpan)
        {
            lock (lockObject)
            {
                UpdateHitListBy300SecondsNoLock(timeSpan);
            }
        }

        private void UpdateHitListBy300SecondsNoLock(int timeSpan)
        {
            while(true)
            {
                if (hitList.Last == null)
                    break;

                (int timeSpanValue, int count) = hitList.Last.Value;
                if (timeSpanValue > timeSpan - maxTime)
                    break;
                else
                {
                    counter -= count;
                    hitList.RemoveLast();
                }
            }
        }
    }
}