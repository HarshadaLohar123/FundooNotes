using BusinessLayer.Interface;
using DataBaseLayer.Notes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.DBContext;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNote.Controllers
{
    public class NoteController : ControllerBase
    {
        FundooContext fundooContext;
        INoteBL noteBL;

        // constructor
        public NoteController(FundooContext fundoo, INoteBL noteBL)
        {
            this.fundooContext = fundoo;
            this.noteBL = noteBL;
        }

        /// <summary>
        /// Add Notes
        /// </summary>
        /// <param name="notesPostModel"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost("AddNote")]
        public async Task<ActionResult> AddUser(NotesPostModel notesPostModel)
        {
            try
            {
                var userid = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("userId", StringComparison.InvariantCultureIgnoreCase));
                int userId = Int32.Parse(userid.Value);
                await this.noteBL.AddNote(notesPostModel, userId);

                return this.Ok(new { success = true, message = $"User Added Successfully" });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Update Notes
        /// </summary>
        /// <param name="noteId"></param>
        /// <param name="noteUpdateModel"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPut("Update/{noteId}")]
        public async Task<ActionResult> UpdateNote(int noteId, NoteUpdateModel noteUpdateModel)
        {
            try
            {
                var userid = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("userID", StringComparison.InvariantCultureIgnoreCase));
                int UserId = Int32.Parse(userid.Value);

                var note = fundooContext.Notes.FirstOrDefault(u => u.Userid == UserId && u.NoteID == noteId);
                if (note == null)
                {
                    return this.BadRequest(new { success = false, message = "Failed to Update note" });
                }
                await this.noteBL.UpdateNote(UserId, noteId, noteUpdateModel);
                return this.Ok(new { success = true, message = "Note Updated successfully!!!" });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
