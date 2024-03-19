using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceRecord.Core.WebAPI.DatabaseContext;
using ServiceRecord.Core.WebAPI.Models;

namespace ServiceRecord.Core.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubJobTypesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SubJobTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetSubJobTypes")]
        public ReturnObject<List<SubJobType>> GetSubJobTypes()
        {
            List<SubJobType> list = new List<SubJobType>();

            if (_context.SubJobTypes == null)
            {
                //code 1- target table does not exist, code 2- target does not exist, code 3- target already exists
                return new ReturnObject<List<SubJobType>>() { Success = false, Data = list, Validated = true, ReturnCode = 1 };
            }

            list = _context.SubJobTypes.ToList();

            return new ReturnObject<List<SubJobType>>() { Success = true, Data = list, Validated = true };
        }

        [HttpPost]
        [Route("UpdateSubJobType")]
        public ReturnObject<SubJobType> UpdateSubJobType(SubJobType SubJobType)
        {
            _context.Entry(SubJobType).State = EntityState.Modified;

            try
            {
                _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                if (!SubJobTypeExists(SubJobType.SubJobID))
                {
                    //code 1- target table does not exist, code 2- target does not exist, code 3- target already exists
                    return new ReturnObject<SubJobType>() { Success = false, Data = SubJobType, Validated = true, ReturnCode = 2 };
                }
                else
                {
                    //throw;
                    return new ReturnObject<SubJobType>() { Success = false, Data = SubJobType, Validated = true, Message = e.Message };
                }
            }

            return new ReturnObject<SubJobType>() { Success = true, Data = SubJobType, Validated = true };
        }

        [HttpPost]
        [Route("AddSubJobType")]
        public ReturnObject<SubJobType> AddSubJobType(SubJobType SubJobType)
        {
            if (_context.SubJobTypes == null)
            {
                //code 1- target table does not exist, code 2- target does not exist, code 3- target already exists
                return new ReturnObject<SubJobType>() { Success = false, Data = SubJobType, Validated = true, ReturnCode = 1 };
            }


            int lastId = _context.SubJobTypes.Max(x => x.SubJobID) + 1;
            SubJobType.SubJobID = lastId;

            _context.SubJobTypes.Add(SubJobType);

            try
            {
                //save the new record
                _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                //if the SubJobType already exists...
                if (SubJobTypeExists(SubJobType.SubJobID))
                {
                    //code 1- target table does not exist, code 2- target does not exist, code 3- target already exists
                    return new ReturnObject<SubJobType>() { Success = false, Data = SubJobType, Validated = true, ReturnCode = 3 };
                }
                else
                {
                    return new ReturnObject<SubJobType>() { Success = false, Data = SubJobType, Validated = true, Message = e.Message };
                }
            }

            return new ReturnObject<SubJobType>() { Success = true, Data = SubJobType, Validated = true };
        }

        [HttpPost]
        [Route("DeleteSubJobType")]
        public ReturnObject<SubJobType> DeleteSubJobType(int id)
        {
            if (_context.SubJobTypes == null)
            {
                //code 1- target table does not exist, code 2- target does not exist, code 3- target already exists
                return new ReturnObject<SubJobType>() { Success = false, Data = null, Validated = true, ReturnCode = 1 };
            }

            var SubJobType = _context.SubJobTypes.Find(id);

            if (SubJobType == null)
            {
                //code 1- target table does not exist, code 2- target does not exist, code 3- target already exists
                return new ReturnObject<SubJobType>() { Success = false, Data = SubJobType, Validated = true, ReturnCode = 2 };
            }

            _context.SubJobTypes.Remove(SubJobType);
            _context.SaveChangesAsync();

            return new ReturnObject<SubJobType>() { Success = true, Data = SubJobType, Validated = true };
        }

        private bool SubJobTypeExists(int id)
        {
            return (_context.SubJobTypes?.Any(e => e.SubJobID == id)).GetValueOrDefault();
        }
    }
}
