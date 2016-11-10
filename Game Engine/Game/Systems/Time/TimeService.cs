using Game_Engine.Engine.Logman;
using Game_Engine.Engine.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Engine.Game.Systems.Time
{
    class TimeService : Service
    {
        public float TimeMultiplier { get; private set; } = 5f;
        private double _internalTime = 0;
        private double currentTime;
        public double CurrentTime
        {
            get
            {
                return currentTime;
            }
            private set
            {
                currentTime = value;
            }
        }
        public override void Init()
        {
            Message.On("use-time", new Services.ServiceManager.ServiceMessage.MessageAct(UseTime));
        }

        internal override void Update(double delta)
        {
            _internalTime += delta;
            if (_internalTime >= 1)
            {
                Logger.Log(LogLevel.Debug, $"One real second = {_internalTime}, five IG second = {CurrentTime}");
                CurrentTime += TimeMultiplier;
                _internalTime = 0;
            }
        }

        private void UseTime(object[] o)
        {

        }
    }
}
