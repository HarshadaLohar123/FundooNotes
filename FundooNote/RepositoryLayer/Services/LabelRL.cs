﻿using Microsoft.Extensions.Configuration;
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
    }
}