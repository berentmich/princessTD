using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrincessTowerDefence.Model
{
    public class ArsenalModel
    {
        public ObservableCollection<PrincessModel> BluePrincesses { get; set; }
        public ObservableCollection<PrincessModel> YellowPrincesses { get; set; }
        public ObservableCollection<PrincessModel> PinkPrincesses { get; set; }

        public ArsenalModel()
        {
            BluePrincesses = new ObservableCollection<PrincessModel>();
            YellowPrincesses = new ObservableCollection<PrincessModel>();
            PinkPrincesses = new ObservableCollection<PrincessModel>();
        }

        public ArsenalModel(int blue, int yellow, int pink)
        {
            BluePrincesses = new ObservableCollection<PrincessModel>();
            YellowPrincesses = new ObservableCollection<PrincessModel>();
            PinkPrincesses = new ObservableCollection<PrincessModel>();

            for (int i = 0; i < blue; i++)
                BluePrincesses.Add(new PrincessModel(PrincessType.Blue));
            for (int i = 0; i < yellow; i++)
                YellowPrincesses.Add(new PrincessModel(PrincessType.Yellow));
            for (int i = 0; i < pink; i++)
                PinkPrincesses.Add(new PrincessModel(PrincessType.Pink));
        }

    }
}
