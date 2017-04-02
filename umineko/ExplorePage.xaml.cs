using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// 空白ページの項目テンプレートについては、https://go.microsoft.com/fwlink/?LinkId=234238 を参照してください

namespace umineko
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class ExplorePage : Page
    {
        public ExplorePage()
        {
            this.InitializeComponent();

            InitFoldersList();
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            ExploreMenuSpliteView.IsPaneOpen = !ExploreMenuSpliteView.IsPaneOpen;
        }

        private ObservableCollection<string> items = new ObservableCollection<string>();

        public ObservableCollection<string> Items
        {
            get { return this.items; }
        }

        public async void InitFoldersList()
        {
            StorageFolder removableDevices = KnownFolders.PicturesLibrary;
            System.Diagnostics.Debug.WriteLine(removableDevices.Name);
            IReadOnlyList<IStorageItem> files = await removableDevices.GetItemsAsync();
            System.Diagnostics.Debug.WriteLine(files);
            foreach ( IStorageItem folder in files )
            {
                System.Diagnostics.Debug.WriteLine(folder.Name);
                Items.Add(folder.Name);
            }
        }
    }
}
