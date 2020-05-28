using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BDVTest.BLL.DTO;
using BDVTest.DAL;
using BDVTest.DAL.Models;

namespace BDVTest.BLL
{
    public interface IWorkSheetService
    {
        bool CreateWorkSheets(IList<BaseWorkSheetDto> baseWorkSheetDtos);
        
        IList<WorkSheetOneDto> ReadWorkSheetOneDataByTime(DateTime? time);
        IList<WorkSheetTwoDto> ReadWorkSheetTwoDataByTime(DateTime? time);
        
        bool UpdateWorkSheetOneData(int id, WorkSheetOneDto workSheetOneDto);
        bool UpdateWorkSheetTwoData(int id, WorkSheetTwoDto workSheetTwoDto);

        bool DeleteWorkSheetOneData(int id);
        bool DeleteWorkSheetTwoData(int id);
    }
    public class WorkSheetService : IWorkSheetService
    {
        private ApplicationDbContext _applicationDbContext;
        private IMapper _mapper;

        public WorkSheetService(ApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }

        public bool CreateWorkSheets(IList<BaseWorkSheetDto> baseWorkSheetDtos)
        {
            var creationTime = DateTime.Now;
            try
            {
                foreach (var baseWorkSheetDto in baseWorkSheetDtos)
                {
                    switch (baseWorkSheetDto)
                    {
                        case WorkSheetOneDto _:
                            var workSheetOne = _mapper.Map<WorkSheetOne>(baseWorkSheetDto);
                            workSheetOne.CreationTime = creationTime;
                            _applicationDbContext.WorkSheetOnes.Add(workSheetOne);
                            break;
                        case WorkSheetTwoDto _:
                            var workSheetTwo = _mapper.Map<WorkSheetTwo>(baseWorkSheetDto);
                            workSheetTwo.CreationTime = creationTime;
                            _applicationDbContext.WorkSheetTwos.Add(workSheetTwo);
                            break;
                    }
                }
                _applicationDbContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new ApplicationException("Save error in WorkSheetService.CreateWorkSheets");
            }

            return true;
        }

        public IList<WorkSheetOneDto> ReadWorkSheetOneDataByTime(DateTime? time)
        {
            var workSheetOnes = _applicationDbContext.WorkSheetOnes.Where(wso => wso.CreationTime < time).ToList();
            return _mapper.Map<List<WorkSheetOneDto>>(workSheetOnes);
        }

        public IList<WorkSheetTwoDto> ReadWorkSheetTwoDataByTime(DateTime? time)
        {
            var workSheetTwos = _applicationDbContext.WorkSheetTwos.Where(wso => wso.CreationTime < time).ToList();
            return _mapper.Map<List<WorkSheetTwoDto>>(workSheetTwos);
        }

        public bool UpdateWorkSheetOneData(int id, WorkSheetOneDto workSheetOneDto)
        {
            try
            {
                var updatingWorkSheetOne = _applicationDbContext.WorkSheetOnes.FirstOrDefault(wso => wso.Id == id);
                if (updatingWorkSheetOne == null)
                {
                    return false;
                }
                
                _mapper.Map(workSheetOneDto, updatingWorkSheetOne);
                _applicationDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Update error in WorkSheetService.UpdateWorkSheetOneData");
            }
            return true;
        }

        public bool UpdateWorkSheetTwoData(int id, WorkSheetTwoDto workSheetTwoDto)
        {
            try
            {
                var updatingWorkSheetTwo = _applicationDbContext.WorkSheetTwos.FirstOrDefault(wso => wso.Id == id);
                if (updatingWorkSheetTwo == null)
                {
                    return false;
                }
                
                _mapper.Map(workSheetTwoDto, updatingWorkSheetTwo);
                _applicationDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Update error in WorkSheetService.UpdateWorkSheetTwoData");
            }
            return true;
        }

        public bool DeleteWorkSheetOneData(int id)
        {
            WorkSheetOne removableWorkSheetOne = _applicationDbContext.WorkSheetOnes.FirstOrDefault(i => i.Id == id);
            if (removableWorkSheetOne == null)
            {
                return false;
            }

            try
            {
                _applicationDbContext.WorkSheetOnes.Remove(removableWorkSheetOne);
                _applicationDbContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new ApplicationException("Delete error in WorkSheetService.DeleteWorkSheetOneData");
            }
            return true;
        }

        public bool DeleteWorkSheetTwoData(int id)
        {
            WorkSheetTwo removableWorkSheetTwo = _applicationDbContext.WorkSheetTwos.FirstOrDefault(i => i.Id == id);
            if (removableWorkSheetTwo == null)
            {
                return false;
            }

            try
            {
                _applicationDbContext.WorkSheetTwos.Remove(removableWorkSheetTwo);
                _applicationDbContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new ApplicationException("Delete error in WorkSheetService.DeleteWorkSheetTwoData");
            }
            return true;
        }
    }
}