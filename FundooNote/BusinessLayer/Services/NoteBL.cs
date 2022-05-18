using BusinessLayer.Interface;
using DataBaseLayer.Notes;
using RepositoryLayer.Entities;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class NoteBL : INoteBL
    {
        INoteRL noteRL;
        public NoteBL(INoteRL noteRL)
        {
            this.noteRL = noteRL;
        }

        public async Task AddNote(NotesPostModel notesPostModel, int UserID)
        {

            try
            {
                await this.noteRL.AddNote(notesPostModel, UserID);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<Note> UpdateNote(int userId, int noteId, NoteUpdateModel noteUpdateModel)
        {
            try
            {
                return await this.noteRL.UpdateNote(userId, noteId, noteUpdateModel);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}