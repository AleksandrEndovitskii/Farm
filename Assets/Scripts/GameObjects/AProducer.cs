﻿using System;
using GameObjects.Utils;
using Managers;
using UnityEngine;

namespace GameObjects
{
    public abstract class AProducer : IProducer, IProgressive
    {
        public Action<float> ProgressChanged = delegate { };
        public Action ProductionIsReady = delegate { };
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

        public abstract int ProductionDuration { get; }

        public float Progress
        {
            get
            {
                var progress = ((float)ProductionDuration - (float)WillProduceAfterSecondsCount) / (float)ProductionDuration;

                return progress;
            }
        }

        public AProducer()
        {
            GameManager.Instance.TimeManager.SecondPassed += TimeManagerOnSecondPassed;
            WillProduceAfterSecondsCountChanged += OnWillProduceAfterSecondsCountChanged;

            ResetWillProduceAfterSecondsCount();
        }

        public abstract void ResetWillProduceAfterSecondsCount();

        public virtual void TryProduceProduct()
        {
            WillProduceAfterSecondsCount--;

            if (WillProduceAfterSecondsCount == 0)
            {
                ResetWillProduceAfterSecondsCount();

                Debug.Log(string.Format("Production {0} is ready.", this.GetType().Name));

                ProductionIsReady.Invoke();
            }
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