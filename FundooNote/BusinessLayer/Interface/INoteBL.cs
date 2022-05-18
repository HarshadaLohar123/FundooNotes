using DataBaseLayer.Notes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface INoteBL
    {
        Task AddNote(NotesPostModel notesPostModel, int UserID);
    }
}
