using DataBaseLayer.Notes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    public interface INoteRL
    {
        Task AddNote(NotesPostModel notesPostModel, int UserID);
    }
}
