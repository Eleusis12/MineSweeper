using FastMember;
using Library.Helpers;
using Microsoft.Toolkit.Uwp.UI.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MineSweeperUWP.View
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class LeaderBoardPage : Page
	{
		public event NotificationTaskHandler AskListViewItems;

		public LeaderBoardPage()
		{
			this.InitializeComponent();

			if (AskListViewItems != null)
			{
				AskListViewItems();
			}
		}

		internal void ShowTop10(List<Top10Resultado> listaTop10)
		{
			IEnumerable<Top10Resultado> data = listaTop10;
			DataTable table = new DataTable();
			using (var reader = ObjectReader.Create(data))
			{
				table.Load(reader);
			}
			FillDataGrid(table, dataGrid);
		}

		public static void FillDataGrid(DataTable table, DataGrid grid)
		{
			grid.Columns.Clear();
			grid.AutoGenerateColumns = false;
			for (int i = 0; i < table.Columns.Count; i++)
			{
				grid.Columns.Add(new DataGridTextColumn()
				{
					Header = table.Columns[i].ColumnName,
					Binding = new Binding { Path = new PropertyPath("[" + i.ToString() + "]") }
				});
			}

			var collection = new ObservableCollection<object>();
			foreach (DataRow row in table.Rows)
			{
				collection.Add(row.ItemArray);
			}

			grid.ItemsSource = collection;
		}

		public class DataGridElements
		{
		}

		private void Back_Button(object sender, RoutedEventArgs e)
		{
			On_BackRequested();
		}

		private bool On_BackRequested()
		{
			if (this.Frame.CanGoBack)
			{
				this.Frame.GoBack();
				return true;
			}
			return false;
		}
	}
}