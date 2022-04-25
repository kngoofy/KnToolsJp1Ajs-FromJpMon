using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace KnToolsJp1Ajs_FromJpMon
{
    /// <summary>
    /// SelectSeverAjs.xaml の相互作用ロジック
    /// </summary>
    public partial class SelectSeverAjs : Window
    {
        public ObservableCollection<CheckTreeSource> TreeRoot { get; set; }

        //public SelectSeverAjs()
        //{
        //    InitializeComponent();
        //}
        
        /// <summary>
        /// 初期コンポーネント
        /// </summary>
        /// <param name="dir"></param>
        public SelectSeverAjs(string dir=@"c:\temp")
        {
            InitializeComponent();

        }

        /// <summary>
        /// 
        /// </summary>
        private void Button_Click_Exit(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_UpdateList(object sender, RoutedEventArgs e)
        {

            TreeRoot = new ObservableCollection<CheckTreeSource>();
            var item1 = new CheckTreeSource() { Text = "Server1", IsExpanded = true, IsChecked = false };
            var item11 = new CheckTreeSource() { Text = "ajsServer-1-1", IsExpanded = false, IsChecked = false };
            var item12 = new CheckTreeSource() { Text = "ajsServer-1-2", IsExpanded = false, IsChecked = false };
            var item2 = new CheckTreeSource() { Text = "Server2", IsExpanded = true, IsChecked = false };
            var item21 = new CheckTreeSource() { Text = "ajsServer-2-1", IsExpanded = false, IsChecked = false };
            var item22 = new CheckTreeSource() { Text = "ajsServer-2-2", IsExpanded = false, IsChecked = false };
            TreeRoot.Add(item1);
            TreeRoot.Add(item2);
            item1.Add(item11);
            item1.Add(item12);
            item2.Add(item21);
            item2.Add(item22);

            //AJSサーバを取得

            //  AJSの定義を取得
            //  データ積み込み

            DataContext = this;

            ;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_CreateBook(object sender, RoutedEventArgs e)
        {

            foreach (var level1 in TreeRoot)
            {
                //if (!level1.IsChecked)
                //{
                    foreach (var level2 in (level1.Children.Where(n => n.IsChecked == true).ToList()))
                    {
                        Debug.WriteLine("{0},{1}", level1.Text, level2.Text);
                    }
                //}
                
            }
            ;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {

            ;
        }
    }
}
