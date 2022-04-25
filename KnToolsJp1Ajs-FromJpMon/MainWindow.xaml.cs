using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Path = System.IO.Path;
using Directory = System.IO.Directory;
using OpenFileDialog = System.Windows.Forms.OpenFileDialog;
using System.Diagnostics;

namespace KnToolsJp1Ajs_FromJpMon
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Jp1AjsBookFolder.Text = Directory.GetCurrentDirectory();
        }

        /// <summary>
        /// 終了
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnMenuExit(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// HelpのAboutウィンドウ表示
        /// </summary>
        private void OnMenuAbout(object sender, RoutedEventArgs e)
        {
            var _childWindow = new About();
            _childWindow.ShowDialog();
        }


        private void Button_Click_SelectJp1AjsBookFolder(object sender, RoutedEventArgs e)
        {
            // OpenFileDialog クラスのインスタンスを生成
            var openFileDialog = new OpenFileDialog();

            string dir = Jp1AjsBookFolder.Text;

            //Default ファイル名
            openFileDialog.FileName = "select folder";

            //Default ファイルの種類
            openFileDialog.DefaultExt = ".xlsx";

            //ファイルの種類リストを設定
            openFileDialog.Filter = "Folder|.";

            //存在しないといけないか？を指定
            openFileDialog.CheckFileExists = false;

            //
            openFileDialog.Title = "ディレクトリの指定";

            // テキストボックスにファイル名 (ファイルパス) が設定されている場合は
            // ファイルのディレクトリー (フォルダー) を初期表示する
            if (!string.IsNullOrWhiteSpace(dir))
            {
                // 存在する場合は InitialDirectory プロパティに設定
                string fileDir = Path.GetDirectoryName(dir);
                if (Directory.Exists(fileDir))
                {
                    openFileDialog.InitialDirectory = fileDir;
                }
            }

            // ダイアログを表示
            DialogResult dialogResult = openFileDialog.ShowDialog();
            if (dialogResult == System.Windows.Forms.DialogResult.Cancel)
            {
                // キャンセルされたので終了
                return;
            }

            // 選択されたファイル名 (ファイルパス) をテキストボックスに設定
            Jp1AjsBookFolder.Text = Path.GetDirectoryName(openFileDialog.FileName);
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_MakeKnowServers(object sender, RoutedEventArgs e)
        {
            var list = new Servers();

            if ((bool)Server1.IsChecked) { list.AddNewServer(Server1.Content.ToString()); }
            if ((bool)Server2.IsChecked) { list.AddNewServer(Server2.Content.ToString()); }
            if ((bool)Server3.IsChecked) { list.AddNewServer(Server3.Content.ToString()); }

            string dir = Jp1AjsBookFolder.Text;
            Debug.WriteLine("Directory:" + dir);
            
            foreach (var server in list.SeverList)
            {
                //Server AJS名を取る
                Debug.WriteLine("Server:"+server);
                //Jp1AjsBookを作成する
                ;
            }

            ;
        }

        private void Button_Click_MakeListServers(object sender, RoutedEventArgs e)
        {

            //var _childWindow = new SelectSeverAjs(Jp1AjsBookFolder.Text);
            var _childWindow = new SelectSeverAjs();

            _childWindow.ShowDialog();


        }


    }
}
