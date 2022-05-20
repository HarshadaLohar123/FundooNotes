using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface ILabelBL
    {
        Task AddLabel(int userId, int noteId, string labelName);
        Task<List<Labels>> GetLabelByuserId(int userId);
        Task<List<Labels>> GetLabelByNoteId(int userId, int noteId);
    }
}
