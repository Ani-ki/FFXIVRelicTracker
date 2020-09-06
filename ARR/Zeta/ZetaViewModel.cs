﻿using FFXIVRelicTracker.ARR.ARR;
using FFXIVRelicTracker.Helpers;
using FFXIVRelicTracker.Models;
using FFXIVRelicTracker.Models.ARR;
using FFXIVRelicTracker.Models.Helpers;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows.Input;

namespace FFXIVRelicTracker.ARR.Zeta 
{
    class ZetaViewModel: ObservableObject, IPageViewModel
    {
        private IEventAggregator iEventAggregator;
        private ZetaModel zetaModel;
        private Character selectedCharacter;
        private ArrWeapon arrWeapon;
        private ObservableCollection<string> availableZetaJobs;

        public ZetaViewModel(IEventAggregator iEventAggregator)
        {
            this.iEventAggregator = iEventAggregator;
            SubscriptionToken subscriptionToken =
                            this
                                .iEventAggregator
                                .GetEvent<PubSubEvent<Character>>()
                                .Subscribe((details) =>
                                {
                                    this.SelectedCharacter = details;
                                });
            iEventAggregator.GetEvent<PubSubEvent<ArrWeapon>>().Subscribe((details) => { this.ArrWeapon = details; });
        }

        #region Properties
        public string Name => "Zodiac Zeta";

        public ZetaModel ZetaModel
        {
            get { return zetaModel; }
            set
            {
                zetaModel = value;
                OnPropertyChanged(nameof(ZetaModel));
            }
        }

        public Character SelectedCharacter
        {
            get { return selectedCharacter; }
            set
            {
                selectedCharacter = value;

                OnPropertyChanged(nameof(SelectedCharacter));
                if (value != null)
                {
                    zetaModel = SelectedCharacter.ArrProgress.ZetaModel;
                    ArrWeapon = SelectedCharacter.ArrProgress.Arr;
                }
            }
        }
        public ArrWeapon ArrWeapon
        {
            get { return arrWeapon; }
            set
            {
                arrWeapon = value;
                OnPropertyChanged(nameof(ArrWeapon));
                LoadAvailableJobs();
            }
        }

        public ObservableCollection<string> AvailableZetaJobs
        {
            get { return availableZetaJobs; }
            set
            {
                availableZetaJobs = value;
                OnPropertyChanged(nameof(AvailableZetaJobs));
            }
        }

        public string CurrentZeta
        {
            get { return ZetaModel.CurrentZeta; }
            set
            {
                if (zetaModel.CurrentZeta != value) { ResetBools(); }

                ZetaModel.CurrentZeta = value;
                OnPropertyChanged(nameof(CurrentZeta));
            }
        }

        #region Light
        public string LightError
        {
            get { return lightError; }
            set
            {
                lightError = value;
                OnPropertyChanged(nameof(LightError));
            }
        }

        public string CurrentLightString
        {
            get { return currentLightString; }
            set
            {
                LightError = "";
                currentLightString = value;
                OnPropertyChanged(nameof(CurrentLightString));
                if (CurrentLight.ToString() != value & value != "")
                {
                    try
                    {
                        CurrentLight = Int32.Parse(value);
                    }
                    catch (FormatException)
                    {
                        LightError = "Enter numeric values only";
                    }
                }
                else if (value == "")
                {
                    CurrentLight = 0;
                }

            }
        }

        public int CurrentLight
        {
            get { return zetaModel.CurrentLight; }
            set
            {
                if (value >= 0 & value <= 100)
                {
                    zetaModel.CurrentLight = value;
                    if (value.ToString() != CurrentLightString)
                    {
                        CurrentLightString = value.ToString();
                    }
                    OnPropertyChanged(nameof(CurrentLight));
                    UpdateActivity();
                }
            }
        }
        public string ZetaActivity
        {
            get { return zetaModel.ZetaActivity; }
            set
            {
                zetaModel.ZetaActivity = value;
                OnPropertyChanged(nameof(ZetaActivity));
            }
        }
        #endregion

        #region Bools
        public BoolObject RamVisibility
        {
            get { return ZetaModel.ramVisibility; }
            set
            {
                ZetaModel.ramVisibility = value;
                OnPropertyChanged(nameof(RamVisibility));
            }
        }
        public BoolObject BullVisibility
        {
            get { return ZetaModel.bullVisibility; }
            set
            {
                ZetaModel.bullVisibility = value;
                OnPropertyChanged(nameof(BullVisibility));
            }
        }
        public BoolObject TwinsVisibility
        {
            get { return ZetaModel.twinsVisibility; }
            set
            {
                ZetaModel.twinsVisibility = value;
                OnPropertyChanged(nameof(TwinsVisibility));
            }
        }
        public BoolObject CrabVisibility
        {
            get { return ZetaModel.crabVisibility; }
            set
            {
                ZetaModel.crabVisibility = value;
                OnPropertyChanged(nameof(CrabVisibility));
            }
        }
        public BoolObject LionVisibility
        {
            get { return ZetaModel.lionVisibility; }
            set
            {
                ZetaModel.lionVisibility = value;
                OnPropertyChanged(nameof(LionVisibility));
            }
        }
        public BoolObject MaidenVisibility
        {
            get { return ZetaModel.maidenVisibility; }
            set
            {
                ZetaModel.maidenVisibility = value;
                OnPropertyChanged(nameof(MaidenVisibility));
            }
        }
        public BoolObject ScalesVisibility
        {
            get { return ZetaModel.scalesVisibility; }
            set
            {
                ZetaModel.scalesVisibility = value;
                OnPropertyChanged(nameof(ScalesVisibility));
            }
        }
        public BoolObject ScorpionVisibility
        {
            get { return ZetaModel.scorpionVisibility; }
            set
            {
                ZetaModel.scorpionVisibility = value;
                OnPropertyChanged(nameof(ScorpionVisibility));
            }
        }
        public BoolObject ArcherVisibility
        {
            get { return ZetaModel.archerVisibility; }
            set
            {
                ZetaModel.archerVisibility = value;
                OnPropertyChanged(nameof(ArcherVisibility));
            }
        }
        public BoolObject GoatVisibility
        {
            get { return ZetaModel.goatVisibility; }
            set
            {
                ZetaModel.goatVisibility = value;
                OnPropertyChanged(nameof(GoatVisibility));
            }
        }
        public BoolObject Water_bearerVisibility
        {
            get { return ZetaModel.water_bearerVisibility; }
            set
            {
                ZetaModel.water_bearerVisibility = value;
                OnPropertyChanged(nameof(Water_bearerVisibility));
            }
        }
        public BoolObject FishVisibility
        {
            get { return ZetaModel.fishVisibility; }
            set
            {
                ZetaModel.fishVisibility = value;
                OnPropertyChanged(nameof(FishVisibility));
            }
        }
        #endregion
        #endregion

        #region Methods

        private void ResetLight()
        {
            LightError = "";
            CurrentLightString = "0";
            CurrentLight = 0;
            ZetaActivity = "No Sense";
        }

        private void UpdateActivity()
        {
            switch (CurrentLight)
            {
                case int n when n >= 40:
                    ZetaActivity = "Full Soul Resonance (Complete)";
                    break;
                case int n when n >= 36:
                    ZetaActivity = "Extreme Sense";
                    break;
                case int n when n >= 32:
                    ZetaActivity = "Intense Sense";
                    break;
                case int n when n >= 28:
                    ZetaActivity = "Vigorous Sense";
                    break;
                case int n when n >= 24:
                    ZetaActivity = "Robust Sense";
                    break;
                case int n when n >= 20:
                    ZetaActivity = "Distinct Sense";
                    break;
                case int n when n >= 16:
                    ZetaActivity = "Modest Sense";
                    break;
                case int n when n >= 12:
                    ZetaActivity = "Slight Sense";
                    break;
                case int n when n >= 8:
                    ZetaActivity = "Faint Sense";
                    break;
                case int n when n >= 4:
                    ZetaActivity = "Indistinct Sense";
                    break;
                default:
                    ZetaActivity = "No Sense";
                    break;
            }
        }
        private void LoadAvailableJobs()
        {
            AvailableZetaJobs = new ObservableCollection<string>();
            {

                foreach (ArrStages job in ArrWeapon)
                {
                    if (job.Braves.Progress == ArrProgress.States.Completed & job.Zeta.Progress != ArrProgress.States.Completed)
                    {
                        AvailableZetaJobs.Add(job.Name);
                        if (job.Zeta.Progress == ArrProgress.States.Initiated)
                        {
                            CurrentZeta = job.Name;
                        }
                    }
                }
            }
        }
        private void ResetBools()
        {
            RamVisibility.Bool = false;
            BullVisibility.Bool = false;
            TwinsVisibility.Bool = false;
            CrabVisibility.Bool = false;
            LionVisibility.Bool = false;
            MaidenVisibility.Bool = false;
            ScalesVisibility.Bool = false;
            ScorpionVisibility.Bool = false;
            ArcherVisibility.Bool = false;
            GoatVisibility.Bool = false;
            Water_bearerVisibility.Bool = false;
            FishVisibility.Bool = false;

            ResetLight();
        }
        #endregion

        #region Commands
        private ICommand _AddPointsButton;
        #region Add Light Command
        public ICommand AddPointsButton
        {
            get
            {
                if (_AddPointsButton == null)
                {
                    _AddPointsButton = new RelayCommand(
                        param => this.AddCommand(param),
                        param => this.CanAdd()
                        );
                }
                return _AddPointsButton;
            }
        }

        private bool CanAdd() { return true; }
        private void AddCommand(object param)
        {
            CurrentLight += Int32.Parse((string)param);
        }
        #endregion

        #region Complete Button
        private ICommand _CompleteButton;

        public ICommand CompleteButton
        {
            get
            {
                if (_CompleteButton == null)
                {
                    _CompleteButton = new RelayCommand(
                        param => this.CompleteCommand(param),
                        param => this.CanComplete()
                        );
                }
                return _CompleteButton;
            }
        }

        private bool CanComplete() { return CurrentZeta != null; }
        private void CompleteCommand(object param)
        {

            ArrStages arrStages = ArrWeapon.JobList[ArrWeapon.JobListString.IndexOf(CurrentZeta)];
            arrStages.Zeta.Progress = ArrProgress.States.Completed;
            ResetBools();
            LoadAvailableJobs();
        }
        #endregion
        #region Toggle Button
        private ICommand _ToggleButton;
        private string currentLightString;
        private string lightError;

        public ICommand ToggleButton
        {
            get
            {
                if (_ToggleButton == null)
                {
                    _ToggleButton = new RelayCommand(
                        param => this.ToggleCommand(param),
                        param => this.CanToggle()
                        );
                }
                return _ToggleButton;
            }
        }

        private bool CanToggle() { return true; }
        private void ToggleCommand(object param)
        {
            BoolObject tempbool = (BoolObject)param;
            tempbool.Bool = !tempbool.Bool;
            ResetLight();
        }

        #endregion
        #endregion
    }
}