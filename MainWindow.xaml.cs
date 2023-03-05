using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace Pract2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        NoteList allNotes = new NoteList(); ///создание списка всех заметок и заметок на выбранные даты
        List<Note> currentNotes = new List<Note>();

        private void SaveButton_Click(object sender, RoutedEventArgs e) ///сохранение изменений в заметке
        {
            allNotes.notes.Remove(currentNotes[ListOfNotes.SelectedIndex]);

            currentNotes[ListOfNotes.SelectedIndex].name = NameBox.Text;
            currentNotes[ListOfNotes.SelectedIndex].description = DescBox.Text;

            allNotes.notes.Add(currentNotes[ListOfNotes.SelectedIndex]);
            allNotes.SaveList();

            CurrentNotesUpd();
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e) ///создание заметки
        {
            Note note = new Note(NameBox.Text, DescBox.Text, dp1.SelectedDate.Value);
            allNotes.notes.Add(note);
            allNotes.SaveList();
            CurrentNotesUpd();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e) ///удаление заметки
        {
            allNotes.notes.Remove(currentNotes[ListOfNotes.SelectedIndex]);
            allNotes.SaveList();

            currentNotes.Remove(currentNotes[ListOfNotes.SelectedIndex]);
            CurrentNotesUpd();
        }

        private void dp1_SelectedDateChanged(object sender, SelectionChangedEventArgs e) ///обработка изменения выбранной даты
        {
            try
            {
                if (allNotes.notes.Count != null)
                {
                    CurrentNotesUpd();
                }
            }
            catch 
            {

            }
            
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e) /// обработка выбора заметки
        {
            try
            {
                NameBox.Text = currentNotes[ListOfNotes.SelectedIndex].name;
                DescBox.Text = currentNotes[ListOfNotes.SelectedIndex].description;
            }
            catch 
            {
                NameBox.Text = "";
                DescBox.Text = "";
            }
            
        }

        private void CurrentNotesUpd() ///обновление списка заметок к выбранной дате
        {
            string date = dp1.SelectedDate.Value.ToShortDateString();

            currentNotes.Clear();
            ListOfNotes.Items.Clear();

            try
            {
                foreach (Note note in allNotes.notes)
                {
                    if (note.dataTime.ToShortDateString() == date)
                    {
                        currentNotes.Add(note);
                        ListOfNotes.Items.Add(note.name);
                    }
                }
            }
            finally
            {

            }
        }
    }
}
