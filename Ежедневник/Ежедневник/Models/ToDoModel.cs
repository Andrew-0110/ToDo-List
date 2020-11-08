using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ежедневник.Models
{
    class ToDoModel : INotifyPropertyChanged
    {
        public DateTime CreationDate { get; set; } = DateTime.Now;
        private bool isDone;
        public bool IsDone
        {
            get { return isDone; }
            set
            {
                if(isDone == value)
                    return;
                isDone = value;
                OnPropertyChanged("IsDone");
            }
        }
        private string text;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Text
        {
            get { return text; }
            set
            {
                if(text == value)
                    return;
                text = value;
                OnPropertyChanged("Text");
            }
        }
        protected virtual void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
