﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnToolsJp1Ajs_FromJpMon
{
    public class CheckTreeSource : INotifyPropertyChanged
    {
        //
        private bool _IsExpanded = true;
        private bool? _IsChecked = false;
        private string _Text = "";
        private CheckTreeSource _Parent = null;
        private ObservableCollection<CheckTreeSource> _Children = null;


        public bool IsExpanded
        {
            get { return _IsExpanded; }
            set { _IsExpanded = value; OnPropertyChanged("IsExpanded"); }
        }

        public bool? IsChecked
        {
            get { return _IsChecked; }
            set { _IsChecked = value; OnPropertyChanged("IsChecked"); }
        }

        public string Text
        {
            get { return _Text; }
            set { _Text = value; OnPropertyChanged("Text"); }
        }

        public CheckTreeSource Parent
        {
            get { return _Parent; }
            set { _Parent = value; OnPropertyChanged("Parent"); }
        }

        public ObservableCollection<CheckTreeSource> Children
        {
            get { return _Children; }
            set { _Children = value; OnPropertyChanged("Childen"); }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        private void OnPropertyChanged(string name)
        {
            if (null == this.PropertyChanged) return;
            this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="child"></param>
        public void Add(CheckTreeSource child)
        {
            if (null == Children) Children = new ObservableCollection<CheckTreeSource>();
            child.Parent = this;
            Children.Add(child);
        }

        /// <summary>
        /// 
        /// </summary>
        public void UpdateParentStatus()
        {
            if (null != Parent)
            {
                int isCheckedNull = 0;
                int isCheckedOn = 0;
                int isCheckedOff = 0;
                if (null != Parent.Children)
                {
                    foreach (var item in Parent.Children)
                    {
                        if (null == item.IsChecked) isCheckedNull += 1;
                        if (true == item.IsChecked) isCheckedOn += 1;
                        if (false == item.IsChecked) isCheckedOff += 1;
                    }
                }
                if ((0 < isCheckedNull) || (0 < isCheckedOn) || (0 < isCheckedOff))
                {
                    if (0 < isCheckedNull)
                        Parent.IsChecked = null;
                    else if ((0 < isCheckedOn) && (0 < isCheckedOff))
                        Parent.IsChecked = null;
                    else if (0 < isCheckedOn)
                        Parent.IsChecked = true;
                    else
                        Parent.IsChecked = false;
                }
                Parent.UpdateParentStatus();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void UpdateChildStatus()
        {
            if (null != IsChecked)
            {
                if (null != Children)
                {
                    foreach (var item in Children)
                    {
                        item.IsChecked = IsChecked;
                        item.UpdateChildStatus();
                    }
                }
            }
        }

    }
}
