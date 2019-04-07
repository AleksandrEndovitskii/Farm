using System;
using GameObjects.Utils;
using Managers;
using UnityEngine;

namespace GameObjects
{
    public abstract class AProducer<T> : IProducer<T>, IProgressive where T : class, IProduction, new()
    {
        public Action<float> ProgressChanged { get; set; }
        public Action<T> ProductionIsReady = delegate { };
        public Action WillProduceAfterSecondsCountChanged = delegate { };

        private int _willProduceAfterSecondsCount;
        public int WillProduceAfterSecondsCount
        {
            get
            {
                return _willProduceAfterSecondsCount;
            }
            protected set
            {
                if (_willProduceAfterSecondsCount == value)
                {
                    return;
                }

                _willProduceAfterSecondsCount = value;

                WillProduceAfterSecondsCountChanged.Invoke();
            }
        }

        public T Production { get; private set; }

        public abstract int ProductionDuration { get; }

        public float Progress
        {
            get
            {
                var progress = ((float)ProductionDuration - (float)WillProduceAfterSecondsCount) / (float)ProductionDuration;

                return progress;
            }
        }
        public bool IsReady
        {
            get
            {
                var result = Progress == 1f;

                return result;
            }
        }

        public AProducer()
        {
            ProgressChanged = delegate { };

            GameManager.Instance.TimeManager.SecondPassed += TimeManagerOnSecondPassed;
            WillProduceAfterSecondsCountChanged += OnWillProduceAfterSecondsCountChanged;

            ResetWillProduceAfterSecondsCount();
        }

        public abstract void ResetWillProduceAfterSecondsCount();

        public virtual void TryProduceProduct()
        {
            if (Production != null) // already have production - cant produce more
            {
                return;
            }

            WillProduceAfterSecondsCount--;

            if (WillProduceAfterSecondsCount == 0)
            {
                Debug.Log(string.Format("Production {0} is ready.", this.GetType().Name));
                
                Production = new T();

                ProductionIsReady.Invoke(Production);
            }
        }

        public T CollectProduction()
        {
            var production = Production;
            Production = null;
            ResetWillProduceAfterSecondsCount();
            return production;
        }

        private void TimeManagerOnSecondPassed()
        {
            TryProduceProduct();
        }

        private void OnWillProduceAfterSecondsCountChanged()
        {
            ProgressChanged.Invoke(Progress);
        }
    }
}
