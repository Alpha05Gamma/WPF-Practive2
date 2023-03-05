using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pract2
{
    internal class Note
    {
        public string name { get; set; } ///поля класса
        public string description { get; set; }

        public DateTime dataTime { get; set; }

        public Note(string name, string description, DateTime dataTime) ///конструктор
        {
            this.name = name;
            this.description = description;
            this.dataTime = dataTime;
        }
    }

    internal class NoteList 
    {
        public List<Note> notes;
        public NoteList() ///конструктор
        {
            try ///проверка на считывание пустого файла либо отстутствие файла вообще
            {
                this.notes = IO.Deserialize<List<Note>>();
            }
            catch 
            {
                this.notes = new List<Note>();
                IO.Serialize(this.notes);
            }
            finally
            {
                if (this.notes == null)
                {
                    this.notes = new List<Note>();
                    IO.Serialize(this.notes);
                }
            }
        }

        public void SaveList()/// сохрание списка в файл
        {
            IO.Serialize(this.notes);
        }
    }
}
