using System;
using GameObjects.Utils;
using Managers;
using UnityEngine;

namespace GameObjects
{
    public abstract class AProducer<T> : IProducer, IProgressive where T : class, IProduction, new()
    {
        public Action<float> ProgressChanged { get; set; }
        public Action<IProduction> ProductionIsReady = delegate { };
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

        public IProduction Production { get; private set; }

        public int ProductionDuration
        {
            get
            {
                return GameManager.Instance.ProductionDurationDictionaryService
                    .GetProductionDuration<T>();
            }
        }

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

        public void ResetWillProduceAfterSecondsCount()
        {
            WillProduceAfterSecondsCount = GameManager.Instance.ProductionDurationDictionaryService
                .GetProductionDuration<T>();
        }

        public virtual void TryProduceProduct()
        {
            if (Production != null) // already have production - cant produce more
            {
                return;
            }

            WillProduceAfterSecondsCount--;

            if (WillProduceAfterSecondsCount == 0)
            {
                Production = new T();

                Debug.Log(string.Format("{0} has produced {1}.", this.GetType().Name, Production.GetType().Name));

                ProductionIsReady.Invoke(Production);
            }
        }

        public IProduction TryCollectProduction()
        {
            var production = Production;
            Production = null;
            if (production != null) // production was gathered and will be given away - need to start new production
            {
                ResetWillProduceAfterSecondsCount(); 
            }
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
