﻿using FFXIVRelicTracker.ARR.Animus;
using FFXIVRelicTracker.ARR.ArrHelpers;
using FFXIVRelicTracker.ARR.Atma;
using FFXIVRelicTracker.ARR.Braves;
using FFXIVRelicTracker.ARR.Nexus;
using FFXIVRelicTracker.ARR.Novus;
using FFXIVRelicTracker.ARR.Relic;
using FFXIVRelicTracker.ARR.Zeta;
using FFXIVRelicTracker.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Text;
using System.Windows;

namespace FFXIVRelicTracker.Models
{
    public class ArrModel:ObservableObject
    {
        private ArrWeapon arrWeapon;
        private RelicModel relicModel;
        private AtmaModel atmaModel;
        private AnimusModel animusModel;
        private NovusModel novusModel;
        private NexusModel nexusModel;
        private BravesModel bravesModel;
        private ZetaModel zetaModel;

        public ArrModel()
        {
            ArrWeapon = new ArrWeapon();
            RelicModel = new RelicModel();
            AtmaModel = new AtmaModel();
            AnimusModel = new AnimusModel();
            NovusModel = new NovusModel();
            NexusModel = new NexusModel();
            BravesModel = new BravesModel();
            ZetaModel = new ZetaModel();
        }
        public ArrWeapon ArrWeapon
        {
            get { return arrWeapon; }
            set
            {
                if(value!=null)
                {
                    arrWeapon = value;
                    OnPropertyChanged(nameof(ArrWeapon));
                }
            }
        }

        #region Stage Models
        public RelicModel RelicModel
        {
            get { return relicModel; }
            set
            {
                if (value != null)
                {
                    relicModel = value;
                    OnPropertyChanged(nameof(RelicModel));
                }
            }
        }

        public AtmaModel AtmaModel
        {
            get { return atmaModel; }
            set
            {
                if (value != null)
                {
                    atmaModel = value;
                    OnPropertyChanged(nameof(AtmaModel));
                }
            }
        }

        public AnimusModel AnimusModel
        {
            get { return animusModel; }
            set
            {
                if (value != null)
                {
                    animusModel = value;
                    OnPropertyChanged(nameof(AnimusModel));
                }
            }
        }

        public NovusModel NovusModel
        {
            get { return novusModel; }
            set
            {
                if (value != null)
                {
                    novusModel = value;
                    OnPropertyChanged(nameof(NovusModel));
                }
            }
        }

        public NexusModel NexusModel
        {
            get { return nexusModel; }
            set
            {
                if (value != null)
                {
                    nexusModel = value;
                    OnPropertyChanged(nameof(NexusModel));
                }
            }
        }
        public BravesModel BravesModel
        {
            get { return bravesModel; }
            set
            {
                if (value != null)
                {
                    bravesModel = value;
                    OnPropertyChanged(nameof(BravesModel));
                }
            }
        }
        public ZetaModel ZetaModel
        {
            get { return zetaModel; }
            set
            {
                if (value != null)
                {
                    zetaModel = value;
                    OnPropertyChanged(nameof(ZetaModel));
                }
            }
        }

        #endregion
        
    }
}
