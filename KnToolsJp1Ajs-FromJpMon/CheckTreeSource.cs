using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnToolsJp1Ajs_FromJpMon
{
    /// <summary>
    /// TreeViewのアイテム 親・子アイテムチェックボックス付きオブジェクト
    /// </summary>
    public class CheckTreeSource : INotifyPropertyChanged
    {
        //フィールド
        private bool _IsExpanded = true;
        private bool? _IsChecked = false;
        private string _Text = "";
        private CheckTreeSource _Parent = null;
        private ObservableCollection<CheckTreeSource> _Children = null;

        //エクスパンドする
        public bool IsExpanded
        {
            get { return _IsExpanded; }
            set { _IsExpanded = value; OnPropertyChanged("IsExpanded"); }
        }

        //チェックする
        public bool? IsChecked
        {
            get { return _IsChecked; }
            set { _IsChecked = value; OnPropertyChanged("IsChecked"); }
        }

        //アイテム名 テキスト
        public string Text
        {
            get { return _Text; }
            set { _Text = value; OnPropertyChanged("Text"); }
        }

        //親アイテム
        public CheckTreeSource Parent
        {
            get { return _Parent; }
            set { _Parent = value; OnPropertyChanged("Parent"); }
        }

        //子アイテム
        public ObservableCollection<CheckTreeSource> Children
        {
            get { return _Children; }
            set { _Children = value; OnPropertyChanged("Childen"); }
        }

        //プロパティ変更されたぞ イベントハンドラ
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// プロパティが変更された時
        /// </summary>
        /// <param name="name"></param>
        private void OnPropertyChanged(string name)
        {
            if (null == this.PropertyChanged) return;
            this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        /// <summary>
        /// 子アイテムを追加する
        /// </summary>
        /// <param name="child"></param>
        public void Add(CheckTreeSource child)
        {
            if (null == Children) Children = new ObservableCollection<CheckTreeSource>();
            child.Parent = this;
            Children.Add(child);
        }

        /// <summary>
        /// 親アイテムのチェックを付ける
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
        /// 子アイテムのチェックを付ける
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
