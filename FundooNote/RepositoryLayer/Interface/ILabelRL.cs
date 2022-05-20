using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    public interface ILabelRL
    {
        Task AddLabel(int userId, int noteId, string labelName);
        Task<List<Labels>> GetLabelByuserId(int userId);
        Task<List<Labels>> GetlabelByNoteId(int userId, int NoteId);


    }
}
