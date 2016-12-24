using System.Reflection;
using Verse;

namespace LT
{
    public class Building_DoorMat : Building
    {
        public override void Tick()
        {
            base.Tick();
            // Execute only every 10 ticks
            if (!this.IsHashIntervalTick(10))
            {
                return;
            }
            foreach(var rect in this.OccupiedRect())
            {
                if(rect.Impassable(Map))
                {
                    continue;
                }
                // A pawn over me
                var pawn = Map.thingGrid.ThingAt<Pawn>(rect);
                pawn?.filth.GetType().GetMethod("TryDropFilth", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(pawn.filth, null);
            }
        }
    }
}
