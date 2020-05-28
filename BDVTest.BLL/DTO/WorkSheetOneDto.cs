namespace BDVTest.BLL.DTO
{
    public class WorkSheetOneDto : BaseWorkSheetDto
    {
        public override BaseWorkSheetDto CreateNewWorkSheetDto()
        {
            return new WorkSheetOneDto();
        }
    }
}