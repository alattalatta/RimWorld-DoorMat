using System.Linq;
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
            if (! this.IsHashIntervalTick(10))
            {
                return;
            }
            foreach (var rect in this.OccupiedRect())
            {
                if (rect.Impassable(Map))
                {
                    continue;
                }
                
                var pawns = Map.thingGrid.ThingsAt(rect)
                    .Where(s => s.GetType() == typeof(Pawn))
                    .Cast<Pawn>();
                foreach (var pawn in pawns)
                {
                    pawn?.filth.GetType().GetMethod("TryDropFilth", BindingFlags.Instance | BindingFlags.NonPublic)
                        .Invoke(pawn.filth, null);
                }
            }
        }

        public override void DrawGUIOverlay()
        {
            //
        }
    }
}