using System;
using System.Collections.Generic;
using BDVTest.BLL.DTO;

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
}