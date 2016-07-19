using System.Reflection;
using Verse;

namespace LT
{
    public class Building_DoorMat : Building
    {
        public override void Tick()
        {
            base.Tick();
            if(!Gen.IsHashIntervalTick(this, 10))
            {
                return;
            }
            //Execute every 10 ticks
            foreach(var current in this.OccupiedRect())
            {
                if(current.Impassable())
                {
                    continue;
                }
                var pawn = Find.Map.thingGrid.ThingAt<Pawn>(current);
                if(pawn != null)
                {
                    pawn.filth.GetType().GetMethod("TryDropFilth", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(pawn.filth, null);
                }
            }
        }
    }
}
