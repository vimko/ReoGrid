using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace unvell.ReoGrid
{
    /// <summary>
    /// sheet 视图模型
    /// </summary>
    public class SheetViewModel : INotifyPropertyChanged
    {
        #region 事件

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region 属性

        /// <summary>
        /// Sheet name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// data
        /// </summary>
        public ObservableCollection<ObservableCollection<object>> Data { get; set; }

        #endregion

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null && !string.IsNullOrWhiteSpace(propertyName))
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
