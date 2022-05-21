using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.DBContext;
using RepositoryLayer.Entities;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Services
{
    public class LabelRL : ILabelRL
    {
        FundooContext fundoo; // used field here
        public IConfiguration Configuration { get; }
        public LabelRL(FundooContext fundooContext, IConfiguration configuration)
        {
            this.fundoo = fundooContext;
            this.Configuration = configuration;
        }

        public async Task AddLabel(int userId, int noteId, string labelName)
        {

            try
            {
                var user = fundoo.Users.FirstOrDefault(u => u.Userid == userId);
                var note = fundoo.Notes.FirstOrDefault(b => b.NoteID == noteId);
                Labels label = new Labels
                {
                    user = user,
                    note = note
                };
                label.LabelName = labelName;
                fundoo.Labels.Add(label);
                await fundoo.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<List<Labels>> GetLabelByuserId(int userId)
        {
            try
            {
                List<Labels> reuslt = await fundoo.Labels.Where(u => u.Userid == userId).ToListAsync();
                return reuslt;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<List<Labels>> GetlabelByNoteId(int userId, int NoteId)
        {
            try
            {
                List<Labels> reuslt = await fundoo.Labels.Where(u => u.NoteID == NoteId && u.Userid == userId).Include(u => u.user).Include(u => u.note).ToListAsync();
                return reuslt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Labels> UpdateLabel(int userId, int labelId, string labelName)
        {
            try
            {
                var reuslt = fundoo.Labels.FirstOrDefault(u => u.LabelId== labelId && u.Userid == userId);

                if (reuslt != null)
                {
                    reuslt.LabelName= labelName;
                    await fundoo.SaveChangesAsync();
                    var result = fundoo.Labels.Where(u => u.LabelId == labelId).FirstOrDefaultAsync();
                    return reuslt;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task DeleteLabel(int labelId, int userId)
        {
            try
            {
                var result = fundoo.Labels.FirstOrDefault(u => u.LabelId == labelId && u.Userid == userId);
                fundoo.Labels.Remove(result);
                await fundoo.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}