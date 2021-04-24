using WindowsStore.Client.Admin.Common.Infrastructure;

namespace WindowsStore.Client.Admin.RemoteService.ModelMapping
{
    public static class PagingParameterMapper
    {
        public static AdminService.PagingParameters GetPagingParametersDC(this PagingParameters pagingParameters)
        {
            return new AdminService.PagingParameters()
            {
                PageIndex = pagingParameters.PageIndex,
                PageSize = pagingParameters.PageSize
            };
        }

        public static PagingParameters GetPagingParameter(this AdminService.PagingParameters pagingParametersDC)
        {
            return new PagingParameters()
            {
                PageIndex = pagingParametersDC.PageIndex,
                PageSize = pagingParametersDC.PageSize
            };
        }
    }
}
