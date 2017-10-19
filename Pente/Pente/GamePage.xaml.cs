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

namespace Pente
{
    /// <summary>
    /// Interaction logic for GamePage.xaml
    /// </summary>
    public partial class GamePage : Page
    {
        public GamePage()
        {
            InitializeComponent();
        }

        //private void Save_Click(object sender, RoutedEventArgs e)
        //{
        //    if (recentPath == "")
        //    {
        //        SaveAs_Click(sender, e);
        //    }
        //    Stream filestream = File.Open(recentPath + "\\contacts.con", FileMode.Create);
        //    BinaryFormatter formatter = new BinaryFormatter();
        //    formatter.Serialize(filestream, contacts);
        //    filestream.Close();
        //}

        //private void SaveAs_Click(object sender, RoutedEventArgs e)
        //{
        //    SaveFileDialog saveFileDialog = new SaveFileDialog();

        //    saveFileDialog.Filter = "ContactList file (*.con)|*.con";
        //    //saveFileDialog.InitialDirectory = @"..\\..\\SavedContactLists\\";

        //    saveFileDialog.ShowDialog();

        //    if (saveFileDialog.ShowDialog() == true)
        //    {
        //        recentPath = saveFileDialog.FileName;
        //        Stream filestream = File.Open(saveFileDialog.FileName, FileMode.Create);
        //        BinaryFormatter formatter = new BinaryFormatter();
        //        formatter.Serialize(filestream, contacts);
        //        filestream.Close();
        //    }
        //}

        //private void Load_Click(object sender, RoutedEventArgs e)
        //{
        //    OpenFileDialog openFileDialog = new OpenFileDialog();
        //    openFileDialog.Filter = "ContactList file (*.con)|*.con";
        //    openFileDialog.ShowDialog();

        //    Stream filestream = File.Open(openFileDialog.FileName, FileMode.Open);
        //    BinaryFormatter formatter = new BinaryFormatter();
        //    ObservableCollection<Contact> cons = new ObservableCollection<Contact>();
        //    cons = (ObservableCollection<Contact>)formatter.Deserialize(filestream);
        //    contacts.Clear();
        //    foreach (Contact contact in cons)
        //    {
        //        contacts.Add(contact);
        //    }
        //    filestream.Close();
        //}
    }
}
