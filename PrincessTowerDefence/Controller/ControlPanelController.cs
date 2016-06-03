using PrincessTowerDefence.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PrincessTowerDefence.Controller
{
    public class ControlPanelController : ControllerBase
    {
        public ArsenalModel Arsenal { get; set; }
        public ICommand ChooseBlue { get; set; }
        public ICommand ChoosePink { get; set; }
        public ICommand ChooseYellow { get; set; }
        public PrincessModel ChosenPrincess { get; set; }
        public int TimeLeft { get; set; }

        public ControlPanelController()
        {
            Arsenal = new ArsenalModel();
            ChooseBlue = new RelayCommand(SelectBlue);
            ChoosePink = new RelayCommand(SelectPink);
            ChooseYellow = new RelayCommand(SelectYellow);
            ChosenPrincess = null;
            TimeLeft = 66;
        }

        public void Update()
        {
            OnPropertyChanged("TimeLeft");
            OnPropertyChanged("Arsenal");
        }

        private void SelectBlue()
        {
            ChosenPrincess = GetPrincessFromArsenal(PrincessType.Blue);
        }
        private void SelectPink()
        {
            ChosenPrincess = GetPrincessFromArsenal(PrincessType.Pink);
        }
        private void SelectYellow()
        {
            ChosenPrincess = GetPrincessFromArsenal(PrincessType.Yellow);
        }

        private PrincessModel GetPrincessFromArsenal(PrincessType type)
        {
            PrincessModel princess = null;
            ObservableCollection<PrincessModel> princesses = new ObservableCollection<PrincessModel>();
            switch(type)
            {
                case PrincessType.Blue:
                    princesses = Arsenal.BluePrincesses;
                    break;
                case PrincessType.Pink:
                    princesses = Arsenal.PinkPrincesses;
                    break;
                case PrincessType.Yellow:
                    princesses = Arsenal.YellowPrincesses;
                    break;
            }

            if(princesses.Count > 0)
            {
                princess = princesses[0];
    
                princesses.RemoveAt(0);
            }

            return princess;
        }
    }
}
