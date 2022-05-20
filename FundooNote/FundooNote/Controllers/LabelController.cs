using BusinessLayer.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.DBContext;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNote.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LabelController : Controller
    {
        FundooContext fundooContext;
        ILabelBL labelBL;

        public LabelController(FundooContext fundooContext, ILabelBL labelBL)
        {
            this.fundooContext = fundooContext;
            this.labelBL = labelBL;
        }

        /// <summary>
        /// this metod used for adding label
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="noteId"></param>
        /// <param name="labelName"></param>
        /// <returns></returns>
         [Authorize]  
        [HttpPost("AddLabel/{noteId}/{labelName}")]
        public async Task<ActionResult> AddLabel(int noteId, string labelName)
        {
            try
            {
                var userid = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("UserID", StringComparison.InvariantCultureIgnoreCase));
                int userID = Int32.Parse(userid.Value);
                //int noteId = Int32.Parse(userid.Value);

                await this.labelBL.AddLabel(userID, noteId, labelName);
                return this.Ok(new { success = true, message = "Lable Added Successfully " });
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }
    }
}
