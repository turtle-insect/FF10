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
using System.Windows.Navigation;
using System.Windows.Shapes;
using FF10.Models;
using FF10.ViewModels;
using Microsoft.Win32;

namespace FF10.Views
{
	/// <summary>
	/// MainWindow.xaml の相互作用ロジック
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void Window_PreviewDragOver(object sender, DragEventArgs e)
		{
			e.Handled = e.Data.GetDataPresent(DataFormats.FileDrop);
		}

		private void Window_Drop(object sender, DragEventArgs e)
		{
			String[] files = e.Data.GetData(DataFormats.FileDrop) as String[];
			if (files == null) return;
			if (!System.IO.File.Exists(files[0])) return;

			Load(files[0], false);
		}

		private void MenuItemFileOpen_Click(object sender, RoutedEventArgs e)
		{
			OpenFileDialog dlg = new OpenFileDialog();
			if (dlg.ShowDialog() == false) return;

			Load(dlg.FileName, false);
		}

		private void MenuItemFileOpenForce_Click(object sender, RoutedEventArgs e)
		{
			OpenFileDialog dlg = new OpenFileDialog();
			if (dlg.ShowDialog() == false) return;

			Load(dlg.FileName, true);
		}

		private void MenuItemFileSave_Click(object sender, RoutedEventArgs e)
		{
			Save();
		}

		private void MenuItemFileSaveAs_Click(object sender, RoutedEventArgs e)
		{
			SaveFileDialog dlg = new SaveFileDialog();
			if (dlg.ShowDialog() == false) return;

			if (SaveData.Instance().SaveAs(dlg.FileName) == true) MessageBox.Show(Properties.Resources.MessageSaveSuccess);
			else MessageBox.Show(Properties.Resources.MessageSaveFail);
		}

		private void MenuItemFileImport_Click(object sender, RoutedEventArgs e)
		{
			OpenFileDialog dlg = new OpenFileDialog();
			if (dlg.ShowDialog() == false) return;

			SaveData.Instance().Import(dlg.FileName);
			DataContext = new MainWindowViewModel();
		}

		private void MenuItemFileExport_Click(object sender, RoutedEventArgs e)
		{
			SaveFileDialog dlg = new SaveFileDialog();
			if (dlg.ShowDialog() == false) return;

			SaveData.Instance().Export(dlg.FileName);
		}

		private void MenuItemFileExit_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void MenuItemAbout_Click(object sender, RoutedEventArgs e)
		{
			new AboutWindow().ShowDialog();
		}

		private void ButtonEquipmentItem_Click(object sender, RoutedEventArgs e)
		{
			Equipment equip = (sender as Button)?.DataContext as Equipment;
			var dlg = new ChoiceWindow();
			dlg.ID = equip.ID;
			dlg.Type = ChoiceWindow.eType.eEquipment;
			dlg.ShowDialog();
			equip.ID = dlg.ID;
		}

		private void ButtonItem_Click(object sender, RoutedEventArgs e)
		{
			Item item = (sender as Button)?.DataContext as Item;
			var dlg = new ChoiceWindow();
			dlg.ID = item.ID;
			dlg.ShowDialog();
			item.ID = dlg.ID;
		}

		private void Load(String filename, bool force)
		{
			if (SaveData.Instance().Open(filename, force) == false)
			{
				MessageBox.Show(Properties.Resources.MessageLoadFail);
				return;
			}

			DataContext = new MainWindowViewModel();
			MessageBox.Show(Properties.Resources.MessageLoadSuccess);
		}

		private void Save()
		{
			if (SaveData.Instance().Save() == true) MessageBox.Show(Properties.Resources.MessageSaveSuccess);
			else MessageBox.Show(Properties.Resources.MessageSaveFail);
		}
	}
}
