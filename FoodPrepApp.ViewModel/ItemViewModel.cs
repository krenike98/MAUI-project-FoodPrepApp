using FoodPrepApp.Model;
using FoodPrepApp.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodPrepApp.ViewModel
{
    public class ItemViewModel : BindingSource
    {
        private Item item;
        private int _numberOfPortions;

        public int numberOfPortions
        {
            get => _numberOfPortions;
            set
            {
                if (_numberOfPortions != value)
                {
                    _numberOfPortions = value;
                    OnPropertyChanged(nameof(numberOfPortions));
                }
            }
        }


        public Guid id { get; }
        public string name { get; set; }
        public string description { get; set; }
        public DateTime expirationDate { get; set; }

        public DelegateCommand IncreaseCommand { get; private set; }
        public DelegateCommand DecreaseCommand { get; private set; }
        public ItemViewModel(Item item)
        {
            this.id = item.Id;
            this.name = item.Name;
            this.expirationDate = item.ExpirationDate;
            this.numberOfPortions = item.NumberOfPortions;
            this.description = item.Description;

            this.item = item;
             
            IncreaseCommand = new DelegateCommand(Increase);
            DecreaseCommand = new DelegateCommand(Decrease);
        }

        private void Increase(object? param)
        {
            this.numberOfPortions++;
            item.NumberOfPortions++;
        }

        private void Decrease(object? param)
        {
            if (numberOfPortions > 0)
            {
                item.NumberOfPortions--;
                this.numberOfPortions--;
            }
        }

    }
}
