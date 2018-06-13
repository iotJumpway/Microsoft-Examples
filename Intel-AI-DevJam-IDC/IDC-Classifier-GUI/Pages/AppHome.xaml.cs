using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Graphics.Imaging;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Search;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace IDC_Classifier_GUI
{
    /// <summary>
    /// Classification gallery
    /// </summary>
    public sealed partial class AppHome : Page
    {
        public AppHome()
        {
            this.InitializeComponent();
            this.DisplayAllFiles();
        }

        private async Task DisplayAllFiles()
        {
            Debug.WriteLine("-- GETTING FILES");
            StorageFolder appInstalledFolder = Windows.ApplicationModel.Package.Current.InstalledLocation;
            StorageFolder dataFolder = await appInstalledFolder.GetFolderAsync("Data");
            IReadOnlyList<StorageFile> fileList = await dataFolder.GetFilesAsync();

            this.ImageHolder.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Auto });
            this.ImageHolder.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength() });
            this.ImageHolder.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength() });
            this.ImageHolder.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength() });
            this.ImageHolder.RowDefinitions.Add(new RowDefinition() { Height = new GridLength() });

            var result = new ObservableCollection<BitmapImage>();
            var i = 0;
            int row = 0;
            foreach (StorageFile file in fileList)
            {
                Debug.WriteLine(file.Name);
                using (var stream = await file.OpenAsync(FileAccessMode.Read))
                {
                    var bitmapDecoder = await BitmapDecoder.CreateAsync(stream);
                    var pixelProvider = await bitmapDecoder.GetPixelDataAsync();
                    var bits = pixelProvider.DetachPixelData();
                    var softwareBitmap = new SoftwareBitmap(
                      BitmapPixelFormat.Bgra8,
                      (int)bitmapDecoder.PixelWidth,
                      (int)bitmapDecoder.PixelHeight,
                      BitmapAlphaMode.Premultiplied);
                    softwareBitmap.CopyFromBuffer(bits.AsBuffer());

                    var softwareBitmapSource = new SoftwareBitmapSource();
                    await softwareBitmapSource.SetBitmapAsync(softwareBitmap);

                    var source = new SoftwareBitmapSource();
                    await source.SetBitmapAsync(softwareBitmap);

                    Image image = new Image();
                    image.Source = softwareBitmapSource;
                    image.Name = file.Name;
                    image.Width = 250;
                    image.Height = 250;
                    image.SetValue(Grid.ColumnProperty, i);
                    image.SetValue(Grid.RowProperty, row);
                    this.ImageHolder.Children.Add(image);

                    if (i != 0 && i % 4 == 0)
                    {
                        Debug.WriteLine("-- New Image Row "+ row);
                        this.ImageHolder.RowDefinitions.Add(
                            new RowDefinition() { Height = GridLength.Auto });
                        i = -1;
                        row++;
                    }

                    i++;
                }

                this.ImageHolder.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength() });
                Button button = new Button();
                button.Content = "Classify All Images";
                //button.Click += SubscribeButton_Click;
                button.Width = 250;
                button.Height = 75;
                button.Foreground = new SolidColorBrush(Windows.UI.Colors.Black);
                button.SetValue(Grid.ColumnProperty, 5);
                button.SetValue(Grid.RowProperty, 0);
                this.ImageHolder.Children.Add(button);
            }

        }
        private async Task GetFolders()
        {
            Debug.WriteLine("-- GETTING FOLDERS");
            StorageFolder appInstalledFolder = Windows.ApplicationModel.Package.Current.InstalledLocation;
            StorageFolder dataFolder = await appInstalledFolder.GetFolderAsync("Data");
            IReadOnlyList<StorageFolder> folderList = await dataFolder.GetFoldersAsync();

            foreach (StorageFolder folder in folderList)
            {
                Debug.WriteLine(folder.DisplayName);
            }

        }
        private async Task ChooseImages()
        {

            Debug.WriteLine("-- CHOOSE IMAGES");
            FolderPicker folderpicker = new FolderPicker();
            folderpicker.FileTypeFilter.Add("*");
            StorageFolder tmpfolder = await folderpicker.PickSingleFolderAsync();
            QueryOptions options;

            options = new QueryOptions(CommonFileQuery.DefaultQuery, new[] { ".png", ".jpg", ".bmp", ".tiff", ".jpeg", ".gif" });
            options.FolderDepth = FolderDepth.Deep;
            StorageFileQueryResult k = tmpfolder.CreateFileQueryWithOptions(options);
            IReadOnlyList<StorageFile> image_files = await k.GetFilesAsync();

        }

        private void Camera_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AppHome));
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }
    }
}
