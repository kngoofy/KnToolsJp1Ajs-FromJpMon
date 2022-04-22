using System;
using System.Collections.Generic;
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
    /// CheckTreeView.xaml の相互作用ロジック
    /// </summary>
    public partial class CheckTreeView : TreeView
    {
        public CheckTreeView()
        {
            InitializeComponent();
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            var checkBox = (CheckBox)sender;
            var source = (CheckTreeSource)checkBox.DataContext;

            source.UpdateChildStatus();
            source.UpdateParentStatus();
        }

    }
}
