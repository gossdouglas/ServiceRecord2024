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
    public class ResourceTypesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ResourceTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetResourceTypes")]
        public ReturnObject<List<ResourceType>> GetResourceTypes()
        {
            List<ResourceType> list = new List<ResourceType>();

            if (_context.ResourceTypes == null)
            {
                //code 1- target table does not exist, code 2- target does not exist, code 3- target already exists
                return new ReturnObject<List<ResourceType>>() { Success = false, Data = list, Validated = true, ReturnCode = 1 };
            }

            list = _context.ResourceTypes.ToList();

            return new ReturnObject<List<ResourceType>>() { Success = true, Data = list, Validated = true };
        }

        [HttpPost]
        [Route("UpdateResourceType")]
        public ReturnObject<ResourceType> UpdateResourceType(ResourceType ResourceType)
        {
            _context.Entry(ResourceType).State = EntityState.Modified;

            try
            {
                _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                if (!ResourceTypeExists(ResourceType.ResourceTypeID))
                {
                    //code 1- target table does not exist, code 2- target does not exist, code 3- target already exists
                    return new ReturnObject<ResourceType>() { Success = false, Data = ResourceType, Validated = true, ReturnCode = 2 };
                }
                else
                {
                    //throw;
                    return new ReturnObject<ResourceType>() { Success = false, Data = ResourceType, Validated = true, Message = e.Message };
                }
            }

            return new ReturnObject<ResourceType>() { Success = true, Data = ResourceType, Validated = true };
        }

        [HttpPost]
        [Route("AddResourceType")]
        public ReturnObject<ResourceType> AddResourceType(ResourceType ResourceType)
        {
            if (_context.ResourceTypes == null)
            {
                //code 1- target table does not exist, code 2- target does not exist, code 3- target already exists
                return new ReturnObject<ResourceType>() { Success = false, Data = ResourceType, Validated = true, ReturnCode = 1 };
            }


            int lastId = _context.ResourceTypes.Max(x => x.ResourceTypeID) + 1;
            ResourceType.ResourceTypeID = lastId;

            _context.ResourceTypes.Add(ResourceType);

            try
            {
                //save the new record
                _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                //if the ResourceType already exists...
                if (ResourceTypeExists(ResourceType.ResourceTypeID))
                {
                    //code 1- target table does not exist, code 2- target does not exist, code 3- target already exists
                    return new ReturnObject<ResourceType>() { Success = false, Data = ResourceType, Validated = true, ReturnCode = 3 };
                }
                else
                {
                    return new ReturnObject<ResourceType>() { Success = false, Data = ResourceType, Validated = true, Message = e.Message };
                }
            }

            return new ReturnObject<ResourceType>() { Success = true, Data = ResourceType, Validated = true };
        }

        [HttpPost]
        [Route("DeleteResourceType")]
        public ReturnObject<ResourceType> DeleteResourceType(int id)
        {
            if (_context.ResourceTypes == null)
            {
                //code 1- target table does not exist, code 2- target does not exist, code 3- target already exists
                return new ReturnObject<ResourceType>() { Success = false, Data = null, Validated = true, ReturnCode = 1 };
            }

            var ResourceType = _context.ResourceTypes.Find(id);

            if (ResourceType == null)
            {
                //code 1- target table does not exist, code 2- target does not exist, code 3- target already exists
                return new ReturnObject<ResourceType>() { Success = false, Data = ResourceType, Validated = true, ReturnCode = 2 };
            }

            _context.ResourceTypes.Remove(ResourceType);
            _context.SaveChangesAsync();
            
            return new ReturnObject<ResourceType>() { Success = true, Data = ResourceType, Validated = true };
        }

        private bool ResourceTypeExists(int id)
        {
            return (_context.ResourceTypes?.Any(e => e.ResourceTypeID == id)).GetValueOrDefault();
        }

        ////check 5 times to see if the new record was created
        //for (int i = 1; i == 5; i++)
        //{
        //    //if not created...
        //    if (!ResourceTypeExists(ResourceType.ResourceTypeID)) {
        //        //save the new record
        //        _context.SaveChangesAsync();
        //    }                 
        //}

        ////if not created...
        //if (!ResourceTypeExists(ResourceType.ResourceTypeID))
        //{
        //    //save the new record
        //    //code 1- target table does not exist, code 2- target does not exist, code 3- target already exists, code 4- operation failed
        //    return new ReturnObject<ResourceType>() { Success = false, Data = ResourceType, Validated = true, ReturnCode = 4 };

        //}
    }
}
