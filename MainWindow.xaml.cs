using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Pract2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        NoteList allNotes = new NoteList();
        List<Note> currentNotes = new List<Note>();

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            allNotes.notes.Remove(currentNotes[ListOfNotes.SelectedIndex]);

            currentNotes[ListOfNotes.SelectedIndex].name = NameBox.Text;
            currentNotes[ListOfNotes.SelectedIndex].description = DescBox.Text;

            allNotes.notes.Add(currentNotes[ListOfNotes.SelectedIndex]);
            allNotes.SaveList();

            CurrentNotesUpd();
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            Note note = new Note(NameBox.Text, DescBox.Text, dp1.SelectedDate.Value);
            allNotes.notes.Add(note);
            allNotes.SaveList();
            CurrentNotesUpd();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e) 
        {
            allNotes.notes.Remove(currentNotes[ListOfNotes.SelectedIndex]);
            allNotes.SaveList();

            currentNotes.Remove(currentNotes[ListOfNotes.SelectedIndex]);
            CurrentNotesUpd();
        }

        private void dp1_SelectedDateChanged(object sender, SelectionChangedEventArgs e) 
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

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e) 
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

        private void CurrentNotesUpd() 
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
