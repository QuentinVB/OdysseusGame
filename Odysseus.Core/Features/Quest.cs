using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odysseus.Core
{
    public enum QuestType
    {
        Start,
        End,
    }
    class Quest : Feature
    {
        QuestType _questType;
        public Quest(GameCore core, QuestType questType) : base(core)
        {
            _questType = questType;
        }

        public override string Display {
            get {
                switch (_questType)
                {
                    case QuestType.Start: return "Its the begining";
                    case QuestType.End: Core.PlayerShip.TakeDamage(int.MaxValue); return "Its the end, thanks for playing"; 
                    default: return "wtf ?";
                }
            }
        }


        public override void Answer(int answer)
        {
            Active = false;
        }
    }
}
